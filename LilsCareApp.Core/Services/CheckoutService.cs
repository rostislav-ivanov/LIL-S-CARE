using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Checkout;
using LilsCareApp.Infrastructure.Data;
using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LilsCareApp.Core.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly ApplicationDbContext _context;

        public CheckoutService(ApplicationDbContext context)
        {
            _context = context;
        }


        // get default address delivery Id for user if existing
        public async Task<int?> GetDefaultAddressIdAsync(string userId)
        {
            return await _context.Users
                .Where(u => u.Id == userId)
                .Select(u => u.DefaultAddressDeliveryId)
                .FirstOrDefaultAsync();
        }

        // get all payment methods 
        public async Task<IEnumerable<PaymentMethod>> GetPaymentMethodsAsync()
        {
            return await _context.PaymentMethods
                .AsNoTracking()
                .ToListAsync();
        }

        // get all promo codes for user witch are not expired and not already applied
        public async Task<IEnumerable<PromoCodeDTO>> GetPromoCodesAsync(string userId)
        {
            return await _context.PromoCodes
                .Where(pc => pc.AppUserId == userId
                    && pc.ExpirationDate >= DateTime.UtcNow
                    && pc.AppliedDate == null)
                .Select(pc => new PromoCodeDTO()
                {
                    Id = pc.Id,
                    Code = pc.Code,
                    Discount = pc.Discount,
                    ExpirationDate = pc.ExpirationDate
                })
                .AsNoTracking()
                .ToListAsync();
        }



        // Save order to database and return unique order number.
        // Add new address delivery to database if not existing.
        // Remove products from user's bag.
        //remove ordered quantity from products store
        // Set the applied date to promo code if is applied.
        // Set new default address delivery to user.
        // Return unique order number to user.
        public async Task<string> CheckoutSaveAsync(OrderDTO orderDTO, string userId)
        {
            // get user
            AppUser appUser = await _context.Users.FirstAsync(u => u.Id == userId);

            Order order = new Order()
            {
                CreatedOn = DateTime.UtcNow,
                StatusOrderId = 1,
                AppUser = appUser,
                PaymentMethodId = orderDTO.PaymentMethodId,
                NoteForDelivery = orderDTO.NoteForDelivery,
                ProductsOrders = new List<ProductOrder>(),
                PromoCodeId = orderDTO.PromoCodeId,
                SubTotal = orderDTO.SubTotal(),
                Discount = orderDTO.Discount(),
                ShippingPrice = orderDTO.ShippingPrice() ?? 0,
                Total = orderDTO.Total()


            };

            // add products to order
            foreach (var product in orderDTO.ProductsInBag)
            {
                ProductOrder productOrder = new ProductOrder()
                {
                    ProductId = product.Id,
                    Quantity = product.Quantity,
                    Price = product.Price,
                    ImagePath = await _context.ImageProducts
                        .Where(ip => ip.Id == product.Id)
                        .Select(ip => ip.ImagePath)
                        .AsNoTracking()
                        .FirstOrDefaultAsync()
                };
                order.ProductsOrders.Add(productOrder);
            }

            // add address to order

            int? addressDeliveryId = orderDTO.Address?.Id ?? orderDTO.Office?.Id;

            if (addressDeliveryId > 0) // if existing address set to order this address delivery
            {
                order.AddressDelivery = await _context.AddressDeliveries.FirstOrDefaultAsync(ad => ad.Id == addressDeliveryId);
            }
            else if (orderDTO.DeliveryType() == orderDTO.AddressDeliveryType) // if new address order add this address delivery
            {
                order.AddressDelivery = new AddressDelivery()
                {
                    FirstName = orderDTO.Address!.FirstName,
                    LastName = orderDTO.Address.LastName,
                    PhoneNumber = orderDTO.Address.PhoneNumber,
                    Country = orderDTO.Address.Country,
                    PostCode = orderDTO.Address.PostCode,
                    Town = orderDTO.Address.Town,
                    Address = orderDTO.Address.Address,
                    District = orderDTO.Address.District,
                    Email = orderDTO.Address.Email,
                    IsShippingToOffice = false,
                    AppUser = appUser
                };
            }
            else if (orderDTO.DeliveryType() == orderDTO.OfficeDeliveryType) // if new office order add this address delivery
            {
                order.AddressDelivery = new AddressDelivery()
                {
                    FirstName = orderDTO.Office!.FirstName,
                    LastName = orderDTO.Office.LastName,
                    PhoneNumber = orderDTO.Office.PhoneNumber,
                    IsShippingToOffice = true,
                    ShippingOfficeId = orderDTO.Office.ShippingOfficeId,
                    AppUser = appUser
                };
            }

            // add order to user
            await _context.Orders.AddAsync(order);

            // remove products from user's bag
            IEnumerable<BagUser> bagUsers = await _context.BagsUsers
                .Where(bu => bu.AppUserId == userId)
                .ToListAsync();

            _context.BagsUsers.RemoveRange(bagUsers);

            //remove ordered quantity from products store
            foreach (var bagUser in bagUsers)
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == bagUser.ProductId);
                if (product != null)
                {
                    product.Quantity -= bagUser.Quantity;
                }
            }

            // set the applied date to promo code if is applied
            PromoCode promoCode = await _context.PromoCodes.FirstOrDefaultAsync(pc => pc.Id == order.PromoCodeId);

            if (promoCode != null)
            {
                promoCode.AppliedDate = DateTime.UtcNow;
            }

            // set new default address delivery to user
            appUser.DefaultAddressDelivery = order.AddressDelivery;

            await _context.SaveChangesAsync();

            // return unique order number to user
            Random random = new Random();

            order.OrderNumber = random.Next(10, 99).ToString() + order.Id.ToString() + random.Next(10, 99).ToString();

            await _context.SaveChangesAsync();

            return order.OrderNumber;
        }



        // get order summary by order number
        public async Task<OrderSummaryDTO> OrderSummaryAsync(string orderSNumber)
        {
            OrderSummaryDTO? orderSummary = await _context.Orders
                .Where(o => o.OrderNumber == orderSNumber)
                .Select(o => new OrderSummaryDTO()
                {
                    OrderNumber = o.OrderNumber,
                    OrderDate = o.CreatedOn,
                    FirstName = o.AddressDelivery.FirstName,
                    LastName = o.AddressDelivery.LastName,
                    PhoneNumber = o.AddressDelivery.PhoneNumber,
                    PostCode = o.AddressDelivery.PostCode,
                    Address = o.AddressDelivery.Address,
                    Town = o.AddressDelivery.Town,
                    District = o.AddressDelivery.District,
                    Country = o.AddressDelivery.Country,
                    IsShippingToOffice = o.AddressDelivery.IsShippingToOffice,
                    ShippingProviderName = o.AddressDelivery.ShippingOffice.ShippingProvider.Name,
                    ShippingOfficeCity = o.AddressDelivery.ShippingOffice.City,
                    ShippingOfficeAddress = o.AddressDelivery.ShippingOffice.OfficeAddress,
                    PaymentMethod = o.PaymentMethod.Type,
                    NoteForDelivery = o.NoteForDelivery,
                    Products = o.ProductsOrders
                        .Select(po => new ProductOrderDTO()
                        {
                            Id = po.Product.Id,
                            Name = po.Product.Name,
                            ImagePath = po.ImagePath,
                            Quantity = po.Quantity,
                            Price = po.Price,
                        }),
                    PromoCode = o.PromoCode.Code,
                    Discount = o.Discount,
                    SubTotal = o.SubTotal,
                    ShippingPrice = o.ShippingPrice,
                    Total = o.Total
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return orderSummary;
        }
    }
}


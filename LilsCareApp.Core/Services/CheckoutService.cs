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

        // get user's default address delivery or create new if it is not existing
        // address could be client's address or courier office
        public async Task<AddressDeliveryDTOtoByChange?> GetAddressDeliveryAsync(string userId)
        {
            // check for existing default address delivery
            var addressDelivery = await _context.Users
                .Where(u => u.Id == userId && u.DefaultAddressDeliveryId != null)
                .Select(ad => new AddressDeliveryDTOtoByChange()
                {
                    Id = ad.DefaultAddressDelivery.Id,
                    FirstName = ad.DefaultAddressDelivery.FirstName,
                    LastName = ad.DefaultAddressDelivery.LastName,
                    Country = ad.DefaultAddressDelivery.Country,
                    PostCode = ad.DefaultAddressDelivery.PostCode,
                    Town = ad.DefaultAddressDelivery.Town,
                    Address = ad.DefaultAddressDelivery.Address,
                    District = ad.DefaultAddressDelivery.District,
                    PhoneNumber = ad.DefaultAddressDelivery.PhoneNumber,
                    IsShippingToOffice = ad.DefaultAddressDelivery.IsShippingToOffice,
                    ShippingOfficeId = ad.DefaultAddressDelivery.ShippingOfficeId
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            // create new address delivery if not existing default address delivery
            if (addressDelivery != null)
            {
                // check if user is selected shipping to courier office
                if (addressDelivery.IsShippingToOffice)
                {
                    addressDelivery.ShippingOffice = await _context.ShippingOffices
                        .Where(so => so.Id == addressDelivery.ShippingOfficeId)
                        .Select(so => new ShippingOfficeDTO()
                        {
                            Id = so.Id,
                            City = so.City,
                            OfficeAddress = so.OfficeAddress,
                            Price = so.Price,
                            ShippingDuration = so.ShippingDuration,
                        })
                        .AsNoTracking()
                        .FirstOrDefaultAsync();


                    addressDelivery.ShippingOffice.ShippingProviderId = await _context.ShippingProviders
                                .Where(sp => sp.ShippingOffices.Any(so => so.Id == addressDelivery.ShippingOfficeId))
                                .Select(sp => sp.Id)
                                .FirstOrDefaultAsync();

                    addressDelivery.IsValid = addressDelivery.FirstName != null
                                         && addressDelivery.LastName != null
                                         && addressDelivery.PhoneNumber != null
                                         && addressDelivery.ShippingOffice != null;
                }
                // if user is selected shipping to your address  
                else
                {
                    addressDelivery.IsValid = addressDelivery.FirstName != null
                                         && addressDelivery.LastName != null
                                         && addressDelivery.Country != null
                                         && addressDelivery.PostCode != null
                                         && addressDelivery.Town != null
                                         && addressDelivery.Address != null;
                }

            }
            return addressDelivery;
        }


        // get list of all shipping providers
        public async Task<IEnumerable<ShippingProviderDTO>> GetShippingProvidersAsync()
        {
            var shippingProviders = await _context.ShippingProviders
                .Select(sp => new ShippingProviderDTO()
                {
                    Id = sp.Id,
                    Name = sp.Name,
                    Description = "доставка до офис на " + sp.Name
                })
                .AsNoTracking()
                .ToListAsync();

            // add option delivery to client's address
            shippingProviders.Add(new ShippingProviderDTO()
            {
                Id = 0,
                Name = "доставка до адрес на клиент",
                Description = "доставка до адрес на клиент"
            });
            return shippingProviders.OrderBy(sp => sp.Id);
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


        // get all cities where the shipping provider has offices
        public async Task<IEnumerable<string>> GetShippingCitiesAsync(int shippingProvidersId)
        {
            return await _context.ShippingOffices
                .Where(so => so.ShippingProviderId == shippingProvidersId)
                .Select(so => so.City)
                .Distinct()
                .AsNoTracking()
                .ToListAsync();
        }


        // get all offices in the city of the selected shipping provider
        public async Task<IEnumerable<ShippingOfficeDTO>> GetShippingOfficesByCityAsync(string city, int? shippingProviderId)
        {
            return await _context.ShippingOffices
                .Where(so => so.City == city && so.ShippingProviderId == shippingProviderId)
                .Select(so => new ShippingOfficeDTO()
                {
                    Id = so.Id,
                    City = so.City,
                    OfficeAddress = so.OfficeAddress,
                    Price = so.Price,
                    ShippingDuration = so.ShippingDuration,
                })
                .AsNoTracking()
                .ToListAsync();
        }


        // save order to database and return unique order number
        // remove products from user's bag
        // set new default address delivery to user
        // set the applied date to promo code if is applied
        public async Task<string> CheckoutSaveAsync(OrderDTO checkout, string userId)
        {
            // get user
            AppUser appUser = await _context.Users.FirstAsync(u => u.Id == userId);

            Order order = new Order()
            {
                CreatedOn = DateTime.UtcNow,
                StatusOrderId = 1,
                AppUser = appUser,
                PaymentMethodId = checkout.PaymentMethodId,
                NoteForDelivery = checkout.AddressDelivery?.NoteForDelivery,
                ProductsOrders = new List<ProductOrder>(),
                PromoCodeId = checkout.PromoCodeId,
                SubTotal = checkout.SubTotal(),
                Discount = checkout.Discount(),
                ShippingPrice = checkout.ShippingPrice() ?? 0,
                Total = checkout.Total()


            };

            // add products to order
            foreach (var product in checkout.ProductsInBag)
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


            // check for existing address delivery
            AddressDelivery addressDelivery = await _context.AddressDeliveries.FirstOrDefaultAsync(ad => ad.Id == checkout.AddressDelivery.Id);

            if (addressDelivery is null) // if not existing address create new address delivery
            {
                addressDelivery = new AddressDelivery()
                {
                    FirstName = checkout.AddressDelivery.FirstName,
                    LastName = checkout.AddressDelivery.LastName,
                    PhoneNumber = checkout.AddressDelivery.PhoneNumber,
                    Country = checkout.AddressDelivery.Country,
                    PostCode = checkout.AddressDelivery.PostCode,
                    Town = checkout.AddressDelivery.Town,
                    Address = checkout.AddressDelivery.Address,
                    District = checkout.AddressDelivery.District,
                    IsShippingToOffice = checkout.AddressDelivery.IsShippingToOffice,
                    ShippingOfficeId = checkout.AddressDelivery.ShippingOffice?.Id,
                    AppUser = appUser

                };
            };

            // add address delivery to order
            order.AddressDelivery = addressDelivery;

            // add order to user
            await _context.Orders.AddAsync(order);

            // set new default address delivery to user
            appUser.DefaultAddressDelivery = addressDelivery;

            // remove products from user's bag
            IEnumerable<BagUser> bagUsers = await _context.BagsUsers
                .Where(bu => bu.AppUserId == userId)
                .ToListAsync();

            // set the applied date to promo code if is applied
            PromoCode promoCode = await _context.PromoCodes.FirstOrDefaultAsync(pc => pc.Id == order.PromoCodeId);

            if (promoCode != null)
            {
                promoCode.AppliedDate = DateTime.UtcNow;
            }

            _context.RemoveRange(bagUsers);

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
                            Description = po.Product.Description,
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


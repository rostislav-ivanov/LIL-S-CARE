using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Checkout;
using LilsCareApp.Core.Models.GuestUser;
using LilsCareApp.Infrastructure.Data;
using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using static LilsCareApp.Infrastructure.DataConstants.Language;

namespace LilsCareApp.Core.Services
{
    public class GuestService : IGuestService
    {
        private readonly IHttpContextManager _httpContextManager;
        private readonly ApplicationDbContext _context;

        public GuestService(IHttpContextManager httpContextManager, ApplicationDbContext context)
        {
            _httpContextManager = httpContextManager;
            _context = context;
        }

        // AddToCart method is used to add a product to the guest's bag.
        public void AddToCart(int productId, int quantity)
        {
            GuestSession? session = _httpContextManager.GetSession();
            if (session == null)
            {
                return;
            }

            var bag = session.GuestBags.FirstOrDefault(b => b.ProductId == productId);
            if (bag == null)
            {
                session.GuestBags.Add(new GuestBag()
                {
                    ProductId = productId,
                    Quantity = quantity
                });
            }
            else if (bag.Quantity + quantity >= 1) // quantity must be at least 1
            {
                bag.Quantity += quantity;
            }

            _httpContextManager.SetSession(session);
        }

        // DeleteProductFromCart method is used to delete a product from the guest's bag.
        public void DeleteProductFromCart(int id)
        {
            GuestSession? session = _httpContextManager.GetSession();

            if (session == null)
            {
                return;
            }

            session.GuestBags.RemoveAll(b => b.ProductId == id);

            _httpContextManager.SetSession(session);
        }


        // GetCountInBag method is used to get the total number of products in the guest's bag.
        public int GetCountInBag()
        {
            GuestSession? session = _httpContextManager.GetSession();

            return session?.GuestBags.Sum(gb => gb.Quantity) ?? 0;
        }


        // GetProductsInBagAsync method is used to get the products in the guest's bag.
        public async Task<IEnumerable<ProductsInBagDTO>> GetProductsInBagAsync()
        {
            GuestSession? session = _httpContextManager.GetSession();

            if (session == null)
            {
                return Enumerable.Empty<ProductsInBagDTO>();
            }

            List<ProductsInBagDTO> productsInBagDTOs = new List<ProductsInBagDTO>();
            var language = _httpContextManager.GetLanguage();

            foreach (var guestProduct in session.GuestBags)
            {
                var product = await _context.Products
                    .Where(p => p.Id == guestProduct.ProductId)
                    .Select(p => new ProductsInBagDTO
                    {
                        Id = p.Id,
                        Name = new Dictionary<string, string>
                        {
                            { Bulgarian, p.Name.NameBG },
                            { Romanian, p.Name.NameRO },
                            { English, p.Name.NameEN }
                        }[language],
                        Optional = new Dictionary<string, string>
                        {
                            { English, p.Optional.OptionalEN },
                            { Bulgarian, p.Optional.OptionalBG },
                            { Romanian, p.Optional.OptionalRO },
                        }[language],
                        Price = p.Price,
                        ImageUrl = p.Images!.FirstOrDefault()!.ImagePath,
                        Quantity = guestProduct.Quantity
                    })
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                if (product != null)
                {
                    productsInBagDTOs.Add(product);
                }
            }

            return productsInBagDTOs;
        }


        // ClearBag method is used to remove all products form the guest's bag.
        public void ClearBag()
        {
            GuestSession? session = _httpContextManager.GetSession();

            session?.GuestBags.Clear();

            _httpContextManager.SetSession(session);
        }


        // Save order to database and return unique order number.
        // Add new address delivery to database related to the order.
        // Remove products from guest's bag.
        // Set the applied date to promo code if is applied.
        // Return unique order number to guest user.
        public async Task<string> CheckoutSaveAsync(OrderDTO orderDTO)
        {
            Order order = new Order()
            {
                CreatedOn = DateTime.UtcNow,
                StatusOrderId = 1,
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
                        .Where(ip => ip.ProductId == product.Id)
                        .OrderBy(ip => ip.ImageOrder)
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
                };
            }

            // add order to user
            await _context.Orders.AddAsync(order);

            // remove products from user's bag
            ClearBag();

            // set the applied date to promo code if is applied
            PromoCode promoCode = await _context.PromoCodes.FirstOrDefaultAsync(pc => pc.Id == order.PromoCodeId);

            if (promoCode != null)
            {
                promoCode.AppliedDate = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();

            // return unique order number to user
            Random random = new Random();

            order.OrderNumber = random.Next(10, 99).ToString() + order.Id.ToString() + random.Next(10, 99).ToString();

            await _context.SaveChangesAsync();

            return order.OrderNumber;
        }

        public GuestSession GetSession()
        {
            return _httpContextManager.GetSession();
        }
    }
}

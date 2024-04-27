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
        private readonly ApplicationDbContext _context;
        private readonly IAppConfigService _appConfigService;
        private readonly IHttpContextManager _httpContextManager;

        public GuestService(
            ApplicationDbContext context,
            IAppConfigService appConfigService,
            IHttpContextManager httpContextManager)
        {
            _context = context;
            _appConfigService = appConfigService;
            _httpContextManager = httpContextManager;
        }

        // AddToCart method is used to add a product to the guest's bag.
        public void AddToCart(int productId, int quantity)
        {
            GuestSession? session = _httpContextManager.GetSessionGuest();
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

            _httpContextManager.SetSessionGuest(session);
        }

        // DeleteProductFromCart method is used to delete a product from the guest's bag.
        public void DeleteProductFromCart(int id)
        {
            GuestSession? session = _httpContextManager.GetSessionGuest();

            if (session == null)
            {
                return;
            }

            session.GuestBags.RemoveAll(b => b.ProductId == id);

            _httpContextManager.SetSessionGuest(session);
        }


        // GetCountInBag method is used to get the total number of products in the guest's bag.
        public int GetCountInBag()
        {
            GuestSession? session = _httpContextManager.GetSessionGuest();

            return session?.GuestBags.Sum(gb => gb.Quantity) ?? 0;
        }


        // GetProductsInBagAsync method is used to get the products in the guest's bag.
        public async Task<IEnumerable<ProductsInBagDTO>> GetProductsInBagAsync()
        {
            GuestSession? session = _httpContextManager.GetSessionGuest();

            if (session == null)
            {
                return Enumerable.Empty<ProductsInBagDTO>();
            }

            List<ProductsInBagDTO> productsInBagDTOs = new List<ProductsInBagDTO>();
            var language = _httpContextManager.GetLanguage();
            decimal exchangeRate = await _appConfigService.GetExchangeRateAsync(language);

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
                        Price = p.Price / exchangeRate,
                        ImageUrl = p.Images!.FirstOrDefault()!.ImagePath,
                        Quantity = guestProduct.Quantity
                    })
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                if (product != null)
                {
                    product.Price = Math.Round(product.Price, 2);
                    productsInBagDTOs.Add(product);
                }
            }

            return productsInBagDTOs;
        }


        // ClearBag method is used to remove all products form the guest's bag.
        public void ClearBag()
        {
            GuestSession? session = _httpContextManager.GetSessionGuest();

            session?.GuestBags.Clear();

            _httpContextManager.SetSessionGuest(session);
        }


        // Save order to database and return unique order number.
        // Remove products from guest's bag.
        // Return unique order number to guest user.
        public async Task<string> CheckoutSaveAsync(OrderDTO orderDTO)
        {
            var language = _httpContextManager.GetLanguage();
            Order order = new Order()
            {
                CreatedOn = DateTime.UtcNow,
                StatusOrderId = 1,
                DeliveryMethodId = orderDTO.DeliveryMethodId,
                PaymentMethodId = orderDTO.PaymentMethodId,
                IsPaid = false,
                NoteForDelivery = orderDTO.NoteForDelivery,
                ShippingPrice = orderDTO.ShippingPrice,
                Discount = orderDTO.Discount,
                SubTotal = orderDTO.SubTotal,
                Total = orderDTO.Total,
                FirstName = orderDTO.Address.FirstName,
                LastName = orderDTO.Address.LastName,
                PhoneNumber = orderDTO.Address.PhoneNumber,
                Address = orderDTO.Address.Address,
                Town = orderDTO.Address.Town,
                District = orderDTO.Address.District,
                Country = orderDTO.Address.Country,
                Email = orderDTO.Address.Email,
                IsShippingToOffice = orderDTO.Address.DeliveryMethodId == 1,
                ShippingOfficeId = orderDTO.Address.ShippingOfficeId,
                ShippingProviderName = orderDTO.Address.ShippingOffice?.ShippingProviderName,
                ShippingOfficeCity = orderDTO.Address.ShippingOffice?.City,
                ShippingOfficeAddress = orderDTO.Address.ShippingOffice?.OfficeAddress,
                Currency = orderDTO.Language,
                ProductsOrders = [],
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

            await _context.Orders.AddAsync(order);

            // remove products from user's bag
            ClearBag();

            await _context.SaveChangesAsync();

            // return unique order number to user
            Random random = new Random();

            order.OrderNumber = random.Next(10, 99).ToString() + order.Id.ToString() + random.Next(10, 99).ToString();

            await _context.SaveChangesAsync();

            return order.OrderNumber;
        }

        public GuestSession GetSession()
        {
            return _httpContextManager.GetSessionGuest();
        }
    }
}

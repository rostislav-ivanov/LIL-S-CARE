using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models;
using LilsCareApp.Infrastructure.Data;
using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LilsCareApp.Core.Services
{
    public class LilsCareService : ILilsCareService
    {
        private readonly ApplicationDbContext _context;

        public LilsCareService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddToSubscribersAsync(SubscriberDTO subscriber)
        {
            await _context.Subscribers.AddAsync(new Subscriber
            {
                Email = subscriber.Email,
                DateAdded = DateTime.Now,
                AppUserId = subscriber.AppUserId
            });

            await _context.SaveChangesAsync();
        }

        public async Task AddToWishAsync(int id, string userId)
        {
            var wishUser = new WishUser
            {
                ProductId = id,
                AppUserId = userId
            };

            if (await _context.WishesUsers.ContainsAsync(wishUser) == false)
            {
                await _context.WishesUsers.AddAsync(wishUser);
                await _context.SaveChangesAsync();
            }
        }


        public async Task RemoveFromWishAsync(int id, string userId)
        {
            var wishUser = _context.WishesUsers.FirstOrDefault(wu => wu.ProductId == id && wu.AppUserId == userId);
            if (wishUser != null)
            {
                _context.WishesUsers.Remove(wishUser);
                await _context.SaveChangesAsync();
            }
        }

        async public Task<IEnumerable<ProductDTO>> GetAllAsync(string userId)
        {
            var products = await _context.Products
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.Images.FirstOrDefault(im => im.ProductId == p.Id).ImagePath,// ?? "https://via.placeholder.com/150",
                    Quantity = p.Quantity,
                    Categories = p.ProductsCategories.Select(pc => new CategoryDTO
                    {
                        Id = pc.Category.Id,
                        Name = pc.Category.Name
                    }).ToList(),
                    IsWish = p.WishesUsers.Any(wu => wu.AppUserId == userId && wu.ProductId == p.Id)
                })
                .AsNoTracking()
                .ToArrayAsync();

            return products;
        }

        public async Task<int> GetCountInBagAsync(string userId)
        {
            int count = await _context.BagsUsers
                .Where(bu => bu.AppUserId == userId)
                .AsNoTracking()
                .SumAsync(bu => bu.Quantity);

            return count;
        }

        public async Task<IEnumerable<ProductsInBagDTO>> GetProductsInBagAsync(string userId)
        {
            var productsInBag = await _context.BagsUsers
                .Where(bu => bu.AppUserId == userId)
                .Select(bu => new ProductsInBagDTO
                {
                    Id = bu.Product.Id,
                    Name = bu.Product.Name,
                    Price = bu.Product.Price,
                    ImageUrl = bu.Product.Images.FirstOrDefault(im => im.ProductId == bu.Product.Id).ImagePath,
                    Quantity = bu.Quantity
                })
                .AsNoTracking()
                .ToArrayAsync();

            return productsInBag;
        }

        public async Task MessageFromClientAsync(MessageFromClientDTO message)
        {
            var x = new MessageFromClient
            {
                FirstName = message.FirstName,
                LastName = message.LastName,
                EmailForResponse = message.EmailForResponse,
                Message = message.Message,
                DateSent = DateTime.Now,
                AppUserId = message.AppUserId
            };

            await _context.MessagesFromClients.AddAsync(new MessageFromClient
            {
                FirstName = message.FirstName,
                LastName = message.LastName,
                EmailForResponse = message.EmailForResponse,
                Message = message.Message,
                DateSent = DateTime.Now,
                AppUserId = message.AppUserId
            });

            await _context.SaveChangesAsync();
        }

    }
}

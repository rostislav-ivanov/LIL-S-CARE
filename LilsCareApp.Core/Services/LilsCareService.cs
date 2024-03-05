using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models;
using LilsCareApp.Infrastructure.Data;
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
    }
}

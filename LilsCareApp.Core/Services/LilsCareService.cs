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
    }
}

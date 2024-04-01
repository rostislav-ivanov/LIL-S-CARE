using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models;
using LilsCareApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace LilsCareApp.Core.Services
{
    public class AdminDetailsService : IAdminDetailsService
    {

        private readonly ApplicationDbContext _context;
        private const string patternVideo = @"\.mp(4)?$";
        private const string pattern = "\r\n\r\n";

        public AdminDetailsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DetailsDTO> GetProductByIdAsync(int id)
        {
            var details = await _context.Products
             .Select(p => new DetailsDTO
             {
                 Id = p.Id,
                 Name = p.Name,
                 Price = p.Price,
                 Quantity = p.Quantity,
                 Optional = p.Optional,
                 Description = p.Description.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None),
                 Ingredients = p.Ingredients.Split(new string[] { pattern }, StringSplitOptions.None),
                 Purpose = p.Purpose.Split(new string[] { pattern }, StringSplitOptions.None),
                 ShippingCondition = p.ShippingCondition.Split(new string[] { pattern }, StringSplitOptions.None),
                 IngredientINCIs = p.IngredientINCIs.Split(new string[] { pattern }, StringSplitOptions.None),
                 Images = p.Images
                     .Where(im => im.ProductId == p.Id)
                     .Select(im => new ImageDTO
                     {
                         ImagePath = im.ImagePath,
                         IsVideo = Regex.IsMatch(im.ImagePath, patternVideo, RegexOptions.IgnoreCase)
                     }).ToList(),
                 ProductsCategories = p.ProductsCategories
                     .Where(pc => pc.ProductId == p.Id)
                     .Select(pc => new CategoryDTO
                     {
                         Id = pc.Category.Id,
                         Name = pc.Category.Name
                     }).ToList()
             })
             .AsNoTracking()
             .FirstOrDefaultAsync(p => p.Id == id);

            return details;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            return await _context.Categories
                .Select(c => new CategoryDTO
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .AsNoTracking()
                .ToArrayAsync();
        }
    }
}

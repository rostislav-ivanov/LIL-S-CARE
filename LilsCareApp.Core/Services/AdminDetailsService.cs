using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models;
using LilsCareApp.Infrastructure.Data;
using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace LilsCareApp.Core.Services
{
    public class AdminDetailsService : IAdminDetailsService
    {

        private readonly ApplicationDbContext _context;
        private const string patternVideo = @"\.mp(4)?$";

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
                 Description = p.Description,
                 Ingredients = p.Ingredients,
                 Purpose = p.Purpose,
                 ShippingCondition = p.ShippingCondition,
                 IngredientINCIs = p.IngredientINCIs,
                 Images = p.Images
                     .Where(im => im.ProductId == p.Id)
                     .OrderBy(im => im.ImageOrder)
                     .Select(im => new ImageDTO
                     {
                         Id = im.Id,
                         ImagePath = im.ImagePath,
                         ImageOrder = im.ImageOrder,
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

        public async Task MoveImageLeftAsync(int id, int imageOrder)
        {
            var image = await _context.ImageProducts
                .FirstOrDefaultAsync(im => im.ProductId == id && im.ImageOrder == imageOrder);
            if (image == null)
            {
                return;
            }

            var imageLeft = await _context.ImageProducts
                .FirstOrDefaultAsync(im => im.ProductId == id && im.ImageOrder == imageOrder - 1);
            if (imageLeft == null)
            {
                return;
            }

            image.ImageOrder--;
            imageLeft.ImageOrder++;

            await _context.SaveChangesAsync();
        }

        public async Task MoveImageRightAsync(int id, int imageOrder)
        {
            var image = await _context.ImageProducts
                .FirstOrDefaultAsync(im => im.ProductId == id && im.ImageOrder == imageOrder);
            if (image == null)
            {
                return;
            }

            var imageRight = await _context.ImageProducts
                .FirstOrDefaultAsync(im => im.ProductId == id && im.ImageOrder == imageOrder + 1);
            if (imageRight == null)
            {
                return;
            }

            image.ImageOrder++;
            imageRight.ImageOrder--;

            await _context.SaveChangesAsync();
        }

        public async Task<string?> RemoveImageAsync(int id, int imageId)
        {
            var image = await _context.ImageProducts
                .FirstOrDefaultAsync(im => im.ProductId == id && im.Id == imageId);

            if (image == null)
            {
                return null;
            }

            var images = await _context.ImageProducts
                .Where(ip => ip.ProductId == id)
                .OrderBy(ip => ip.ImageOrder)
                .ToListAsync();


            for (int i = 0; i < images.Count; i++)
            {
                if (images[i].ImageOrder > image.ImageOrder)
                {
                    images[i].ImageOrder--;
                }
            }

            _context.ImageProducts.Remove(image);

            await _context.SaveChangesAsync();

            return image.ImagePath;
        }

        public async Task AddProductImageAsync(int id, string filePath)
        {
            if (id == 0 || string.IsNullOrWhiteSpace(filePath))
            {
                return;
            }

            int count = await _context.ImageProducts
                .Where(ip => ip.ProductId == id)
                .CountAsync();

            var image = new ImageProduct
            {
                ProductId = id,
                ImagePath = filePath,
                ImageOrder = count + 1
            };

            await _context.ImageProducts.AddAsync(image);

            await _context.SaveChangesAsync();
        }
    }
}

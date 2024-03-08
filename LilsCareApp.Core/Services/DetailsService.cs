using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models;
using LilsCareApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace LilsCareApp.Core.Services
{
    public class DetailsService : IDetailsService
    {
        private readonly ApplicationDbContext _context;

        public DetailsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DetailsDTO> GetDetailsById(int productId, string appUserId)
        {
            string patternVideo = @"\.mp(4)?$";
            var details = await _context.Products
                .Select(p => new DetailsDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = 1,
                    AvailableQuantity = p.Quantity,
                    Weight = p.Weight,
                    Purpose = p.Purpose,
                    Description = p.Description,
                    IngredientINCIs = p.IngredientINCIs,
                    Ingredients = p.Ingredients,
                    Images = p.Images
                        .Where(im => im.ProductId == p.Id)
                        .Select(im => new ImageDTO
                        {
                            ImagePath = im.ImagePath,
                            IsVideo = Regex.IsMatch(im.ImagePath, patternVideo, RegexOptions.IgnoreCase)
                        }).ToList(),
                    Reviews = p.Reviews.Select(r => new ReviewDTO
                    {
                        Id = r.Id,
                        AuthorName = r.AuthorName,
                        Email = r.Email,
                        Rating = r.Rating,
                        Title = r.Title,
                        Comment = r.Comment,
                        CreatedOn = r.CreatedOn,
                        ProductId = r.ProductId,
                        AuthorId = r.AppUserId,
                    })
                        .ToList(),
                    ProductsCategories = p.ProductsCategories
                        .Where(pc => pc.ProductId == p.Id)
                        .Select(pc => new CategoryDTO
                        {
                            Id = pc.Category.Id,
                            Name = pc.Category.Name
                        }).ToList(),
                    IsWish = p.WishesUsers.Any(w => w.ProductId == p.Id && w.AppUserId == appUserId)
                })
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == productId);

            return details;
        }
    }
}

using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models;
using LilsCareApp.Infrastructure.Data;
using LilsCareApp.Infrastructure.Data.Models;
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
                    Reviews = p.Reviews
                        .Select(r => new GetReviewDTO
                        {
                            ProductId = r.ProductId,
                            AuthorName = r.Author.UserName,
                            Rating = r.Rating,
                            Title = r.Title,
                            Comment = r.Comment,
                            Images = r.Images
                                .Select(im => new ImageDTO
                                {
                                    ImagePath = im.ImagePath,
                                    IsVideo = Regex.IsMatch(im.ImagePath, patternVideo, RegexOptions.IgnoreCase)
                                }).ToList(),
                            CreatedOn = r.CreatedOn,
                        }).ToList(),
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


        public async Task AddReviewAsync(AddReviewDTO review)
        {
            if (await _context.Products.FindAsync(review.ProductId) == null)
            {
                return;
            }

            if (await _context.Users.FindAsync(review.AuthorId) == null)
            {
                return;
            }

            if (review.Stars.Count(s => s) == 0)
            {
                return;
            }

            var newReview = await _context.Reviews.FindAsync(review.ProductId, review.AuthorId);
            if (newReview == null)
            {
                newReview = new Review
                {
                    ProductId = review.ProductId,
                    AuthorId = review.AuthorId,
                    Rating = review.Stars.Count(s => s),
                    Title = review.Title,
                    Comment = review.Comment,
                    CreatedOn = DateTime.Now,
                };
                await _context.Reviews.AddAsync(newReview);
            }
            else
            {
                newReview.Rating = review.Stars.Count(s => s);
                newReview.Title = review.Title;
                newReview.Comment = review.Comment;
                newReview.CreatedOn = DateTime.Now;
                if (review.Images.Count > 0)
                {
                    _context.ImageReviews.RemoveRange(newReview.Images);
                }
            }

            if (review.Images.Count > 0)
            {
                List<ImageReview> images = new List<ImageReview>();
                foreach (var imagePath in review.Images)
                {
                    ImageReview newImage = new ImageReview
                    {
                        ImagePath = imagePath,
                        AuthorId = review.AuthorId,
                        ProductId = review.ProductId
                    };
                    images.Add(newImage);
                }
                await _context.ImageReviews.AddRangeAsync(images);
            }

            await _context.SaveChangesAsync();
        }

    }
}

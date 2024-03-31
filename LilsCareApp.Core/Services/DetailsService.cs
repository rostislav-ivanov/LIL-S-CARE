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
        private const string patternVideo = @"\.mp(4)?$";

        public DetailsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DetailsDTO> GetDetailsByIdAsync(int productId, string appUserId)
        {

            var details = await _context.Products
                .Select(p => new DetailsDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = 1,
                    AvailableQuantity = p.Quantity,
                    Optional = new KeyValuePair<string, string>(p.Optional.Name, p.Optional.Description),
                    Description = p.Description.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None),
                    Ingredients = p.Ingredients.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None),
                    Purpose = p.Purpose.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None),
                    ShippingCondition = p.ShippingCondition.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None),
                    IngredientINCIs = p.IngredientINCIs.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None),
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
                            AuthorName = r.Author.UserName ?? string.Empty,
                            AuthorEmail = r.Author.Email ?? string.Empty,
                            AuthorImage = r.Author.ImagePath,
                            Rating = r.Rating,
                            Title = r.Title,
                            Comment = r.Comment,
                            Images = r.Images
                                .Select(im => new ImageDTO
                                {
                                    ImagePath = im.ImagePath,
                                    IsVideo = Regex.IsMatch(im.ImagePath, patternVideo, RegexOptions.IgnoreCase)
                                }).ToArray(),
                            CreatedOn = r.CreatedOn,
                        })
                        .OrderByDescending(r => r.CreatedOn)
                        .ToList(),
                    Rating = p.Reviews.Count > 0 ? p.Reviews.Average(r => r.Rating) : 0,
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

        public async Task<AddReviewDTO?> GetReviewAsync(int productId, string userId)
        {
            if (await _context.Products.FindAsync(productId) == null)
            {
                return null;
            }

            if (await _context.Users.FindAsync(userId) == null)
            {
                return null;
            }

            AddReviewDTO? review = await _context.Reviews
                .Where(r => r.ProductId == productId && r.AuthorId == userId)
                .Select(r => new AddReviewDTO
                {
                    ProductId = r.ProductId,
                    ProductName = r.Product.Name,
                    ProductImage = r.Product.Images.FirstOrDefault().ImagePath,
                    AuthorId = r.AuthorId,
                    AuthorName = r.Author.UserName ?? string.Empty,
                    Email = r.Author.Email ?? string.Empty,
                    Title = r.Title,
                    Comment = r.Comment,
                    Images = r.Images
                        .Select(im => new ImageDTO
                        {
                            Id = im.Id,
                            ImagePath = im.ImagePath,
                            IsVideo = Regex.IsMatch(im.ImagePath, patternVideo, RegexOptions.IgnoreCase)
                        })
                        .OrderBy(im => im.Id)
                        .ToArray(),
                    Rating = r.Rating
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (review is null)
            {
                review = await _context.Products
                    .Where(p => p.Id == productId)
                    .Select(p => new AddReviewDTO
                    {
                        ProductId = p.Id,
                        ProductName = p.Name,
                        ProductImage = p.Images.FirstOrDefault().ImagePath,
                        AuthorId = userId,
                        AuthorName = _context.Users.Find(userId).UserName ?? string.Empty,
                        Email = _context.Users.Find(userId).Email ?? string.Empty,
                        Rating = 0,
                    })
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
            }

            for (int i = 0; i < review.Rating; i++)
            {
                review.Stars[i] = true;
            }

            return review;
        }

        public async Task SaveReviewAsync(AddReviewDTO review)
        {
            if (await _context.Products.FindAsync(review.ProductId) == null)
            {
                return;
            }

            if (await _context.Users.FindAsync(review.AuthorId) == null)
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
                    Rating = review.Rating,
                    Title = review.Title,
                    Comment = review.Comment,
                    CreatedOn = DateTime.Now,
                };

                await _context.Reviews.AddAsync(newReview);
            }
            else
            {
                newReview.Rating = review.Rating;
                newReview.Title = review.Title;
                newReview.Comment = review.Comment;
                newReview.CreatedOn = DateTime.Now;
            }


            if (review.Images.Any(im => im.ImagePath != string.Empty))
            {
                List<ImageReview> imageReview = await _context.ImageReviews
                    .Where(ir => ir.AuthorId == review.AuthorId && ir.ProductId == review.ProductId)
                    .ToListAsync();
                if (imageReview.Any())
                {
                    _context.ImageReviews.RemoveRange(imageReview);
                }

                List<ImageReview> newImageReview = review.Images
                    .Select(im => new ImageReview
                    {
                        ImagePath = im.ImagePath,
                        ProductId = review.ProductId,
                        AuthorId = review.AuthorId
                    })
                    .ToList();

                await _context.ImageReviews.AddRangeAsync(newImageReview);
            }

            await _context.SaveChangesAsync();
        }
    }
}

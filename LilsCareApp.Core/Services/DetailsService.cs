using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Details;
using LilsCareApp.Core.Models.Products;
using LilsCareApp.Infrastructure.Data;
using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using static LilsCareApp.Infrastructure.DataConstants.Language;

namespace LilsCareApp.Core.Services
{
    public class DetailsService : IDetailsService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAppConfigService _appConfigService;
        private readonly IHttpContextManager _httpContextManager;

        private const string patternVideo = @"\.mp(4)?$";

        public DetailsService(
            ApplicationDbContext context,
            IAppConfigService appConfigService,
            IHttpContextManager httpContextManager)
        {
            _context = context;
            _appConfigService = appConfigService;
            _httpContextManager = httpContextManager;
        }

        public async Task<DetailsDTO> GetDetailsByIdAsync(int productId, string appUserId)
        {
            if (await _context.Products.FindAsync(productId) == null)
            {
                return null;
            }

            var language = _httpContextManager.GetLanguage();
            decimal exchangeRate = await _appConfigService.GetExchangeRateAsync(language);

            var details = await _context.Products
                .Select(p => new DetailsDTO
                {
                    Id = p.Id,
                    Name = new Dictionary<string, string>
                    {
                        { Bulgarian, p.Name.NameBG },
                        { Romanian, p.Name.NameRO },
                        { English, p.Name.NameEN }
                    }[language],
                    Price = p.Price / exchangeRate,
                    Quantity = 1,
                    AvailableQuantity = p.Quantity,
                    Optional = new Dictionary<string, string>
                        {
                            { English, p.Optional.OptionalEN },
                            { Bulgarian, p.Optional.OptionalBG },
                            { Romanian, p.Optional.OptionalRO },
                        }[language],
                    Sections = p.Sections
                        .Where(s => s.ProductId == p.Id)
                        .OrderBy(s => s.SectionOrder)
                        .Select(s => new SectionDTO
                        {
                            Id = s.Id,
                            Title = new Dictionary<string, string>
                            {
                                { Bulgarian, s.Title.TitleBG },
                                { Romanian, s.Title.TitleRO },
                                { English, s.Title.TitleEN }
                            }[language],
                            Description = new Dictionary<string, string>
                            {
                                { Bulgarian, s.Description.DescriptionBG },
                                { Romanian, s.Description.DescriptionRO },
                                { English, s.Description.DescriptionEN }
                            }[language],
                            SectionOrder = s.SectionOrder
                        })
                        .ToList(),
                    Images = p.Images
                        .Where(im => im.ProductId == p.Id)
                        .OrderBy(im => im.ImageOrder)
                        .Select(im => new ImageDTO
                        {
                            ImagePath = im.ImagePath,
                            IsVideo = Regex.IsMatch(im.ImagePath, patternVideo, RegexOptions.IgnoreCase)
                        })
                        .ToList(),
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
                            Name = new Dictionary<string, string>
                            {
                                { Bulgarian, pc.Category.Name.NameBG },
                                { Romanian, pc.Category.Name.NameRO },
                                { English, pc.Category.Name.NameEN }
                            }[language],
                        }).ToList(),
                    IsWish = p.WishesUsers.Any(w => w.ProductId == p.Id && w.AppUserId == appUserId)
                })
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == productId);

            details.Price = Math.Round(details.Price, 2);

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

            var language = _httpContextManager.GetLanguage();

            AddReviewDTO? review = await _context.Reviews
                .Where(r => r.ProductId == productId && r.AuthorId == userId)
                .Select(r => new AddReviewDTO
                {
                    ProductId = r.ProductId,
                    ProductName = new Dictionary<string, string>
                    {
                        { Bulgarian, r.Product.Name.NameBG },
                        { Romanian, r.Product.Name.NameRO },
                        { English, r.Product.Name.NameEN }
                    }[language],
                    ProductImage = r.Product.Images.FirstOrDefault(im => im.ImageOrder == 1).ImagePath,
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
                        ProductName = new Dictionary<string, string>
                        {
                            { Bulgarian, p.Name.NameBG },
                            { Romanian, p.Name.NameRO },
                            { English, p.Name.NameEN }
                        }[language],
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

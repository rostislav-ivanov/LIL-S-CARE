using LilsCareApp.Infrastructure.Data.DataConfiguration;
using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data
{
    internal class ReviewsConfiguration : IEntityTypeConfiguration<Review>
    {
        private readonly IEnumerable<Review> reviews = new List<Review>
        {
            new Review
            {
                Id = 1,
                AuthorName = "John Doe",
                Email = "john@doe.com",
                Rating = 4,
                Title = "Great product",
                Comment = "Great product, I love it!",
                CreatedOn = DateTime.Now,
                ProductId = 1,
                AppUserId = ConfigurationHelper.AppUser.Id,
            },
            new Review
            {
                Id = 2,
                AuthorName = "John Doe 2",
                Email = "john@doe.com",
                Rating = 3,
                Title = "Great product",
                Comment = "Great product, I love it!",
                CreatedOn = DateTime.Now,
                ProductId = 1,
                AppUserId = ConfigurationHelper.AppUser.Id,
            },
                        new Review
            {
                Id = 3,
                AuthorName = "John Doe 3",
                Email = "john@doe.com",
                Rating = 3,
                Title = "Great product",
                Comment = "Great product, I love it!",
                CreatedOn = DateTime.Now,
                ProductId = 2,
                AppUserId = ConfigurationHelper.AppUser.Id,
            },
        };
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasData(reviews);
        }
    }
}
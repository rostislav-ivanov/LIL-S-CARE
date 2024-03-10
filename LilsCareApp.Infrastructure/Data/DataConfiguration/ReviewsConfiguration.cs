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
                Rating = 4,
                Title = "Great product",
                Comment = "Great product, I love it!",
                CreatedOn = DateTime.Now,
                ProductId = 2,
                AuthorId = ConfigurationHelper.AppUser.Id,
            },
            new Review
            {
                Rating = 3,
                Title = "Great product",
                Comment = "Great product, I love it!",
                CreatedOn = DateTime.Now,
                ProductId = 3,
                AuthorId = ConfigurationHelper.AppUser.Id,
            },
            new Review
            {
                Rating = 3,
                Title = "Great product",
                Comment = "Great product, I love it!",
                CreatedOn = DateTime.Now,
                ProductId = 4,
                AuthorId = ConfigurationHelper.AppUser.Id,
            },
        };
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasData(reviews);
        }
    }
}
using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class WishesUsersConfiguration : IEntityTypeConfiguration<WishUser>
    {
        private readonly IEnumerable<WishUser> wishesUsers = new List<WishUser>
            {
                new WishUser
                {
                    ProductId = 1,
                    AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef"
                },
                new WishUser
                {
                    ProductId = 3,
                    AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef"
                },
                new WishUser
                {
                    ProductId = 4,
                    AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef"
                }
            };
        public void Configure(EntityTypeBuilder<WishUser> builder)
        {

            builder.HasData(wishesUsers);
        }
    }
}
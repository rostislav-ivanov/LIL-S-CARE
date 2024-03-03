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
                    AppUserId = ConfigurationHelper.AppUser.Id
                },
                new WishUser
                {
                    ProductId = 3,
                    AppUserId = ConfigurationHelper.AppUser.Id
                },
                new WishUser
                {
                    ProductId = 4,
                    AppUserId = ConfigurationHelper.AppUser.Id
                }
            };
        public void Configure(EntityTypeBuilder<WishUser> builder)
        {

            builder.HasData(wishesUsers);
        }
    }
}
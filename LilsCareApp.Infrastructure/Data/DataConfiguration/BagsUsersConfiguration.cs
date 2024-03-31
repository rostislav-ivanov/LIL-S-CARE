using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class BagsUsersConfiguration : IEntityTypeConfiguration<BagUser>
    {
        private readonly IEnumerable<BagUser> bagsUsers = new List<BagUser>
            {
                new BagUser
                {
                    AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                    ProductId = 1,
                    Quantity = 2
                },
                new BagUser
                {
                    AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                    ProductId = 2,
                    Quantity = 3
                },
                new BagUser
                {
                    AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                    ProductId = 3,
                    Quantity = 4
                },

            };
        public void Configure(EntityTypeBuilder<BagUser> builder)
        {
            builder.HasData(bagsUsers);
        }
    }
}
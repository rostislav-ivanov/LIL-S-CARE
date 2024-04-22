using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        private readonly IEnumerable<Product> products =
        [
                new ()
                {
                    Id = 1,
                    NameId = 1,
                    Price = 5.50m,
                    Quantity = 10,
                    OptionalId = 1,
                    IsShow = true,
                },
                new ()
                {
                    Id = 2,
                    NameId = 2,
                    Price = 4.00m,
                    OptionalId = 2,
                    Quantity = 20,
                    IsShow = true,
                },
                new ()
                {
                    Id = 3,
                    NameId = 3,
                    Price = 12.00m,
                    OptionalId = 3,
                    Quantity = 30,
                    IsShow = true,
                },
                new ()
                {
                    Id = 4,
                    NameId = 4,
                    Price = 10.00m,
                    OptionalId = 4,
                    Quantity = 0,
                    IsShow = true,
                },
                new ()
                {
                    Id = 5,
                    NameId = 5,
                    Price = 8.50m,
                    OptionalId = 5,
                    Quantity = 10,
                    IsShow = true,
                },
                new ()
                {
                    Id = 6,
                    NameId = 6,
                    Price = 10.00m,
                    OptionalId = 6,
                    Quantity = 20,
                    IsShow = true,
                },
                new ()
                {
                    Id = 7,
                    NameId = 7,
                    Price = 10.00m,
                    OptionalId = 7,
                    Quantity = 0,
                    IsShow = true,
                },

        ];

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(products);
        }
    }
}
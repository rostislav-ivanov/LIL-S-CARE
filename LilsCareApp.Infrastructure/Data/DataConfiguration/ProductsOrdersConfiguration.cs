using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class ProductsOrdersConfiguration : IEntityTypeConfiguration<ProductOrder>
    {
        private readonly IEnumerable<ProductOrder> productsOrders =
            [
            new ()
            {
                ProductId = 1,
                OrderId = 1,
                Price = 5.00m,
                Quantity = 2,
                ImagePath = "/files/products/product-01-image-01.webp",
            },
            new ()
            {
                ProductId = 1,
                OrderId = 2,
                Price = 5.50m,
                Quantity = 3,
                ImagePath = "/files/products/product-01-image-01.webp",
            },
            new ()
            {
                ProductId = 2,
                OrderId = 1,
                Price = 6.50m,
                Quantity = 4,
                ImagePath = "/files/products/product-02-image-01.webp",
            },
            new ()
            {
                ProductId = 3,
                OrderId = 1,
                Price = 5.50m,
                Quantity = 3,
                ImagePath = "/files/products/product-03-image-01.webp",
            },
        ];

        public void Configure(EntityTypeBuilder<ProductOrder> builder)
        {
            builder.HasData(productsOrders);
        }
    }
}
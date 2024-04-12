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
            },
            new ()
            {
                ProductId = 1,
                OrderId = 2,
            },
            new ()
            {
                ProductId = 2,
                OrderId = 1,
            },
            new ()
            {
                ProductId = 3,
                OrderId = 1,
            },
            new ()
            {
                ProductId = 3,
                OrderId = 2,
            },
            new ()
            {
                ProductId = 4,
                OrderId = 1,
            },
            new ()
            {
                ProductId = 5,
                OrderId = 2,
            },
            new ()
            {
                ProductId = 6,
                OrderId = 1,
            },
            new ()
            {
                ProductId = 6,
                OrderId = 2,
            },
            new ()
            {
                ProductId = 7,
                OrderId = 1,
            }
        ];

        public void Configure(EntityTypeBuilder<ProductOrder> builder)
        {
            builder.HasData(productsOrders);
        }
    }
}
using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class ProductsCategoriesConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        private readonly IEnumerable<ProductCategory> productsCategories = new List<ProductCategory>
        {
            new ProductCategory
            {
                ProductId = 1,
                CategoryId = 1
            },
            new ProductCategory
            {
                ProductId = 1,
                CategoryId = 2
            },
            new ProductCategory
            {
                ProductId = 2,
                CategoryId = 2
            },
            new ProductCategory
            {
                ProductId = 2,
                CategoryId = 3
            }
        };
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasData(productsCategories);
        }
    }
}
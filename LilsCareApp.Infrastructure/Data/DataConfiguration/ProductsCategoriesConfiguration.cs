using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class ProductsCategoriesConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        private readonly IEnumerable<ProductCategory> productsCategories = new List<ProductCategory>
        {
            new ProductCategory { ProductId = 1,CategoryId = 1},
            new ProductCategory { ProductId = 1,CategoryId = 2},
            new ProductCategory { ProductId = 2,CategoryId = 3},
            new ProductCategory { ProductId = 2,CategoryId = 4},
            new ProductCategory { ProductId = 3,CategoryId = 1},
            new ProductCategory { ProductId = 4,CategoryId = 2},
            new ProductCategory { ProductId = 4,CategoryId = 3},
            new ProductCategory { ProductId = 4,CategoryId = 4},
            new ProductCategory { ProductId = 5,CategoryId = 1},
            new ProductCategory { ProductId = 5,CategoryId = 2},
            new ProductCategory { ProductId = 6,CategoryId = 3},
            new ProductCategory { ProductId = 6,CategoryId = 4},
            new ProductCategory { ProductId = 7,CategoryId = 1},

        };
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasData(productsCategories);
        }
    }
}
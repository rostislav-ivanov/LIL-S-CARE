using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class ProductsCategoriesConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        private readonly IEnumerable<ProductCategory> productsCategories =
        [
            new () { ProductId = 1,CategoryId = 1},
            new () { ProductId = 2,CategoryId = 1},
            new () { ProductId = 3,CategoryId = 1},
            new () { ProductId = 4,CategoryId = 1},
            new () { ProductId = 5,CategoryId = 1},
            new () { ProductId = 6,CategoryId = 1},
            new () { ProductId = 1,CategoryId = 2},
            new () { ProductId = 1,CategoryId = 3},
            new () { ProductId = 2,CategoryId = 3},
            new () { ProductId = 2,CategoryId = 4},
            new () { ProductId = 3,CategoryId = 5},
            new () { ProductId = 4,CategoryId = 2},
            new () { ProductId = 4,CategoryId = 3},
            new () { ProductId = 4,CategoryId = 5},
            new () { ProductId = 5,CategoryId = 3},
            new () { ProductId = 5,CategoryId = 5},
            new () { ProductId = 6,CategoryId = 3},
            new () { ProductId = 6,CategoryId = 4},

        ];
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasData(productsCategories);
        }
    }
}
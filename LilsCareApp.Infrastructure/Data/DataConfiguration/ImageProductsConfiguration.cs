using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class ImageProductsConfiguration : IEntityTypeConfiguration<ImageProduct>
    {
        private readonly IEnumerable<ImageProduct> images = new List<ImageProduct>()
        {

                new ImageProduct
                {
                    Id = 1,
                    ProductId = 1,
                    ImagePath = "/files/products/product-01-image-01.webp"
                },
                new ImageProduct
                {
                    Id = 2,
                    ProductId = 1,
                    ImagePath = "/files/products/product-01-image-02.webp"
                },
                new ImageProduct
                {
                    Id = 3,
                    ProductId = 1,
                    ImagePath = "/files/products/product-01-image-03.webp"
                },
                new ImageProduct
                {
                    Id = 4,
                    ProductId = 1,
                    ImagePath = "/files/products/product-01-image-04.webp"
                },
                new ImageProduct
                {
                    Id = 5,
                    ProductId = 2,
                    ImagePath = "/files/products/product-02-image-01.webp"
                },
                new ImageProduct
                {
                    Id = 6,
                    ProductId = 2,
                    ImagePath = "/files/products/product-02-image-02.webp"
                },
                new ImageProduct
                {
                    Id = 7,
                    ProductId = 2,
                    ImagePath = "/files/products/product-02-image-03.webp"
                },
                new ImageProduct
                {
                    Id = 8,
                    ProductId = 2,
                    ImagePath = "/files/products/product-02-image-04.webp"
                },
                new ImageProduct
                {
                    Id = 9,
                    ProductId = 2,
                    ImagePath = "/files/products/product-02-image-05.webp"
                },
                new ImageProduct
                {
                    Id = 10,
                    ProductId = 3,
                    ImagePath = "/files/products/product-03-image-01.webp"
                },
                new ImageProduct
                {
                    Id = 11,
                    ProductId = 3,
                    ImagePath = "/files/products/product-03-image-02.webp"
                },
                new ImageProduct
                {
                    Id = 12,
                    ProductId = 3,
                    ImagePath = "/files/products/product-03-image-03.webp"
                },
                new ImageProduct
                {
                    Id = 13,
                    ProductId = 3,
                    ImagePath = "/files/products/product-03-image-04.webp"
                },
                new ImageProduct
                {
                    Id = 14,
                    ProductId = 3,
                    ImagePath = "/files/products/product-03-image-05.webp"
                },
                new ImageProduct
                {
                    Id = 15,
                    ProductId = 4,
                    ImagePath = "/files/products/product-04-image-01.webp"
                },
                new ImageProduct
                {
                    Id = 16,
                    ProductId = 4,
                    ImagePath = "/files/products/product-04-image-02.webp"
                },
                new ImageProduct
                {
                    Id = 17,
                    ProductId = 4,
                    ImagePath = "/files/products/product-04-image-03.webp"
                },
                new ImageProduct
                {
                    Id = 18,
                    ProductId = 4,
                    ImagePath = "/files/products/product-04-image-04.webp"
                },
                new ImageProduct
                {
                    Id = 19,
                    ProductId = 5,
                    ImagePath = "/files/products/product-05-image-01.webp"
                },
                new ImageProduct
                {
                    Id = 20,
                    ProductId = 5,
                    ImagePath = "/files/products/product-05-image-02.webp"
                },
                new ImageProduct
                {
                    Id = 21,
                    ProductId = 5,
                    ImagePath = "/files/products/product-05-image-03.webp"
                },
                new ImageProduct
                {
                    Id = 22,
                    ProductId = 5,
                    ImagePath = "/files/products/product-05-image-04.webp"
                },
                new ImageProduct
                {
                    Id = 23,
                    ProductId = 6,
                    ImagePath = "/files/products/product-06-image-01.webp"
                },
                new ImageProduct
                {
                    Id = 24,
                    ProductId = 6,
                    ImagePath = "/files/products/product-06-image-02.webp"
                },
                new ImageProduct
                {
                    Id = 25,
                    ProductId = 6,
                    ImagePath = "/files/products/product-06-image-03.webp"
                },
                new ImageProduct
                {
                    Id = 26,
                    ProductId = 6,
                    ImagePath = "/files/products/product-06-image-04.webp"
                },
                new ImageProduct
                {
                    Id = 27,
                    ProductId = 6,
                    ImagePath = "/files/products/product-06-image-05.webp"
                },

        };
        public void Configure(EntityTypeBuilder<ImageProduct> builder)
        {
            builder.HasData(images);
        }
    }
}
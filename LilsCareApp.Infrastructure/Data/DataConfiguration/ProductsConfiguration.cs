using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        private readonly IEnumerable<Product> products = new List<Product>
        {
                new Product
                {
                    Id = 1,
                    Name = "НАТУРАЛЕН СУХ ДЕЗОДОРАНТ",
                    Price = 5.50m,
                    Quantity = 10,
                    Optional = "Тегло:  25 г.",
                    IsShow = true,
                },
                new Product
                {
                    Id = 2,
                    Name = "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК",
                    Price = 4.00m,
                    Optional = "Тегло:  5 г.",
                    Quantity = 20,
                    IsShow = true,
                },
                new Product
                {
                    Id = 3,
                    Name = "ХИДРАТИРАЩ КРЕМ С ШИПКА И НИАЦИНАМИД",
                    Price = 12.00m,
                    Optional = "Тегло:  50 г.",
                    Quantity = 30,
                    IsShow = true,
                },
                new Product
                {
                    Id = 4,
                    Name = "ДВУФАЗНА МИЦЕЛАРНА ВОДА ЗЕЛЕН ЧАЙ И ЖОЖОБА",
                    Price = 10.00m,
                    Optional = "Тегло:  100 мл.",
                    Quantity = 0,
                    IsShow = true,
                },
                new Product
                {
                    Id = 5,
                    Name = "НАТУРАЛЕН КРЕМ ДЕЗОДОРАНТ",
                    Price = 8.50m,
                   Optional = "Тегло:  50 г.",
                    Quantity = 10,
                    IsShow = true,
                },
                new Product
                {
                    Id = 6,
                    Name = "СЕРУМ МАСЛО С ШИПКА, ЖОЖОБА, АРГАН И ЯГОДОВИ СЕМКИ",
                    Price = 10.00m,
                    Optional = "Тегло:  20 мл.",
                    Quantity = 20,
                    IsShow = true,
                },
                new Product
                {
                    Id = 7,
                    Name = "",
                    Price = 10.00m,
                    Optional = "",
                    Quantity = 0,
                    IsShow = true,
                },

        };

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(products);
        }
    }
}
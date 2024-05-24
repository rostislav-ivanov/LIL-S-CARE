using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class ProductOptionalConfiguration : IEntityTypeConfiguration<ProductOptional>
    {
        private readonly IEnumerable<ProductOptional> optionals =
        [
            new ()
            {
                Id = 1,
                        OptionalEN = "Weight:  25 g.",
                        OptionalBG = "Тегло:  25 г.",
                        OptionalRO = "Greutate:  25 g.",
                        ProductId = 1,
            },
            new ()
            {
                Id = 2,
                        OptionalEN = "Weight:  5 g.",
                        OptionalBG = "Тегло:  5 г.",
                        OptionalRO = "Greutate:  5 g.",
                        ProductId = 2,
            },
            new ()
            {
                Id = 3,
                        OptionalEN = "Weight:  50 g.",
                        OptionalBG = "Тегло:  50 г.",
                        OptionalRO = "Greutate:  50 g.",
                        ProductId = 3,
            },
            new ()
            {
                Id = 4,
                        OptionalEN = "Weight:  100 ml.",
                        OptionalBG = "Тегло:  100 мл.",
                        OptionalRO = "Greutate:  100 ml.",
                        ProductId = 4,
            },
            new ()
            {
                Id = 5,
                        OptionalEN = "Weight:  50 g.",
                        OptionalBG = "Тегло:  50 г.",
                        OptionalRO = "Greutate:  50 g.",
                        ProductId = 5,
            },
            new ()
            {
                Id = 6,
                        OptionalEN = "Weight:  20 ml.",
                        OptionalBG = "Тегло:  20 мл.",
                        OptionalRO = "Greutate:  20 ml.",
                        ProductId = 6,
            },
            new ()
            {
                Id = 7,
                        OptionalEN = "",
                        OptionalBG = "",
                        OptionalRO = "",
                        ProductId = 7,
            },
        ];

        public void Configure(EntityTypeBuilder<ProductOptional> builder)
        {
            builder.HasData(optionals);
        }
    }
}
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
            },
            new ()
            {
                Id = 2,
                        OptionalEN = "Weight:  5 g.",
                        OptionalBG = "Тегло:  5 г.",
                        OptionalRO = "Greutate:  5 g.",
            },
            new ()
            {
                Id = 3,
                        OptionalEN = "Weight:  50 g.",
                        OptionalBG = "Тегло:  50 г.",
                        OptionalRO = "Greutate:  50 g.",
            },
            new ()
            {
                Id = 4,
                        OptionalEN = "Weight:  100 ml.",
                        OptionalBG = "Тегло:  100 мл.",
                        OptionalRO = "Greutate:  100 ml.",
            },
            new ()
            {
                Id = 5,
                        OptionalEN = "Weight:  50 g.",
                        OptionalBG = "Тегло:  50 г.",
                        OptionalRO = "Greutate:  50 g.",
            },
            new ()
            {
                Id = 6,
                        OptionalEN = "Weight:  20 ml.",
                        OptionalBG = "Тегло:  20 мл.",
                        OptionalRO = "Greutate:  20 ml.",
            },
            new ()
            {
                Id = 7,
                        OptionalEN = "",
                        OptionalBG = "",
                        OptionalRO = "",
            },
        ];

        public void Configure(EntityTypeBuilder<ProductOptional> builder)
        {
            builder.HasData(optionals);
        }
    }
}
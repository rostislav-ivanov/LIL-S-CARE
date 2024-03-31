using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class OptionalConfiguration : IEntityTypeConfiguration<Optional>
    {
        private readonly IEnumerable<Optional> optionals = new List<Optional>
        {
            new Optional { Id = 1, Name = "Тегло:", Description = "25 г." },
            new Optional { Id = 2, Name = "Тегло", Description = "5 г." },
            new Optional { Id = 3, Name = "Тегло:", Description = "50 г." },
            new Optional { Id = 4, Name = "Тегло:", Description = "100 мл." },
            new Optional { Id = 5, Name = "Тегло:", Description = "20 мл." },
        };
        public void Configure(EntityTypeBuilder<Optional> builder)
        {
            builder.HasData(optionals);
        }
    }
}
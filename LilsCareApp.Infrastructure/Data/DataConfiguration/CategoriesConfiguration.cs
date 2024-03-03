using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class CategoriesConfiguration : IEntityTypeConfiguration<Category>
    {
        private readonly IEnumerable<Category> categories = new List<Category>
        {
            new Category { Id = 1, Name = "Всички" },
            new Category { Id = 2, Name = "за тяло" },
            new Category { Id = 3, Name = "за суха кожа" },
            new Category { Id = 4, Name = "за мазна кожа" },
            new Category { Id = 5, Name = "за лице" },
        };

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(categories);
        }
    }
}
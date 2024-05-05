using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class CategoryNamesConfiguration : IEntityTypeConfiguration<CategoryName>
    {
        public readonly IEnumerable<CategoryName> categories =
        [
            new ()
            {
                Id = 1,
                NameEN = "all",
                NameBG = "всички",
                NameRO = "toate",
                CategoryId = 1
            },
            new ()
            {
                Id = 2,
                NameEN = "body",
                NameBG = "за тяло",
                NameRO = "pentru corp",
                CategoryId = 2
            },
            new ()
            {
                Id = 3,
                NameEN = "dry skin",
                NameBG = "за суха кожа",
                NameRO = "pentru piele uscata",
                CategoryId = 3
            },
            new ()
            {
                Id = 4,
                NameEN = "oily skin",
                NameBG = "за мазна кожа",
                NameRO = "pentru piele grasa",
                CategoryId = 4
            },
            new ()
            {
                Id = 5,
                NameEN = "face",
                NameBG = "за лице",
                NameRO = "pentru fata",
                CategoryId = 5
            },
        ];

        public void Configure(EntityTypeBuilder<CategoryName> builder)
        {
            builder.HasData(categories);
        }
    }
}

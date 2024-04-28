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
                NameRO = "toate"
            },
            new ()
            {
                Id = 2,
                NameEN = "body",
                NameBG = "за тяло",
                NameRO = "pentru corp"
            },
            new ()
            {
                Id = 3,
                NameEN = "dry skin",
                NameBG = "за суха кожа",
                NameRO = "pentru piele uscata"
            },
            new ()
            {
                Id = 4,
                NameEN = "oily skin",
                NameBG = "за мазна кожа",
                NameRO = "pentru piele grasa"
            },
            new ()
            {
                Id = 5,
                NameEN = "face",
                NameBG = "за лице",
                NameRO = "pentru fata"
            },
        ];

        public void Configure(EntityTypeBuilder<CategoryName> builder)
        {
            builder.HasData(categories);
        }
    }
}

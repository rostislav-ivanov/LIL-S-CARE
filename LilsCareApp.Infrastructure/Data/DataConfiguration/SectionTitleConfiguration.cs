using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class SectionTitleConfiguration : IEntityTypeConfiguration<SectionTitle>
    {
        private readonly IEnumerable<SectionTitle> titles =
        [
            new ()
            {
                Id = 1,
                TitleEN = "DESCRIPTION",
                TitleBG = "ОПИСАНИЕ",
                TitleRO = "DESCRIERE"
            },
            new ()
            {
                Id = 2,
                TitleEN = "ABOUT THE INGREDIENTS",
                TitleBG = "ЗА СЪСТАВКИТЕ",
                TitleRO = "DESPRE INGREDIENTE"
            },
            new ()
            {
                Id = 3,
                TitleEN = "USE",
                TitleBG = "УПОТРЕБА",
                TitleRO = "UTILIZARE"
            },
            new ()
            {
                Id = 4,
                TitleEN = "PICKUP AND DELIVERY",
                TitleBG = "ИЗПРАЩАНЕ И ДОСТАВКА",
                TitleRO = "RIDICARE ȘI LIVRARE"
            },
            new ()
            {
                Id = 5,
                TitleEN = "COMPOSITION, INCI",
                TitleBG = "СЪСТАВ, INCI",
                TitleRO = "COMPOZIȚIE, INCI"
            },
            new ()
            {
                Id = 6,
                TitleEN = "DESCRIPTION",
                TitleBG = "ОПИСАНИЕ",
                TitleRO = "DESCRIERE"
            },
            new ()
            {
                Id = 7,
                TitleEN = "ABOUT THE INGREDIENTS",
                TitleBG = "ЗА СЪСТАВКИТЕ",
                TitleRO = "DESPRE INGREDIENTE"
            },
            new ()
            {
                Id = 8,
                TitleEN = "USE",
                TitleBG = "УПОТРЕБА",
                TitleRO = "UTILIZARE"
            },
            new ()
            {
                Id = 9,
                TitleEN = "PICKUP AND DELIVERY",
                TitleBG = "ИЗПРАЩАНЕ И ДОСТАВКА",
                TitleRO = "RIDICARE ȘI LIVRARE"
            },
            new ()
            {
                Id = 10,
                TitleEN = "COMPOSITION, INCI",
                TitleBG = "СЪСТАВ, INCI",
                TitleRO = "COMPOZIȚIE, INCI"
            },
            new ()
            {
                Id = 11,
                TitleEN = "DESCRIPTION",
                TitleBG = "ОПИСАНИЕ",
                TitleRO = "DESCRIERE"
            },
            new ()
            {
                Id = 12,
                TitleEN = "ABOUT THE INGREDIENTS",
                TitleBG = "ЗА СЪСТАВКИТЕ",
                TitleRO = "DESPRE INGREDIENTE"
            },
            new ()
            {
                Id = 13,
                TitleEN = "USE",
                TitleBG = "УПОТРЕБА",
                TitleRO = "UTILIZARE"
            },
            new ()
            {
                Id = 14,
                TitleEN = "PICKUP AND DELIVERY",
                TitleBG = "ИЗПРАЩАНЕ И ДОСТАВКА",
                TitleRO = "RIDICARE ȘI LIVRARE"
            },
            new ()
            {
                Id = 15,
                TitleEN = "COMPOSITION, INCI",
                TitleBG = "СЪСТАВ, INCI",
                TitleRO = "COMPOZIȚIE, INCI"
            },
            new ()
            {
                Id = 16,
                TitleEN = "DESCRIPTION",
                TitleBG = "ОПИСАНИЕ",
                TitleRO = "DESCRIERE"
            },
            new ()
            {
                Id = 17,
                TitleEN = "ABOUT THE INGREDIENTS",
                TitleBG = "ЗА СЪСТАВКИТЕ",
                TitleRO = "DESPRE INGREDIENTE"
            },
            new ()
            {
                Id = 18,
                TitleEN = "USE",
                TitleBG = "УПОТРЕБА",
                TitleRO = "UTILIZARE"
            },
            new ()
            {
                Id = 19,
                TitleEN = "PICKUP AND DELIVERY",
                TitleBG = "ИЗПРАЩАНЕ И ДОСТАВКА",
                TitleRO = "RIDICARE ȘI LIVRARE"
            },
            new ()
            {
                Id = 20,
                TitleEN = "COMPOSITION, INCI",
                TitleBG = "СЪСТАВ, INCI",
                TitleRO = "COMPOZIȚIE, INCI"
            },
            new ()
            {
                Id = 21,
                TitleEN = "DESCRIPTION",
                TitleBG = "ОПИСАНИЕ",
                TitleRO = "DESCRIERE"
            },
            new ()
            {
                Id = 22,
                TitleEN = "ABOUT THE INGREDIENTS",
                TitleBG = "ЗА СЪСТАВКИТЕ",
                TitleRO = "DESPRE INGREDIENTE"
            },
            new ()
            {
                Id = 23,
                TitleEN = "USE",
                TitleBG = "УПОТРЕБА",
                TitleRO = "UTILIZARE"
            },
            new ()
            {
                Id = 24,
                TitleEN = "PICKUP AND DELIVERY",
                TitleBG = "ИЗПРАЩАНЕ И ДОСТАВКА",
                TitleRO = "RIDICARE ȘI LIVRARE"
            },
            new ()
            {
                Id = 25,
                TitleEN = "COMPOSITION, INCI",
                TitleBG = "СЪСТАВ, INCI",
                TitleRO = "COMPOZIȚIE, INCI"
            },
            new ()
            {
                Id = 26,
                TitleEN = "DESCRIPTION",
                TitleBG = "ОПИСАНИЕ",
                TitleRO = "DESCRIERE"
            },
            new ()
            {
                Id = 27,
                TitleEN = "ABOUT THE INGREDIENTS",
                TitleBG = "ЗА СЪСТАВКИТЕ",
                TitleRO = "DESPRE INGREDIENTE"
            },
            new ()
            {
                Id = 28,
                TitleEN = "USE",
                TitleBG = "УПОТРЕБА",
                TitleRO = "UTILIZARE"
            },
            new ()
            {
                Id = 29,
                TitleEN = "PICKUP AND DELIVERY",
                TitleBG = "ИЗПРАЩАНЕ И ДОСТАВКА",
                TitleRO = "RIDICARE ȘI LIVRARE"
            },
            new ()
            {
                Id = 30,
                TitleEN = "COMPOSITION, INCI",
                TitleBG = "СЪСТАВ, INCI",
                TitleRO = "COMPOZIȚIE, INCI"
            },
            new ()
            {
                Id = 31,
                TitleEN = "DESCRIPTION",
                TitleBG = "ОПИСАНИЕ",
                TitleRO = "DESCRIERE"
            },
            new ()
            {
                Id = 32,
                TitleEN = "ABOUT THE INGREDIENTS",
                TitleBG = "ЗА СЪСТАВКИТЕ",
                TitleRO = "DESPRE INGREDIENTE"
            },
            new ()
            {
                Id = 33,
                TitleEN = "USE",
                TitleBG = "УПОТРЕБА",
                TitleRO = "UTILIZARE"
            },
            new ()
            {
                Id = 34,
                TitleEN = "PICKUP AND DELIVERY",
                TitleBG = "ИЗПРАЩАНЕ И ДОСТАВКА",
                TitleRO = "RIDICARE ȘI LIVRARE"
            },
            new ()
            {
                Id = 35,
                TitleEN = "COMPOSITION, INCI",
                TitleBG = "СЪСТАВ, INCI",
                TitleRO = "COMPOZIȚIE, INCI"
            },
        ];
        public void Configure(EntityTypeBuilder<SectionTitle> builder)
        {
            builder.HasData(titles);
        }
    }
}
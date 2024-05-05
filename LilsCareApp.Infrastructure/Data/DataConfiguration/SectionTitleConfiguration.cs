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
                TitleRO = "DESCRIERE",
                SectionId = 1
            },
            new ()
            {
                Id = 2,
                TitleEN = "ABOUT THE INGREDIENTS",
                TitleBG = "ЗА СЪСТАВКИТЕ",
                TitleRO = "DESPRE INGREDIENTE",
                SectionId = 2
            },
            new ()
            {
                Id = 3,
                TitleEN = "USE",
                TitleBG = "УПОТРЕБА",
                TitleRO = "UTILIZARE",
                SectionId = 3
            },
            new ()
            {
                Id = 4,
                TitleEN = "PICKUP AND DELIVERY",
                TitleBG = "ИЗПРАЩАНЕ И ДОСТАВКА",
                TitleRO = "RIDICARE ȘI LIVRARE",
                SectionId = 4
            },
            new ()
            {
                Id = 5,
                TitleEN = "COMPOSITION, INCI",
                TitleBG = "СЪСТАВ, INCI",
                TitleRO = "COMPOZIȚIE, INCI",
                SectionId = 5
            },
            new ()
            {
                Id = 6,
                TitleEN = "DESCRIPTION",
                TitleBG = "ОПИСАНИЕ",
                TitleRO = "DESCRIERE",
                SectionId = 6
            },
            new ()
            {
                Id = 7,
                TitleEN = "ABOUT THE INGREDIENTS",
                TitleBG = "ЗА СЪСТАВКИТЕ",
                TitleRO = "DESPRE INGREDIENTE",
                SectionId = 7
            },
            new ()
            {
                Id = 8,
                TitleEN = "USE",
                TitleBG = "УПОТРЕБА",
                TitleRO = "UTILIZARE",
                SectionId = 8
            },
            new ()
            {
                Id = 9,
                TitleEN = "PICKUP AND DELIVERY",
                TitleBG = "ИЗПРАЩАНЕ И ДОСТАВКА",
                TitleRO = "RIDICARE ȘI LIVRARE",
                SectionId = 9
            },
            new ()
            {
                Id = 10,
                TitleEN = "COMPOSITION, INCI",
                TitleBG = "СЪСТАВ, INCI",
                TitleRO = "COMPOZIȚIE, INCI",
                SectionId = 10
            },
            new ()
            {
                Id = 11,
                TitleEN = "DESCRIPTION",
                TitleBG = "ОПИСАНИЕ",
                TitleRO = "DESCRIERE",
                SectionId = 11
            },
            new ()
            {
                Id = 12,
                TitleEN = "ABOUT THE INGREDIENTS",
                TitleBG = "ЗА СЪСТАВКИТЕ",
                TitleRO = "DESPRE INGREDIENTE",
                SectionId = 12
            },
            new ()
            {
                Id = 13,
                TitleEN = "USE",
                TitleBG = "УПОТРЕБА",
                TitleRO = "UTILIZARE",
                SectionId = 13
            },
            new ()
            {
                Id = 14,
                TitleEN = "PICKUP AND DELIVERY",
                TitleBG = "ИЗПРАЩАНЕ И ДОСТАВКА",
                TitleRO = "RIDICARE ȘI LIVRARE",
                SectionId = 14
            },
            new ()
            {
                Id = 15,
                TitleEN = "COMPOSITION, INCI",
                TitleBG = "СЪСТАВ, INCI",
                TitleRO = "COMPOZIȚIE, INCI",
                SectionId = 15
            },
            new ()
            {
                Id = 16,
                TitleEN = "DESCRIPTION",
                TitleBG = "ОПИСАНИЕ",
                TitleRO = "DESCRIERE",
                SectionId = 16
            },
            new ()
            {
                Id = 17,
                TitleEN = "ABOUT THE INGREDIENTS",
                TitleBG = "ЗА СЪСТАВКИТЕ",
                TitleRO = "DESPRE INGREDIENTE",
                SectionId = 17
            },
            new ()
            {
                Id = 18,
                TitleEN = "USE",
                TitleBG = "УПОТРЕБА",
                TitleRO = "UTILIZARE",
                SectionId = 18
            },
            new ()
            {
                Id = 19,
                TitleEN = "PICKUP AND DELIVERY",
                TitleBG = "ИЗПРАЩАНЕ И ДОСТАВКА",
                TitleRO = "RIDICARE ȘI LIVRARE",
                SectionId = 19
            },
            new ()
            {
                Id = 20,
                TitleEN = "COMPOSITION, INCI",
                TitleBG = "СЪСТАВ, INCI",
                TitleRO = "COMPOZIȚIE, INCI",
                SectionId = 20
            },
            new ()
            {
                Id = 21,
                TitleEN = "DESCRIPTION",
                TitleBG = "ОПИСАНИЕ",
                TitleRO = "DESCRIERE",
                SectionId = 21
            },
            new ()
            {
                Id = 22,
                TitleEN = "ABOUT THE INGREDIENTS",
                TitleBG = "ЗА СЪСТАВКИТЕ",
                TitleRO = "DESPRE INGREDIENTE",
                SectionId = 22
            },
            new ()
            {
                Id = 23,
                TitleEN = "USE",
                TitleBG = "УПОТРЕБА",
                TitleRO = "UTILIZARE",
                SectionId = 23
            },
            new ()
            {
                Id = 24,
                TitleEN = "PICKUP AND DELIVERY",
                TitleBG = "ИЗПРАЩАНЕ И ДОСТАВКА",
                TitleRO = "RIDICARE ȘI LIVRARE",
                SectionId = 24
            },
            new ()
            {
                Id = 25,
                TitleEN = "COMPOSITION, INCI",
                TitleBG = "СЪСТАВ, INCI",
                TitleRO = "COMPOZIȚIE, INCI",
                SectionId = 25
            },
            new ()
            {
                Id = 26,
                TitleEN = "DESCRIPTION",
                TitleBG = "ОПИСАНИЕ",
                TitleRO = "DESCRIERE",
                SectionId = 26
            },
            new ()
            {
                Id = 27,
                TitleEN = "ABOUT THE INGREDIENTS",
                TitleBG = "ЗА СЪСТАВКИТЕ",
                TitleRO = "DESPRE INGREDIENTE",
                SectionId = 27
            },
            new ()
            {
                Id = 28,
                TitleEN = "USE",
                TitleBG = "УПОТРЕБА",
                TitleRO = "UTILIZARE",
                SectionId = 28
            },
            new ()
            {
                Id = 29,
                TitleEN = "PICKUP AND DELIVERY",
                TitleBG = "ИЗПРАЩАНЕ И ДОСТАВКА",
                TitleRO = "RIDICARE ȘI LIVRARE",
                SectionId = 29
            },
            new ()
            {
                Id = 30,
                TitleEN = "COMPOSITION, INCI",
                TitleBG = "СЪСТАВ, INCI",
                TitleRO = "COMPOZIȚIE, INCI",
                SectionId = 30
            },
            new ()
            {
                Id = 31,
                TitleEN = "DESCRIPTION",
                TitleBG = "ОПИСАНИЕ",
                TitleRO = "DESCRIERE",
                SectionId = 31
            },
            new ()
            {
                Id = 32,
                TitleEN = "ABOUT THE INGREDIENTS",
                TitleBG = "ЗА СЪСТАВКИТЕ",
                TitleRO = "DESPRE INGREDIENTE",
                SectionId = 32
            },
            new ()
            {
                Id = 33,
                TitleEN = "USE",
                TitleBG = "УПОТРЕБА",
                TitleRO = "UTILIZARE",
                SectionId = 33
            },
            new ()
            {
                Id = 34,
                TitleEN = "PICKUP AND DELIVERY",
                TitleBG = "ИЗПРАЩАНЕ И ДОСТАВКА",
                TitleRO = "RIDICARE ȘI LIVRARE",
                SectionId = 34
            },
            new ()
            {
                Id = 35,
                TitleEN = "COMPOSITION, INCI",
                TitleBG = "СЪСТАВ, INCI",
                TitleRO = "COMPOZIȚIE, INCI",
                SectionId = 35
            },
        ];
        public void Configure(EntityTypeBuilder<SectionTitle> builder)
        {
            builder.HasData(titles);
        }
    }
}
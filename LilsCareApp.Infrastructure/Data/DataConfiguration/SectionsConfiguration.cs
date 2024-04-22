using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class SectionsConfiguration : IEntityTypeConfiguration<Section>
    {
        private readonly IEnumerable<Section> sections =
        [
            new ()
            {
                Id = 1,
                TitleId = 1,
                DescriptionId = 1,
                SectionOrder = 1,
                ProductId = 1
            },
            new ()
            {
                Id = 2,
                TitleId = 2,
                DescriptionId = 2,
                SectionOrder = 2,
                ProductId = 1
            },
            new ()
            {
                Id = 3,
                TitleId = 3,
                DescriptionId = 3,
                SectionOrder = 3,
                ProductId = 1
            },
            new ()
            {
                Id = 4,
                TitleId = 4,
                DescriptionId = 4,
                SectionOrder = 4,
                ProductId = 1
            },
            new ()
            {
                Id = 5,
                TitleId = 5,
                DescriptionId = 5,
                SectionOrder = 5,
                ProductId = 1
            },
            new ()
            {
                Id = 6,
                TitleId = 6,
                DescriptionId = 6,
                SectionOrder = 1,
                ProductId = 2
            },
            new ()
            {
                Id = 7,
                TitleId = 7,
                DescriptionId = 7,
                SectionOrder = 2,
                ProductId = 2
            },
            new ()
            {
                Id = 8,
                TitleId = 8,
                DescriptionId = 8,
                SectionOrder = 3,
                ProductId = 2
            },
            new ()
            {
                Id = 9,
                TitleId = 9,
                DescriptionId = 9,
                SectionOrder = 4,
                ProductId = 2
            },
            new ()
            {
                Id = 10,
                TitleId = 10,
                DescriptionId = 10,
                SectionOrder = 5,
                ProductId = 2
            },
            new ()
            {
                Id = 11,
                TitleId = 11,
                DescriptionId = 11,
                SectionOrder = 1,
                ProductId = 3
            },
            new ()
            {
                Id = 12,
                TitleId = 12,
                DescriptionId = 12,
                SectionOrder = 2,
                ProductId = 3
            },
            new ()
            {
                Id = 13,
                TitleId = 13,
                DescriptionId = 13,
                SectionOrder = 3,
                ProductId = 3
            },
            new ()
            {
                Id = 14,
                TitleId = 14,
                DescriptionId = 14,
                SectionOrder = 4,
                ProductId = 3
            },
            new ()
            {
                Id = 15,
                TitleId = 15,
                DescriptionId = 15,
                SectionOrder = 5,
                ProductId = 3
            }
            ,
            new ()
            {
                Id = 16,
                TitleId = 16,
                DescriptionId = 16,
                SectionOrder = 1,
                ProductId = 4
            },
            new ()
            {
                Id = 17,
                TitleId = 17,
                DescriptionId = 17,
                SectionOrder = 2,
                ProductId = 4
            },
            new ()
            {
                Id = 18,
                TitleId = 18,
                DescriptionId = 18,
                SectionOrder = 3,
                ProductId = 4
            },
            new ()
            {
                Id = 19,
                TitleId = 19,
                DescriptionId = 19,
                SectionOrder = 4,
                ProductId = 4
            },
            new ()
            {
                Id = 20,
                TitleId = 20,
                DescriptionId = 20,
                SectionOrder = 5,
                ProductId = 4
            }
            ,
            new ()
            {
                Id = 21,
                TitleId = 21,
                DescriptionId = 21,
                SectionOrder = 1,
                ProductId = 5
            },
            new ()
            {
                Id = 22,
                TitleId = 22,
                DescriptionId = 22,
                SectionOrder = 2,
                ProductId = 5
            },
            new ()
            {
                Id = 23,
                TitleId = 23,
                DescriptionId = 23,
                SectionOrder = 3,
                ProductId = 5
            },
            new ()
            {
                Id = 24,
                TitleId = 24,
                DescriptionId = 24,
                SectionOrder = 4,
                ProductId = 5
            },
            new ()
            {
                Id = 25,
                TitleId = 25,
                DescriptionId = 25,
                SectionOrder = 5,
                ProductId = 5
            },
            new ()
            {
                Id = 26,
                TitleId = 26,
                DescriptionId = 26,
                SectionOrder = 1,
                ProductId = 6
            },
            new ()
            {
                Id = 27,
                TitleId = 27,
                DescriptionId = 27,
                SectionOrder = 2,
                ProductId = 6
            },
            new ()
            {
                Id = 28,
                TitleId = 28,
                DescriptionId = 28,
                SectionOrder = 3,
                ProductId = 6
            },
            new ()
            {
                Id = 29,
                TitleId = 29,
                DescriptionId = 29,
                SectionOrder = 4,
                ProductId = 6
            },
            new ()
            {
                Id = 30,
                TitleId = 30,
                DescriptionId = 30,
                SectionOrder = 5,
                ProductId = 6
            },
            new ()
            {
                Id = 31,
                TitleId = 31,
                DescriptionId = 31,
                SectionOrder = 1,
                ProductId = 7
            },
            new ()
            {
                Id = 32,
                TitleId = 32,
                DescriptionId = 32,
                SectionOrder = 2,
                ProductId = 7
            },
            new ()
            {
                Id = 33,
                TitleId = 33,
                DescriptionId = 33,
                SectionOrder = 3,
                ProductId = 7
            },
            new ()
            {
                Id = 34,
                TitleId = 34,
                DescriptionId = 34,
                SectionOrder = 4,
                ProductId = 7
            },
            new ()
            {
                Id = 35,
                TitleId = 35,
                DescriptionId = 35,
                SectionOrder = 5,
                ProductId = 7
            }
        ];
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasData(sections);
        }
    }
}
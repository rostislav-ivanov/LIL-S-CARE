using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Infrastructure.DataConstants.Section;

namespace LilsCareApp.Infrastructure.Data.Models
{
    public class SectionDescription
    {
        [Key]
        public int Id { get; set; }

        [Comment("The section's description in English")]
        [MaxLength(DescriptionMaxLength)]
        public required string DescriptionEN { get; set; }

        [Comment("The section's description in Bulgarian")]
        [MaxLength(DescriptionMaxLength)]
        public required string DescriptionBG { get; set; }

        [Comment("The section's description in Romanian")]
        [MaxLength(DescriptionMaxLength)]
        public required string DescriptionRO { get; set; }

        public int SectionId { get; set; }

        public Section Section { get; set; } = null!;
    }
}
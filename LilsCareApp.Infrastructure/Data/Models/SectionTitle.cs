using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Infrastructure.DataConstants.Section;

namespace LilsCareApp.Infrastructure.Data.Models
{
    public class SectionTitle
    {
        [Key]
        public int Id { get; set; }

        [Comment("The section's title in English")]
        [MaxLength(TitleMaxLength)]
        public required string TitleEN { get; set; }

        [Comment("The section's title in Bulgarian")]
        [MaxLength(TitleMaxLength)]
        public required string TitleBG { get; set; }

        [Comment("The section's title in Romanian")]
        [MaxLength(TitleMaxLength)]
        public required string TitleRO { get; set; }

        [Comment("Navigation Property to Sections")]
        public IEnumerable<Section> Sections { get; set; } = [];
    }
}
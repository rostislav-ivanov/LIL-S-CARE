using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LilsCareApp.Infrastructure.Data.Models
{
    [Comment("The section model. Keeping descriptions of product")]
    public class Section
    {
        [Comment("The section's primary key")]
        [Key]
        public int Id { get; set; }

        [Comment("The section's title Id")]
        public int TitleId { get; set; }

        [ForeignKey(nameof(TitleId))]
        public SectionTitle Title { get; set; } = null!;

        [Comment("The section's description Id")]
        public int DescriptionId { get; set; }

        [ForeignKey(nameof(DescriptionId))]
        public SectionDescription Description { get; set; } = null!;

        [Comment("The section's order in page")]
        public int SectionOrder { get; set; }

        [Comment("The product's primary key")]
        public int ProductId { get; set; }

        [Comment("Navigation property to the product")]
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
    }
}
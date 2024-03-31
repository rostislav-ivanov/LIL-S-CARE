using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Infrastructure.DataConstants.Optional;

namespace LilsCareApp.Infrastructure.Data.Models
{
    [Comment("The optional property of product")]
    public class Optional
    {
        [Comment("The optional's primary key")]
        [Key]
        public int Id { get; set; }

        [Comment("Product's optional name")]
        [MaxLength(NameMaxLength)]
        public required string Name { get; set; }

        [Comment("Product's optional description")]
        [MaxLength(DescriptionMaxLength)]
        public required string Description { get; set; }

        [Comment("Navigation property to the product")]
        public IEnumerable<Product> Products { get; set; } = [];
    }
}
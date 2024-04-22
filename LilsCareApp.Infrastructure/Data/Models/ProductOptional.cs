using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Infrastructure.DataConstants.Product;

namespace LilsCareApp.Infrastructure.Data.Models
{
    public class ProductOptional
    {
        [Key]
        public int Id { get; set; }

        [Comment("The product's optional in English")]
        [MaxLength(OptionalMaxLength)]
        public required string OptionalEN { get; set; }

        [Comment("The product's optional in Bulgarian")]
        [MaxLength(OptionalMaxLength)]
        public required string OptionalBG { get; set; }

        [Comment("The product's optional in Romanian")]
        [MaxLength(OptionalMaxLength)]
        public required string OptionalRO { get; set; }

        [Comment("Navigation Property to Products")]
        public IEnumerable<Product> Products { get; set; } = [];
    }
}
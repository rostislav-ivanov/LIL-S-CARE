using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Infrastructure.DataConstants.Product;

namespace LilsCareApp.Infrastructure.Data.Models
{
    public class ProductName
    {
        [Key]
        public int Id { get; set; }

        [Comment("The product's name in English")]
        [MaxLength(NameMaxLength)]
        public required string NameEN { get; set; }

        [Comment("The product's name in Bulgarian")]
        [MaxLength(NameMaxLength)]
        public required string NameBG { get; set; }

        [Comment("The product's name in Romanian")]
        [MaxLength(NameMaxLength)]
        public required string NameRO { get; set; }

        [Comment("Navigation Property to Products")]
        public IEnumerable<Product> Products { get; set; } = [];

    }
}
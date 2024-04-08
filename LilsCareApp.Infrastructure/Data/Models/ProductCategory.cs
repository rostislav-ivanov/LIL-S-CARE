using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LilsCareApp.Infrastructure.Data.Models
{

    [Comment("Many to many relation between products and categories")]
    [PrimaryKey("ProductId", "CategoryId")]
    public class ProductCategory
    {
        [Comment("The product id")]
        [Required]
        public int ProductId { get; set; }

        [Comment("Navigation property to the product")]
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;

        [Comment("The category id")]
        [Required]
        public int CategoryId { get; set; }

        [Comment("Navigation property to the category")]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

    }
}
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Infrastructure.DataConstants.Category;

namespace LilsCareApp.Infrastructure.Data.Models
{
    [Comment("The category of the product")]
    public class Category
    {
        [Comment("The category's primary key")]
        [Key]
        public int Id { get; set; }

        [Comment("The category's name")]
        [Required]
        [MaxLength(NameMaxLength)]
        public required string Name { get; set; }

        [Comment("Navigation property to the products in this category")]
        public List<ProductCategory> ProductsCategories { get; set; } = new List<ProductCategory>();
    }
}
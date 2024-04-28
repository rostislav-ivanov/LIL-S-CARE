using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LilsCareApp.Infrastructure.Data.Models
{
    [Comment("The category of the product")]
    public class Category
    {
        [Comment("The category's primary key")]
        [Key]
        public int Id { get; set; }

        [Comment("The category's name Id")]
        public int NameId { get; set; }

        [ForeignKey(nameof(NameId))]
        public CategoryName Name { get; set; } = null!;

        [Comment("Navigation property to the products in this category")]
        public List<ProductCategory> ProductsCategories { get; set; } = new List<ProductCategory>();
    }
}
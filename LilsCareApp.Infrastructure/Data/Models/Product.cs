using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LilsCareApp.Infrastructure.DataConstants.Product;

namespace LilsCareApp.Infrastructure.Data.Models
{
    [Comment("The product model")]
    public class Product
    {
        [Comment("The product's primary key")]
        [Key]
        public int Id { get; set; }

        [Comment("The product's name")]
        [MaxLength(NameMaxLength)]
        public required string Name { get; set; }

        [Comment("The product's price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Comment("The product's quantity")]
        public int Quantity { get; set; }

        [Comment("The optional property of product")]
        [MaxLength(OptionalMaxLength)]
        public required string Optional { get; set; }

        [Comment("Sections keeping descriptions of product")]
        public IEnumerable<Section> Sections { get; set; } = [];

        [Comment("Is the product show on online store")]
        public bool IsShow { get; set; }

        [Comment("Navigation Property to product's images")]
        public List<ImageProduct>? Images { get; set; }

        [Comment("Navigation property to the product's Reviews")]
        public List<Review>? Reviews { get; set; }

        [Comment("Navigation property to the product's Categories")]
        public List<ProductCategory> ProductsCategories { get; set; } = new List<ProductCategory>();

        [Comment("Navigation property to the Wishes Products")]
        public List<WishUser> WishesUsers { get; set; } = new List<WishUser>();

        [Comment("Navigation property to the Sopping Bags Products")]
        public List<BagUser> BagsUsers { get; set; } = new List<BagUser>();

        [Comment("Navigation Property to Orders")]
        public List<ProductOrder> ProductsOrders { get; set; } = new List<ProductOrder>();
    }
}




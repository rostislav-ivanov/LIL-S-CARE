using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LilsCareApp.Infrastructure.Data.Models
{
    [Comment("The product model")]
    public class Product
    {
        [Comment("The product's primary key")]
        [Key]
        public int Id { get; set; }

        [Comment("The product's name Id")]
        public int NameId { get; set; }

        [ForeignKey(nameof(NameId))]
        public ProductName Name { get; set; } = null!;

        [Comment("The product's price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Comment("The product's quantity")]
        public int Quantity { get; set; }

        [Comment("The product's optional Id")]
        public int OptionalId { get; set; }

        [ForeignKey(nameof(OptionalId))]
        public ProductOptional Optional { get; set; } = null!;

        [Comment("Sections keeping descriptions of product")]
        public List<Section> Sections { get; set; } = [];

        [Comment("Is the product show on online store")]
        public bool IsShow { get; set; }

        [Comment("Navigation Property to product's images")]
        public List<ImageProduct>? Images { get; set; }

        [Comment("Navigation property to the product's Reviews")]
        public List<Review>? Reviews { get; set; }

        [Comment("Navigation property to the product's Categories")]
        public List<ProductCategory> ProductsCategories { get; set; } = [];

        [Comment("Navigation property to the Wishes Products")]
        public List<WishUser> WishesUsers { get; set; } = [];

        [Comment("Navigation property to the Sopping Bags Products")]
        public List<BagUser> BagsUsers { get; set; } = [];

        [Comment("Navigation Property to Orders")]
        public List<ProductOrder> ProductsOrders { get; set; } = [];
    }
}




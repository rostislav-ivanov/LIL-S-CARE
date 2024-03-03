using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace LilsCareApp.Infrastructure.Data.Models
{
    [Comment("Many to many relation between products and orders")]
    [PrimaryKey("ProductId", "OrderId")]
    public class ProductOrder
    {
        public int ProductId { get; set; }
        [Comment("Navigation property to the product")]
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;

        public int OrderId { get; set; }
        [Comment("Navigation property to the order")]
        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;
    }
}
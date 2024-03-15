using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LilsCareApp.Infrastructure.DataConstants.Speditor;

namespace LilsCareApp.Infrastructure.Data.Models
{
    [Comment("Shipping providers")]
    public class ShippingProvider
    {
        [Comment("Unique identifier of shipping provider")]
        [Key]
        public int Id { get; set; }

        [Comment("Name of shipping provider")]
        [Required]
        [MaxLength(NameMaxLength)]
        public required string Name { get; set; }

        [Comment("Navigation property to orders")]
        public List<Order> Orders { get; set; } = new List<Order>();

        [Comment("Price of shipping")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Comment("Description duration of shipping")]
        public string? Description { get; set; }

        [Comment("Is delivery to address")]
        public bool IsDeliveryToAddress { get; set; }
    }
}

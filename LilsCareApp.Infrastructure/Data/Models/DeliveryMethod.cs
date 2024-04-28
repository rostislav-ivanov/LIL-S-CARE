using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LilsCareApp.Infrastructure.Data.Models
{
    public class DeliveryMethod
    {
        [Comment("Delivery method id")]
        [Key]
        public int Id { get; set; }

        [Comment("Delivery method name Id")]
        public int NameId { get; set; }

        [Comment("Navigation Property to DeliveryName")]
        [ForeignKey(nameof(NameId))]
        public DeliveryName Name { get; set; } = null!;

        [Comment("Navigation property to orders")]
        public List<Order> Orders { get; set; } = [];
    }
}
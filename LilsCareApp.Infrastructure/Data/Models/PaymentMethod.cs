using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LilsCareApp.Infrastructure.Data.Models
{
    [Comment("Payment methods")]
    public class PaymentMethod
    {
        [Comment("Payment method id")]
        [Key]
        public int Id { get; set; }

        [Comment("Payment method type Id")]
        public int TypeId { get; set; }

        [ForeignKey(nameof(TypeId))]
        public PaymentType Type { get; set; } = null!;

        [Comment("Navigation property to orders")]
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}

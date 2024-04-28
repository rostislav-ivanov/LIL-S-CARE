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

        [Comment("Payment method name Id")]
        public int NameId { get; set; }

        [Comment("Navigation Property to PaymentName")]
        [ForeignKey(nameof(NameId))]
        public PaymentName Name { get; set; } = null!;

        [Comment("Navigation property to orders")]
        public List<Order> Orders { get; set; } = [];
    }
}

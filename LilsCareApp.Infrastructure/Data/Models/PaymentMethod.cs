using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Infrastructure.DataConstants.PaymentMethod;

namespace LilsCareApp.Infrastructure.Data.Models
{
    [Comment("Payment methods")]
    public class PaymentMethod
    {
        [Comment("Payment method id")]
        [Key]
        public int Id { get; set; }

        [Comment("Payment method type")]
        [Required]
        [MinLength(NameMinLength)]
        public required string Type { get; set; }

        [Comment("Navigation property to orders")]
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}

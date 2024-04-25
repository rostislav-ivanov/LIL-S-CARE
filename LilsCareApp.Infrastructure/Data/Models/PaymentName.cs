using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Infrastructure.DataConstants.PaymentMethod;

namespace LilsCareApp.Infrastructure.Data.Models
{
    public class PaymentName
    {
        [Comment("Payment name id")]
        [Key]
        public int Id { get; set; }

        [Comment("The payment name in English")]
        [MaxLength(NameMaxLength)]
        public required string NameEN { get; set; }

        [Comment("The payment name in Bulgarian")]
        [MaxLength(NameMaxLength)]
        public required string NameBG { get; set; }

        [Comment("The payment name in Romanian")]
        [MaxLength(NameMaxLength)]
        public required string NameRO { get; set; }

        [Comment("Navigation Property to PaymentMethods")]
        public IEnumerable<PaymentMethod> PaymentMethods { get; set; } = [];
    }
}
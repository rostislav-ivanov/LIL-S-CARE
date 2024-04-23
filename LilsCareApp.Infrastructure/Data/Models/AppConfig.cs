using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LilsCareApp.Infrastructure.Data.Models
{
    public class AppConfig
    {
        [Key]
        public int Id { get; set; }

        [Comment("The price at which the shipping is free.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal FreeShipping { get; set; }

        [Comment("The price at which the delivery to an address is paid.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal AddressDeliveryPrice { get; set; }

        [Comment("The exchange rate of the euro.")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal ExchangeRateEUR { get; set; }

        [Comment("The exchange rate of the leva.")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal ExchangeRateBGN { get; set; }

        [Comment("The exchange rate of the lei.")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal ExchangeRateRON { get; set; }
    }
}

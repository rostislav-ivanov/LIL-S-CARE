using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace LilsCareApp.Infrastructure.Data.Models
{
    public class ShippingOffice
    {

        public int Id { get; set; }

        public required string City { get; set; }


        public required string OfficeAddress { get; set; }

        [Comment("Price of shipping")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }


        [Comment("Duration of shipping")]
        public int ShippingDuration { get; set; }


        [Comment("Shipping Provider Id")]
        public int ShippingProviderId { get; set; }

        [Comment("Navigation Property to ShippingProvider")]
        [ForeignKey(nameof(ShippingProviderId))]
        public ShippingProvider ShippingProvider { get; set; } = null!;

        [Comment("Navigation Property to AddressDelivery")]
        public IEnumerable<AddressDelivery> DeliveryAddresses { get; set; } = [];

        [Comment("Navigation Property to Order")]
        public IEnumerable<Order> Orders { get; set; } = [];
    }
}
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LilsCareApp.Infrastructure.DataConstants.Order;

namespace LilsCareApp.Infrastructure.Data.Models
{
    [Comment("Order")]
    public class Order
    {
        [Comment("Order Id")]
        [Key]
        public int Id { get; set; }

        [Comment("Order Number")]
        public string? OrderNumber { get; set; }

        [Comment("Date of Order Creating")]
        public DateTime CreatedOn { get; set; }

        [Comment("Status of Order")]
        public int StatusOrderId { get; set; }

        [Comment("Navigation Property to StatusOrder")]
        [ForeignKey(nameof(StatusOrderId))]
        public StatusOrder StatusOrder { get; set; } = null!;

        [Comment("Address Delivery Id")]
        public int AddressDeliveryId { get; set; }

        [Comment("Navigation Property to AddressDelivery")]
        [ForeignKey(nameof(AddressDeliveryId))]
        public AddressDelivery AddressDelivery { get; set; } = null!;

        [Comment("App User Id")]
        public string? AppUserId { get; set; }

        [Comment("Navigation Property to AppUser")]
        [ForeignKey(nameof(AppUserId))]
        public AppUser? AppUser { get; set; }

        [Comment("Date of Shipping Creating")]
        public DateTime? DateShipping { get; set; }

        [Comment("Tracking Number of Order")]
        [MaxLength(TrackingNumberMaxLength)]
        public string? TrackingNumber { get; set; }

        [Comment("Payment Method Id")]
        public int? PaymentMethodId { get; set; }

        [Comment("Navigation Property to PaymentMethod")]
        [ForeignKey(nameof(PaymentMethodId))]
        public PaymentMethod PaymentMethod { get; set; } = null!;

        [Comment("Navigation Property to Products")]
        public List<ProductOrder> ProductsOrders { get; set; } = new List<ProductOrder>();

        [Comment("Note for Delivery")]
        public string? NoteForDelivery { get; set; }

        [Comment("Shipping Price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ShippingPrice { get; set; }

        [Comment("Sub Total")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SubTotal { get; set; }

        [Comment("Absolute Discount value")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Discount { get; set; }

        [Comment("Total")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        [Comment("Promo Code Id")]
        public int? PromoCodeId { get; set; }

        [Comment("Navigation Property to PromoCode")]
        [ForeignKey(nameof(PromoCodeId))]
        public PromoCode? PromoCode { get; set; }

    }

}


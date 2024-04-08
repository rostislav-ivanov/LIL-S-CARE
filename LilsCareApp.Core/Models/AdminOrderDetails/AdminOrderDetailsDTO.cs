using LilsCareApp.Core.Models.Account;
using LilsCareApp.Core.Models.AdminOrders;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Core.ErrorMessageConstants;
using static LilsCareApp.Infrastructure.DataConstants.Order;

namespace LilsCareApp.Core.Models.AdminOrderDetails
{
    public class AdminOrderDetailsDTO
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; }

        public StatusOrderDTO StatusOrder { get; set; } = null!;

        public DeliveryAddressDTO AddressDelivery { get; set; } = null!;

        public string? AppUserId { get; set; } = null!;

        public DateTime? DateShipping { get; set; }


        [MaxLength(TrackingNumberMaxLength, ErrorMessage = StringLengthMax)]
        [RegularExpression(TrackingNumberPattern, ErrorMessage = InvalidField)]
        [Display(Name = "тракинг номер")]
        public string TrackingNumber { get; set; } = string.Empty;

        public string PaymentMethod { get; set; } = string.Empty;

        public bool IsPaid { get; set; }

        public List<ProductsOrdersDTO> ProductsOrders { get; set; } = [];

        public decimal ShippingPrice { get; set; }

        public decimal Discount { get; set; }

        public decimal SubTotal() => ProductsOrders.Sum(p => p.Quantity * p.Price) - Discount;

        public decimal Total() => SubTotal() + ShippingPrice;


    }
}

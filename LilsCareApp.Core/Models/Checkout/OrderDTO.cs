namespace LilsCareApp.Core.Models.Checkout
{
    public class OrderDTO
    {
        public string AppUserId { get; set; } = string.Empty;

        public IEnumerable<ProductsInBagDTO> ProductsInBag { get; set; } = [];

        public int PaymentMethodId { get; set; } = 1;

        public IEnumerable<PaymentMethodDTO> PaymentMethods { get; set; } = [];

        public int DeliveryMethodId { get; set; }

        public IEnumerable<DeliveryMethodDTO> DeliveryMethods { get; set; } = [];

        public int PromoCodeId { get; set; }

        public IEnumerable<PromoCodeDTO> PromoCodes { get; set; } = [];

        public string? NoteForDelivery { get; set; }

        public bool IsSelectedAddress { get; set; }

        public string Language { get; set; } = string.Empty;

        public decimal ExchangeRate { get; set; }

        public decimal Discount { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Total { get; set; }

        public decimal ShippingPrice { get; set; }

        public AddressOrderDTO Address { get; set; } = null!;


    }
}

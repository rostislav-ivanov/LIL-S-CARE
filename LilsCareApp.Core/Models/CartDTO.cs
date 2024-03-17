namespace LilsCareApp.Core.Models
{
    public class CartDTO
    {
        public IEnumerable<ProductInCartDTO> Products { get; set; } = new List<ProductInCartDTO>();

        public PromoCodeDTO? PromoCodeDTO { get; set; }

        public DiscountDTO? Discount { get; set; }

        public IEnumerable<OfficeDeliveryDTO> ShippingProviders { get; set; } = new List<OfficeDeliveryDTO>();

        public int ShippingProviderId { get; set; }

        public string? NoteFormUser { get; set; }

        public decimal SubTotal { get; set; }

        public decimal ShippingPrice { get; set; }

        public decimal Total { get; set; }
    }
}

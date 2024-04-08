namespace LilsCareApp.Core.Models.Account
{
    public class MyOrderDTO
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }

        public string OrderNumber { get; set; } = string.Empty;

        public string StatusOrder { get; set; } = string.Empty;

        public decimal Total { get; set; }

        public IEnumerable<MyProductOrderDTO> Products { get; set; } = [];

        public DateTime? DateShipping { get; set; }

        public string? TrackingNumber { get; set; }

        public decimal ShippingPrice { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Discount { get; set; }

    }
}

namespace LilsCareApp.Core.Models
{
    public class ShippingProviderDTO
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public decimal Price { get; set; }

        public string? Description { get; set; }

        public bool IsDeliveryToAddress { get; set; }
    }
}
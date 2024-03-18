namespace LilsCareApp.Core.Models.Checkout
{
    public class ShippingProviderDTO
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}
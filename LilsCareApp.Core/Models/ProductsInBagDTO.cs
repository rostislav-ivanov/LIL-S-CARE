namespace LilsCareApp.Core.Models
{
    public class ProductsInBagDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public KeyValuePair<string, string>? Optional { get; set; }

        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }

        public int Quantity { get; set; }
    }
}

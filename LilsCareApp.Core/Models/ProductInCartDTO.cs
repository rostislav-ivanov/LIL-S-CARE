
namespace LilsCareApp.Core.Models
{
    public class ProductInCartDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public string? Weight { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public required string ImageUrl { get; set; } = "https://via.placeholder.com/150";

        public int Quantity { get; set; }

        public decimal Sum => Price * Quantity;
    }
}

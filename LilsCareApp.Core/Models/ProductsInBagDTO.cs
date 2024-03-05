namespace LilsCareApp.Core.Models
{
    public class ProductsInBagDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public required string ImageUrl { get; set; } = "https://via.placeholder.com/150";

        public int Quantity { get; set; }
    }
}

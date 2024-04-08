namespace LilsCareApp.Core.Models.Products
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public List<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();

        public required string ImageUrl { get; set; } = "https://via.placeholder.com/150";

        public bool IsWish { get; set; } = false;

        public bool IsShow { get; set; } = true;
    }
}

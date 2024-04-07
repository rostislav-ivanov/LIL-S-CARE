namespace LilsCareApp.Core.Models.AdminProducts
{
    public class AdminProductDTO
    {
        public int Id { get; set; }

        public string ImagePath { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public bool IsShow { get; set; }
    }
}
namespace LilsCareApp.Core.Models
{
    public class DetailsDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int AvailableQuantity { get; set; }

        public string? Weight { get; set; }

        public string? Purpose { get; set; }

        public string? Description { get; set; }

        public string? IngredientINCIs { get; set; }

        public string? Ingredients { get; set; }

        public List<ImageDTO>? Images { get; set; }

        public List<ReviewDTO>? Reviews { get; set; }

        public List<CategoryDTO> ProductsCategories { get; set; } = new List<CategoryDTO>();

        public bool IsWish { get; set; }

    }
}

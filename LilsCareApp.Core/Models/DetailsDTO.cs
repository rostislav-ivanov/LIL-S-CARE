namespace LilsCareApp.Core.Models
{
    public class DetailsDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int AvailableQuantity { get; set; }

        public string Weight { get; set; } = string.Empty;

        public string Purpose { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string IngredientINCIs { get; set; } = string.Empty;

        public string Ingredients { get; set; } = string.Empty;

        public List<ImageDTO> Images { get; set; } = new List<ImageDTO>();

        public List<GetReviewDTO> Reviews { get; set; } = new List<GetReviewDTO>();

        public List<CategoryDTO> ProductsCategories { get; set; } = new List<CategoryDTO>();

        public bool IsWish { get; set; }

        public AddReviewDTO? AddReview { get; set; }

    }
}

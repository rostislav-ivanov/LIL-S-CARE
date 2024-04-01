namespace LilsCareApp.Core.Models
{
    public class DetailsDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int AvailableQuantity { get; set; }

        public string? Optional { get; set; }

        public IEnumerable<string>? Description { get; set; }

        public IEnumerable<string>? Ingredients { get; set; }

        public IEnumerable<string>? Purpose { get; set; }

        public IEnumerable<string>? ShippingCondition { get; set; }

        public IEnumerable<string>? IngredientINCIs { get; set; }


        public List<ImageDTO> Images { get; set; } = new List<ImageDTO>();

        public List<GetReviewDTO> Reviews { get; set; } = new List<GetReviewDTO>();

        public double Rating { get; set; }

        public List<CategoryDTO> ProductsCategories { get; set; } = new List<CategoryDTO>();

        public bool IsWish { get; set; }

        public AddReviewDTO? AddReview { get; set; }

    }
}

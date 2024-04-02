namespace LilsCareApp.Core.Models
{
    public class DetailsDTO
    {
        private const string separator = "\r\n";
        public int Id { get; set; }
        public required string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int AvailableQuantity { get; set; }

        public string? Optional { get; set; }

        public string Description { get; set; } = string.Empty;

        public string Ingredients { get; set; } = string.Empty;

        public string Purpose { get; set; } = string.Empty;

        public string ShippingCondition { get; set; } = string.Empty;

        public string IngredientINCIs { get; set; } = string.Empty;

        public List<ImageDTO> Images { get; set; } = new List<ImageDTO>();

        public List<GetReviewDTO> Reviews { get; set; } = new List<GetReviewDTO>();

        public double Rating { get; set; }

        public List<CategoryDTO> ProductsCategories { get; set; } = new List<CategoryDTO>();

        public bool IsWish { get; set; }

        public AddReviewDTO? AddReview { get; set; }

        public IEnumerable<string> GetDescription() => Description.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);
        public IEnumerable<string> GetIngredients() => Ingredients.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);
        public IEnumerable<string> GetPurpose() => Purpose.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);
        public IEnumerable<string> GetShippingCondition() => ShippingCondition.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);
        public IEnumerable<string> GetIngredientINCIs() => IngredientINCIs.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);


    }
}

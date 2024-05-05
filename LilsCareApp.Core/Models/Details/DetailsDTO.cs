using LilsCareApp.Core.Models.Products;

namespace LilsCareApp.Core.Models.Details
{
    public class DetailsDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int AvailableQuantity { get; set; }

        public string Optional { get; set; } = string.Empty;

        public List<SectionDTO> Sections { get; set; } = [];

        public List<ImageDTO> Images { get; set; } = [];

        public List<GetReviewDTO> Reviews { get; set; } = [];

        public double Rating { get; set; }

        public List<CategoryDTO> ProductsCategories { get; set; } = [];

        public bool IsWish { get; set; }

        public AddReviewDTO? AddReview { get; set; }

    }
}

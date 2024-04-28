namespace LilsCareApp.Core.Models.Products
{
    public class ProductsDTO
    {
        public IEnumerable<ProductDTO> Products { get; set; } = [];

        public IList<CategoryDTO> Categories { get; set; } = [];

        public int TotalProductsCount { get; set; }

        public int ProductsPerPage { get; set; }

        public int CurrentPage { get; set; }

        public int? CategoryId { get; set; }

    }
}

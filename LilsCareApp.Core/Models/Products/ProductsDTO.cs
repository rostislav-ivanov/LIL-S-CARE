namespace LilsCareApp.Core.Models.Products
{
    public class ProductsDTO
    {
        public IEnumerable<ProductDTO> Products { get; set; } = [];

        public IList<CategoryDTO> Categories { get; set; } = [];
    }
}

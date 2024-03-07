namespace LilsCareApp.Core.Models
{
    public class ProductsDTO
    {
        public IEnumerable<ProductDTO> Products { get; set; } = new List<ProductDTO>();

        public IList<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();
    }
}

using LilsCareApp.Core.Models;

namespace LilsCareApp.Areas.Admin.Models
{
    public class AdminDetailsDTO
    {
        public DetailsDTO Product { get; set; } = null!;

        public IEnumerable<CategoryDTO> Categories { get; set; } = null!;

        public IEnumerable<int> GetProductCategoriesId() => Product.ProductsCategories.Select(x => x.Id);
    }
}

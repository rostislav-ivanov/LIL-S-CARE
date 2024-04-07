namespace LilsCareApp.Core.Models.AdminProducts
{
    public class AdminProductsDTO
    {
        public IEnumerable<AdminProductDTO> Products { get; set; } = [];

        public int TotalProductsCount { get; set; }

        public int ProductsPerPage { get; set; }

        public int CurrentPage { get; set; }

        public ProductSortType ProductSortType { get; set; }

        public string? Search { get; set; }
    }
}

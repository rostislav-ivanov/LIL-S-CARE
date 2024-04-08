using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.AdminProducts;
using Microsoft.AspNetCore.Mvc;
using static LilsCareApp.Infrastructure.DataConstants.Product;

namespace LilsCareApp.Areas.Admin.Controllers
{
    public class ProductsController : AdminController
    {
        private readonly IAdminProductService _service;

        public ProductsController(IAdminProductService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(
            ProductSortType productSortType,
            string? search,
            int currentPage = 1,
            int productsPerPage = ProductsPerPages)
        {
            AdminProductsDTO products = await _service.GetProductsQueryAsync(productSortType, search, currentPage, productsPerPage);

            return View(products);
        }


        public async Task<IActionResult> ProductToShop(int id)
        {
            await _service.ProductToShopAsync(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            bool isOrdered = await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

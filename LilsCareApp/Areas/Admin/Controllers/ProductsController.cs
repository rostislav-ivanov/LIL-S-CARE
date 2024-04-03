using LilsCareApp.Areas.Admin.Models;
using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace LilsCareApp.Areas.Admin.Controllers
{
    public class ProductsController : AdminController
    {
        private readonly IAdminProductService _service;

        public ProductsController(IAdminProductService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductDTO> products = await _service.GetAllProductsAsync();

            return View(products);
        }

        public async Task<IActionResult> OrderBy(int orderBy)
        {

            SortType sort = (SortType)orderBy;

            IEnumerable<ProductDTO> products = [];
            switch (sort)
            {
                case SortType.NameAsc:
                    products = await _service.GetProductsOrderByNameAscAsync();
                    break;
                case SortType.NameDesc:
                    products = await _service.GetProductsOrderByNameDescAsync();
                    break;
                case SortType.IdAsc:
                    products = await _service.GetProductsOrderByIdAscAsync();
                    break;
                case SortType.IdDesc:
                    products = await _service.GetProductsOrderByIdDescAsync();
                    break;
                case SortType.PriceAsc:
                    products = await _service.GetProductsOrderByPriceAscAsync();
                    break;
                case SortType.PriceDesc:
                    products = await _service.GetProductsOrderByPriceDescAsync();
                    break;
                case SortType.QuantityAsc:
                    products = await _service.GetProductsOrderByQuantityAscAsync();
                    break;
                case SortType.QuantityDesc:
                    products = await _service.GetProductsOrderByQuantityDescAsync();
                    break;
                case SortType.IsShowAsc:
                    products = await _service.GetProductsOrderByIsShowAscAsync();
                    break;
                case SortType.IsShowDesc:
                    products = await _service.GetProductsOrderByIsShowDescAsync();
                    break;
                default:
                    products = await _service.GetAllProductsAsync();
                    break;
            }

            return View(nameof(Index), products);
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

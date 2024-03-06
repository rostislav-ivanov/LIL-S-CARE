using LilsCareApp.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LilsCareApp.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly ILilsCareService _service;

        public ProductsController(ILilsCareService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            return View(id);
        }


    }
}

using Microsoft.AspNetCore.Mvc;

namespace LilsCareApp.Controllers
{
    public class ProductsController : BaseController
    {
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

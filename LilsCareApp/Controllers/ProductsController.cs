using Microsoft.AspNetCore.Mvc;

namespace LilsCareApp.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

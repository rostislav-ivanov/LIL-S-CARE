using Microsoft.AspNetCore.Mvc;

namespace LilsCareApp.Controllers
{
    public class CartController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

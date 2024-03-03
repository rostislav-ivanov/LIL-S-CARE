using Microsoft.AspNetCore.Mvc;

namespace LilsCareApp.Controllers
{
    public class IngredientsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

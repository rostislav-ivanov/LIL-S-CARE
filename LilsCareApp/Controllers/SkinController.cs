using Microsoft.AspNetCore.Mvc;

namespace LilsCareApp.Controllers
{
    public class SkinController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

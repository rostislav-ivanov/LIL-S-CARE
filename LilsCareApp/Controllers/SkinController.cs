using Microsoft.AspNetCore.Mvc;

namespace LilsCareApp.Controllers
{
    public class SkinController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

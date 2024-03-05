using Microsoft.AspNetCore.Mvc;

namespace LilsCareApp.Controllers
{
    public class IngredientsController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

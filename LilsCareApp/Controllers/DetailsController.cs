using Microsoft.AspNetCore.Mvc;

namespace LilsCareApp.Controllers
{
    public class DetailsController : BaseController
    {
        public IActionResult Index(int id)
        {
            return View(id);
        }
    }
}

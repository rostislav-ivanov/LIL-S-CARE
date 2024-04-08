using Microsoft.AspNetCore.Mvc;

namespace LilsCareApp.Controllers
{
    public class TermsConditionsController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

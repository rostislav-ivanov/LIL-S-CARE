using LilsCareApp.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LilsCareApp.Controllers
{
    public class CheckoutController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductsService _service;

        public CheckoutController(ILogger<HomeController> logger, IProductsService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var model = 0;
            return View(model);
        }
    }
}

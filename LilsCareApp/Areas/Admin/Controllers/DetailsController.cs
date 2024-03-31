using LilsCareApp.Areas.Admin.Models;
using LilsCareApp.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LilsCareApp.Areas.Admin.Controllers
{
    public class DetailsController : AdminController
    {
        private readonly IAdminDetailsService _adminDetailsService;

        public DetailsController(IAdminDetailsService adminDetailsService)
        {
            _adminDetailsService = adminDetailsService;
        }
        public async Task<IActionResult> Index(int id)
        {
            AdminDetailsDTO model = new AdminDetailsDTO()
            {
                Product = await _adminDetailsService.GetProductByIdAsync(id),
                Categories = await _adminDetailsService.GetCategoriesAsync()
            };

            return View(model);
        }
    }
}

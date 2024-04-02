using LilsCareApp.Areas.Admin.Models;
using LilsCareApp.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LilsCareApp.Areas.Admin.Controllers
{
    public class DetailsController : AdminController
    {
        private readonly IAdminDetailsService _adminDetailsService;
        private readonly IFileService _fileService;

        public DetailsController(IAdminDetailsService adminDetailsService, IFileService fileService)
        {
            _adminDetailsService = adminDetailsService;
            _fileService = fileService;
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

        public async Task<IActionResult> MoveImageLeft(int id, int image)
        {
            if (id != 0 && image != 0)
            {
                await _adminDetailsService.MoveImageLeftAsync(id, image);
            }

            return RedirectToAction(nameof(Index), new { id });
        }

        public async Task<IActionResult> MoveImageRight(int id, int image)
        {
            if (id != 0 && image != 0)
            {
                await _adminDetailsService.MoveImageRightAsync(id, image);
            }

            return RedirectToAction(nameof(Index), new { id });
        }

        public async Task<IActionResult> RemoveImage(int id, int imageId)
        {
            if (id != 0 && imageId != 0)
            {
                string? imagePath = await _adminDetailsService.RemoveImageAsync(id, imageId);
                if (imagePath != null)
                {
                    _fileService.DeleteFile(imagePath);
                }
            }

            return RedirectToAction(nameof(Index), new { id });
        }

        [HttpPost]
        public async Task<IActionResult> AddProductImage(int id)
        {
            var files = Request.Form.Files.FirstOrDefault();
            if (files?.Length > 0)
            {
                string? filePath = await _fileService.SaveFile(files);

                if (filePath != null)
                {
                    // Save the file path to the database
                    await _adminDetailsService.AddProductImageAsync(id, filePath);
                }
            }

            return RedirectToAction(nameof(Index), new { id });
        }

        [HttpPost]
        public async Task<IActionResult> Description(int id, string description)
        {


            return RedirectToAction(nameof(Index), new { id });
        }
    }
}

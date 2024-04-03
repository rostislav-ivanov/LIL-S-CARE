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
            if (id == 0)
            {
                return BadRequest();
            }

            AdminDetailsDTO model = new AdminDetailsDTO()
            {
                Product = await _adminDetailsService.GetProductByIdAsync(id),
                Categories = await _adminDetailsService.GetCategoriesAsync()
            };

            return View(model);
        }

        public async Task<IActionResult> Add(int id)
        {
            AdminDetailsDTO model = new AdminDetailsDTO()
            {
                Categories = await _adminDetailsService.GetCategoriesAsync()
            };

            if (id != 0)
            {
                model.Product = await _adminDetailsService.CreateProductByTemplateAsync(id);
            }
            else
            {
                model.Product = await _adminDetailsService.CreateProductAsync();
            }

            return View(nameof(Index), model);
        }

        [HttpPost]
        public async Task<IActionResult> EditName(int id, string name)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                AdminDetailsDTO model = new()
                {
                    Product = await _adminDetailsService.GetProductByIdAsync(id),
                    Categories = await _adminDetailsService.GetCategoriesAsync()
                };

                model.Product.Name = name;

                return View(nameof(Index), model);
            }

            await _adminDetailsService.EditNameAsync(id, name);

            return RedirectToAction(nameof(Index), new { id });
        }


        public async Task<IActionResult> MoveImageLeft(int id, int image)
        {
            if (id == 0 && image == 0)
            {
                return BadRequest();
            }
            await _adminDetailsService.MoveImageLeftAsync(id, image);

            return RedirectToAction(nameof(Index), new { id });
        }

        public async Task<IActionResult> MoveImageRight(int id, int image)
        {
            if (id == 0 && image == 0)
            {
                return BadRequest();
            }
            await _adminDetailsService.MoveImageRightAsync(id, image);

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


        public async Task<IActionResult> AddSection(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            await _adminDetailsService.AddSectionAsync(id);

            return RedirectToAction(nameof(Index), new { id });
        }


        [HttpPost]
        public async Task<IActionResult> EditSection(int id, int sectionId, string title, string description)
        {
            if (id == 0 || sectionId == 0)
            {
                return BadRequest();
            }

            await _adminDetailsService.EditSectionAsync(sectionId, title, description);

            return RedirectToAction(nameof(Index), new { id });
        }

        public async Task<IActionResult> DeleteSection(int id, int sectionId)
        {
            if (id == 0 || sectionId == 0)
            {
                return BadRequest();
            }

            await _adminDetailsService.DeleteSectionAsync(id, sectionId);

            return RedirectToAction(nameof(Index), new { id });
        }

        public async Task<IActionResult> MoveSectionUp(int id, int sectionOrder)
        {
            if (id == 0 || sectionOrder == 0)
            {
                return BadRequest();
            }

            await _adminDetailsService.MoveSectionUpAsync(id, sectionOrder);

            return RedirectToAction(nameof(Index), new { id });
        }

        public async Task<IActionResult> MoveSectionDown(int id, int sectionOrder)
        {
            if (id == 0 || sectionOrder == 0)
            {
                return BadRequest();
            }

            await _adminDetailsService.MoveSectionDownAsync(id, sectionOrder);

            return RedirectToAction(nameof(Index), new { id });
        }

        public async Task<IActionResult> AddRemoveCategory(int id, int categoryId)
        {
            if (id == 0 || categoryId == 0)
            {
                return BadRequest();
            }

            await _adminDetailsService.AddRemoveCategoryAsync(id, categoryId);

            return RedirectToAction(nameof(Index), new { id });
        }
    }
}

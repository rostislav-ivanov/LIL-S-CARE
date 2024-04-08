using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.AdminProducts;
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

        // GET: Admin/Details by product id 
        public async Task<IActionResult> Index(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            AdminDetailsDTO model = await _adminDetailsService.GetProductByIdAsync(id);
            model.Categories = await _adminDetailsService.GetCategoriesAsync();

            return View(model);
        }

        // GET: Admin/Details/Add by product id.
        // If Id is 0, create a new product.
        // Else create a product by template of the given product's Id.
        public async Task<IActionResult> Add(int id)
        {
            AdminDetailsDTO model = new();

            if (id != 0)
            {
                model = await _adminDetailsService.CreateProductByTemplateAsync(id);
            }
            else
            {
                model = await _adminDetailsService.CreateProductAsync();
            }
            model.Categories = await _adminDetailsService.GetCategoriesAsync();

            return View(nameof(Index), model);
        }


        // POST: Admin/Details/EditName by product id.
        // Edit the product name.
        [HttpPost]
        public async Task<IActionResult> EditName(int id, string name)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                var model = await _adminDetailsService.GetProductByIdAsync(id);
                model.Categories = await _adminDetailsService.GetCategoriesAsync();
                model.Name = name;

                return View(nameof(Index), model);
            }

            await _adminDetailsService.EditNameAsync(id, name);

            return RedirectToAction(nameof(Index), new { id });
        }


        // POST: Admin/Details/AddProductImage by product id.
        // Add to product new image.
        // If the file is not an image, it will not be added.
        // If the file is an image, it will be saved in the wwwroot/files folder.
        // The file path will be saved in the database.
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

        // POST: Admin/Details/RemoveImage by product id and image id.
        // Remove image from product.
        // If the image is not found, it will not be removed.
        // If the image is found, it will be deleted from the wwwroot/files folder.
        // The file path will be removed from the database.
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

        // POST: Admin/Details/MoveImageLeft by product id and image id.
        // Move image one position to the left.
        public async Task<IActionResult> MoveImageLeft(int id, int image)
        {
            if (id == 0 && image == 0)
            {
                return BadRequest();
            }
            await _adminDetailsService.MoveImageLeftAsync(id, image);

            return RedirectToAction(nameof(Index), new { id });
        }

        // POST: Admin/Details/MoveImageRight by product id and image id.
        // Move image one position to the right.
        public async Task<IActionResult> MoveImageRight(int id, int image)
        {
            if (id == 0 && image == 0)
            {
                return BadRequest();
            }
            await _adminDetailsService.MoveImageRightAsync(id, image);

            return RedirectToAction(nameof(Index), new { id });
        }

        // POST: Admin/Details/AddSection by product id.
        // Add new section with product's description to the product.
        public async Task<IActionResult> AddSection(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            await _adminDetailsService.AddSectionAsync(id);

            return RedirectToAction(nameof(Index), new { id });
        }

        // POST: Admin/Details/EditSection by product id, section id, section title and section description.
        // Edit the section title and description.
        [HttpPost]
        public async Task<IActionResult> EditSection(int id, int sectionId, string sectionTitle, string sectionDescription)
        {
            if (id == 0 || sectionId == 0)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                var model = await _adminDetailsService.GetProductByIdAsync(id);
                model.Categories = await _adminDetailsService.GetCategoriesAsync();
                var section = model.Sections.FirstOrDefault(s => s.Id == sectionId);
                if (section == null)
                {
                    return BadRequest();
                }
                section.Title = sectionTitle;
                section.Description = sectionDescription;

                return View(nameof(Index), model);
            }

            await _adminDetailsService.EditSectionAsync(sectionId, sectionTitle, sectionDescription);

            return RedirectToAction(nameof(Index), new { id });
        }

        // POST: Admin/Details/DeleteSection by product id and section id.
        // Delete the section.
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

        // POST: Admin/Details/MoveSectionDown by product id and section order.
        // Move section one position down.
        public async Task<IActionResult> MoveSectionDown(int id, int sectionOrder)
        {
            if (id == 0 || sectionOrder == 0)
            {
                return BadRequest();
            }

            await _adminDetailsService.MoveSectionDownAsync(id, sectionOrder);

            return RedirectToAction(nameof(Index), new { id });
        }

        // POST: Admin/Details/AddRemoveCategory by product id and category id.
        // Add or remove category to the product.
        public async Task<IActionResult> AddRemoveCategory(int id, int categoryId)
        {
            if (id == 0 || categoryId == 0)
            {
                return BadRequest();
            }

            await _adminDetailsService.AddRemoveCategoryAsync(id, categoryId);

            return RedirectToAction(nameof(Index), new { id });
        }

        // POST: Admin/Details/EditPrice by product id and price.
        // Edit the product price.
        public async Task<IActionResult> EditPrice(int id, decimal price)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                var model = await _adminDetailsService.GetProductByIdAsync(id);
                model.Categories = await _adminDetailsService.GetCategoriesAsync();
                model.Price = price;

                return View(nameof(Index), model);
            }

            await _adminDetailsService.EditPriceAsync(id, price);

            return RedirectToAction(nameof(Index), new { id });
        }

        // POST: Admin/Details/AddQuantity by product id and quantity.
        // Add quantity to the product. 
        // If the quantity is negative, it will be subtracted.
        public async Task<IActionResult> AddQuantity(int id, int quantity)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                var model = await _adminDetailsService.GetProductByIdAsync(id);
                model.Categories = await _adminDetailsService.GetCategoriesAsync();
                model.Quantity = quantity;

                return View(nameof(Index), model);
            }

            await _adminDetailsService.AddQuantityAsync(id, quantity);

            return RedirectToAction(nameof(Index), new { id });
        }

        // POST: Admin/Details/EditOptional by product id and optional.
        // Edit the product optional. 
        // Optional is a string that can be used for additional information about the product.
        public async Task<IActionResult> EditOptional(int id, string optional)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                var model = await _adminDetailsService.GetProductByIdAsync(id);
                model.Categories = await _adminDetailsService.GetCategoriesAsync();
                model.Optional = optional;

                return View(nameof(Index), model);
            }

            await _adminDetailsService.EditOptionalAsync(id, optional);

            return RedirectToAction(nameof(Index), new { id });
        }

        // POST: Admin/Details/AddNewCategory by product id and new category.
        // Add new category to application.
        // If the category already exists, it will not be added.
        public async Task<IActionResult> AddNewCategory(int id, string newCategory)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                var model = await _adminDetailsService.GetProductByIdAsync(id);
                model.Categories = await _adminDetailsService.GetCategoriesAsync();
                model.NewCategory = newCategory;

                return View(nameof(Index), model);
            }

            // Add the new category to the database
            await _adminDetailsService.AddNewCategoryAsync(newCategory);

            return RedirectToAction(nameof(Index), new { id });
        }


        // POST: Admin/Details/DeleteCategory by product id and category id.
        // Delete the category from the product.
        // If the product has only one category, it will not be deleted.
        public async Task<IActionResult> DeleteCategory(int id, int categoryId)
        {
            if (id == 0 || categoryId == 0)
            {
                return BadRequest();
            }

            await _adminDetailsService.DeleteCategoryAsync(id, categoryId);

            return RedirectToAction(nameof(Index), new { id });
        }
    }
}

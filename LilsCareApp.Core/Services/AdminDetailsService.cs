﻿using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models;
using LilsCareApp.Infrastructure.Data;
using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace LilsCareApp.Core.Services
{
    public class AdminDetailsService : IAdminDetailsService
    {

        private readonly ApplicationDbContext _context;
        private const string patternVideo = @"\.mp(4)?$";

        public AdminDetailsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DetailsDTO> GetProductByIdAsync(int id)
        {
            var details = await _context.Products
             .Select(p => new DetailsDTO
             {
                 Id = p.Id,
                 Name = p.Name,
                 Price = p.Price,
                 Quantity = p.Quantity,
                 Optional = p.Optional,
                 Sections = p.Sections
                        .Where(s => s.ProductId == p.Id)
                        .OrderBy(s => s.SectionOrder)
                        .Select(s => new SectionDTO
                        {
                            Id = s.Id,
                            Title = s.Title,
                            Description = s.Description,
                            SectionOrder = s.SectionOrder
                        })
                        .ToList(),
                 Images = p.Images
                     .Where(im => im.ProductId == p.Id)
                     .OrderBy(im => im.ImageOrder)
                     .Select(im => new ImageDTO
                     {
                         Id = im.Id,
                         ImagePath = im.ImagePath,
                         ImageOrder = im.ImageOrder,
                         IsVideo = Regex.IsMatch(im.ImagePath, patternVideo, RegexOptions.IgnoreCase)
                     }).ToList(),
                 ProductsCategories = p.ProductsCategories
                     .Where(pc => pc.ProductId == p.Id)
                     .Select(pc => new CategoryDTO
                     {
                         Id = pc.Category.Id,
                         Name = pc.Category.Name
                     }).ToList()
             })
             .AsNoTracking()
             .FirstOrDefaultAsync(p => p.Id == id);

            return details;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            return await _context.Categories
                .Select(c => new CategoryDTO
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .AsNoTracking()
                .ToArrayAsync();
        }

        public async Task<DetailsDTO> CreateProductAsync()
        {
            Product product = new Product()
            {
                Name = "",
                Optional = "",
            };

            await _context.Products.AddAsync(product);

            await _context.SaveChangesAsync();

            DetailsDTO details = new DetailsDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                Optional = product.Optional,
                Sections = [],
                ProductsCategories = []
            };

            return details;
        }

        public async Task<DetailsDTO> CreateProductByTemplateAsync(int id)
        {
            var product = await _context.Products
                .Where(p => p.Id == id)
                .Select(p => new Product
                {
                    Name = "Нов продукт",
                    Price = p.Price,
                    Optional = p.Optional,
                    IsShow = false,
                    Sections = p.Sections
                        .Select(s => new Section
                        {
                            Title = s.Title,
                            Description = s.Description,
                            SectionOrder = s.SectionOrder
                        })
                        .ToList(),
                    ProductsCategories = p.ProductsCategories
                        .Select(pc => new ProductCategory
                        {
                            CategoryId = pc.CategoryId,
                        })
                        .ToList()
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return await CreateProductAsync();
            }

            await _context.Products.AddAsync(product);

            await _context.SaveChangesAsync();

            return await GetProductByIdAsync(product.Id);
        }

        public async Task EditNameAsync(int id, string name)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return;
            }

            product.Name = name;
            await _context.SaveChangesAsync();
        }

        public async Task MoveImageLeftAsync(int id, int imageOrder)
        {
            var image = await _context.ImageProducts
                .FirstOrDefaultAsync(im => im.ProductId == id && im.ImageOrder == imageOrder);
            if (image == null)
            {
                return;
            }

            var imageLeft = await _context.ImageProducts
                .FirstOrDefaultAsync(im => im.ProductId == id && im.ImageOrder == imageOrder - 1);
            if (imageLeft == null)
            {
                return;
            }

            image.ImageOrder--;
            imageLeft.ImageOrder++;

            await _context.SaveChangesAsync();
        }

        public async Task MoveImageRightAsync(int id, int imageOrder)
        {
            var image = await _context.ImageProducts
                .FirstOrDefaultAsync(im => im.ProductId == id && im.ImageOrder == imageOrder);
            if (image == null)
            {
                return;
            }

            var imageRight = await _context.ImageProducts
                .FirstOrDefaultAsync(im => im.ProductId == id && im.ImageOrder == imageOrder + 1);
            if (imageRight == null)
            {
                return;
            }

            image.ImageOrder++;
            imageRight.ImageOrder--;

            await _context.SaveChangesAsync();
        }

        public async Task<string?> RemoveImageAsync(int id, int imageId)
        {
            var image = await _context.ImageProducts
                .FirstOrDefaultAsync(im => im.ProductId == id && im.Id == imageId);

            if (image == null)
            {
                return null;
            }

            var images = await _context.ImageProducts
                .Where(ip => ip.ProductId == id)
                .OrderBy(ip => ip.ImageOrder)
                .ToListAsync();


            for (int i = 0; i < images.Count; i++)
            {
                if (images[i].ImageOrder > image.ImageOrder)
                {
                    images[i].ImageOrder--;
                }
            }

            _context.ImageProducts.Remove(image);

            await _context.SaveChangesAsync();

            return image.ImagePath;
        }

        public async Task AddProductImageAsync(int id, string filePath)
        {
            if (id == 0 || string.IsNullOrWhiteSpace(filePath))
            {
                return;
            }

            int count = await _context.ImageProducts
                .Where(ip => ip.ProductId == id)
                .CountAsync();

            var image = new ImageProduct
            {
                ProductId = id,
                ImagePath = filePath,
                ImageOrder = count + 1
            };

            await _context.ImageProducts.AddAsync(image);

            await _context.SaveChangesAsync();
        }


        public async Task AddSectionAsync(int id)
        {
            var product = await _context.Products
                .Include(p => p.Sections)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return;
            }

            int count = product.Sections.Count;
            Section section = new Section
            {
                Title = "",
                Description = "",
                SectionOrder = count + 1,
                ProductId = id
            };

            await _context.Sections.AddAsync(section);
            await _context.SaveChangesAsync();
        }


        public async Task EditSectionAsync(int sectionId, string title, string description)
        {
            var section = await _context.Sections
                .FirstOrDefaultAsync(s => s.Id == sectionId);

            if (section == null)
            {
                return;
            }

            section.Title = title;
            section.Description = description;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSectionAsync(int productId, int sectionId)
        {
            var section = await _context.Sections
                .FirstOrDefaultAsync(s => s.Id == sectionId);

            if (section == null)
            {
                return;
            }

            var sections = await _context.Sections
                .Where(s => s.ProductId == productId)
                .OrderBy(ip => ip.SectionOrder)
                .ToListAsync();

            for (int i = 0; i < sections.Count; i++)
            {
                if (sections[i].SectionOrder > section.SectionOrder)
                {
                    sections[i].SectionOrder--;
                }
            }

            _context.Sections.Remove(section);
            await _context.SaveChangesAsync();
        }

        public async Task MoveSectionDownAsync(int id, int sectionOrder)
        {
            var section = await _context.Sections
                .FirstOrDefaultAsync(s => s.ProductId == id && s.SectionOrder == sectionOrder);

            if (section == null)
            {
                return;
            }

            var sectionDown = await _context.Sections
                .FirstOrDefaultAsync(s => s.ProductId == id && s.SectionOrder == sectionOrder + 1);

            if (sectionDown == null)
            {
                return;
            }

            section.SectionOrder++;
            sectionDown.SectionOrder--;

            await _context.SaveChangesAsync();
        }

        public async Task MoveSectionUpAsync(int id, int sectionOrder)
        {
            var section = await _context.Sections
                .FirstOrDefaultAsync(s => s.ProductId == id && s.SectionOrder == sectionOrder);

            if (section == null)
            {
                return;
            }

            var sectionUp = await _context.Sections
                .FirstOrDefaultAsync(s => s.ProductId == id && s.SectionOrder == sectionOrder - 1);

            if (sectionUp == null)
            {
                return;
            }

            section.SectionOrder--;
            sectionUp.SectionOrder++;

            await _context.SaveChangesAsync();
        }

        public async Task AddRemoveCategoryAsync(int id, int categoryId)
        {
            var productCategory = await _context.ProductsCategories
                .FirstOrDefaultAsync(pc => pc.ProductId == id && pc.CategoryId == categoryId);

            if (productCategory == null)
            {
                await _context.ProductsCategories.AddAsync(new ProductCategory
                {
                    ProductId = id,
                    CategoryId = categoryId
                });
            }
            else
            {
                _context.ProductsCategories.Remove(productCategory);
            }

            await _context.SaveChangesAsync();
        }
    }
}

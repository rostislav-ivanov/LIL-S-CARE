using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models;
using LilsCareApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LilsCareApp.Core.Services
{
    public class AdminProductService : IAdminProductService
    {
        private readonly ApplicationDbContext _context;

        public AdminProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        async public Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _context.Products
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.Images.FirstOrDefault().ImagePath ?? "https://via.placeholder.com/150",
                    Quantity = p.Quantity,
                    Categories = p.ProductsCategories.Select(pc => new CategoryDTO
                    {
                        Id = pc.Category.Id,
                        Name = pc.Category.Name
                    }).ToList(),
                    IsShow = p.IsShow
                })
                .AsNoTracking()
                .ToArrayAsync();

            return products;
        }


        public async Task<IEnumerable<ProductDTO>> GetProductsOrderByIdAscAsync()
        {
            var products = await _context.Products
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.Images.FirstOrDefault().ImagePath ?? "https://via.placeholder.com/150",
                    Quantity = p.Quantity,
                    Categories = p.ProductsCategories.Select(pc => new CategoryDTO
                    {
                        Id = pc.Category.Id,
                        Name = pc.Category.Name
                    }).ToList(),
                    IsShow = p.IsShow
                })
                .OrderBy(p => p.Id)
                .AsNoTracking()
                .ToArrayAsync();

            return products;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsOrderByIdDescAsync()
        {
            var products = await _context.Products
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.Images.FirstOrDefault().ImagePath ?? "https://via.placeholder.com/150",
                    Quantity = p.Quantity,
                    Categories = p.ProductsCategories.Select(pc => new CategoryDTO
                    {
                        Id = pc.Category.Id,
                        Name = pc.Category.Name
                    }).ToList(),
                    IsShow = p.IsShow
                })
                .OrderByDescending(p => p.Id)
                .AsNoTracking()
                .ToArrayAsync();

            return products;
        }


        public async Task<IEnumerable<ProductDTO>> GetProductsOrderByNameAscAsync()
        {
            var products = await _context.Products
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.Images.FirstOrDefault().ImagePath ?? "https://via.placeholder.com/150",
                    Quantity = p.Quantity,
                    Categories = p.ProductsCategories.Select(pc => new CategoryDTO
                    {
                        Id = pc.Category.Id,
                        Name = pc.Category.Name
                    }).ToList(),
                    IsShow = p.IsShow
                })
                .OrderBy(p => p.Name)
                .AsNoTracking()
                .ToArrayAsync();

            return products;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsOrderByNameDescAsync()
        {
            var products = await _context.Products
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.Images.FirstOrDefault().ImagePath ?? "https://via.placeholder.com/150",
                    Quantity = p.Quantity,
                    Categories = p.ProductsCategories.Select(pc => new CategoryDTO
                    {
                        Id = pc.Category.Id,
                        Name = pc.Category.Name
                    }).ToList(),
                    IsShow = p.IsShow
                })
                .OrderByDescending(p => p.Name)
                .AsNoTracking()
                .ToArrayAsync();

            return products;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsOrderByPriceAscAsync()
        {
            var products = await _context.Products
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.Images.FirstOrDefault().ImagePath ?? "https://via.placeholder.com/150",
                    Quantity = p.Quantity,
                    Categories = p.ProductsCategories.Select(pc => new CategoryDTO
                    {
                        Id = pc.Category.Id,
                        Name = pc.Category.Name
                    }).ToList(),
                    IsShow = p.IsShow
                })
                .OrderBy(p => p.Price)
                .AsNoTracking()
                .ToArrayAsync();

            return products;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsOrderByPriceDescAsync()
        {
            var products = await _context.Products
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.Images.FirstOrDefault().ImagePath ?? "https://via.placeholder.com/150",
                    Quantity = p.Quantity,
                    Categories = p.ProductsCategories.Select(pc => new CategoryDTO
                    {
                        Id = pc.Category.Id,
                        Name = pc.Category.Name
                    }).ToList(),
                    IsShow = p.IsShow
                })
                .OrderByDescending(p => p.Price)
                .AsNoTracking()
                .ToArrayAsync();

            return products;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsOrderByQuantityAscAsync()
        {
            var products = await _context.Products
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.Images.FirstOrDefault().ImagePath ?? "https://via.placeholder.com/150",
                    Quantity = p.Quantity,
                    Categories = p.ProductsCategories.Select(pc => new CategoryDTO
                    {
                        Id = pc.Category.Id,
                        Name = pc.Category.Name
                    }).ToList(),
                    IsShow = p.IsShow
                })
                .OrderBy(p => p.Quantity)
                .AsNoTracking()
                .ToArrayAsync();

            return products;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsOrderByQuantityDescAsync()
        {
            var products = await _context.Products
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.Images.FirstOrDefault().ImagePath ?? "https://via.placeholder.com/150",
                    Quantity = p.Quantity,
                    Categories = p.ProductsCategories.Select(pc => new CategoryDTO
                    {
                        Id = pc.Category.Id,
                        Name = pc.Category.Name
                    }).ToList(),
                    IsShow = p.IsShow
                })
                .OrderByDescending(p => p.Quantity)
                .AsNoTracking()
                .ToArrayAsync();

            return products;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsOrderByIsShowAscAsync()
        {
            var products = await _context.Products
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.Images.FirstOrDefault().ImagePath ?? "https://via.placeholder.com/150",
                    Quantity = p.Quantity,
                    Categories = p.ProductsCategories.Select(pc => new CategoryDTO
                    {
                        Id = pc.Category.Id,
                        Name = pc.Category.Name
                    }).ToList(),
                    IsShow = p.IsShow
                })
                .OrderBy(p => p.IsShow)
                .AsNoTracking()
                .ToArrayAsync();

            return products;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsOrderByIsShowDescAsync()
        {
            var products = await _context.Products
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.Images.FirstOrDefault().ImagePath ?? "https://via.placeholder.com/150",
                    Quantity = p.Quantity,
                    Categories = p.ProductsCategories.Select(pc => new CategoryDTO
                    {
                        Id = pc.Category.Id,
                        Name = pc.Category.Name
                    }).ToList(),
                    IsShow = p.IsShow
                })
                .OrderByDescending(p => p.IsShow)
                .AsNoTracking()
                .ToArrayAsync();

            return products;
        }
    }
}


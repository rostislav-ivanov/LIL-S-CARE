﻿using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Extensions;
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
                .ProjectToProductDTO()
                .AsNoTracking()
                .ToArrayAsync();

            return products;
        }


        public async Task<IEnumerable<ProductDTO>> GetProductsOrderByIdAscAsync()
        {
            var products = await _context.Products
                .ProjectToProductDTO()
                .OrderBy(p => p.Id)
                .AsNoTracking()
                .ToArrayAsync();

            return products;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsOrderByIdDescAsync()
        {
            var products = await _context.Products
                .ProjectToProductDTO()
                .OrderByDescending(p => p.Id)
                .AsNoTracking()
                .ToArrayAsync();

            return products;
        }


        public async Task<IEnumerable<ProductDTO>> GetProductsOrderByNameAscAsync()
        {
            var products = await _context.Products
                .ProjectToProductDTO()
                .OrderBy(p => p.Name)
                .AsNoTracking()
                .ToArrayAsync();

            return products;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsOrderByNameDescAsync()
        {
            var products = await _context.Products
                .ProjectToProductDTO()
                .OrderByDescending(p => p.Name)
                .AsNoTracking()
                .ToArrayAsync();

            return products;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsOrderByPriceAscAsync()
        {
            var products = await _context.Products
                .ProjectToProductDTO()
                .OrderBy(p => p.Price)
                .AsNoTracking()
                .ToArrayAsync();

            return products;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsOrderByPriceDescAsync()
        {
            var products = await _context.Products
                .ProjectToProductDTO()
                .OrderByDescending(p => p.Price)
                .AsNoTracking()
                .ToArrayAsync();

            return products;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsOrderByQuantityAscAsync()
        {
            var products = await _context.Products
                .ProjectToProductDTO()
                .OrderBy(p => p.Quantity)
                .AsNoTracking()
                .ToArrayAsync();

            return products;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsOrderByQuantityDescAsync()
        {
            var products = await _context.Products
                .ProjectToProductDTO()
                .OrderByDescending(p => p.Quantity)
                .AsNoTracking()
                .ToArrayAsync();

            return products;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsOrderByIsShowAscAsync()
        {
            var products = await _context.Products
                .ProjectToProductDTO()
                .OrderBy(p => p.IsShow)
                .AsNoTracking()
                .ToArrayAsync();

            return products;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsOrderByIsShowDescAsync()
        {
            var products = await _context.Products
                .ProjectToProductDTO()
                .OrderByDescending(p => p.IsShow)
                .AsNoTracking()
                .ToArrayAsync();

            return products;
        }

        public async Task ProductToShopAsync(int id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return;
            }

            product.IsShow = !product.IsShow;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return false;
            }

            bool isOrdered = await _context.ProductsOrders
                .AnyAsync(po => po.ProductId == id);
            if (isOrdered)
            {
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}


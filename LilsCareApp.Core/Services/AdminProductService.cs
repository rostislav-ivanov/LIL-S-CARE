using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.AdminProducts;
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

        public async Task<AdminProductsDTO> GetProductsQueryAsync(
            ProductSortType productSortType,
            string? search,
            int currentPage,
            int productsPerPage)
        {
            var productsFiltered = _context.Products
                .Where(p => string.IsNullOrEmpty(search) || p.Id.ToString() == search || p.Name.NameBG.ToUpper().Contains(search.ToUpper()))
                .Select(p => new AdminProductDTO
                {
                    Id = p.Id,
                    ImagePath = p.Images.OrderBy(im => im.ImageOrder).FirstOrDefault().ImagePath,
                    Name = p.Name.NameBG,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    IsShow = p.IsShow,
                });


            var productsSorted = productSortType switch
            {
                ProductSortType.IdAsc => productsFiltered.OrderBy(p => p.Id),
                ProductSortType.IdDesc => productsFiltered.OrderByDescending(p => p.Id),
                ProductSortType.NameAsc => productsFiltered.OrderBy(p => p.Name),
                ProductSortType.NameDesc => productsFiltered.OrderByDescending(p => p.Name),
                ProductSortType.PriceAsc => productsFiltered.OrderBy(p => p.Price),
                ProductSortType.PriceDesc => productsFiltered.OrderByDescending(p => p.Price),
                ProductSortType.QuantityAsc => productsFiltered.OrderBy(p => p.Quantity),
                ProductSortType.QuantityDesc => productsFiltered.OrderByDescending(p => p.Quantity),
                ProductSortType.IsShowAsc => productsFiltered.OrderBy(p => p.IsShow),
                ProductSortType.IsShowDesc => productsFiltered.OrderByDescending(p => p.IsShow),
                _ => productsFiltered
            };

            var totalProductsCount = await productsSorted.CountAsync();
            var products = await productsSorted
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage)
                .AsNoTracking()
                .ToListAsync();

            return new AdminProductsDTO
            {
                Products = products,
                TotalProductsCount = totalProductsCount,
                ProductsPerPage = productsPerPage,
                CurrentPage = currentPage,
                ProductSortType = productSortType,
                Search = search
            };
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


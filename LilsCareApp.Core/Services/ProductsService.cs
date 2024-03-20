using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models;
using LilsCareApp.Infrastructure.Data;
using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LilsCareApp.Core.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext _context;

        public ProductsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ProductsService()
        {
        }

        async public Task<IEnumerable<ProductDTO>> GetAllAsync(string userId)
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
                    IsWish = p.WishesUsers.Any(wu => wu.AppUserId == userId && wu.ProductId == p.Id)
                })
                .AsNoTracking()
                .ToArrayAsync();

            return products;
        }

        public async Task<IEnumerable<ProductDTO>> GetByCategoryAsync(int id, string userId)
        {
            var products = await _context.Products
                .Where(p => p.ProductsCategories.Any(pc => pc.CategoryId == id))
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
                    IsWish = p.WishesUsers.Any(wu => wu.AppUserId == userId && wu.ProductId == p.Id)
                })
                .AsNoTracking()
                .ToArrayAsync();

            return products;
        }

        public async Task<IList<CategoryDTO>> GetCategoriesAsync()
        {
            var categories = await _context.Categories
                .Select(c => new CategoryDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .AsNoTracking()
                .ToListAsync();

            return categories;
        }

        public async Task AddToWishAsync(int id, string userId)
        {
            var wishUser = new WishUser
            {
                ProductId = id,
                AppUserId = userId
            };

            if (await _context.WishesUsers.ContainsAsync(wishUser) == false)
            {
                await _context.WishesUsers.AddAsync(wishUser);
                await _context.SaveChangesAsync();
            }
        }


        public async Task RemoveFromWishAsync(int id, string userId)
        {
            var wishUser = _context.WishesUsers.FirstOrDefault(wu => wu.ProductId == id && wu.AppUserId == userId);
            if (wishUser != null)
            {
                _context.WishesUsers.Remove(wishUser);
                await _context.SaveChangesAsync();
            }
        }




        public async Task<IEnumerable<ProductsInBagDTO>> GetProductsInBagAsync(string userId)
        {
            var productsInBag = await _context.BagsUsers
                .Where(bu => bu.AppUserId == userId)
                .Select(bu => new ProductsInBagDTO
                {
                    Id = bu.Product.Id,
                    Name = bu.Product.Name,
                    Weight = bu.Product.Weight,
                    Price = bu.Product.Price,
                    ImageUrl = bu.Product.Images.FirstOrDefault().ImagePath,
                    Quantity = bu.Quantity
                })
                .AsNoTracking()
                .ToArrayAsync();

            return productsInBag;
        }

        public async Task AddToCartAsync(int productId, string userId, int quantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product is null || userId is null)
            {
                return;
            }

            var bagUser = await _context.BagsUsers
                .FirstOrDefaultAsync(bu => bu.ProductId == productId && bu.AppUserId == userId);
            if (bagUser == null)
            {
                bagUser = new BagUser
                {
                    ProductId = productId,
                    AppUserId = userId,
                    Quantity = quantity
                };
                await _context.BagsUsers.AddAsync(bagUser);
            }
            else if (bagUser.Quantity + quantity >= 1) // quantity must be at least 1
            {
                bagUser.Quantity += quantity;
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductFromCartAsync(int productId, string userId)
        {
            var bagUser = _context.BagsUsers.FirstOrDefault(bu => bu.ProductId == productId && bu.AppUserId == userId);
            if (bagUser is null)
            {
                return;
            }

            _context.BagsUsers.Remove(bagUser);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetCountInBagAsync(string userId)
        {
            int count = await _context.BagsUsers
                .Where(bu => bu.AppUserId == userId)
                .AsNoTracking()
                .SumAsync(bu => bu.Quantity);
            return count;
        }








        public async Task<CartDTO> GetProductsInCartAsync(string userId)
        {


            CartDTO cart = new CartDTO()
            {
                Products = await _context.BagsUsers
                    .Where(bu => bu.AppUserId == userId)
                    .Select(bu => new ProductInCartDTO
                    {
                        Id = bu.Product.Id,
                        Name = bu.Product.Name,
                        Price = bu.Product.Price,
                        Weight = bu.Product.Weight,
                        ImageUrl = bu.Product.Images.FirstOrDefault().ImagePath,
                        Quantity = bu.Quantity
                    })
                    .AsNoTracking()
                    .ToListAsync(),

                ShippingProviderId = 2
            };

            return cart;
        }








    }
}

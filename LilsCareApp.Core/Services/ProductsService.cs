using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Extensions;
using LilsCareApp.Core.Models.Checkout;
using LilsCareApp.Core.Models.Products;
using LilsCareApp.Infrastructure.Data;
using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using static LilsCareApp.Infrastructure.DataConstants.Language;

namespace LilsCareApp.Core.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextManager _httpContextManager;

        public ProductsService(ApplicationDbContext context, IHttpContextManager httpContextManager)
        {
            _context = context;
            _httpContextManager = httpContextManager;
        }

        public async Task<ProductsDTO> GetProductsQueryAsync(string userId, int? categoryId, int currentPage, int productsPerPage)
        {
            var language = _httpContextManager.GetLanguage();

            var productsFiltered = _context.Products
                .Where(p => categoryId == null || p.ProductsCategories.Any(pc => pc.Category.Id == categoryId))
                .ProjectToProductDTO(userId, language);

            var totalProductsCount = await productsFiltered.CountAsync();
            var products = await productsFiltered
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage)
                .AsNoTracking()
                .ToListAsync();

            return new ProductsDTO
            {
                Products = products,
                Categories = await GetCategoriesAsync(),
                TotalProductsCount = totalProductsCount,
                ProductsPerPage = productsPerPage,
                CurrentPage = currentPage,
                CategoryId = categoryId
            };
        }

        public async Task<IList<CategoryDTO>> GetCategoriesAsync()
        {
            var language = _httpContextManager.GetLanguage();

            var categories = await _context.Categories
                .Select(c => new CategoryDTO
                {
                    Id = c.Id,
                    Name = new Dictionary<string, string>
                    {
                        { Bulgarian, c.Name.NameBG },
                        { Romanian, c.Name.NameRO },
                        { English, c.Name.NameEN }
                    }[language],
                })
                .AsNoTracking()
                .ToListAsync();

            return categories;
        }

        public async Task AddRemoveWishAsync(int id, string userId)
        {
            if (await _context.Products.FirstOrDefaultAsync(p => p.Id == id) == null)
            {
                return;
            }

            if (await _context.Users.FirstOrDefaultAsync(u => u.Id == userId) == null)
            {
                return;
            }

            var wishUser = new WishUser
            {
                ProductId = id,
                AppUserId = userId
            };

            if (await _context.WishesUsers.ContainsAsync(wishUser) == false)
            {
                await _context.WishesUsers.AddAsync(wishUser);
            }
            else
            {
                _context.WishesUsers.Remove(wishUser);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductsInBagDTO>> GetProductsInBagAsync(string userId)
        {
            var language = _httpContextManager.GetLanguage();

            var productsInBag = await _context.BagsUsers
                .Where(bu => bu.AppUserId == userId)
                .Select(bu => new ProductsInBagDTO
                {
                    Id = bu.Product.Id,
                    Name = new Dictionary<string, string>
                    {
                        { Bulgarian, bu.Product.Name.NameBG },
                        { Romanian, bu.Product.Name.NameRO },
                        { English, bu.Product.Name.NameEN }
                    }[language],
                    Optional = new Dictionary<string, string>
                    {
                        { English, bu.Product.Optional.OptionalEN },
                        { Bulgarian, bu.Product.Optional.OptionalBG },
                        { Romanian,bu.Product.Optional.OptionalRO },
                    }[language],
                    Price = bu.Product.Price,
                    ImageUrl = bu.Product.Images.FirstOrDefault(im => im.ImageOrder == 1).ImagePath,
                    Quantity = bu.Quantity
                })
                .AsNoTracking()
                .ToArrayAsync();

            return productsInBag;
        }

        public async Task AddToCartAsync(int productId, string userId, int quantity)
        {
            var product = await _context.Products.FindAsync(productId);
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (product is null || user is null || quantity == 0)
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

        public async Task<IEnumerable<ProductDTO>> GetMyWishesAsync(string userId)
        {
            var language = _httpContextManager.GetLanguage();

            var products = await _context.Products
                .Where(p => p.WishesUsers.Any(wu => wu.AppUserId == userId))
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = new Dictionary<string, string>
                    {
                        { Bulgarian, p.Name.NameBG },
                        { Romanian, p.Name.NameRO },
                        { English, p.Name.NameEN }
                    }[language],
                    Price = p.Price,
                    ImageUrl = p.Images.FirstOrDefault(im => im.ImageOrder == 1).ImagePath ?? "https://via.placeholder.com/150",
                    Quantity = p.Quantity,
                    IsWish = p.WishesUsers.Any(wu => wu.AppUserId == userId)
                })
                .AsNoTracking()
                .ToArrayAsync();

            return products;
        }

        // Migrate products in bag from guest to user
        public async Task MigrateProductsInBagAsync(string userId, IEnumerable<ProductsInBagDTO> guestBag)
        {
            var productsInBag = await _context.BagsUsers
                .Where(bu => bu.AppUserId == userId)
                .ToArrayAsync();

            _context.BagsUsers.RemoveRange(productsInBag);

            IEnumerable<BagUser> bagUsers = guestBag.Select(bag => new BagUser
            {
                ProductId = bag.Id,
                AppUserId = userId,
                Quantity = bag.Quantity
            });

            await _context.BagsUsers.AddRangeAsync(bagUsers);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync(string userId)
        {
            var language = _httpContextManager.GetLanguage();

            return await _context.Products
                .ProjectToProductDTO(userId, language)
                .AsNoTracking()
                .ToArrayAsync();
        }
    }
}

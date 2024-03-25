using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models;
using LilsCareApp.Core.Models.GuestUser;
using LilsCareApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LilsCareApp.Core.Services
{
    public class GuestService : IGuestService
    {
        private readonly ApplicationDbContext _context;

        public GuestService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductsInBagDTO>> GetProductsInBagAsync(List<GuestBag> guestBags)
        {
            List<ProductsInBagDTO> productsInBag = new List<ProductsInBagDTO>();

            foreach (var bag in guestBags)
            {
                var product = await _context.Products
                    .Where(p => p.Id == bag.ProductId)
                    .Select(p => new ProductsInBagDTO
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price,
                        Weight = p.Weight,
                        ImageUrl = p.Images.FirstOrDefault().ImagePath,
                        Quantity = bag.Quantity,
                    })
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                productsInBag.Add(product);
            }


            return productsInBag;
        }

    }
}


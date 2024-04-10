using LilsCareApp.Core.Models.Products;
using LilsCareApp.Infrastructure.Data.Models;

namespace LilsCareApp.Core.Extensions
{
    public static class IQuerableProductExtension
    {
        public static IQueryable<ProductDTO> ProjectToProductDTO(this IQueryable<Product> products, string userId)
        {
            return products
                .Where(p => p.IsShow)
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.Images.OrderBy(im => im.ImageOrder).FirstOrDefault().ImagePath ?? "https://via.placeholder.com/150",
                    Quantity = p.Quantity,
                    IsWish = p.WishesUsers.Any(wu => wu.AppUserId == userId),
                });


        }

    }
}

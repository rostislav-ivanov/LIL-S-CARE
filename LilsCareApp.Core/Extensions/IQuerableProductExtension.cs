using LilsCareApp.Core.Models.Products;
using LilsCareApp.Infrastructure.Data.Models;
using static LilsCareApp.Infrastructure.DataConstants.Language;

namespace LilsCareApp.Core.Extensions
{
    public static class IQuerableProductExtension
    {
        public static IQueryable<ProductDTO> ProjectToProductDTO(this IQueryable<Product> products, string userId, string language)
        {
            return products
                .Where(p => p.IsShow)
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
                    ImageUrl = p.Images.OrderBy(im => im.ImageOrder).FirstOrDefault().ImagePath ?? "https://via.placeholder.com/150",
                    Quantity = p.Quantity,
                    IsWish = p.WishesUsers.Any(wu => wu.AppUserId == userId),
                });


        }

    }
}

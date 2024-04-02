using LilsCareApp.Core.Models;
using LilsCareApp.Infrastructure.Data.Models;

namespace LilsCareApp.Core.Extensions
{
    public static class IQuerableProductExtension
    {
        public static IQueryable<ProductDTO> ProjectToProductDTO(this IQueryable<Product> products)
        {
            return products
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.Images.FirstOrDefault(im => im.ImageOrder == 1).ImagePath ?? "https://via.placeholder.com/150",
                    Quantity = p.Quantity,
                    IsShow = p.IsShow
                });
        }
    }
}

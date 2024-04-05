using LilsCareApp.Core.Models.AdminOrders;
using LilsCareApp.Core.Models.Products;
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

        public static IQueryable<AdminOrderDTO> ProjectToAdminOrderDTO(this IQueryable<Order> orders)
        {
            return orders
                .Select(o => new AdminOrderDTO
                {
                    Id = o.Id,
                    OrderNumber = o.OrderNumber,
                    Date = o.CreatedOn,
                    Customer = o.AddressDelivery.FirstName + " " + o.AddressDelivery.LastName,
                    Payment = o.IsPaid ? "Платена" : "Неплатена",
                    StatusOrder = o.StatusOrder.Name,
                    Total = o.Total
                });
        }
    }
}

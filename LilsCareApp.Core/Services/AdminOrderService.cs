using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.AdminOrders;
using LilsCareApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LilsCareApp.Core.Services
{
    public class AdminOrderService : IAdminOrderService
    {
        private readonly ApplicationDbContext _context;

        public AdminOrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AdminOrdersDTO> GetOrdersQueryAsync(
            OrderSortType orderSortType,
            string? status,
            bool? payment,
            string? search,
            int currentPage,
            int ordersPerPage)
        {
            var ordersFiltered = _context.Orders
                .Where(o => string.IsNullOrEmpty(status) || o.StatusOrder.Name.NameBG == status)
                .Where(o => payment == null || o.IsPaid == payment)
                .Where(o => string.IsNullOrEmpty(search) || o.OrderNumber.Contains(search) || o.AddressDelivery.FirstName.Contains(search) || o.AddressDelivery.LastName.Contains(search))
                .Select(o => new AdminOrderDTO
                {
                    Id = o.Id,
                    OrderNumber = o.OrderNumber,
                    Date = o.CreatedOn,
                    Customer = o.AddressDelivery.FirstName + " " + o.AddressDelivery.LastName,
                    Payment = o.IsPaid ? "Платена" : "Неплатена",
                    StatusOrder = o.StatusOrder.Name.NameBG,
                    Total = o.ProductsOrders.Sum(p => p.Quantity * p.Price) - o.Discount + o.ShippingPrice,
                    Currency = o.Currency
                });
            ;

            var ordersSorted = orderSortType switch
            {
                OrderSortType.OrderAsc => ordersFiltered.OrderBy(o => o.OrderNumber),
                OrderSortType.OrderDesc => ordersFiltered.OrderByDescending(o => o.OrderNumber),
                OrderSortType.DateAsc => ordersFiltered.OrderBy(o => o.Date),
                OrderSortType.DateDesc => ordersFiltered.OrderByDescending(o => o.Date),
                OrderSortType.CustomerAsc => ordersFiltered.OrderBy(o => o.Customer),
                OrderSortType.CustomerDesc => ordersFiltered.OrderByDescending(o => o.Customer),
                OrderSortType.PaymentAsc => ordersFiltered.OrderBy(o => o.Payment),
                OrderSortType.PaymentDesc => ordersFiltered.OrderByDescending(o => o.Payment),
                OrderSortType.StatusOrderAsc => ordersFiltered.OrderBy(o => o.StatusOrder),
                OrderSortType.StatusOrderDesc => ordersFiltered.OrderByDescending(o => o.StatusOrder),
                OrderSortType.TotalAsc => ordersFiltered.OrderBy(o => o.Total),
                OrderSortType.TotalDesc => ordersFiltered.OrderByDescending(o => o.Total),
                _ => ordersFiltered
            };

            var totalOrdersCount = await ordersSorted.CountAsync();
            var orders = await ordersSorted
                .Skip((currentPage - 1) * ordersPerPage)
                .Take(ordersPerPage)
                .AsNoTracking()
                .ToListAsync();

            return new AdminOrdersDTO
            {
                Orders = orders,
                StatusesOrder = await GetStatusesOrderAsync(),
                TotalOrdersCount = totalOrdersCount,
                OrdersPerPage = ordersPerPage,
                CurrentPage = currentPage,
                Status = status,
                Payment = payment,
                OrderSortType = orderSortType,
                Search = search
            };

        }

        public async Task<IEnumerable<StatusOrderDTO>> GetStatusesOrderAsync()
        {
            return await _context.StatusOrders
                .Select(so => new StatusOrderDTO
                {
                    Id = so.Id,
                    Status = so.Name.NameBG
                })
                .AsNoTracking()
                .ToListAsync();
        }

    }
}

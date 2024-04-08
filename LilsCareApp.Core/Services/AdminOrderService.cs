using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Account;
using LilsCareApp.Core.Models.AdminOrderDetails;
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
                .Where(o => string.IsNullOrEmpty(status) || o.StatusOrder.Name == status)
                .Where(o => payment == null || o.IsPaid == payment)
                .Where(o => string.IsNullOrEmpty(search) || o.OrderNumber.Contains(search) || o.AddressDelivery.FirstName.Contains(search) || o.AddressDelivery.LastName.Contains(search))
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
                    Status = so.Name
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<AdminOrderDetailsDTO> GetOrderDetailsAsync(int id)
        {
            var order = await _context.Orders
                .Where(o => o.Id == id)
                .Select(o => new AdminOrderDetailsDTO
                {
                    Id = o.Id,
                    OrderNumber = o.OrderNumber,
                    CreatedOn = o.CreatedOn,
                    StatusOrder = new StatusOrderDTO
                    {
                        Id = o.StatusOrder.Id,
                        Status = o.StatusOrder.Name
                    },
                    AddressDelivery = new DeliveryAddressDTO
                    {
                        AddressId = o.AddressDelivery.Id,
                        FirstName = o.AddressDelivery.FirstName,
                        LastName = o.AddressDelivery.LastName,
                        Country = o.AddressDelivery.Country,
                        PostCode = o.AddressDelivery.PostCode,
                        Town = o.AddressDelivery.Town,
                        Address = o.AddressDelivery.Address,
                        District = o.AddressDelivery.District,
                        Email = o.AddressDelivery.Email,
                        PhoneNumber = o.AddressDelivery.PhoneNumber,
                        ShippingProvider = o.AddressDelivery.ShippingOffice.ShippingProvider.Name,
                        OfficeCity = o.AddressDelivery.ShippingOffice.City,
                        OfficeAddress = o.AddressDelivery.ShippingOffice.OfficeAddress,
                        IsOffice = o.AddressDelivery.IsShippingToOffice
                    },
                    AppUserId = o.AppUserId,
                    DateShipping = o.DateShipping,
                    TrackingNumber = o.TrackingNumber,
                    PaymentMethod = o.PaymentMethod.Type,
                    IsPaid = o.IsPaid,
                    ProductsOrders = o.ProductsOrders
                        .Select(po => new ProductsOrdersDTO
                        {
                            Id = po.Product.Id,
                            Name = po.Product.Name,
                            Quantity = po.Quantity,
                            Price = po.Price,
                            ImageUrl = po.ImagePath,
                            Optional = po.Product.Optional
                        })
                        .ToList(),
                    ShippingPrice = o.ShippingPrice,
                    Discount = o.Discount
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return order;
        }

        public async Task AddTrackingCodeAsync(int id, string trackingNumber)
        {
            var order = await _context.Orders
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync();

            if (order == null)
            {
                return;
            }

            order.TrackingNumber = trackingNumber;
            await _context.SaveChangesAsync();
        }
    }
}

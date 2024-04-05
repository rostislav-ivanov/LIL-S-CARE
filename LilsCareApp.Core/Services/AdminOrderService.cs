using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Extensions;
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

        public async Task<IEnumerable<AdminOrderDTO>> GetOrdersAsync()
        {
            var orders = await _context
                .Orders
                .ProjectToAdminOrderDTO()
                .AsNoTracking()
                .ToListAsync();

            return orders;
        }

        public async Task<IEnumerable<AdminOrderDTO>> GetOrdersOrderByOrderAscAsync()
        {
            return await _context.Orders
                .OrderBy(o => o.OrderNumber)
                .ProjectToAdminOrderDTO()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<AdminOrderDTO>> GetOrdersOrderByOrderDescAsync()
        {
            return await _context.Orders
                .OrderByDescending(o => o.OrderNumber)
                .ProjectToAdminOrderDTO()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<AdminOrderDTO>> GetOrdersOrderByDateAscAsync()
        {
            return await _context.Orders
                .OrderBy(o => o.CreatedOn)
                .ProjectToAdminOrderDTO()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<AdminOrderDTO>> GetOrdersOrderByDateDescAsync()
        {
            return await _context.Orders
                .OrderByDescending(o => o.CreatedOn)
                .ProjectToAdminOrderDTO()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<AdminOrderDTO>> GetOrdersOrderByCustomerAscAsync()
        {
            return await _context.Orders
                .OrderBy(o => o.AddressDelivery.FirstName)
                .ProjectToAdminOrderDTO()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<AdminOrderDTO>> GetOrdersOrderByCustomerDescAsync()
        {
            return await _context.Orders
                .OrderByDescending(o => o.AddressDelivery.FirstName)
                .ProjectToAdminOrderDTO()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<AdminOrderDTO>> GetOrdersOrderByPaymentAscAsync()
        {
            return await _context.Orders
                .OrderBy(o => o.IsPaid)
                .ProjectToAdminOrderDTO()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<AdminOrderDTO>> GetOrdersOrderByPaymentDescAsync()
        {
            return await _context.Orders
                .OrderByDescending(o => o.IsPaid)
                .ProjectToAdminOrderDTO()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<AdminOrderDTO>> GetOrdersOrderByStatusOrderAscAsync()
        {
            return await _context.Orders
                .OrderBy(o => o.StatusOrder.Name)
                .ProjectToAdminOrderDTO()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<AdminOrderDTO>> GetOrdersOrderByStatusOrderDescAsync()
        {
            return await _context.Orders
                .OrderByDescending(o => o.StatusOrder.Name)
                .ProjectToAdminOrderDTO()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<AdminOrderDTO>> GetOrdersOrderByTotalAscAsync()
        {
            return await _context.Orders
                .OrderBy(o => o.Total)
                .ProjectToAdminOrderDTO()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<AdminOrderDTO>> GetOrdersOrderByTotalDescAsync()
        {
            return await _context.Orders
                .OrderByDescending(o => o.Total)
                .ProjectToAdminOrderDTO()
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

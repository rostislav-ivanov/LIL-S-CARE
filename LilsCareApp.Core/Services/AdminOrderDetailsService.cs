﻿using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.AdminOrderDetails;
using LilsCareApp.Infrastructure.Data;
using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LilsCareApp.Core.Services
{
    public class AdminOrderDetailsService : IAdminOrderDetailsService
    {
        private readonly ApplicationDbContext _context;

        public AdminOrderDetailsService(ApplicationDbContext context)
        {
            _context = context;
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
                    StatusOrderId = o.StatusOrder.Id,
                    DeliveryMethodId = o.DeliveryMethod.Id,
                    AppUserId = o.AppUserId,
                    AppUserName = o.AppUser != null ? o.AppUser.UserName : null,
                    DateShipping = o.DateShipping,
                    TrackingNumber = o.TrackingNumber,
                    PaymentMethodId = o.PaymentMethod.Id,
                    IsPaid = o.IsPaid,
                    NoteForDelivery = o.NoteForDelivery,
                    ExchangeRate = o.ExchangeRate,
                    Currency = o.Currency,
                    ShippingPrice = o.ShippingPrice,
                    Discount = o.Discount,
                    SubTotal = o.ProductsOrders.Sum(p => p.Quantity * p.Price) - o.Discount,
                    Total = o.ProductsOrders.Sum(p => p.Quantity * p.Price) - o.Discount + o.ShippingPrice,
                    FirstName = o.FirstName,
                    LastName = o.LastName,
                    PhoneNumber = o.PhoneNumber,
                    PostCode = o.PostCode,
                    Address = o.Address,
                    Town = o.Town,
                    District = o.District,
                    Country = o.Country,
                    Email = o.Email,
                    ShippingProviderName = o.ShippingProviderName,
                    OfficeCity = o.ShippingOfficeCity,
                    OfficeAddress = o.ShippingOfficeAddress,
                    ProductsOrders = o.ProductsOrders
                        .Select(po => new ProductsOrdersDTO
                        {
                            Id = po.Product.Id,
                            Name = po.Product.Name.NameBG,
                            Quantity = po.Quantity,
                            Price = po.Price,
                            ImageUrl = po.ImagePath,
                            Optional = po.Product.Optional.OptionalBG,
                        })
                        .ToList(),
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (order != null)
            {
                order.SubTotal = Math.Round(order.SubTotal, 2);
                order.Total = Math.Round(order.Total, 2);
            }

            return order;
        }

        public async Task<IEnumerable<ProductsNamesDTO>> GetProductsNameAsync()
        {
            return await _context.Products
                .Select(p => new ProductsNamesDTO
                {
                    Id = p.Id,
                    Name = p.Name.NameBG
                })
                .AsNoTracking()
                .ToListAsync();
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

        public async Task ChangeStatusAsync(int id, int statusId)
        {
            var order = await _context.Orders
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync();

            var status = await _context.StatusOrders
                .Where(s => s.Id == statusId)
                .FirstOrDefaultAsync();

            if (order == null || status == null)
            {
                return;
            }

            order.StatusOrder = status;

            await _context.SaveChangesAsync();
        }

        public async Task ChangeDeliveryMethodAsync(int id, int deliveryMethodId)
        {
            var order = await _context.Orders
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync();

            var deliveryMethod = await _context.DeliveryMethods
                .Where(dm => dm.Id == deliveryMethodId)
                .FirstOrDefaultAsync();

            if (order == null || deliveryMethod == null)
            {
                return;
            }

            order.DeliveryMethod = deliveryMethod;

            await _context.SaveChangesAsync();
        }

        public async Task ChangePaymentAsync(int id, bool? isPaid)
        {
            var order = await _context.Orders
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync();

            if (order == null || isPaid == null || order.IsPaid == isPaid.Value)
            {
                return;
            }

            order.IsPaid = isPaid.Value;

            await _context.SaveChangesAsync();
        }

        public async Task AddProductToOrderAsync(int id, int productId)
        {
            var order = await _context.Orders
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync();

            var product = await _context.Products
                .Include(p => p.Images)
                .Where(p => p.Id == productId)
                .FirstOrDefaultAsync();

            if (order == null || product == null)
            {
                return;
            }

            var productOrder = await _context.ProductsOrders
                .Where(po => po.ProductId == productId && po.OrderId == id)
                .FirstOrDefaultAsync();

            if (productOrder != null)
            {
                productOrder.Quantity++;
            }
            else
            {
                order.ProductsOrders.Add(new ProductOrder
                {
                    Product = product,
                    Quantity = 1,
                    Price = Math.Round((product.Price / order.ExchangeRate), 2),
                    ImagePath = product.Images?.OrderBy(im => im.ImageOrder).FirstOrDefault()?.ImagePath
                });
            }

            // Decrease quantity in store
            product.Quantity--;



            await _context.SaveChangesAsync();
        }

        public async Task RemoveProductFromOrderAsync(int id, int productId)
        {
            var productOrder = await _context.ProductsOrders
                .Where(po => po.ProductId == productId && po.OrderId == id)
                .FirstOrDefaultAsync();

            if (productOrder == null)
            {
                return;
            }

            // Increase quantity in store
            var product = await _context.Products
                .Where(p => p.Id == productId)
                .FirstOrDefaultAsync();
            if (product != null)
            {
                product.Quantity += productOrder.Quantity;
            }

            _context.ProductsOrders.Remove(productOrder);
            await _context.SaveChangesAsync();
        }

        public async Task AddQuantityToProductAsync(int id, int productId, int quantity)
        {
            var productOrder = await _context.ProductsOrders
                .Where(po => po.ProductId == productId && po.OrderId == id)
                .FirstOrDefaultAsync();

            if (productOrder == null)
            {
                return;
            }

            productOrder.Quantity += quantity;

            if (productOrder.Quantity <= 0)
            {
                _context.ProductsOrders.Remove(productOrder);
            }

            // Change quantity in store
            var product = await _context.Products
                .Where(p => p.Id == productId)
                .FirstOrDefaultAsync();
            if (product != null)
            {
                product.Quantity -= quantity;
            }

            await _context.SaveChangesAsync();
        }

        public async Task EditDiscountAsync(int id, decimal discount)
        {
            var order = await _context.Orders
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync();

            if (order == null)
            {
                return;
            }

            order.Discount = discount;
            await _context.SaveChangesAsync();
        }

        public async Task AddOfficeDeliveryAsync(AdminOrderDetailsDTO model)
        {
            var order = await _context.Orders
                .Where(o => o.Id == model.Id)
                .FirstOrDefaultAsync();

            if (order == null)
            {
                return;
            }

            order.ShippingProviderName = model.ShippingProviderName;
            order.ShippingOfficeCity = model.OfficeCity;
            order.ShippingOfficeAddress = model.OfficeAddress;
            order.FirstName = model.FirstName;
            order.LastName = model.LastName;
            order.PhoneNumber = model.PhoneNumber;
            order.Email = model.Email;

            await _context.SaveChangesAsync();
        }

        public async Task AddHomeDeliveryAsync(AdminOrderDetailsDTO model)
        {
            var order = await _context.Orders
                .Where(o => o.Id == model.Id)
                .FirstOrDefaultAsync();

            if (order == null)
            {
                return;
            }

            order.FirstName = model.FirstName;
            order.LastName = model.LastName;
            order.Country = model.Country;
            order.PostCode = model.PostCode;
            order.Address = model.Address;
            order.Town = model.Town;
            order.District = model.District;
            order.PhoneNumber = model.PhoneNumber;
            order.Email = model.Email;

            await _context.SaveChangesAsync();
        }
    }
}

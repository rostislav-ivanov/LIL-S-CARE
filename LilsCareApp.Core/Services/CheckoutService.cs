using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Checkout;
using LilsCareApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LilsCareApp.Core.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly ApplicationDbContext _context;

        public CheckoutService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IDeliveryDTO> GetAddressDeliveryAsync(string userId)
        {
            var delivery = await _context.AddressDeliveries
                .AsNoTracking()
                .FirstOrDefaultAsync(ad => ad.AppUsers.Any(u => u.Id == userId));

            if (delivery == null)
            {
                return null;
            }

            if (delivery.ShippingOffice != null && delivery.ShippingOffice.Id != 0)
            {
                var officeDelivery = new OfficeDeliveryDTO()
                {
                    Id = delivery.Id,
                    FirstName = delivery.FirstName,
                    LastName = delivery.LastName,
                    PhoneNumber = delivery.PhoneNumber,
                    ShippingOffice = new ShippingOfficeDTO()
                    {
                        Id = delivery.ShippingOffice.Id,
                        City = delivery.ShippingOffice.City,
                        OfficeAddress = delivery.ShippingOffice.OfficeAddress,
                        Price = delivery.ShippingOffice.Price,
                        ShippingDuration = delivery.ShippingOffice.ShippingDuration
                    },
                    ShippingProvider = new ShippingProviderDTO()
                    {
                        Description = "доставка до офис на " + delivery.ShippingOffice.ShippingProvider.Name
                    }
                };

                officeDelivery.IsValid = officeDelivery.FirstName != null
                                        && officeDelivery.LastName != null
                                        && officeDelivery.PhoneNumber != null;

                return officeDelivery;

            }

            var addressDelivery = new AddressDeliveryDTO()
            {
                Id = delivery.Id,
                FirstName = delivery.FirstName,
                LastName = delivery.LastName,
                Country = delivery.Country,
                PostCode = delivery.PostCode,
                Town = delivery.Town,
                Address = delivery.Address,
                District = delivery.District,
                PhoneNumber = delivery.PhoneNumber,
                ShippingProvider = new ShippingProviderDTO()
                {
                    Id = 0,
                    Description = "доставка до адрес на клиент"
                }
            };

            addressDelivery.IsValid = addressDelivery.FirstName != null
                                     && addressDelivery.LastName != null
                                     && addressDelivery.Country != null
                                     && addressDelivery.PostCode != null
                                     && addressDelivery.Town != null
                                     && addressDelivery.Address != null;

            return addressDelivery;
        }

        public async Task<IEnumerable<ShippingProviderDTO>> GetShippingProvidersAsync()
        {
            var shippingProviders = await _context.ShippingProviders
                .Select(sp => new ShippingProviderDTO()
                {
                    Id = sp.Id,
                    Description = "доставка до офис на " + sp.Name
                })
                .AsNoTracking()
                .ToListAsync();
            shippingProviders.Add(new ShippingProviderDTO()
            {
                Id = 0,
                Description = "доставка до адрес на клиент"
            });
            return shippingProviders.OrderByDescending(sp => sp.Id);
        }

        public async Task<IEnumerable<ShippingOfficeDTO>> GetShippingOfficesAsync()
        {
            return await _context.ShippingOffices
                .Select(so => new ShippingOfficeDTO()
                {
                    Id = so.Id,
                    City = so.City,
                    OfficeAddress = so.OfficeAddress,
                    Price = so.Price,
                    ShippingDuration = so.ShippingDuration,
                })
                .AsNoTracking()
                .ToListAsync();
        }

    }
}

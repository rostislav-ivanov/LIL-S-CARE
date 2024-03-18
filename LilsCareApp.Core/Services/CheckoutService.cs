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
                return new AddressDeliveryDTO();
            }

            if (delivery.ShippingOffice != null && delivery.ShippingOffice.Id != 0)
            {
                var officeDelivery = new OfficeDeliveryDTO()
                {
                    Id = delivery.Id,
                    FirstName = delivery.FirstName,
                    LastName = delivery.LastName,
                    PhoneNumber = delivery.PhoneNumber,
                    IsShippingToOffice = delivery.IsShippingToOffice,
                    ShippingOffice = new ShippingOfficeDTO()
                    {
                        Id = delivery.ShippingOffice.Id,
                        City = delivery.ShippingOffice.City,
                        OfficeAddress = delivery.ShippingOffice.OfficeAddress,
                        Price = delivery.ShippingOffice.Price,
                        ShippingDuration = delivery.ShippingOffice.ShippingDuration
                    },
                    ShippingProviderId = delivery.ShippingOffice.ShippingProvider.Id,
                    ShippingProvider = new ShippingProviderDTO()
                    {
                        Id = delivery.ShippingOffice.ShippingProvider.Id,
                        Description = "доставка до офис на " + delivery.ShippingOffice.ShippingProvider.Name
                    }
                };

                officeDelivery.ShippingProviderId = delivery.ShippingOffice.ShippingProvider.Id;
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
                IsShippingToOffice = delivery.IsShippingToOffice,
                ShippingProviderId = 0,
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
            return shippingProviders.OrderBy(sp => sp.Id);
        }


        public async Task<ShippingOfficeDTO?> GetShippingOfficeByIdAsync(int officeId)
        {
            return await _context.ShippingOffices
                .Where(so => so.Id == officeId)
                .Select(so => new ShippingOfficeDTO()
                {
                    Id = so.Id,
                    City = so.City,
                    OfficeAddress = so.OfficeAddress,
                    Price = so.Price,
                    ShippingDuration = so.ShippingDuration,
                })
                .AsNoTracking()
                .FirstOrDefaultAsync(so => so.Id == officeId);
        }

        public async Task<IEnumerable<string>> GetShippingCitiesAsync(int shippingProvidersId)
        {
            return await _context.ShippingOffices
                .Where(so => so.ShippingProviderId == shippingProvidersId)
                .Select(so => so.City)
                .Distinct()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<ShippingOfficeDTO>> GetShippingOfficesByCityAsync(string city, int? shippingProviderId)
        {
            return await _context.ShippingOffices
                .Where(so => so.City == city && so.ShippingProviderId == shippingProviderId)
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

        public async Task CheckoutSaveAsync(OrderDTO? checkout, string userId)
        {
            //AddressDelivery addressDelivery = new AddressDelivery()
            //{
            //    FirstName = checkout.AddressDelivery.FirstName,
            //    LastName = checkout.AddressDelivery.LastName,
            //    PhoneNumber = checkout.AddressDelivery.PhoneNumber,
            //    Country = checkout.AddressDelivery.Country,
            //    PostCode = checkout.AddressDelivery.PostCode,
            //    Town = checkout.AddressDelivery.Town,
            //    Address = checkout.AddressDelivery.Address,
            //    District = checkout.AddressDelivery.District,
            //};

            //Order order = new Order()
            //{
            //    CreatedOn = DateTime.UtcNow,
            //    StatusOrderId = 1,

            //};
            //throw new NotImplementedException();
        }
    }
}

using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Checkout;
using LilsCareApp.Infrastructure.Data;
using LilsCareApp.Infrastructure.Data.Models;
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

        public async Task<AddressDeliveryDTO?> GetAddressDeliveryAsync(string userId)
        {

            var addressDelivery = await _context.Users
                .Where(u => u.Id == userId)
                .Select(u => u.DefaultAddressDelivery)
                .Select(ad => new AddressDeliveryDTO()
                {
                    Id = ad.Id,
                    FirstName = ad.FirstName,
                    LastName = ad.LastName,
                    Country = ad.Country,
                    PostCode = ad.PostCode,
                    Town = ad.Town,
                    Address = ad.Address,
                    District = ad.District,
                    PhoneNumber = ad.PhoneNumber,
                    IsShippingToOffice = ad.IsShippingToOffice,
                    ShippingOfficeId = ad.ShippingOfficeId
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (addressDelivery != null)
            {
                if (addressDelivery.IsShippingToOffice)
                {
                    addressDelivery.ShippingOffice = await _context.ShippingOffices
                        .Where(so => so.Id == addressDelivery.ShippingOfficeId)
                        .Select(so => new ShippingOfficeDTO()
                        {
                            Id = so.Id,
                            City = so.City,
                            OfficeAddress = so.OfficeAddress,
                            Price = so.Price,
                            ShippingDuration = so.ShippingDuration,
                        })
                        .AsNoTracking()
                        .FirstOrDefaultAsync();


                    addressDelivery.ShippingOffice.ShippingProviderId = await _context.ShippingProviders
                                .Where(sp => sp.ShippingOffices.Any(so => so.Id == addressDelivery.ShippingOfficeId))
                                .Select(sp => sp.Id)
                                .FirstOrDefaultAsync();

                    addressDelivery.IsValid = addressDelivery.FirstName != null
                                         && addressDelivery.LastName != null
                                         && addressDelivery.PhoneNumber != null
                                         && addressDelivery.ShippingOffice != null;
                }
                else
                {
                    addressDelivery.IsValid = addressDelivery.FirstName != null
                                         && addressDelivery.LastName != null
                                         && addressDelivery.Country != null
                                         && addressDelivery.PostCode != null
                                         && addressDelivery.Town != null
                                         && addressDelivery.Address != null;
                }

            }
            return addressDelivery;
        }

        public async Task<IEnumerable<ShippingProviderDTO>> GetShippingProvidersAsync()
        {
            var shippingProviders = await _context.ShippingProviders
                .Select(sp => new ShippingProviderDTO()
                {
                    Id = sp.Id,
                    Name = sp.Name,
                    Description = "доставка до офис на " + sp.Name
                })
                .AsNoTracking()
                .ToListAsync();
            shippingProviders.Add(new ShippingProviderDTO()
            {
                Id = 0,
                Name = "доставка до адрес на клиент",
                Description = "доставка до адрес на клиент"
            });
            return shippingProviders.OrderBy(sp => sp.Id);
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

        public async Task CheckoutSaveAsync(OrderDTO checkout, string userId)
        {

            AppUser appUser = await _context.Users.FirstAsync(u => u.Id == userId);

            Order order = new Order()
            {
                CreatedOn = DateTime.UtcNow,
                StatusOrderId = 1,
                AppUserId = userId,
                PaymentMethodId = checkout.PaymentMethodId,
                NoteForDelivery = checkout.NoteForDelivery,
            };

            // check for existing address delivery
            AddressDelivery addressDelivery = await _context.AddressDeliveries.FirstOrDefaultAsync(ad => ad.Id == checkout.AddressDelivery.Id);

            if (addressDelivery is null) // create new address delivery
            {
                addressDelivery = new AddressDelivery()
                {
                    FirstName = checkout.AddressDelivery.FirstName,
                    LastName = checkout.AddressDelivery.LastName,
                    PhoneNumber = checkout.AddressDelivery.PhoneNumber,
                    Country = checkout.AddressDelivery.Country,
                    PostCode = checkout.AddressDelivery.PostCode,
                    Town = checkout.AddressDelivery.Town,
                    Address = checkout.AddressDelivery.Address,
                    District = checkout.AddressDelivery.District,
                    IsShippingToOffice = checkout.AddressDelivery.IsShippingToOffice,
                    ShippingOfficeId = checkout.AddressDelivery.ShippingOffice.Id,
                    AppUser = appUser

                };
            };


            // set new default address delivery to user

            appUser.DefaultAddressDelivery = addressDelivery;

            order.AddressDelivery = addressDelivery;

            await _context.Orders.AddAsync(order);

            await _context.SaveChangesAsync();
        }
    }
}


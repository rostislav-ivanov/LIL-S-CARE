using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Account;
using LilsCareApp.Core.Models.Checkout;
using LilsCareApp.Infrastructure.Data;
using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using static LilsCareApp.Infrastructure.DataConstants.Language;

namespace LilsCareApp.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextManager _httpContextManager;

        public AccountService(ApplicationDbContext context, IHttpContextManager httpContextManager)
        {
            _context = context;
            _httpContextManager = httpContextManager;
        }

        // Get the user account details
        public async Task<MyAddressDTO?> GetMyAccountAsync(string userId)
        {
            return await _context.Users
                .Where(u => u.Id == userId)
                .Select(u => new MyAddressDTO
                {
                    UserName = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    PhoneNumber = u.PhoneNumber,
                    Email = u.Email,
                    ImagePath = u.ImagePath
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        // Update the user account details
        public async Task UpdateMyAccountAsync(string userId, MyAddressDTO myAccount)
        {
            var user = await _context.Users.FirstOrDefaultAsync(au => au.Id == userId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found");
            }

            user.FirstName = myAccount.FirstName;
            user.LastName = myAccount.LastName;
            user.PhoneNumber = myAccount.PhoneNumber;
            user.Email = myAccount.Email;
            user.NormalizedEmail = myAccount.Email?.ToUpper();
            // Update the image path if a new image was uploaded
            if (myAccount.ImagePath != null)
            {
                // Delete the old image
                var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", user.ImagePath?.Substring(1) ?? "");
                if (File.Exists(oldImagePath))
                {
                    File.Delete(oldImagePath);
                }
                user.ImagePath = myAccount.ImagePath;
            }

            await _context.SaveChangesAsync();
        }


        // Get the user image path
        public async Task<string> GetUserImagePathAsync(string userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(au => au.Id == userId);

            return user.ImagePath;
        }

        // Get all orders of the user
        public async Task<IEnumerable<MyOrderDTO>> GetMyOrdersAsync(string userId)
        {
            var language = _httpContextManager.GetLanguage();

            return await _context.Orders
                .Where(o => o.AppUserId == userId)
                .OrderByDescending(o => o.CreatedOn)
                .Select(o => new MyOrderDTO
                {
                    Id = o.Id,
                    CreatedOn = o.CreatedOn,
                    OrderNumber = o.OrderNumber,
                    StatusOrder = new Dictionary<string, string>
                    {
                        { Bulgarian, o.StatusOrder.Name.NameBG },
                        { Romanian, o.StatusOrder.Name.NameRO },
                        { English, o.StatusOrder.Name.NameEN }
                    }[language],
                    Products = o.ProductsOrders
                        .Select(op => new MyProductOrderDTO
                        {
                            ProductId = op.ProductId,
                            ProductName = new Dictionary<string, string>
                            {
                                { Bulgarian, op.Product.Name.NameBG },
                                { Romanian, op.Product.Name.NameRO },
                                { English, op.Product.Name.NameEN }
                            }[language],
                            ImagePath = op.ImagePath,
                            Quantity = op.Quantity,
                            Price = op.Price,
                        })
                        .ToList(),
                    DateShipping = o.DateShipping,
                    TrackingNumber = o.TrackingNumber,
                    Currency = o.Currency,
                    Discount = o.Discount,
                    SubTotal = o.SubTotal,
                    ShippingPrice = o.ShippingPrice,
                    Total = o.Total,
                })
                .AsNoTracking()
                .ToListAsync();
        }


        // Return all delivery addresses  of the user (to address and to office)
        public async Task<IEnumerable<DeliveryAddressDTO>> GetMyAddressesAsync(string userId)
        {
            IEnumerable<DeliveryAddressDTO> myAddresses = await _context.AddressDeliveries
                .Where(ad => ad.AppUserId == userId && !ad.IsDeleted)
                .Select(ad => new DeliveryAddressDTO
                {
                    AddressId = ad.Id,
                    FirstName = ad.FirstName,
                    LastName = ad.LastName,
                    Country = ad.Country,
                    PostCode = ad.PostCode,
                    Town = ad.Town,
                    Address = ad.Address,
                    District = ad.District,
                    Email = ad.Email,
                    PhoneNumber = ad.PhoneNumber,
                    ShippingProvider = ad.ShippingOffice != null ? ad.ShippingOffice.ShippingProvider.Name : null,
                    OfficeCity = ad.ShippingOffice != null ? ad.ShippingOffice.City : null,
                    OfficeAddress = ad.ShippingOffice != null ? ad.ShippingOffice.OfficeAddress : null,
                    IsOffice = ad.IsShippingToOffice,
                    IsDefault = ad.IsDefault
                })
                .AsNoTracking()
                .ToListAsync();

            return myAddresses;
        }


        // If the address is the default address, set the default address to null.
        // Remove the delivery address from the user.
        public async Task RemoveAddressFromAppUserAsync(int addressId)
        {
            var address = await _context.AddressDeliveries.FirstOrDefaultAsync(ad => ad.Id == addressId);

            if (address == null)
            {
                return;
            }

            if (await _context.Orders.AnyAsync(o => o.AddressDeliveryId == addressId))
            {
                address.IsDeleted = true;
                address.IsDefault = false;
                return;
            }
            else
            {
                _context.AddressDeliveries.Remove(address);
            }

            await _context.SaveChangesAsync();
        }


        // Set the default delivery address
        public async Task SetDefaultAddressAsync(string userId, int addressId)
        {
            var addresses = await _context.AddressDeliveries
                .Where(ad => ad.AppUserId == userId)
                .ToListAsync();

            foreach (var address in addresses)
            {
                address.IsDefault = address.Id == addressId;
            }

            await _context.SaveChangesAsync();
        }


        // Get all shipping providers
        public async Task<IEnumerable<ShippingProviderDTO>> GetShippingProvidersAsync()
        {
            return await _context.ShippingProviders
                .Select(sp => new ShippingProviderDTO
                {
                    Id = sp.Id,
                    Name = sp.Name
                })
                .AsNoTracking()
                .ToListAsync();
        }


        // Get all cities of the shipping provider
        public async Task<IEnumerable<string>> GetShippingProviderCitiesAsync(int shippingProviderId)
        {
            return await _context.ShippingOffices
                .Where(so => so.ShippingProviderId == shippingProviderId)
                .Select(so => so.City)
                .Distinct()
                .OrderBy(c => c)
                .AsNoTracking()
                .ToListAsync();
        }


        // Get all offices of the shipping provider in the city
        public async Task<IEnumerable<ShippingOfficeDTO>> GetShippingOfficesAsync(int? shippingProviderId, string city)
        {
            return await _context.ShippingOffices
                .Where(so => so.ShippingProviderId == shippingProviderId && so.City == city)
                .Select(so => new ShippingOfficeDTO
                {
                    Id = so.Id,
                    ShippingProviderId = so.ShippingProviderId,
                    ShippingProviderName = so.ShippingProvider.Name,
                    City = so.City,
                    OfficeAddress = so.OfficeAddress,
                    Price = so.Price,
                    ShippingDuration = so.ShippingDuration
                })
                .AsNoTracking()
                .ToListAsync();
        }

        // Add the address delivery
        public async Task AddAddressDeliveryAsync(string userId, AddressOrderDTO address)
        {
            if (address is null || userId is null)
            {
                return;
            }

            AddressDelivery addressDelivery = new()
            {
                FirstName = address.FirstName,
                LastName = address.LastName,
                PhoneNumber = address.PhoneNumber,
                Country = address.Country,
                PostCode = address.PostCode,
                Town = address.Town,
                Address = address.Address,
                District = address.District,
                Email = address.Email,
                AppUserId = userId,
                IsShippingToOffice = address.DeliveryMethodId == 1,
                ShippingOfficeId = address.ShippingOfficeId,
                IsDefault = false,
                IsDeleted = false,
            };

            await _context.AddressDeliveries.AddAsync(addressDelivery);

            await _context.SaveChangesAsync();
        }

        // Edit the address delivery
        // If the address has any orders,
        // remain the address to the database.
        // Create a new address with the edited data to user
        // and remove the old address form the user
        // else edit the address
        public async Task EditAddressDeliveryAsync(string userId, AddressOrderDTO model)
        {
            var address = await _context.AddressDeliveries.FirstOrDefaultAsync(ad => ad.Id == model.Id);

            if (address is null || userId is null)
            {
                return;
            }

            address.FirstName = model.FirstName;
            address.LastName = model.LastName;
            address.PhoneNumber = model.PhoneNumber;
            address.Country = model.Country;
            address.PostCode = model.PostCode;
            address.Town = model.Town;
            address.Address = model.Address;
            address.District = model.District;
            address.Email = model.Email;
            address.AppUserId = userId;
            address.IsShippingToOffice = model.DeliveryMethodId == 1;
            address.ShippingOfficeId = model.ShippingOfficeId;
            address.IsDefault = false;
            address.IsDeleted = false;

            await _context.SaveChangesAsync();
        }

        // Get the delivery address to be edited
        public async Task<AddressOrderDTO> GetAddressDeliveryAsync(int addressId)
        {
            var address = await _context.AddressDeliveries
                .Where(ad => ad.Id == addressId && !ad.IsDeleted)
                .Select(ad => new AddressOrderDTO()
                {
                    Id = ad.Id,
                    FirstName = ad.FirstName,
                    LastName = ad.LastName,
                    PhoneNumber = ad.PhoneNumber,
                    PostCode = ad.PostCode ?? string.Empty,
                    Address = ad.Address ?? string.Empty,
                    Town = ad.Town ?? string.Empty,
                    District = ad.District ?? string.Empty,
                    Country = ad.Country ?? string.Empty,
                    Email = ad.Email ?? string.Empty,
                    ShippingOfficeId = ad.ShippingOfficeId,
                    ShippingOffice = ad.ShippingOffice != null ? new ShippingOfficeDTO()
                    {
                        Id = ad.ShippingOffice.Id,
                        ShippingProviderId = ad.ShippingOffice.ShippingProviderId,
                        ShippingProviderName = ad.ShippingOffice.ShippingProvider.Name,
                        City = ad.ShippingOffice.City,
                        OfficeAddress = ad.ShippingOffice.OfficeAddress,
                        Price = ad.ShippingOffice.Price,
                        ShippingDuration = ad.ShippingOffice.ShippingDuration,
                    } : null,
                    ShippingProviderId = ad.ShippingOffice != null ? ad.ShippingOffice.ShippingProviderId : 0,
                    ShippingProviderCity = ad.ShippingOffice != null ? ad.ShippingOffice.City : string.Empty,
                    DeliveryMethodId = ad.IsShippingToOffice ? 1 : 2,
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (address != null && address.DeliveryMethodId == 1)
            {
                address.ShippingProviders = await GetShippingProvidersAsync();
                address.ShippingProviderCities = await GetShippingProviderCitiesAsync(address.ShippingProviderId);
                address.ShippingOffices = await GetShippingOfficesAsync(address.ShippingProviderId, address.ShippingProviderCity);
            }

            return address;
        }

        public async Task<string?> GetEmailUser(string userId)
        {
            return await _context.Users
                .Where(u => u.Id == userId)
                .Select(u => u.Email)
                .FirstOrDefaultAsync();
        }

        public async Task<string?> GetAddressOwnerId(int addressId)
        {
            return await _context.AddressDeliveries
                .Where(ad => ad.Id == addressId)
                .Select(ad => ad.AppUserId)
                .FirstOrDefaultAsync();
        }

        public Task<string?> GetPromoCodeOwnerId(int promoCodeId)
        {
            return _context.PromoCodes
                .Where(pc => pc.Id == promoCodeId)
                .Select(pc => pc.AppUserId)
                .FirstOrDefaultAsync();
        }
    }
}

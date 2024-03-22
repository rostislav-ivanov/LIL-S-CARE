using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Account;
using LilsCareApp.Core.Models.Checkout;
using LilsCareApp.Infrastructure.Data;
using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LilsCareApp.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;

        public AccountService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MyAccountDTO?> GetMyAccountAsync(string userId)
        {
            return await _context.Users
                .Where(u => u.Id == userId)
                .Select(u => new MyAccountDTO
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

        public async Task UpdateMyAccountAsync(string userId, MyAccountDTO myAccount)
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


        public async Task<dynamic> GetUserImagePathAsync(string userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(au => au.Id == userId);
            if (user == null)
            {
                return null;
            }
            return user.ImagePath;
        }

        public async Task<IEnumerable<MyAddressDTO>> GetMyAddressesAsync(string userId)
        {
            var defaultAddressId = await _context.Users
                .Where(u => u.Id == userId)
                .Select(u => u.DefaultAddressDeliveryId)
                .FirstOrDefaultAsync();

            IEnumerable<MyAddressDTO> myAddresses = await _context.AddressDeliveries
                .Where(ad => ad.AppUserId == userId)
                .Select(ad => new MyAddressDTO
                {
                    AddressId = ad.Id,
                    FirstName = ad.FirstName,
                    LastName = ad.LastName,
                    PhoneNumber = ad.PhoneNumber,
                    Country = ad.Country,
                    PostCode = ad.PostCode,
                    Town = ad.Town,
                    Address = ad.Address,
                    District = ad.District,
                    Email = ad.Email,
                    ShippingProvider = ad.ShippingOffice.ShippingProvider.Name,
                    OfficeCity = ad.ShippingOffice.City,
                    OfficeAddress = ad.ShippingOffice.OfficeAddress,
                    IsOffice = ad.IsShippingToOffice,
                    IsDefault = ad.Id == defaultAddressId
                })
                //.OrderByDescending(ad => ad.IsDefault)
                .AsNoTracking()
                .ToListAsync();

            return myAddresses;
        }

        public async Task AddAddressAsync(string userId, AddressDTO model)
        {
            AddressDelivery address = new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Country = model.Country,
                PostCode = model.PostCode,
                Town = model.Town,
                Address = model.Address,
                District = model.District,
                Email = model.Email,
                AppUserId = userId,
                IsShippingToOffice = false
            };

            await _context.AddressDeliveries.AddAsync(address);

            await _context.SaveChangesAsync();
        }

        public async Task<AddressDTO?> GetAddressAsync(int addressId)
        {
            return await _context.AddressDeliveries
                .Where(ad => ad.Id == addressId)
                .Select(ad => new AddressDTO
                {
                    Id = ad.Id,
                    FirstName = ad.FirstName,
                    LastName = ad.LastName,
                    PhoneNumber = ad.PhoneNumber,
                    Country = ad.Country ?? string.Empty,
                    PostCode = ad.PostCode ?? string.Empty,
                    Town = ad.Town ?? string.Empty,
                    Address = ad.Address ?? string.Empty,
                    District = ad.District ?? string.Empty,
                    Email = ad.Email ?? string.Empty
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAddressAsync(string userId, AddressDTO model)
        {
            var address = await _context.AddressDeliveries.FirstOrDefaultAsync(ad => ad.Id == model.Id);
            if (address == null)
            {
                throw new InvalidOperationException("Address not found");
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
            address.IsShippingToOffice = false;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAddressAsync(int addressId)
        {
            var address = await _context.AddressDeliveries.FirstOrDefaultAsync(ad => ad.Id == addressId);

            if (address == null)
            {
                return;
            }
            _context.AddressDeliveries.Remove(address);

            var user = await _context.Users.FirstOrDefaultAsync(u => u.DefaultAddressDeliveryId == addressId);

            if (user != null)
            {
                user.DefaultAddressDelivery = null;
            }

            await _context.SaveChangesAsync();
        }

        public async Task SetDefaultAddressAsync(string userId, int addressId)
        {
            var users = await _context.Users.ToListAsync();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var address = await _context.AddressDeliveries.FirstOrDefaultAsync(ad => ad.Id == addressId);
            if (user != null && address != null)
            {
                user.DefaultAddressDelivery = address;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<OfficeDTO?> GetOfficeAsync(int addressId)
        {

            var office = await _context.AddressDeliveries
                .Where(ad => ad.Id == addressId)
                .Select(ad => new OfficeDTO
                {
                    Id = ad.Id,
                    ShippingProviderId = ad.ShippingOffice.ShippingProviderId,
                    ShippingOfficeId = ad.ShippingOfficeId,
                    FirstName = ad.FirstName,
                    LastName = ad.LastName,
                    PhoneNumber = ad.PhoneNumber,
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (office != null)
            {
                office.ShippingProviders = await _context.ShippingProviders
                    .Select(sp => new ShippingProviderDTO
                    {
                        Id = sp.Id,
                        Name = sp.Name,
                    })
                    .AsNoTracking()
                    .ToListAsync();

                office.ShippingOffices = await _context.ShippingOffices
                    .Select(so => new ShippingOfficeDTO
                    {
                        Id = so.Id,
                        City = so.City,
                        OfficeAddress = so.OfficeAddress
                    })
                    .AsNoTracking()
                    .ToListAsync();
            }

            return office;
        }

        public async Task UpdateOfficeAsync(string userId, OfficeDTO model)
        {
            var address = await _context.AddressDeliveries.FirstOrDefaultAsync(ad => ad.Id == model.Id);
            if (address == null)
            {
                throw new InvalidOperationException("Address not found");
            }
            address.FirstName = model.FirstName;
            address.LastName = model.LastName;
            address.PhoneNumber = model.PhoneNumber;
            address.ShippingOfficeId = model.ShippingOfficeId;
            address.AppUserId = userId;
            address.IsShippingToOffice = true;

            await _context.SaveChangesAsync();
        }
    }
}

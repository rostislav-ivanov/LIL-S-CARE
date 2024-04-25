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
            if (user == null)
            {
                return null;
            }
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
                    //Total = o.Total,
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
                    ShippingPrice = o.ShippingPrice,
                    //SubTotal = o.SubTotal,
                    Discount = o.Discount
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

            address.IsDeleted = true;
            address.IsDefault = false;

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
                    City = so.City,
                    OfficeAddress = so.OfficeAddress,
                    Price = so.Price,
                    ShippingDuration = so.ShippingDuration
                })
                .AsNoTracking()
                .ToListAsync();
        }


        // Add the office delivery address
        public async Task AddOfficeDeliveryAsync(string userId, OfficeDTO model)
        {
            AddressDelivery addressDelivery = new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                ShippingOfficeId = model.ShippingOfficeId,
                AppUserId = userId,
                IsShippingToOffice = true
            };

            await _context.AddressDeliveries.AddAsync(addressDelivery);

            await _context.SaveChangesAsync();
        }

        // Edit the office delivery address
        // If the address has any orders,
        // remain the address to the database.
        // Create a new address with the edited data to user
        // and remove the old address form the user
        // else edit the address
        public async Task EditOfficeDeliveryAsync(string userId, OfficeDTO model)
        {
            var address = await _context.AddressDeliveries.FirstOrDefaultAsync(ad => ad.Id == model.Id);

            if (address == null)
            {
                return;
            }

            address.AppUser = null;
            address.FirstName = model.FirstName;
            address.LastName = model.LastName;
            address.PhoneNumber = model.PhoneNumber;
            address.ShippingOfficeId = model.ShippingOfficeId;
            address.AppUserId = userId;
            address.IsShippingToOffice = true;

            await _context.SaveChangesAsync();
        }

        // Add the address delivery
        public async Task AddAddressDeliveryAsync(string userId, AddressDTO address)
        {
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
                IsShippingToOffice = false
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
        public async Task EditAddressDeliveryAsync(string userId, AddressDTO model)
        {
            var address = await _context.AddressDeliveries.FirstOrDefaultAsync(ad => ad.Id == model.Id);

            if (address == null)
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
            address.IsShippingToOffice = false;

            await _context.SaveChangesAsync();
        }

        // Get the delivery address to be edited
        public async Task<DeliveryAddressesDTO> GetAddressDeliveryAsync(int addressId)
        {
            DeliveryAddressesDTO addressDeliveryDTO = new();

            var addressDelivery = await _context.AddressDeliveries.FirstOrDefaultAsync(ad => ad.Id == addressId);

            if (addressDelivery?.IsShippingToOffice == true)  // If the delivery address is to office
            {
                addressDeliveryDTO.Office = await _context.AddressDeliveries
                    .Where(ad => ad.Id == addressId)
                    .Select(ad => new OfficeDTO
                    {
                        Id = ad.Id,
                        ShippingProviderId = ad.ShippingOffice!.ShippingProviderId,
                        ShippingOfficeId = ad.ShippingOfficeId,
                        FirstName = ad.FirstName,
                        LastName = ad.LastName,
                        PhoneNumber = ad.PhoneNumber,
                        CityName = ad.ShippingOffice.City
                    })
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                addressDeliveryDTO.Office!.ShippingProviders = await GetShippingProvidersAsync();

                addressDeliveryDTO.Office.ShippingProviderCities =
                    await GetShippingProviderCitiesAsync(addressDeliveryDTO.Office.ShippingProviderId ?? 0);

                addressDeliveryDTO.Office.ShippingOffices =
                    await GetShippingOfficesAsync(addressDeliveryDTO.Office.ShippingProviderId, addressDeliveryDTO.Office.CityName);
            }
            else if (addressDelivery?.IsShippingToOffice == false) // If the delivery address is to address
            {
                addressDeliveryDTO.Address = new AddressDTO
                {
                    Id = addressDelivery.Id,
                    FirstName = addressDelivery.FirstName,
                    LastName = addressDelivery.LastName,
                    PhoneNumber = addressDelivery.PhoneNumber,
                    Country = addressDelivery.Country ?? string.Empty,
                    PostCode = addressDelivery.PostCode ?? string.Empty,
                    Town = addressDelivery.Town ?? string.Empty,
                    Address = addressDelivery.Address ?? string.Empty,
                    District = addressDelivery.District ?? string.Empty,
                    Email = addressDelivery.Email ?? string.Empty
                };
            }

            return addressDeliveryDTO;
        }
    }
}

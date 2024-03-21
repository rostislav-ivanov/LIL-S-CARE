using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Account;
using LilsCareApp.Infrastructure.Data;
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
                throw new InvalidOperationException("User not found");
            }
            return user.ImagePath;
        }

    }
}

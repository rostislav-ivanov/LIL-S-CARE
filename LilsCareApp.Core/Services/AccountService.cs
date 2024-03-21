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
    }
}

using LilsCareApp.Core.Contracts;
using LilsCareApp.Infrastructure.Data;

namespace LilsCareApp.Core.Services
{
    public class AdminProductService : IAdminProductService
    {
        private readonly ApplicationDbContext _context;

        public AdminProductService(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}

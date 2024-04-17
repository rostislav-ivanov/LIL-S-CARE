using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Home;
using LilsCareApp.Infrastructure.Data;
using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LilsCareApp.Core.Services
{
    public class HomeService : IHomeService
    {
        private readonly ApplicationDbContext _context;

        public HomeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddToSubscribersAsync(SubscriberDTO subscriber)
        {
            await _context.Subscribers.AddAsync(new Subscriber
            {
                Email = subscriber.EmailSubscriber,
                DateAdded = DateTime.Now,
                AppUserId = subscriber.AppUserId
            });

            await _context.SaveChangesAsync();
        }

        public async Task MessageFromClientAsync(ContactUsDTO message)
        {
            var x = new MessageFromClient
            {
                FirstName = message.FirstName,
                LastName = message.LastName,
                EmailForResponse = message.EmailForResponse,
                Message = message.Message,
                DateSent = DateTime.Now,
                AppUserId = message.AppUserId
            };

            await _context.MessagesFromClients.AddAsync(new MessageFromClient
            {
                FirstName = message.FirstName,
                LastName = message.LastName,
                EmailForResponse = message.EmailForResponse,
                Message = message.Message,
                DateSent = DateTime.Now,
                AppUserId = message.AppUserId
            });

            await _context.SaveChangesAsync();
        }

        public async Task AddPromoCodeForFirstRegistrationAsync(string userId)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                return;
            }

            var promoCode = new PromoCode
            {
                Code = "-10 % за регистрация",
                Discount = 0.1m,
                ExpirationDate = DateTime.UtcNow.AddMonths(12),
                AppUserId = userId,
            };

            await _context.PromoCodes.AddAsync(promoCode);
            await _context.SaveChangesAsync();
        }

        public async Task EmailConfirmationAsync(string userId)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return;
            }

            user.EmailConfirmed = true;
            await _context.SaveChangesAsync();
        }
    }
}

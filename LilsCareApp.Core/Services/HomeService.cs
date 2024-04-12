using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Home;
using LilsCareApp.Infrastructure.Data;
using LilsCareApp.Infrastructure.Data.Models;

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


    }
}

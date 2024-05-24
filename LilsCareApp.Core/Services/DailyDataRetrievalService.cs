using LilsCareApp.Core.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LilsCareApp.Core.Services
{
    public class DailyDataRetrievalService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public DailyDataRetrievalService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var serviceProvider = scope.ServiceProvider;
                    var shippingProviderService = serviceProvider.GetRequiredService<IShippingProviderService>();

                    // Call the method to retrieve data once per day
                    await shippingProviderService.GetShippingProvidersAsync();
                }

                // Wait for 24 hours before the next execution
                await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
            }
        }
    }
}

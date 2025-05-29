using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Crushy.WebSocket;

namespace Crushy.Services
{
    public class MatchingBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<MatchingBackgroundService> _logger;

        public MatchingBackgroundService(IServiceProvider serviceProvider, ILogger<MatchingBackgroundService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var matchingService = scope.ServiceProvider.GetRequiredService<MatchingService>();
                        await matchingService.CheckAllUsersForMatching();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Matching background service hatası");
                }

                // Her 10 saniyede bir kontrol et
                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }
        }
    }
}
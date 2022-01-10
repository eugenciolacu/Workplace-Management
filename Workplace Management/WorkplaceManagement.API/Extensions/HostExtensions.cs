using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using WorkplaceManagement.Domain.Context;
using WorkplaceManagement.LoggerService;

namespace WorkplaceManagement.API.Extensions
{
    public static class HostExtensions
    {
        public static async Task SeedDataAsync(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    ApplicationContext applicationContext = services.GetRequiredService<ApplicationContext>();

                    await Seed.SeedTestData(applicationContext);
                }
                catch (Exception ex)
                {
                    ILoggerManager logger = services.GetRequiredService<ILoggerManager>();
                    logger.LogError(ex, "An error occured during database seeding");
                }
            }
        }
    }
}

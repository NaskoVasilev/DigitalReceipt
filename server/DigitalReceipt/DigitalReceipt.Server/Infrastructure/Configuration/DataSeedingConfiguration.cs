using DigitalReceipt.Data;
using DigitalReceipt.Data.Seeding;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalReceipt.Server.Infrastructure.Configuration
{
    public static class DataSeedingConfiguration
    {
        public static IApplicationBuilder SeedData(this IApplicationBuilder app)
        {
            using (IServiceScope serviceScope = app.ApplicationServices.CreateScope())
            {
                ApplicationDbContext dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                new DigitalReceiptSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            return app;
        }
    }
}

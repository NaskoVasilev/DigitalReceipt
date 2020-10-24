using DigitalReceipt.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalReceipt.Server.Infrastructure.Configuration
{
    public static class BusinessLogicConfiguration
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services
                .AddTransient<IUserService, UserService>()
                .AddTransient<IReceiptService, ReceiptService>();

            return services;
        }
    }
}

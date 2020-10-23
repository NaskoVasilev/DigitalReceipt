using DigitalReceipt.Server.Infrastructure.Configuration.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalReceipt.Server.Infrastructure.Configuration
{
    public static class SettingsConfiguration
    {
        public static IServiceCollection AddApplicationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSettings<ConnectionStrings>(nameof(ConnectionStrings), configuration);
            return services;
        }

        public static T AddSettings<T>(this IServiceCollection services, string sectionName, IConfiguration configuration)
            where T : class
        {
            T settings = configuration
               .GetSection(sectionName)
               .Get<T>();

            if (settings != null)
            {
                services.AddSingleton(settings);
            }

            return settings;
        }
    }
}

using DigitalReceipt.Common.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalReceipt.Server.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCorsRules(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddCors(options => options.AddPolicy("AllowWebApp", builder => builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .WithOrigins(appSettings.AllowedOrigins ?? new string[0])));

            return services;
        }
    }
}

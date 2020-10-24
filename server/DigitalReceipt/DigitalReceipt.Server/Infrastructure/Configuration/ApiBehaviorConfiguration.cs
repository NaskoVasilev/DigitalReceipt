using DigitalReceipt.Server.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalReceipt.Server.Infrastructure.Configuration
{
    public static class ApiBehaviorConfiguration
    {
        public static IServiceCollection ConfigureApiBehavior(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
                options.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    return new BadRequestObjectResult(actionContext.ModelState.Errors());
                };
            });

            return services;
        }
    }
}

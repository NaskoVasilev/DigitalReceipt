using DigitalReceipt.Server.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace DigitalReceipt.Server.Infrastructure.Filters
{
    public class ValidateModelStateActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState.Errors());
            }
            else
            {
                await next();
            }
        }
    }
}

using DigitalReceipt.Common;
using DigitalReceipt.Common.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace DigitalReceipt.Server.Infrastructure.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<ExceptionFilter> logger;
        private readonly AppSettings appSettings;

        public ExceptionFilter(ILogger<ExceptionFilter> logger, AppSettings appSettings)
        {
            this.logger = logger;
            this.appSettings = appSettings;
        }

        public override void OnException(ExceptionContext context)
        {
            string message = $"ErrorMessage: {context.Exception.Message}\n";
            if (context.Exception.InnerException != null)
            {
                message += $"Inner exception message: {context.Exception.InnerException.Message}\n";
                message += $"Inner exception stack trace: {context.Exception.InnerException.StackTrace}\n";
            }

            message += $"Stack trace: {context.Exception.StackTrace}\nException Date: {DateTime.UtcNow}";
            logger.LogError(context.Exception, message);

            // If expose stack trace is enabled, we return the error to the client(really helpful while developing the app) 
            // but expose stack trace should be disabled in production!!! Go to appsettings.json in AppSettings section and set ExposeStackTrace to false!!!
            if (appSettings.ExposeStackTrace)
            {
                context.Result = new BadRequestObjectResult(message);
            }
            else
            {
                context.Result = new BadRequestObjectResult(new string[] { ErrorMessages.GenericErrorMessage });
            }
        }
    }
}

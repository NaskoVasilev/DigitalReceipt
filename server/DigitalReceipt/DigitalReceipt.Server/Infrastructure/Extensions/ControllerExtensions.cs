using DigitalReceipt.Models.Common;
using Microsoft.AspNetCore.Mvc;

namespace DigitalReceipt.Server.Infrastructure.Extensions
{
    public static class ControllerExtensions
    {
        public static ActionResult ToActionResult(this ControllerBase controller, Result result)
        {
            if (result.Succeeded)
            {
                return controller.Ok();
            }
            else
            {
                return controller.BadRequest(result.Errors);
            }
        }
    }
}

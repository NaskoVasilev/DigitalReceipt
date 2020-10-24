using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DigitalReceipt.Server.Infrastructure.Extensions
{
    public static class IdentityResultExtensions
    {
        public static ActionResult ToActionResult(this IdentityResult identityResult, object responseData = null)
        {
            if (identityResult.Succeeded)
            {
                if (responseData != null)
                {
                    return new OkObjectResult(responseData);
                }
                else
                {
                    return new OkResult();
                }
            }
            else
            {
                return new BadRequestObjectResult(identityResult.Errors.Select(e => e.Description));
            }
        }
    }
}

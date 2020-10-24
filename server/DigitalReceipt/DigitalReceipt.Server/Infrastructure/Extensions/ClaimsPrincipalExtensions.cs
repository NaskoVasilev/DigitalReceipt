using System.Linq;
using System.Security.Claims;

namespace DigitalReceipt.Server.Infrastructure.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal user) =>
            user.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
    }
}

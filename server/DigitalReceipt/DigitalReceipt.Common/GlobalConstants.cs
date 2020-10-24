using System.Globalization;
using System.Security.Authentication;

namespace DigitalReceipt.Common
{
    public static class GlobalConstants
    {
        public const string CorsPolicy = "AllowWebApp";

        public static class AuthenticationConstants
        {
            public const int TokenShortExpirationTimeInDays = 1;
            public const int TokenLongExpirationTimeInDays = 7;
            public const int LockoutTimeInMinutes = 5;
            public const int MaxFailedAccessAttempts = 5;
        }

        public static class Roles
        {
            public const string Administrator = "Administrator";
            public const string Company = "Company";
            public const string Cashier = "Cashier";
        }
    }
}

using System.Collections.Generic;

namespace DigitalReceipt.Models.Users
{
    public class LoggedUserModel
    {
        public string UserId { get; set; }

        public string Email { get; set; }

        public IEnumerable<string> Roles { get; set; }

        public string Token { get; set; }
    }
}

using DigitalReceipt.Data.Enums;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DigitalReceipt.Data.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            Receipts = new HashSet<Receipt>();
        }

        public UserPreferences? Preferences { get; set; }

        public ICollection<Receipt> Receipts { get; set; }
    }
}

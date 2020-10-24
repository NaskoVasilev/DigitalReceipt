using DigitalReceipt.Common.Mappings;
using DigitalReceipt.Data.Enums;
using DigitalReceipt.Data.Models;

namespace DigitalReceipt.Models.Users
{
    public class UserPreferenceInputModel : IMapTo<User>
    {
        public UserPreferences? Preferences { get; set; }
    }
}

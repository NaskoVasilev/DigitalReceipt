using static DigitalReceipt.Common.ModelConstants.UserConstants;
using System.ComponentModel.DataAnnotations;
using DigitalReceipt.Common.Mappings;
using DigitalReceipt.Data.Models;

namespace DigitalReceipt.Models.Users
{
    public class CreateCashierModel : IMapTo<User>
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
        public string Password { get; set; } 
    }
}

using static DigitalReceipt.Common.ModelConstants.UserConstants;
using System.ComponentModel.DataAnnotations;
using DigitalReceipt.Common.Mappings;
using DigitalReceipt.Data.Models;

namespace DigitalReceipt.Models.Users
{
    public class RegisterInputModel : IMapFrom<User>
    {
        [Required]
        [EmailAddress]
        [MaxLength(EmailAddressMaxLength)]
        public string Email { get; set; }

        [Required]
        [StringLength(PasswordMinLength, MinimumLength = PasswordMaxLength)]
        public string Password { get; set; }
    }
}

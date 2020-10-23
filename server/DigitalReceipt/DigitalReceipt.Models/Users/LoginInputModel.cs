using System.ComponentModel.DataAnnotations;
using static DigitalReceipt.Common.ModelConstants.UserConstants;

namespace DigitalReceipt.Models.Users
{
    public class LoginInputModel
    {
        [Required]
        [MaxLength(EmailAddressMaxLength)]
        public string Email { get; set; }

        [Required]
        [MaxLength(PasswordMaxLength)]
        public string Password { get; set; }

        public bool Remember { get; set; }
    }
}

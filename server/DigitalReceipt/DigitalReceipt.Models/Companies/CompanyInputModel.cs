using DigitalReceipt.Common.Mappings;
using DigitalReceipt.Data.Models;
using System.ComponentModel.DataAnnotations;
using static DigitalReceipt.Common.ModelConstants;

namespace DigitalReceipt.Models.Companies
{
    public class CompanyInputModel : IMapTo<Company>
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(UserConstants.PasswordMaxLength, MinimumLength = UserConstants.PasswordMinLength)]
        public string Password { get; set; }

        [Required]
        [MaxLength(CompanyConstants.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(CompanyConstants.AddressMaxLength)]
        public string Address { get; set; }
    }
}

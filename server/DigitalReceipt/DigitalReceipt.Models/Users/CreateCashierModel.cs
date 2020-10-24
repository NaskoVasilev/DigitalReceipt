using static DigitalReceipt.Common.ModelConstants.UserConstants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
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

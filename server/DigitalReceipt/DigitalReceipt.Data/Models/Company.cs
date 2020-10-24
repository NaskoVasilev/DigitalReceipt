using DigitalReceipt.Data.Common;
using System.Collections.Generic;

namespace DigitalReceipt.Data.Models
{
    public class Company : Entity<int>
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public ICollection<Receipt> Receipts { get; set; }
    }
}

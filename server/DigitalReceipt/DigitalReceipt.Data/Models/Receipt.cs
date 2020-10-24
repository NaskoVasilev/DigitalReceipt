using DigitalReceipt.Data.Common;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DigitalReceipt.Data.Models
{
    public class Receipt : AuditableEntity<int>
    {
        public Receipt()
        {
            Products = new HashSet<ReceiptProduct>();
        }

        public DateTime Date { get; set; }

        // TODO: extract the address in different table
        public string Address { get; set; }

        public string CashierId { get; set; }
        public User Cashier { get; set; }

        public string Number { get; set; }

        public string FiscalNumber { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public ICollection<ReceiptProduct> Products { get; set; }
    }
}

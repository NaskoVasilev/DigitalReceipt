using DigitalReceipt.Data.Common;
using System;
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

        public string CashierName { get; set; }

        public string Number { get; set; }

        public string FiscalNumber { get; set; }

        public string UIC { get; set; }

        public string CompanyAddress { get; set; }

        public string StoreName { get; set; }

        public string StoreAddress { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public string TaxNumber { get; set; }

        public string ClientNumber { get; set; }

        public string IdFiscalNumber { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public ICollection<ReceiptProduct> Products { get; set; }
    }
}

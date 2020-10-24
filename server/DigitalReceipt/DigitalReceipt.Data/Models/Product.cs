using DigitalReceipt.Data.Common;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DigitalReceipt.Data.Models
{
    public class Product : Entity<int>
    {
        public Product()
        {
            Receipts = new HashSet<ReceiptProduct>();
        }

        public string Name { get; set; }

        public string Barcode { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public ICollection<ReceiptProduct> Receipts { get; set; }
    }
}

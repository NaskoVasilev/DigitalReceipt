using DigitalReceipt.Models.Products;
using System.Collections.Generic;

namespace DigitalReceipt.Models.Receipts
{
    public class ReceiptByCompanyViewModel
    {
        public string CompanyName { get; set; }

        public IEnumerable<ReceiptViewModel> Receipts { get; set; }
    }
}

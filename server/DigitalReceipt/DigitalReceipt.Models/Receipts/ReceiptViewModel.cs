using DigitalReceipt.Models.Products;
using System;
using System.Collections.Generic;
using DigitalReceipt.Common.Mappings;
using DigitalReceipt.Data.Models;

namespace DigitalReceipt.Models.Receipts
{
    public class ReceiptViewModel : IMapFrom<Receipt>
    {
        public DateTime Date { get; set; }

        public string CashierName { get; set; }

        public string Number { get; set; }

        public string FiscalNumber { get; set; }

        public string UIC { get; set; }

        public string CompanyAddress { get; set; }

        public string StoreName { get; set; }

        public string StoreAddress { get; set; }

        public string CompanyName { get; set; }

        public string TaxNumber { get; set; }

        public string ClientNumber { get; set; }

        public string IdFiscalNumber { get; set; }

        public IList<ProductViewModel> Products { get; set; }
    }
}

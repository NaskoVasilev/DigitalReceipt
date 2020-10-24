using AutoMapper;
using DigitalReceipt.Common.Mappings;
using DigitalReceipt.Data.Models;
using DigitalReceipt.Models.Products;
using System;
using System.Collections.Generic;

namespace DigitalReceipt.Models.Receipts
{
    public class ReceiptInputModel : IHaveCustomMappings
    {
        public DateTime Date { get; set; }

        public string CashierName { get; set; }

        public string Number { get; set; }

        public string FiscalNumber { get; set; }

        public string UIC { get; set; }

        public string CompanyName { get; set; }

        public string CompanyAddress { get; set; }

        public string StoreName { get; set; }

        public string StoreAddress { get; set; }

        public string TaxNumber { get; set; }

        public string ClientNumber { get; set; }

        public string IdFiscalNumber { get; set; }

        public string UserId { get; set; }

        public IEnumerable<ProductInputModel> Products { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ReceiptInputModel, Receipt>()
                .ForMember(m => m.Products, y => y.Ignore());
        }
    }
}
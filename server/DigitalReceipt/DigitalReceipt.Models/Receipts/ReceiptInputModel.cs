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
        public string UserId { get; set; }

        public string Number { get; set; }

        public string FiscalNumber { get; set; }

        public string CashierId { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<ProductInputModel> Products { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ReceiptInputModel, Receipt>()
                .ForMember(m => m.Products, y => y.Ignore());
        }
    }
}
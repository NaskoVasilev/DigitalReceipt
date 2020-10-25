using AutoMapper;
using DigitalReceipt.Common.Mappings;
using DigitalReceipt.Data.Enums;
using DigitalReceipt.Data.Models;

namespace DigitalReceipt.Models.Products
{
    public class ProductViewModel : IHaveCustomMappings
    {
        public string Name { get; set; }

        public string Barcode { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public ProductCategory? Category { get; set; }

        public int Quantity { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ReceiptProduct, ProductViewModel>()
                .ForMember(m => m.Name, y => y.MapFrom(e => e.Product.Name))
                .ForMember(m => m.Barcode, y => y.MapFrom(e => e.Product.Barcode))
                .ForMember(m => m.Price, y => y.MapFrom(e => e.Product.Price))
                .ForMember(m => m.Discount, y => y.MapFrom(e => e.Product.Discount));
        }
    }
}

using DigitalReceipt.Common.Mappings;
using DigitalReceipt.Data.Models;
using System.ComponentModel.DataAnnotations;
using static DigitalReceipt.Common.ModelConstants.ProductConstants;

namespace DigitalReceipt.Models.Products
{
    public class ProductInputModel : IMapTo<Product>
    {
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(BarcodeMaxLength)]
        public string Barcode { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }
    }
}

using DigitalReceipt.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static DigitalReceipt.Common.ModelConstants.ProductConstants;

namespace DigitalReceipt.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            builder
                .Property(p => p.Barcode)
                .IsRequired()
                .HasMaxLength(BarcodeMaxLength);
        }
    }
}

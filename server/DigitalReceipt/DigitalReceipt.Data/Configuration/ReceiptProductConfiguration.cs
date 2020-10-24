using DigitalReceipt.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalReceipt.Data.Configuration
{
    public class ReceiptProductConfiguration : IEntityTypeConfiguration<ReceiptProduct>
    {
        public void Configure(EntityTypeBuilder<ReceiptProduct> builder)
        {
            builder.HasKey(e => new { e.ReceiptId, e.ProductId });
        }
    }
}

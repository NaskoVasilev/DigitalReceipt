using DigitalReceipt.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalReceipt.Data.Configuration
{
    public class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            builder
                .Property(e => e.UserId)
                .IsRequired();

            builder
                .HasOne(e => e.User)
                .WithMany(e => e.Receipts);

            builder
                .HasOne(e => e.Cashier)
                .WithMany(e => e.IssuedReceipts);
        }
    }
}

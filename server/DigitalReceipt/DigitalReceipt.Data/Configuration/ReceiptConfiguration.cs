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
                .Property(e => e.Address)
                .IsRequired();

            builder
              .Property(e => e.CashierName)
              .IsRequired();

            builder
              .Property(e => e.ClientNumber)
              .IsRequired();

            builder
              .Property(e => e.FiscalNumber)
              .IsRequired();

            builder
              .Property(e => e.IdFiscalNumber)
              .IsRequired();

            builder
              .Property(e => e.Number)
              .IsRequired();

            builder
              .Property(e => e.TaxNumber)
              .IsRequired();

            builder
              .Property(e => e.UIC)
              .IsRequired();
        }
    }
}

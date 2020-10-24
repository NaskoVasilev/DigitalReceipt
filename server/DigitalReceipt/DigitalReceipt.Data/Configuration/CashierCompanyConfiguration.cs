using DigitalReceipt.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalReceipt.Data.Configuration
{
    public class CashierCompanyConfiguration : IEntityTypeConfiguration<CashierCompany>
    {
        public void Configure(EntityTypeBuilder<CashierCompany> builder)
        {
            builder.Property(e => e.UserId).IsRequired();

            builder.Property(e => e.CashierId).IsRequired();
        }
    }
}

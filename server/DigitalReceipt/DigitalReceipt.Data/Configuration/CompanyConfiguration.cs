using DigitalReceipt.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static DigitalReceipt.Common.ModelConstants.CompanyConstants;

namespace DigitalReceipt.Data.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder
                .Property(e => e.UserId)
                .HasMaxLength(NameMaxLength)
                .IsRequired();

            builder
                .Property(e => e.Address)
                .HasMaxLength(AddressMaxLength)
                .IsRequired();

            builder
                .Property(e => e.Name)
                .IsRequired();
        }
    }
}

using Marketplacesellerportal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marketplacesellerportal.CustomerAddresses
{
    public class CustomerAddressConfiguration
        : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(
            EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.ToTable("CustomerAddresses", "dbo");

            // ============================================================
            // PRIMARY KEY
            // ============================================================

            builder.HasKey(x => x.CustomerAddressId);

            builder.Property(x => x.CustomerAddressId)
                .HasColumnName("CustomerAddressId");

            // ============================================================
            // CUSTOMER
            // ============================================================

            builder.Property(x => x.CustomerId)
                .IsRequired();

            // ============================================================
            // ADDRESS TYPE
            // ============================================================

            builder.Property(x => x.AddressType)
                .HasMaxLength(50)
                .IsRequired();

            // ============================================================
            // ADDRESS
            // ============================================================

            builder.Property(x => x.AddressLine1)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.AddressLine2)
                .HasMaxLength(250);

            // ============================================================
            // LOCATION
            // ============================================================

            builder.Property(x => x.City)
                .HasMaxLength(100);

            builder.Property(x => x.State)
                .HasMaxLength(100);

            builder.Property(x => x.Country)
                .HasMaxLength(100);

            builder.Property(x => x.PostalCode)
                .HasMaxLength(20);

            // ============================================================
            // DEFAULT ADDRESS
            // ============================================================

            builder.Property(x => x.IsDefault)
                .HasDefaultValue(false);

            // ============================================================
            // CREATED DATE
            // ============================================================

            builder.Property(x => x.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
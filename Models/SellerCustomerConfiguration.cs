using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SellerCustomerEntity = Marketplacesellerportal.Models.SellerCustomer;

namespace Marketplacesellerportal.Database.Configurations
{
    public class SellerCustomerConfiguration : IEntityTypeConfiguration<SellerCustomerEntity>
    {
        public void Configure(EntityTypeBuilder<SellerCustomerEntity> builder)
        {
            builder.ToTable("SellerCustomers");

            builder.HasKey(c => c.CustomerId);

            builder.HasOne(c => c.Seller)
               .WithMany()
               .HasForeignKey(c => c.SellerId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(c => new { c.SellerId, c.CustomerCode }).IsUnique()
                .HasDatabaseName("IX_SellerCustomers_SellerId_CustomerCode");
            builder.HasIndex(c => c.SellerId).HasDatabaseName("IX_SellerCustomers_SellerId");
            builder.HasIndex(c => c.Email).HasDatabaseName("IX_SellerCustomers_Email");
            builder.HasIndex(c => c.GSTIN).HasDatabaseName("IX_SellerCustomers_GSTIN");

            builder.Property(c => c.CustomerCode).HasMaxLength(50);
            builder.Property(c => c.CustomerName).IsRequired().HasMaxLength(200);
            builder.Property(c => c.TradeName).HasMaxLength(200);
            builder.Property(c => c.LegalName).HasMaxLength(200);
            builder.Property(c => c.ContactPerson).HasMaxLength(200);
            builder.Property(c => c.Email).HasMaxLength(150);
            builder.Property(c => c.Phone).HasMaxLength(20);
            builder.Property(c => c.GSTIN).HasMaxLength(15);
            builder.Property(c => c.AddressLine1).HasMaxLength(200);
            builder.Property(c => c.AddressLine2).HasMaxLength(200);
            builder.Property(c => c.BuildingName).HasMaxLength(200);
            builder.Property(c => c.Location).HasMaxLength(200);
            builder.Property(c => c.City).HasMaxLength(100);
            builder.Property(c => c.State).HasMaxLength(100);
            builder.Property(c => c.StateCode).HasMaxLength(10);
            builder.Property(c => c.FloorNo).HasMaxLength(50);
            builder.Property(c => c.Country).HasMaxLength(100);
            builder.Property(c => c.PostalCode).HasMaxLength(20);

            builder.Property(c => c.CreditLimit).HasPrecision(18, 2);
            builder.Property(c => c.IsActive).IsRequired().HasDefaultValue(true);
            builder.Property(c => c.CreatedDate).IsRequired().HasDefaultValueSql("GETUTCDATE()");
            builder.Property(c => c.UpdatedDate).IsRequired(false);

            // These are loaded manually, not via EF relations
            builder.Ignore(c => c.StockMovements);
            builder.Ignore(c => c.StockLedgers);
            builder.Ignore(c => c.Warehouses);
        }
    }
}
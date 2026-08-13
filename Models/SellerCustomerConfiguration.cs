using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Database.Configurations
{
    public class SellerCustomerConfiguration
        : IEntityTypeConfiguration<SellerCustomer>
    {
        public void Configure(
            EntityTypeBuilder<SellerCustomer> builder)
        {
            builder.HasKey(c => c.CustomerId);

            builder.Property(c => c.CustomerId)
                .ValueGeneratedOnAdd();

            // Seller -> SellerCustomer
            builder.HasOne<Seller>()
                .WithMany()
                .HasForeignKey(c => c.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            // CustomerCode
            builder.Property(c => c.CustomerCode)
                .HasMaxLength(50);

            // CustomerName
            builder.Property(c => c.CustomerName)
                .IsRequired()
                .HasMaxLength(200);

            // ContactPerson
            builder.Property(c => c.ContactPerson)
                .HasMaxLength(200);

            // Email
            builder.Property(c => c.Email)
                .HasMaxLength(150);

            // Phone
            builder.Property(c => c.Phone)
                .HasMaxLength(20);

            // GSTIN
            builder.Property(c => c.GSTIN)
                .HasMaxLength(15);

            // Address
            builder.Property(c => c.AddressLine1)
                .HasMaxLength(200);

            builder.Property(c => c.AddressLine2)
                .HasMaxLength(200);

            // Location
            builder.Property(c => c.City)
                .HasMaxLength(100);

            builder.Property(c => c.State)
                .HasMaxLength(100);

            builder.Property(c => c.Country)
                .HasMaxLength(100);

            builder.Property(c => c.PostalCode)
                .HasMaxLength(20);

            // Credit Limit
            builder.Property(c => c.CreditLimit)
                .HasPrecision(18, 2);
        }
    }
}

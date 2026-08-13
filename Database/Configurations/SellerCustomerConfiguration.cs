using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.SellerCustomers.Configurations
{
    public class SellerCustomerConfiguration
        : IEntityTypeConfiguration<SellerCustomer>
    {
        public void Configure(
            EntityTypeBuilder<SellerCustomer> builder)
        {
            // Composite Primary Key
            builder.HasKey(x => new
            {
                x.SellerId,
                x.CustomerId
            });

            // Seller -> Customers
            builder.HasOne<Seller>()
                .WithMany()
                .HasForeignKey(x => x.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.CustomerName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.CustomerCode)
                .HasMaxLength(50);

            builder.Property(x => x.Email)
                .HasMaxLength(150);

            builder.Property(x => x.Phone)
                .HasMaxLength(20);

            builder.Property(x => x.GSTIN)
                .HasMaxLength(15);

            builder.Property(x => x.CreditLimit)
                .HasColumnType("decimal(18,2)");
        }
    }
}

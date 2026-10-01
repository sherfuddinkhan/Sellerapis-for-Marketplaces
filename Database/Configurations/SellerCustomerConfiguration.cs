using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SellerCustomerEntity =
    Marketplacesellerportal.Models.SellerCustomer;

namespace Marketplacesellerportal.SellerCustomers.Configurations
{
    public class SellerCustomerConfiguration
        : IEntityTypeConfiguration<SellerCustomerEntity>
    {
        public void Configure(
            EntityTypeBuilder<SellerCustomerEntity> builder)
        {
            // =====================================================
            // TABLE
            // =====================================================

            builder.ToTable(
                "SellerCustomers",
                "dbo");


            // =====================================================
            // COMPOSITE PRIMARY KEY
            // =====================================================

            builder.HasKey(x => new
            {
                x.SellerId,
                x.CustomerId
            });


            // =====================================================
            // SELLER -> SELLER CUSTOMERS
            //
            // IMPORTANT:
            // Explicitly use x.Seller.
            //
            // DO NOT use:
            //
            // builder.HasOne<Seller>()
            //
            // because SellerCustomer already contains:
            //
            // public Seller? Seller { get; set; }
            //
            // Explicit navigation mapping prevents EF from
            // creating a shadow SellerId1 column.
            // =====================================================

            builder.HasOne(x => x.Seller)
                .WithMany()
                .HasForeignKey(x => x.SellerId)
                .OnDelete(DeleteBehavior.Restrict);


            // =====================================================
            // CUSTOMER CODE
            // =====================================================

            builder.Property(x => x.CustomerCode)
                .HasMaxLength(50);


            // =====================================================
            // CUSTOMER NAME
            // =====================================================

            builder.Property(x => x.CustomerName)
                .HasMaxLength(200)
                .IsRequired();


            // =====================================================
            // TRADE NAME
            // =====================================================

            builder.Property(x => x.TradeName)
                .HasMaxLength(200);


            // =====================================================
            // LEGAL NAME
            // =====================================================

            builder.Property(x => x.LegalName)
                .HasMaxLength(200);


            // =====================================================
            // CONTACT PERSON
            // =====================================================

            builder.Property(x => x.ContactPerson)
                .HasMaxLength(200);


            // =====================================================
            // EMAIL
            // =====================================================

            builder.Property(x => x.Email)
                .HasMaxLength(150);


            // =====================================================
            // PHONE
            // =====================================================

            builder.Property(x => x.Phone)
                .HasMaxLength(20);


            // =====================================================
            // GSTIN
            // =====================================================

            builder.Property(x => x.GSTIN)
                .HasMaxLength(15);


            // =====================================================
            // ADDRESS
            // =====================================================

            builder.Property(x => x.AddressLine1)
                .HasMaxLength(200);

            builder.Property(x => x.AddressLine2)
                .HasMaxLength(200);

            builder.Property(x => x.BuildingName)
                .HasMaxLength(200);

            builder.Property(x => x.Location)
                .HasMaxLength(200);

            builder.Property(x => x.City)
                .HasMaxLength(100);

            builder.Property(x => x.State)
                .HasMaxLength(100);

            builder.Property(x => x.StateCode)
                .HasMaxLength(10);

            builder.Property(x => x.FloorNo)
                .HasMaxLength(50);

            builder.Property(x => x.Country)
                .HasMaxLength(100);

            builder.Property(x => x.PostalCode)
                .HasMaxLength(20);


            // =====================================================
            // FINANCIAL
            // =====================================================

            builder.Property(x => x.CreditLimit)
                .HasColumnType("decimal(18,2)");


            // =====================================================
            // STATUS
            // =====================================================

            builder.Property(x => x.IsActive)
                .IsRequired();


            // =====================================================
            // DATES
            // =====================================================

            builder.Property(x => x.CreatedDate)
                .IsRequired();

            builder.Property(x => x.UpdatedDate);
        }
    }
}
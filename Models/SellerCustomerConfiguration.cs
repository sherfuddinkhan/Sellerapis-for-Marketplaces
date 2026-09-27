using Marketplacesellerportal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Database.Configurations
{
    public class SellerCustomerConfiguration
        : IEntityTypeConfiguration<SellerCustomer>
    {
        public void Configure(EntityTypeBuilder<SellerCustomer> builder)
        {
            // =========================================================
            // TABLE
            // =========================================================

            builder.ToTable("SellerCustomers");

            // =========================================================
            // PRIMARY KEY
            // =========================================================

            builder.HasKey(c => c.CustomerId);

            builder.Property(c => c.CustomerId)
                .ValueGeneratedOnAdd();

            // =========================================================
            // SELLER RELATIONSHIP
            // =========================================================

            builder.Property(c => c.SellerId)
                .IsRequired();

            builder.HasOne<Seller>()
                .WithMany()
                .HasForeignKey(c => c.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            // =========================================================
            // CUSTOMER CODE
            // =========================================================

            builder.Property(c => c.CustomerCode)
                .HasMaxLength(50);

            // =========================================================
            // CUSTOMER NAME
            // =========================================================

            builder.Property(c => c.CustomerName)
                .IsRequired()
                .HasMaxLength(200);

            // =========================================================
            // BUSINESS / LEGAL DETAILS
            // =========================================================

            builder.Property(c => c.TradeName)
                .HasMaxLength(200);

            builder.Property(c => c.LegalName)
                .HasMaxLength(200);

            builder.Property(c => c.ContactPerson)
                .HasMaxLength(200);

            // =========================================================
            // CONTACT DETAILS
            // =========================================================

            builder.Property(c => c.Email)
                .HasMaxLength(150);

            builder.Property(c => c.Phone)
                .HasMaxLength(20);

            // =========================================================
            // TAX DETAILS
            // =========================================================

            builder.Property(c => c.GSTIN)
                .HasMaxLength(15);

            // =========================================================
            // ADDRESS DETAILS
            // =========================================================

            builder.Property(c => c.AddressLine1)
                .HasMaxLength(200);

            builder.Property(c => c.AddressLine2)
                .HasMaxLength(200);

            builder.Property(c => c.BuildingName)
                .HasMaxLength(200);

            builder.Property(c => c.Location)
                .HasMaxLength(200);

            builder.Property(c => c.City)
                .HasMaxLength(100);

            builder.Property(c => c.State)
                .HasMaxLength(100);

            builder.Property(c => c.StateCode)
                .HasMaxLength(10);

            builder.Property(c => c.FloorNo)
                .HasMaxLength(50);

            builder.Property(c => c.Country)
                .HasMaxLength(100);

            builder.Property(c => c.PostalCode)
                .HasMaxLength(20);

            // =========================================================
            // FINANCIAL DETAILS
            // =========================================================

            builder.Property(c => c.CreditLimit)
                .HasPrecision(18, 2);

            // =========================================================
            // STATUS
            // =========================================================

            builder.Property(c => c.IsActive)
                .IsRequired();

            // =========================================================
            // AUDIT
            // =========================================================

            builder.Property(c => c.CreatedDate)
                .IsRequired();

            builder.Property(c => c.UpdatedDate);

            // =========================================================
            // NOT MAPPED PROPERTIES
            // =========================================================
            // StockMovements, StockLedgers and Warehouses are already
            // marked [NotMapped] in SellerCustomer.cs and therefore
            // are intentionally not configured as database relationships.
        }
    }

}
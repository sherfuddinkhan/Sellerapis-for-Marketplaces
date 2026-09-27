using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.SalesInvoices.Configurations
{
    public class SalesInvoiceAdditionalChargeConfiguration
        : IEntityTypeConfiguration<SalesInvoiceAdditionalCharge>
    {
        public void Configure(
            EntityTypeBuilder<SalesInvoiceAdditionalCharge> entity)
        {
            // =========================================================
            // PRIMARY KEY / IDENTITY
            // =========================================================

            entity.HasKey(x => x.SalesInvoiceAdditionalChargeId);

            entity.Property(x => x.SalesInvoiceAdditionalChargeId)
                  .ValueGeneratedOnAdd();


            // =========================================================
            // REQUIRED FIELDS
            // =========================================================

            entity.Property(x => x.SalesInvoiceId)
                  .IsRequired();

            entity.Property(x => x.ChargeName)
                  .HasMaxLength(200)
                  .IsRequired();


            // =========================================================
            // CHARGE DETAILS
            // =========================================================

            entity.Property(x => x.ChargeType)
                  .HasMaxLength(100);


            // =========================================================
            // DECIMAL FIELDS
            // =========================================================

            entity.Property(x => x.Amount)
                  .HasColumnType("decimal(18,2)");

            entity.Property(x => x.TaxPercentage)
                  .HasColumnType("decimal(18,2)");

            entity.Property(x => x.TaxAmount)
                  .HasColumnType("decimal(18,2)");

            entity.Property(x => x.TotalAmount)
                  .HasColumnType("decimal(18,2)");


            // =========================================================
            // REMARKS
            // =========================================================

            entity.Property(x => x.Remarks)
                  .HasMaxLength(1000);


            // =========================================================
            // FOREIGN KEY
            // SalesInvoice 1 ---> MANY AdditionalCharges
            // =========================================================

            entity.HasOne(x => x.SalesInvoice)
                  .WithMany(x => x.AdditionalCharges)
                  .HasForeignKey(x => x.SalesInvoiceId)
                  .OnDelete(DeleteBehavior.Cascade);


            // =========================================================
            // INDEX
            // =========================================================

            entity.HasIndex(x => x.SalesInvoiceId);
        }
    }
}

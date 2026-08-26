using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.SalesInvoices.Configurations
{
    public class SalesInvoiceConfiguration : IEntityTypeConfiguration<SalesInvoice>
    {
        public void Configure(EntityTypeBuilder<SalesInvoice> entity)
        {
            // =========================================================
            // PRIMARY KEY / IDENTITY
            // =========================================================

            entity.HasKey(x => x.SalesInvoiceId);

            entity.Property(x => x.SalesInvoiceId)
                  .ValueGeneratedOnAdd();

            // =========================================================
            // REQUIRED FIELDS
            // =========================================================

            entity.Property(x => x.InvoiceNumber)
                  .HasMaxLength(100)
                  .IsRequired();

            // =========================================================
            // DECIMAL FIELDS
            // =========================================================

            entity.Property(x => x.SubTotal)
                  .HasColumnType("decimal(18,2)");

            entity.Property(x => x.DiscountAmount)
                  .HasColumnType("decimal(18,2)");

            entity.Property(x => x.TaxAmount)
                  .HasColumnType("decimal(18,2)");

            entity.Property(x => x.TotalAmount)
                  .HasColumnType("decimal(18,2)");

            entity.Property(x => x.PaidAmount)
                  .HasColumnType("decimal(18,2)");

            entity.Property(x => x.BalanceAmount)
                  .HasColumnType("decimal(18,2)");

            // =========================================================
            // STRING FIELDS
            // =========================================================

            entity.Property(x => x.InvoiceScenario)
                  .HasMaxLength(100);

            entity.Property(x => x.Category)
                  .HasMaxLength(100);

            entity.Property(x => x.TransactionType)
                  .HasMaxLength(100);

            entity.Property(x => x.UserGSTIN)
                  .HasMaxLength(15);

            entity.Property(x => x.DocumentType)
                  .HasMaxLength(100);

            entity.Property(x => x.SupplyType)
                  .HasMaxLength(100);

            entity.Property(x => x.PlaceOfSupply)
                  .HasMaxLength(100);

            entity.Property(x => x.FinancialYear)
                  .HasMaxLength(20);

            entity.Property(x => x.Id)
                  .HasMaxLength(100);

            entity.Property(x => x.RefId)
                  .HasMaxLength(100);

            entity.Property(x => x.PaymentStatus)
                  .HasMaxLength(50);

            entity.Property(x => x.Status)
                  .HasMaxLength(50);

            entity.Property(x => x.Remarks)
                  .HasMaxLength(1000);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.SalesInvoices.Configurations
{
    public class SalesInvoicePaymentConfiguration
        : IEntityTypeConfiguration<SalesInvoicePayment>
    {
        public void Configure(EntityTypeBuilder<SalesInvoicePayment> entity)
        {
            // =========================================================
            // PRIMARY KEY / IDENTITY
            // =========================================================

            entity.HasKey(x => x.SalesInvoicePaymentId);

            entity.Property(x => x.SalesInvoicePaymentId)
                  .ValueGeneratedOnAdd();


            // =========================================================
            // REQUIRED FIELDS
            // =========================================================

            entity.Property(x => x.SalesInvoiceId)
                  .IsRequired();

            entity.Property(x => x.PaymentDate)
                  .IsRequired();


            // =========================================================
            // PAYMENT AMOUNT
            // =========================================================

            entity.Property(x => x.Amount)
                  .HasColumnType("decimal(18,2)");


            // =========================================================
            // STRING FIELDS
            // =========================================================

            entity.Property(x => x.PaymentMode)
                  .HasMaxLength(100);

            entity.Property(x => x.ReferenceNumber)
                  .HasMaxLength(200);

            entity.Property(x => x.Remarks)
                  .HasMaxLength(1000);


            // =========================================================
            // FOREIGN KEY
            // SalesInvoice 1 ---> MANY SalesInvoicePayments
            // =========================================================

            entity.HasOne(x => x.SalesInvoice)
                  .WithMany(x => x.Payments)
                  .HasForeignKey(x => x.SalesInvoiceId)
                  .OnDelete(DeleteBehavior.Cascade);


            // =========================================================
            // INDEX
            // =========================================================

            entity.HasIndex(x => x.SalesInvoiceId);

            entity.HasIndex(x => x.PaymentDate);
        }
    }
}

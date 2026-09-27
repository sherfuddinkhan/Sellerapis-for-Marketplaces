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
            // BASIC / REQUIRED FIELDS
            // =========================================================

            entity.Property(x => x.InvoiceNumber)
                  .HasMaxLength(100)
                  .IsRequired();


            // =========================================================
            // CUSTOMER / BUYER SNAPSHOT
            // =========================================================

            entity.Property(x => x.CompanyName)
                  .HasMaxLength(250);

            entity.Property(x => x.MobileNo)
                  .HasMaxLength(30);

            entity.Property(x => x.EmailAddress)
                  .HasMaxLength(250);

            entity.Property(x => x.CompanyAddress)
                  .HasMaxLength(500);

            entity.Property(x => x.CompanyCity)
                  .HasMaxLength(100);

            entity.Property(x => x.CompanyState)
                  .HasMaxLength(100);

            entity.Property(x => x.CompanyPINCode)
                  .HasMaxLength(20);

            entity.Property(x => x.CustomerGSTIN)
                  .HasMaxLength(15);


            // =========================================================
            // INVOICE DETAILS
            // =========================================================

            entity.Property(x => x.InvoiceScenario)
                  .HasMaxLength(100);

            entity.Property(x => x.Category)
                  .HasMaxLength(100);

            entity.Property(x => x.TransactionType)
                  .HasMaxLength(100);


            // =========================================================
            // PURCHASE ORDER / REFERENCE DETAILS
            // =========================================================

            entity.Property(x => x.PurchaseOrderNo)
                  .HasMaxLength(100);

            entity.Property(x => x.OtherReferences)
                  .HasMaxLength(500);

            entity.Property(x => x.DespatchedDocumentNumber)
                  .HasMaxLength(100);


            // =========================================================
            // GST / TAX DETAILS
            // =========================================================

            entity.Property(x => x.UserGSTIN)
                  .HasMaxLength(15);

            entity.Property(x => x.DocumentType)
                  .HasMaxLength(100);

            entity.Property(x => x.SupplyType)
                  .HasMaxLength(100);

            entity.Property(x => x.PlaceOfSupply)
                  .HasMaxLength(100);

            entity.Property(x => x.StateCode)
                  .HasMaxLength(20);

            entity.Property(x => x.FinancialYear)
                  .HasMaxLength(20);


            // =========================================================
            // DELIVERY / TRANSPORT DETAILS
            // =========================================================

            entity.Property(x => x.DeliveryNote)
                  .HasMaxLength(250);

            entity.Property(x => x.EWayBillNumber)
                  .HasMaxLength(100);

            entity.Property(x => x.VehicleNo)
                  .HasMaxLength(100);

            entity.Property(x => x.Distance)
                  .HasMaxLength(50);

            entity.Property(x => x.Transport)
                  .HasMaxLength(250);

            entity.Property(x => x.TransporterName)
                  .HasMaxLength(250);

            entity.Property(x => x.TransporterID)
                  .HasMaxLength(100);

            entity.Property(x => x.TransporterDocNo)
                  .HasMaxLength(100);

            entity.Property(x => x.TransportMode)
                  .HasMaxLength(100);

            entity.Property(x => x.Destination)
                  .HasMaxLength(250);

            entity.Property(x => x.BillOfLandingOrLRRRNo)
                  .HasMaxLength(150);

            entity.Property(x => x.DespatchedThrough)
                  .HasMaxLength(250);

            entity.Property(x => x.ModeOrTermsOfPayment)
                  .HasMaxLength(250);


            // =========================================================
            // EXTERNAL REFERENCES
            // =========================================================

            entity.Property(x => x.Id)
                  .HasMaxLength(100);

            entity.Property(x => x.RefId)
                  .HasMaxLength(100);


            // =========================================================
            // DECIMAL / AMOUNT FIELDS
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
            // PAYMENT / STATUS
            // =========================================================

            entity.Property(x => x.PaymentMode)
                  .HasMaxLength(100);

            entity.Property(x => x.PaymentStatus)
                  .HasMaxLength(50);

            entity.Property(x => x.Status)
                  .HasMaxLength(50);

            entity.Property(x => x.Remarks)
                  .HasMaxLength(1000);


            // =========================================================
            // RELATIONSHIP
            // SalesInvoice 1 ---> MANY SalesInvoiceItems
            // =========================================================

            entity.HasMany(x => x.Items)
                  .WithOne(x => x.SalesInvoice)
                  .HasForeignKey(x => x.SalesInvoiceId)
                  .OnDelete(DeleteBehavior.Cascade);


            // =========================================================
            // RELATIONSHIP
            // SalesInvoice 1 ---> MANY SalesInvoicePayments
            // =========================================================

            entity.HasMany(x => x.Payments)
                  .WithOne(x => x.SalesInvoice)
                  .HasForeignKey(x => x.SalesInvoiceId)
                  .OnDelete(DeleteBehavior.Cascade);


            // =========================================================
            // RELATIONSHIP
            // SalesInvoice 1 ---> MANY AdditionalCharges
            // =========================================================

            entity.HasMany(x => x.AdditionalCharges)
                  .WithOne(x => x.SalesInvoice)
                  .HasForeignKey(x => x.SalesInvoiceId)
                  .OnDelete(DeleteBehavior.Cascade);


            // =========================================================
            // INDEXES
            // =========================================================

            entity.HasIndex(x => x.InvoiceNumber);

            entity.HasIndex(x => x.SalesOrderId);

            entity.HasIndex(x => x.SellerId);

            entity.HasIndex(x => x.CustomerId);

            entity.HasIndex(x => x.PaymentStatus);

            entity.HasIndex(x => x.Status);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.SalesInvoices.Configurations
{
    public class SalesInvoiceItemConfiguration
        : IEntityTypeConfiguration<SalesInvoiceItem>
    {
        public void Configure(EntityTypeBuilder<SalesInvoiceItem> entity)
        {
            // =========================================================
            // PRIMARY KEY / IDENTITY
            // =========================================================

            entity.HasKey(x => x.SalesInvoiceItemId);

            entity.Property(x => x.SalesInvoiceItemId)
                  .ValueGeneratedOnAdd();


            // =========================================================
            // REQUIRED / RELATIONSHIP FIELDS
            // =========================================================

            entity.Property(x => x.SalesInvoiceId)
                  .IsRequired();

            entity.Property(x => x.ProductId)
                  .IsRequired();


            // =========================================================
            // BASIC DECIMAL FIELDS
            // =========================================================

            entity.Property(x => x.Quantity)
                  .HasColumnType("decimal(18,2)");

            entity.Property(x => x.UnitPrice)
                  .HasColumnType("decimal(18,2)");

            entity.Property(x => x.Discount)
                  .HasColumnType("decimal(18,2)");

            entity.Property(x => x.TaxAmount)
                  .HasColumnType("decimal(18,2)");

            entity.Property(x => x.TotalAmount)
                  .HasColumnType("decimal(18,2)");


            // =========================================================
            // TOPAZ / ITEM DECIMAL FIELDS
            // =========================================================

            entity.Property(x => x.QuantityAmount)
                  .HasColumnType("decimal(18,2)");

            entity.Property(x => x.InvoiceDiscountValue)
                  .HasColumnType("decimal(18,2)");

            entity.Property(x => x.InvoiceDiscountAmount)
                  .HasColumnType("decimal(18,2)");

            entity.Property(x => x.TotalRateBeforeDiscount)
                  .HasColumnType("decimal(18,2)");


            // =========================================================
            // GST DECIMAL FIELDS
            // =========================================================

            entity.Property(x => x.GstPer)
                  .HasColumnType("decimal(18,2)");

            entity.Property(x => x.SgstPer)
                  .HasColumnType("decimal(18,2)");

            entity.Property(x => x.SgstAmount)
                  .HasColumnType("decimal(18,2)");

            entity.Property(x => x.CgstPer)
                  .HasColumnType("decimal(18,2)");

            entity.Property(x => x.CgstAmount)
                  .HasColumnType("decimal(18,2)");

            entity.Property(x => x.IgstPer)
                  .HasColumnType("decimal(18,2)");

            entity.Property(x => x.IgstAmount)
                  .HasColumnType("decimal(18,2)");

            entity.Property(x => x.AfterGSTAmount)
                  .HasColumnType("decimal(18,2)");

            entity.Property(x => x.ColorAmount)
                  .HasColumnType("decimal(18,2)");


            // =========================================================
            // STRING FIELDS
            // =========================================================

            entity.Property(x => x.Description)
                  .HasMaxLength(1000);

            entity.Property(x => x.Uom)
                  .HasMaxLength(50);

            entity.Property(x => x.Hsncode)
                  .HasMaxLength(50);

            entity.Property(x => x.Cases)
                  .HasMaxLength(100);

            entity.Property(x => x.TaxType)
                  .HasMaxLength(100);

            entity.Property(x => x.ColorCode)
                  .HasMaxLength(100);

            entity.Property(x => x.Remarks)
                  .HasMaxLength(1000);

            entity.Property(x => x.SpecificationTypeDetailName)
                  .HasMaxLength(500);


            // =========================================================
            // FOREIGN KEY
            // SalesInvoice 1 ---> MANY SalesInvoiceItems
            // =========================================================

            entity.HasOne(x => x.SalesInvoice)
                  .WithMany(x => x.Items)
                  .HasForeignKey(x => x.SalesInvoiceId)
                  .OnDelete(DeleteBehavior.Cascade);


            // =========================================================
            // PRODUCT RELATIONSHIP
            // SalesInvoiceItem ---> Product
            // =========================================================

            entity.HasOne(x => x.Product)
                  .WithMany()
                  .HasForeignKey(x => x.ProductId)
                  .OnDelete(DeleteBehavior.Restrict);


            // =========================================================
            // INDEXES
            // =========================================================

            entity.HasIndex(x => x.SalesInvoiceId);

            entity.HasIndex(x => x.ProductId);
        }
    }
}

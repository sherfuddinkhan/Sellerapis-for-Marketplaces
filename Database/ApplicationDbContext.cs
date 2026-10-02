using Marketplacesellerportal.Models;
using MarketplaceSellerPortal.Models;
using Microsoft.EntityFrameworkCore;


using ShippingManifestEntity =
    Marketplacesellerportal.Models.ShippingManifest;

using ShelfwiseInventoryEntity =
    Marketplacesellerportal.Models.ShelfwiseInventory;

using VendorItemMasterEntity =
    Marketplacesellerportal.Models.VendorItemMaster;

using ReversePickupEntity =
    Marketplacesellerportal.Models.ReversePickup;

using EInvoiceEntity =
    Marketplacesellerportal.Models.EInvoice;

using EWayBillEntity =
    Marketplacesellerportal.Models.EWayBill;

using BrandEntity =
    Marketplacesellerportal.Models.Brand;

using BrandModelEntity =
    Marketplacesellerportal.Models.BrandModel;

using CategoryEntity =
    Marketplacesellerportal.Models.Category;

using MarketplaceOrderEntity =
    MarketplaceSellerPortal.Models.MarketplaceOrder;

using MarketplaceOrderItemEntity =
    MarketplaceSellerPortal.Models.MarketplaceOrderItem;

using MarketplacePaymentEntity =
    MarketplaceSellerPortal.Models.MarketplacePayment;

using MarketplaceReturnEntity =
    Marketplacesellerportal.Models.MarketplaceReturn;

using ProductImageEntity =
    Marketplacesellerportal.Models.ProductImage;

using SellerCustomerEntity =
    Marketplacesellerportal.Models.SellerCustomer;


namespace Marketplacesellerportal.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        // =========================================================
        // CORE
        // =========================================================

        public DbSet<User> Users { get; set; }

        public DbSet<Seller> Sellers { get; set; }

        public DbSet<SellerCustomerEntity> SellerCustomers { get; set; }

        public DbSet<FacilityChannelInventory> FacilityChannelInventories { get; set; }
        // =========================================================
        // INVOICE / GENERAL
        // =========================================================

        public DbSet<SupplierAddress> SupplierAddresses { get; set; }

        public DbSet<SupplierContacts> SupplierContacts { get; set; }

        public DbSet<VendorItemCustomField> VendorItemCustomFields { get; set; }

        public DbSet<SaleOrderAddress> SaleOrderAddresses { get; set; }

        public DbSet<ManifestPackage> ManifestPackages { get; set; }

        public DbSet<InvoiceTaxDetail> InvoiceTaxDetails { get; set; }

        public DbSet<ReversePickupItem> ReversePickupItems { get; set; }

        public DbSet<ReversePickupAddress> ReversePickupAddresses { get; set; }

        public DbSet<ExportJob> ExportJobs { get; set; }

        public DbSet<Picklist> Picklists { get; set; }

        public DbSet<InventoryAdjustment> InventoryAdjustments { get; set; }

        public DbSet<EInvoiceEntity> EInvoices { get; set; }

        public DbSet<EWayBillEntity> EWayBills { get; set; }

        public DbSet<InventoryAdjustmentLog> InventoryAdjustmentLogs { get; set; }


        // =========================================================
        // CATEGORIES
        // =========================================================

        public DbSet<CategoryEntity> Categories { get; set; }


        // =========================================================
        // INVENTORY / WAREHOUSE MODELS
        // =========================================================
        public DbSet<ShippingManifestEntity> ShippingManifests { get; set; }

        public DbSet<ShelfwiseInventoryEntity> ShelfwiseInventories { get; set; }

        public DbSet<VendorItemMasterEntity> VendorItemMasters { get; set; }

        public DbSet<ReversePickupEntity> ReversePickups { get; set; }
        public DbSet<Putaway> Putaways { get; set; }

        public DbSet<Gatepass> Gatepasses { get; set; }


        // =========================================================
        // PRODUCTS
        // =========================================================

        public DbSet<Product> Products { get; set; }

        public DbSet<MarketplaceCustomer> MarketplaceCustomers { get; set; }

        public DbSet<ProductPrice> ProductPrices { get; set; }

        public DbSet<ProductInventory> ProductInventory { get; set; }

        public DbSet<ProductImageEntity> ProductImages { get; set; }

        public DbSet<ProductAttribute> ProductAttributes { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<ProductPackage> ProductPackages { get; set; }

        public DbSet<ProductAddressLabel> ProductAddressLabels { get; set; }


        // =========================================================
        // STOCK
        // =========================================================

        public DbSet<StockMovement> StockMovements { get; set; }

        public DbSet<StockLedger> StockLedgers { get; set; }


        // =========================================================
        // SALES ORDERS
        // =========================================================

        public DbSet<SalesOrderItem> SalesOrderItems { get; set; }

        public DbSet<SalesOrder> SalesOrders { get; set; }


        // =========================================================
        // DELIVERY CHALLANS
        // =========================================================

        public DbSet<DeliveryChallan> DeliveryChallans { get; set; }

        public DbSet<DeliveryChallanItem> DeliveryChallanItems { get; set; }


        // =========================================================
        // SALES INVOICES
        // =========================================================

        public DbSet<SalesInvoice> SalesInvoices { get; set; }

        public DbSet<SalesInvoiceItem> SalesInvoiceItems { get; set; }

        public DbSet<SalesInvoicePayment> SalesInvoicePayments { get; set; }

        public DbSet<SalesInvoiceAdditionalCharge>
            SalesInvoiceAdditionalCharges
        { get; set; }

        public DbSet<CustomerAddress> CustomerAddresses { get; set; }


        // =========================================================
        // SHIPMENTS
        // =========================================================

        public DbSet<Shipment> Shipments { get; set; }


        // =========================================================
        // PAYMENTS
        // =========================================================

        public DbSet<Payment> Payments { get; set; }

        public DbSet<PaymentSettings> PaymentSettings { get; set; }


        // =========================================================
        // CUSTOMER RETURNS
        // =========================================================

        public DbSet<CustomerReturn> CustomerReturns { get; set; }


        // =========================================================
        // WISHLISTS
        // =========================================================

        public DbSet<Wishlist> Wishlists { get; set; }

        public DbSet<WishlistItem> WishlistItems { get; set; }


        // =========================================================
        // REVIEWS
        // =========================================================

        public DbSet<Review> Reviews { get; set; }


        // =========================================================
        // ORDER STATUS HISTORY
        // =========================================================

        public DbSet<OrderStatusHistory> OrderStatusHistories { get; set; }


        // =========================================================
        // MARKETPLACE
        // =========================================================

        public DbSet<MarketplaceListing> MarketplaceListings { get; set; }

        public DbSet<MarketplaceListingInventory>
            MarketplaceListingInventory
        { get; set; }

        public DbSet<AmazonAccount> AmazonAccounts { get; set; }

        public DbSet<AmazonInventorySync> AmazonInventorySync { get; set; }

        public DbSet<Marketplace> Marketplaces { get; set; }

        public DbSet<MarketplaceReturnEntity> MarketplaceReturns { get; set; }

        public DbSet<MarketplaceOrderEntity> MarketplaceOrders { get; set; }

        public DbSet<MarketplaceOrderItemEntity>
            MarketplaceOrderItems
        { get; set; }

        public DbSet<MarketplacePaymentEntity>
            MarketplacePayments
        { get; set; }

        public DbSet<MarketplaceOrderAddress>
            MarketplaceOrderAddresses
        { get; set; }

        public DbSet<MarketplaceShipment>
            MarketplaceShipments
        { get; set; }


        // =========================================================
        // NOTIFICATIONS
        // =========================================================

        public DbSet<Notification> Notifications { get; set; }


        // =========================================================
        // BRANDS
        // =========================================================

        public DbSet<BrandEntity> Brands { get; set; }

        public DbSet<BrandModelEntity> BrandModels { get; set; }


        // =========================================================
        // SUPPLIERS
        // =========================================================

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<PurchaseReturn> PurchaseReturns { get; set; }


        // =========================================================
        // INVENTORY
        // =========================================================

        public DbSet<StockAdjustment> StockAdjustments { get; set; }

        public DbSet<StockTransfer> StockTransfers { get; set; }


        // =========================================================
        // WAREHOUSES
        // =========================================================

        public DbSet<Warehouse> Warehouses { get; set; }

        public DbSet<WarehouseLocation> WarehouseLocations { get; set; }


        // =========================================================
        // PURCHASE ORDERS
        // =========================================================

        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }

        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }


        // =========================================================
        // GOODS RECEIPT
        // =========================================================

        public DbSet<GoodsReceiptNote> GoodsReceiptNotes { get; set; }

        public DbSet<GoodsReceiptItem> GoodsReceiptItems { get; set; }


        // =========================================================
        // MODEL CONFIGURATION
        // =========================================================

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // =====================================================
            // APPLY ALL IEntityTypeConfiguration CLASSES
            // =====================================================

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ApplicationDbContext).Assembly);


            // =====================================================
            // SELLER CUSTOMER
            //
            // IMPORTANT:
            // SellerCustomerConfiguration.cs is responsible for
            // SellerCustomer relationship/key configuration.
            //
            // DO NOT configure SellerCustomer relationship again
            // here. Otherwise EF can create a duplicate/shadow
            // SellerId relationship such as SellerId1.
            // =====================================================


            // =====================================================
            // PRODUCT
            // =====================================================

            modelBuilder.Entity<Product>()
                .ToTable("Products", "dbo");


            // =====================================================
            // PRODUCT -> BRAND
            // =====================================================

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Brand)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.SetNull);


            // =====================================================
            // PRODUCT -> CATEGORY
            // =====================================================

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);


            // =====================================================
            // BRAND
            // =====================================================

            modelBuilder.Entity<BrandEntity>()
                .ToTable("Brands", "dbo");

            modelBuilder.Entity<BrandEntity>()
                .HasKey(b => b.BrandId);


            // =====================================================
            // BRAND -> BRAND MODELS
            // =====================================================

            modelBuilder.Entity<BrandModelEntity>()
                .ToTable("BrandModels", "dbo");

            modelBuilder.Entity<BrandModelEntity>()
                .HasKey(bm => bm.BrandModelId);

            modelBuilder.Entity<BrandModelEntity>()
                .HasOne(bm => bm.Brand)
                .WithMany(b => b.BrandModels)
                .HasForeignKey(bm => bm.BrandId)
                .OnDelete(DeleteBehavior.Cascade);


            // =====================================================
            // INVOICE TAX DETAILS
            // =====================================================

            modelBuilder.Entity<InvoiceTaxDetail>(entity =>
            {
                entity.ToTable(
                    "InvoiceTaxDetails",
                    "dbo");

                entity.HasKey(
                    e => e.InvoiceTaxDetailId);

                entity.Property(
                    e => e.InvoiceTaxDetailId)
                    .HasColumnName("InvoiceTaxDetailId")
                    .ValueGeneratedOnAdd();

                entity.Property(
                    e => e.SalesInvoiceId)
                    .HasColumnName("salesInvoiceId");

                entity.Property(
                    e => e.ChannelProductId)
                    .HasColumnName("channelProductId");

                entity.Property(
                    e => e.TaxPercentage)
                    .HasColumnName("taxPercentage");

                entity.Property(
                    e => e.CentralGst)
                    .HasColumnName("centralGst");

                entity.Property(
                    e => e.StateGst)
                    .HasColumnName("stateGst");

                entity.Property(
                    e => e.IntegratedGst)
                    .HasColumnName("integratedGst");

                entity.Property(
                    e => e.CompensationCess)
                    .HasColumnName("compensationCess");
            });


            // =====================================================
            // MANIFEST PACKAGES
            // =====================================================

            modelBuilder.Entity<ManifestPackage>(entity =>
            {
                entity.ToTable(
                    "ManifestPackages",
                    "dbo");

                entity.HasKey(
                    e => e.ManifestPackageId);

                entity.Property(
                    e => e.ManifestPackageId)
                    .HasColumnName("ManifestPackageId")
                    .ValueGeneratedOnAdd();

                entity.Property(
                    e => e.ShippingManifestCode)
                    .HasColumnName("ShippingManifestCode")
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(
                    e => e.ShippingPackageCode)
                    .HasColumnName("ShippingPackageCode")
                    .HasMaxLength(50);
            });


            // =====================================================
            // PICKLIST
            // =====================================================

            modelBuilder.Entity<Picklist>(entity =>
            {
                entity.ToTable(
                    "picklists",
                    "dbo");

                entity.HasKey(
                    e => e.PicklistCode);

                entity.Property(
                    e => e.PicklistCode)
                    .HasColumnName("picklistCode")
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(
                    e => e.Destination)
                    .HasColumnName("destination")
                    .HasMaxLength(20);

                entity.Property(
                    e => e.ShippingPackageCodes)
                    .HasColumnName("shippingPackageCodes")
                    .HasColumnType("text");

                entity.Property(
                    e => e.CreatedDate)
                    .HasColumnName("createdDate");

                entity.Property(
                    e => e.PicklistId)
                    .HasColumnName("PicklistId")
                    .ValueGeneratedOnAdd();
            });
        }
    }
}
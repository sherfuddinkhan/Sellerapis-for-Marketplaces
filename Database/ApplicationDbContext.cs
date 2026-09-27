using Marketplacesellerportal.Models;
using MarketplaceSellerPortal.Models;
using Microsoft.EntityFrameworkCore;
using EInvoiceEntity = Marketplacesellerportal.Models.EInvoice;
using EWayBillEntity = Marketplacesellerportal.Models.EWayBill;
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

        public DbSet<SellerCustomer> SellerCustomers { get; set; }


        /// <summary>
        /// ////////Invoice//////////////////
        /// </summary>

        public DbSet<EInvoiceEntity> EInvoices { get; set; }
        public DbSet<EWayBillEntity> EWayBills { get; set; }

        // =========================================================
        // CATEGORIES
        // =========================================================

        public DbSet<CategoryEntity> Categories { get; set; }


        // FIX: Use full namespace for Models to avoid folder collision
        public DbSet<Marketplacesellerportal.Models.ShelfwiseInventory> ShelfwiseInventories { get; set; }
        public DbSet<Marketplacesellerportal.Models.VendorItemMaster> VendorItemMasters { get; set; }
        public DbSet<Marketplacesellerportal.Models.ReversePickup> ReversePickups { get; set; }
        public DbSet<Marketplacesellerportal.Models.Putaway> Putaways { get; set; }
        public DbSet<Marketplacesellerportal.Models.Gatepass> Gatepasses { get; set; }
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

        public DbSet<SalesInvoiceAdditionalCharge> SalesInvoiceAdditionalCharges { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            // =====================================================
            // PRODUCT
            // =====================================================
            modelBuilder.Entity<Product>()
               .ToTable("Products", "dbo");

            // =====================================================
            // PRODUCT -> BRAND (keep ONLY one config, delete the other one)
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

     
        }


    }
}
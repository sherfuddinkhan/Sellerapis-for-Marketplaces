using Marketplacesellerportal.Models;
using MarketplaceSellerPortal.Models;
using Microsoft.EntityFrameworkCore;

using MarketplacePaymentEntity =
    MarketplaceSellerPortal.Models.MarketplacePayment;

using MarketplaceOrderEntity =
    MarketplaceSellerPortal.Models.MarketplaceOrder;

using MarketplaceOrderItemEntity =
    MarketplaceSellerPortal.Models.MarketplaceOrderItem;

using BrandEntity =
    Marketplacesellerportal.Models.Brand;

using BrandModelEntity =
    Marketplacesellerportal.Models.BrandModel;

using CategoryEntity =
    Marketplacesellerportal.Models.Category;

using MarketplaceReturnEntity =
    Marketplacesellerportal.Models.MarketplaceReturn;

using ProductImageEntity =
    Marketplacesellerportal.Models.ProductImage;

namespace Marketplacesellerportal.Database;

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


    // =========================================================
    // CATEGORIES
    // =========================================================

    public DbSet<CategoryEntity> Categories { get; set; }


    // =========================================================
    // PRODUCTS
    // =========================================================

    public DbSet<Product> Products { get; set; }

    public DbSet<ProductPrice> ProductPrices { get; set; }

    public DbSet<ProductInventory> ProductInventory { get; set; }

    public DbSet<ProductImageEntity> ProductImages { get; set; }

    public DbSet<ProductAttribute> ProductAttributes { get; set; }

    public DbSet<ProductType> ProductTypes { get; set; }


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
    public DbSet<DeliveryChallanItem> DeliveryChallanItems { get;set;}


    // =========================================================
    // SALES INVOICES
    // =========================================================

    public DbSet<SalesInvoice> SalesInvoices { get; set; }


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

    public DbSet<MarketplaceOrderItemEntity> MarketplaceOrderItems
    {
        get;
        set;
    }

    public DbSet<MarketplacePaymentEntity> MarketplacePayments
    {
        get;
        set;
    }

    public DbSet<MarketplaceOrderAddress> MarketplaceOrderAddresses
    {
        get;
        set;
    }

    public DbSet<MarketplaceShipment> MarketplaceShipments
    {
        get;
        set;
    }


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
        // APPLY EXISTING ENTITY CONFIGURATIONS
        // =====================================================

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ApplicationDbContext).Assembly);


        // =====================================================
        // MARKETPLACE ORDER
        //
        // MarketplaceOrder
        //       1
        //       |
        //       |
        //       *
        // MarketplaceOrderItem
        //
        // =====================================================
        // =====================================================
        // STOCK TABLE MAPPINGS
        // =====================================================

        modelBuilder.Entity<StockMovement>()
            .ToTable("StockMovement", "dbo");

        modelBuilder.Entity<StockLedger>()
            .ToTable("StockLedger", "dbo");

        modelBuilder.Entity<StockAdjustment>()
            .ToTable("StockAdjustments", "dbo");

        modelBuilder.Entity<StockTransfer>()
            .ToTable("StockTransfers", "dbo");

        // =====================================================
        // WAREHOUSE TABLE MAPPING
        // =====================================================

        modelBuilder.Entity<Warehouse>()
            .ToTable("Warehouses", "dbo");

        modelBuilder.Entity<WarehouseLocation>()
            .ToTable("WarehouseLocations", "dbo");
        modelBuilder.Entity<MarketplaceOrderEntity>()
            .HasMany(order => order.Items)
            .WithOne(item => item.Order)
            .HasForeignKey(item => item.MarketplaceOrderId)
            .OnDelete(DeleteBehavior.Cascade);


        // =====================================================
        // MARKETPLACE ORDER
        // SELLER ID
        // =====================================================
        //
        // SellerId is a scalar property only.
        //
        // MarketplaceOrder currently does NOT contain:
        //
        // public Seller? Seller { get; set; }
        //
        // Therefore no Seller relationship is configured here.
        //
        // =====================================================

        modelBuilder.Entity<MarketplaceOrderEntity>()
            .Property(order => order.SellerId)
            .IsRequired();


        // =====================================================
        // MARKETPLACE ORDER
        // CUSTOMER ID
        // =====================================================
        //
        // CustomerId is a scalar property only.
        //
        // MarketplaceOrder currently does NOT contain:
        //
        // public SellerCustomer? Customer { get; set; }
        //
        // Therefore no Customer relationship is configured here.
        //
        // =====================================================

        modelBuilder.Entity<MarketplaceOrderEntity>()
            .Property(order => order.CustomerId)
            .IsRequired();


        // =====================================================
        // MARKETPLACE ACCOUNT ID
        // =====================================================
        //
        // MarketplaceAccountId is a scalar property only.
        //
        // No Marketplace navigation property currently exists
        // inside MarketplaceOrder.
        //
        // Therefore no Marketplace relationship is configured.
        //
        // =====================================================

        modelBuilder.Entity<MarketplaceOrderEntity>()
            .Property(order => order.MarketplaceAccountId)
            .IsRequired();


        // =====================================================
        // MARKETPLACE ORDER TOTAL AMOUNT
        // =====================================================

        modelBuilder.Entity<MarketplaceOrderEntity>()
            .Property(order => order.TotalAmount)
            .HasColumnType("decimal(18,2)");


        // =====================================================
        // MARKETPLACE ORDER ITEM - UNIT PRICE
        // =====================================================

        modelBuilder.Entity<MarketplaceOrderItemEntity>()
            .Property(item => item.UnitPrice)
            .HasColumnType("decimal(18,2)");


        // =====================================================
        // MARKETPLACE ORDER ITEM - TAX
        // =====================================================

        modelBuilder.Entity<MarketplaceOrderItemEntity>()
            .Property(item => item.TaxAmount)
            .HasColumnType("decimal(18,2)");


        // =====================================================
        // MARKETPLACE ORDER ITEM - SHIPPING
        // =====================================================

        modelBuilder.Entity<MarketplaceOrderItemEntity>()
            .Property(item => item.ShippingAmount)
            .HasColumnType("decimal(18,2)");


        // =====================================================
        // MARKETPLACE ORDER ITEM - DISCOUNT
        // =====================================================

        modelBuilder.Entity<MarketplaceOrderItemEntity>()
            .Property(item => item.DiscountAmount)
            .HasColumnType("decimal(18,2)");


        // =====================================================
        // MARKETPLACE ORDER ITEM - TOTAL
        // =====================================================

        modelBuilder.Entity<MarketplaceOrderItemEntity>()
            .Property(item => item.TotalAmount)
            .HasColumnType("decimal(18,2)");
    }
}
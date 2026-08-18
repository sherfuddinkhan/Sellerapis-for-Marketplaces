using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Models;
using BrandModel = Marketplacesellerportal.Models.Brand;
namespace Marketplacesellerportal.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Core
        public DbSet<User> Users { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<SellerCustomer> SellerCustomers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ApplicationDbContext).Assembly);
        }
        public DbSet<Category> Categories { get; set; }
        // Products
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<ProductInventory> ProductInventory { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; }
        public DbSet<StockLedger> StockLedgers { get; set; }
        public DbSet<SalesOrderItem> SalesOrderItems { get; set; }
        public DbSet<DeliveryChallan> DeliveryChallans { get; set; }
        public DbSet<SalesInvoice> SalesInvoices { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<CustomerReturn> CustomerReturns { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<OrderStatusHistory> OrderStatusHistories { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }



        public DbSet<BrandModel> Brands { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        // Suppliers
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<PurchaseReturn> PurchaseReturns { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }


        // Inventory

        public DbSet<StockAdjustment> StockAdjustments { get; set; }
        public DbSet<StockTransfer> StockTransfers { get; set; }
        // Customers


        // Warehouses
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseLocation> WarehouseLocations { get; set; }

        // Purchase Orders
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }

        // Goods Receipt
        public DbSet<GoodsReceiptNote> GoodsReceiptNotes { get; set; }
        public DbSet<GoodsReceiptItem> GoodsReceiptItems { get; set; }
    }
}
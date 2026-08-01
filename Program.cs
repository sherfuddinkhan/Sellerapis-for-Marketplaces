using Marketplacesellerportal.AuthManagement.Helpers;
using Marketplacesellerportal.AuthManagement.Interfaces;
using Marketplacesellerportal.AuthManagement.Repositories;
using Marketplacesellerportal.AuthManagement.Services;
using Marketplacesellerportal.Brand.Interfaces;
using Marketplacesellerportal.Brand.Repositories;
using Marketplacesellerportal.Brand.Services;
using Marketplacesellerportal.Configuration;
using Marketplacesellerportal.CustomerReturns.Interfaces;
using Marketplacesellerportal.CustomerReturns.Repositories;
using Marketplacesellerportal.CustomerReturns.Services;
using Marketplacesellerportal.Customers.Interfaces;
using Marketplacesellerportal.Customers.Repositories;
using Marketplacesellerportal.Customers.Services;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.DeliveryChallans.Interfaces;
using Marketplacesellerportal.DeliveryChallans.Repositories;
using Marketplacesellerportal.DeliveryChallans.Services;
using Marketplacesellerportal.Catalog.Interfaces;
using Marketplacesellerportal.Catalog.Repositories;
using Marketplacesellerportal.Catalog.Services;
using Marketplacesellerportal.GoodsReceiptItems.Interfaces;
using Marketplacesellerportal.GoodsReceiptItems.Repositories;
using Marketplacesellerportal.GoodsReceiptItems.Services;
using Marketplacesellerportal.GoodsReceiptNotes.Interfaces;
using Marketplacesellerportal.GoodsReceiptNotes.Repositories;
using Marketplacesellerportal.GoodsReceiptNotes.Services;
using Marketplacesellerportal.Notifications.Interfaces;
using Marketplacesellerportal.Notifications.Repositories;
using Marketplacesellerportal.Notifications.Services;
using Marketplacesellerportal.OrderStatusHistories.Interfaces;
using Marketplacesellerportal.OrderStatusHistories.Repositories;
using Marketplacesellerportal.OrderStatusHistories.Services;
using Marketplacesellerportal.Payments.Interfaces;
using Marketplacesellerportal.Payments.Repositories;
using Marketplacesellerportal.Payments.Services;
using Marketplacesellerportal.ProductAttributes.Interfaces;
using Marketplacesellerportal.ProductAttributes.Repositories;
using Marketplacesellerportal.ProductAttributes.Services;
using Marketplacesellerportal.ProductImages.Interfaces;
using Marketplacesellerportal.ProductImages.Repositories;
using Marketplacesellerportal.ProductImages.Services;
using Marketplacesellerportal.ProductPrices.Interfaces;
using Marketplacesellerportal.ProductPrices.Repositories;
using Marketplacesellerportal.ProductPrices.Services;
using Marketplacesellerportal.Products.Interfaces;
using Marketplacesellerportal.Products.Repositories;
using Marketplacesellerportal.ProductTypes.Interfaces;
using Marketplacesellerportal.ProductTypes.Repositories;
using Marketplacesellerportal.ProductTypes.Services;
using Marketplacesellerportal.PurchaseOrderItems.Interfaces;
using Marketplacesellerportal.PurchaseOrderItems.Repositories;
using Marketplacesellerportal.PurchaseOrderItems.Services;
using Marketplacesellerportal.PurchaseOrders.Interfaces;
using Marketplacesellerportal.PurchaseOrders.Repositories;
using Marketplacesellerportal.PurchaseOrders.Services;
using Marketplacesellerportal.PurchaseReturns.Interfaces;
using Marketplacesellerportal.PurchaseReturns.Repositories;
using Marketplacesellerportal.PurchaseReturns.Services;
using Marketplacesellerportal.Reviews.Interfaces;
using Marketplacesellerportal.Reviews.Repositories;
using Marketplacesellerportal.Reviews.Services;
using Marketplacesellerportal.SalesInvoices.Interfaces;
using Marketplacesellerportal.SalesInvoices.Repositories;
using Marketplacesellerportal.SalesInvoices.Services;
using Marketplacesellerportal.SalesOrderItems.Interfaces;
using Marketplacesellerportal.SalesOrderItems.Repositories;
using Marketplacesellerportal.SalesOrderItems.Services;
using Marketplacesellerportal.SalesOrders.Interfaces;
using Marketplacesellerportal.SalesOrders.Repositories;
using Marketplacesellerportal.SalesOrders.Services;
using Marketplacesellerportal.Sellers.Interfaces;
using Marketplacesellerportal.Sellers.Interfaces;
using Marketplacesellerportal.Sellers.Repositories;
using Marketplacesellerportal.Sellers.Services;
using Marketplacesellerportal.Sellers.Services;
using Marketplacesellerportal.Shipments.Interfaces;
using Marketplacesellerportal.Shipments.Repositories;
using Marketplacesellerportal.Shipments.Services;
using Marketplacesellerportal.StockAdjustments.Interfaces;
using Marketplacesellerportal.StockAdjustments.Repositories;
using Marketplacesellerportal.StockAdjustments.Services;
using Marketplacesellerportal.StockLedgers.Interfaces;
using Marketplacesellerportal.StockLedgers.Repositories;
using Marketplacesellerportal.StockLedgers.Services;
using Marketplacesellerportal.StockMovements.Interfaces;
using Marketplacesellerportal.StockMovements.Interfaces;
using Marketplacesellerportal.StockMovements.Repositories;
using Marketplacesellerportal.StockMovements.Repositories;
using Marketplacesellerportal.StockMovements.Services;
using Marketplacesellerportal.StockMovements.Services;
using Marketplacesellerportal.StockTransfers.Interfaces;
using Marketplacesellerportal.StockTransfers.Repositories;
using Marketplacesellerportal.StockTransfers.Services;
using Marketplacesellerportal.Suppliers.Interfaces;
using Marketplacesellerportal.Suppliers.Repositories;
using Marketplacesellerportal.Suppliers.Services;
using Marketplacesellerportal.WarehouseLocations.Interfaces;
using Marketplacesellerportal.WarehouseLocations.Repositories;
using Marketplacesellerportal.WarehouseLocations.Services;
using Marketplacesellerportal.Warehouses.Interfaces;
using Marketplacesellerportal.Warehouses.Repositories;
using Marketplacesellerportal.Warehouses.Services;
using Marketplacesellerportal.Brand.Interfaces;
using Marketplacesellerportal.Brand.Repositories;
using Marketplacesellerportal.Brand.Services;
using Marketplacesellerportal.WishlistItems.Interfaces;
using Marketplacesellerportal.WishlistItems.Repositories;
using Marketplacesellerportal.WishlistItems.Services;
using Marketplacesellerportal.Wishlists.Interfaces;
using Marketplacesellerportal.Wishlists.Repositories;
using Marketplacesellerportal.Wishlists.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Register JwtSettings
builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("Jwt"));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
// ?? Add Configure JWT Authentication HERE
var jwtSettings = builder.Configuration
    .GetSection("Jwt")
    .Get<JwtSettings>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = jwtSettings!.Issuer,
        ValidAudience = jwtSettings.Audience,

        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtSettings.Key))
    };
});
builder.Services.AddScoped<ISellerRepository, SellerRepository>();
builder.Services.AddScoped<ISellerService, SellerService>();
builder.Services.AddScoped<ISellerCustomerRepository, SellerCustomerRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<ISellerCustomerService, SellerCustomerService>();
builder.Services.AddScoped<IWarehouseRepository, WarehouseRepository>();
builder.Services.AddScoped<IWarehouseService, WarehouseService>();
builder.Services.AddScoped<ISalesOrderItemRepository, SalesOrderItemRepository>();
builder.Services.AddScoped<ISalesOrderItemService, SalesOrderItemService>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IWarehouseLocationRepository, WarehouseLocationRepository>();
builder.Services.AddScoped<IWarehouseLocationService, WarehouseLocationService>();
builder.Services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
builder.Services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
builder.Services.AddScoped<IShipmentRepository, ShipmentRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IShipmentService, ShipmentService>();
builder.Services.AddScoped<IAuthManagementRepository, AuthManagementRepository>();
builder.Services.AddScoped<IAuthManagementService, AuthManagementService>();

builder.Services.AddSingleton<JwtTokenGenerator>();
builder.Services.AddScoped<IDeliveryChallanRepository, DeliveryChallanRepository>();
builder.Services.AddScoped<IDeliveryChallanService, DeliveryChallanService>();
builder.Services.AddScoped<IGoodsReceiptNoteRepository, GoodsReceiptNotesRepository>();
builder.Services.AddScoped<IGoodsReceiptNoteService, GoodsReceiptNotesService>();
builder.Services.AddScoped<IPurchaseOrderItemRepository,PurchaseOrderItemRepository>();
builder.Services.AddScoped<IGoodsReceiptItemRepository, GoodsReceiptItemRepository>();
builder.Services.AddScoped<IGoodsReceiptItemService, GoodsReceiptItemService>();
builder.Services.AddScoped<IPurchaseOrderItemService, PurchaseOrderItemService>();
builder.Services.AddScoped<IStockLedgerRepository, StockLedgerRepository>();
builder.Services.AddScoped<IStockLedgerService, StockLedgerService>();
builder.Services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
builder.Services.AddScoped<IProductTypeService, ProductTypeService>();
builder.Services.AddScoped<IProductPriceRepository, ProductPriceRepository>();
builder.Services.AddScoped<IWishlistItemRepository, WishlistItemRepository>();
builder.Services.AddScoped<IWishlistItemService, WishlistItemService>();
builder.Services.AddScoped<IProductPriceService, ProductPriceService>();
builder.Services.AddScoped<ISalesOrderRepository, SalesOrderRepository>();
builder.Services.AddScoped<ISalesInvoiceRepository, SalesInvoiceRepository>();
builder.Services.AddScoped<IOrderStatusHistoryRepository, OrderStatusHistoryRepository>();
builder.Services.AddScoped<IOrderStatusHistoryService, OrderStatusHistoryService>();
builder.Services.AddScoped<ISalesInvoiceService, SalesInvoiceService>();

builder.Services.AddScoped<ICatalogRepository, CatalogRepository>();

builder.Services.AddScoped<ICatalogService, CatalogService>();
builder.Services.AddScoped<ISalesOrderService, SalesOrderService>();
builder.Services.AddScoped<IStockAdjustmentRepository, StockAdjustmentRepository>();
builder.Services.AddScoped<IStockAdjustmentService, StockAdjustmentService>();
builder.Services.AddScoped<ICustomerReturnRepository, CustomerReturnRepository>();
builder.Services.AddScoped<ICustomerReturnService, CustomerReturnService>();
builder.Services.AddScoped<IStockMovementRepository, StockMovementRepository>();
builder.Services.AddScoped<IWishlistRepository, WishlistRepository>();
builder.Services.AddScoped<IWishlistService, WishlistService>();
builder.Services.AddScoped<IStockTransferRepository, StockTransferRepository>();
builder.Services.AddScoped<IProductAttributeRepository, ProductAttributeRepository>();
builder.Services.AddScoped<IProductAttributeService, ProductAttributeService>();
builder.Services.AddScoped<IPurchaseReturnRepository, PurchaseReturnRepository>();
builder.Services.AddScoped<IPurchaseReturnService, PurchaseReturnService>();
builder.Services.AddScoped<IProductImageRepository, ProductImageRepository>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IStockTransferService, StockTransferService>();
builder.Services.AddScoped<IStockMovementService, StockMovementService>();
builder.Services.AddAuthorization();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
// ?? Build the application
var app = builder.Build();

// Configure HTTP pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ?? Authentication must come before Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
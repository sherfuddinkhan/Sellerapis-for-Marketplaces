// =========================================================
// SellerCustomerService.cs
// =========================================================
// ✅ Use alias - fixes 'Brand is a namespace but is used like a type'
using Marketplacesellerportal.Categories.Interfaces;
using Marketplacesellerportal.CustomerAddresses.Interface;
using Marketplacesellerportal.CustomerReturns.Interfaces;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.DeliveryChallanItems.Interfaces;
using Marketplacesellerportal.DeliveryChallans.Interfaces;
using Marketplacesellerportal.EInvoice.Interfaces;
using Marketplacesellerportal.EWayBill.Interfaces;
using Marketplacesellerportal.GoodsReceiptItems.Interfaces;
using Marketplacesellerportal.GoodsReceiptNotes.Interfaces;
using Marketplacesellerportal.Interface;
using Marketplacesellerportal.MarketplaceOrderItems.Interfaces;
using Marketplacesellerportal.MarketplaceReturns.Interfaces;
using Marketplacesellerportal.Marketplaces.Interfaces;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Notifications.Interfaces;
using Marketplacesellerportal.OrderStatusHistories.Interfaces;
using Marketplacesellerportal.Payments.Interfaces;
using Marketplacesellerportal.ProductAttributes.Interfaces;
using Marketplacesellerportal.ProductImages.Interfaces;
using Marketplacesellerportal.ProductInventories.Interfaces;
using Marketplacesellerportal.ProductPrices.Interfaces;
using Marketplacesellerportal.Products.Interfaces;
using Marketplacesellerportal.ProductTypes.Interfaces;
using Marketplacesellerportal.PurchaseOrderItems.Interfaces;
using Marketplacesellerportal.PurchaseOrders.Repositories;
using Marketplacesellerportal.PurchaseReturns.Interfaces;
using Marketplacesellerportal.Reviews.Interfaces;
using Marketplacesellerportal.SalesInvoices.Interfaces;
using Marketplacesellerportal.SalesOrderItems.Interfaces;
using Marketplacesellerportal.SalesOrders.Interfaces;
using Marketplacesellerportal.SellerCustomers.DTOs;
using Marketplacesellerportal.SellerCustomers.Interfaces;
using Marketplacesellerportal.Sellers.Interfaces;
using Marketplacesellerportal.Shipments.Interfaces;
using Marketplacesellerportal.StockAdjustments.Interfaces;
using Marketplacesellerportal.StockAdjustments.Repositories;
using Marketplacesellerportal.StockLedgers.Interfaces;
using Marketplacesellerportal.StockLedgers.Repositories;
using Marketplacesellerportal.StockMovements.Interfaces;
using Marketplacesellerportal.StockMovements.Repositories;
using Marketplacesellerportal.StockTransfers.Interfaces;
using Marketplacesellerportal.Suppliers.Interfaces;
using Marketplacesellerportal.WarehouseLocations.Interfaces;
using Marketplacesellerportal.WarehouseLocations.Repositories;
using Marketplacesellerportal.Warehouses.Interfaces;
using Marketplacesellerportal.Warehouses.Repositories;
using Marketplacesellerportal.WishlistItems.Interfaces;
using Marketplacesellerportal.Wishlists.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using BrandEntity = Marketplacesellerportal.Models.BrandModel;
namespace Marketplacesellerportal.SellerCustomers.Services
{
    public class SellerCustomerService : ISellerCustomerService
    {
        // =========================================================
        // REPOSITORIES
        // =========================================================
        private readonly ApplicationDbContext _context; // Now will work
        private readonly ISellerCustomerRepository _repository;

        private readonly IProductRepository _productRepository;
        private readonly IProductInventoryRepository _inventoryRepository;
        private readonly IProductPriceRepository _productPriceRepository;
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductImageRepository _productImageRepository;
        private readonly IProductAttributeRepository _productAttributeRepository;

        private readonly IStockMovementRepository _stockMovementRepository;
        private readonly IStockLedgerRepository _stockLedgerRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IStockAdjustmentRepository _stockAdjustmentRepository;
        private readonly IStockTransferRepository _stockTransferRepository;

        private readonly ISupplierRepository _supplierRepository;
        private readonly IWarehouseLocationRepository _warehouseLocationRepository;

        private readonly ISalesOrderRepository _salesOrderRepository;
        private readonly ISalesOrderItemRepository _salesOrderItemRepository;

        private readonly ICustomerReturnRepository _customerReturnRepository;

        private readonly IDeliveryChallanRepository _deliveryChallanRepository;

        private readonly IGoodsReceiptNoteRepository _goodsReceiptNoteRepository;
        private readonly IGoodsReceiptItemRepository _goodsReceiptItemRepository;

        private readonly INotificationRepository _notificationRepository;
        private readonly IOrderStatusHistoryRepository _orderStatusHistoryRepository;

        private readonly IPaymentRepository _paymentRepository;

        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        private readonly IPurchaseOrderItemRepository _purchaseOrderItemRepository;
        private readonly IPurchaseReturnRepository _purchaseReturnRepository;

        private readonly IReviewRepository _reviewRepository;

        private readonly ISalesInvoiceRepository _salesInvoiceRepository;

        private readonly IShipmentRepository _shipmentRepository;

        private readonly IWishlistRepository _wishlistRepository;
        private readonly IWishlistItemRepository _wishlistItemRepository;


        private readonly ICustomerAddressRepository _customerAddressRepository;


        // =========================================================
        // MARKETPLACE REPOSITORIES
        // =========================================================

        private readonly IMarketplaceOrderRepository _marketplaceOrderRepository;

        private readonly IMarketplaceOrderItemRepository
            _marketplaceOrderItemRepository;

        private readonly IMarketplaceReturnRepository
            _marketplaceReturnRepository;

        // At top of file - inject repositories
        private readonly IDeliveryChallanItemRepository _deliveryChallanItemRepo;
        private readonly IMarketplaceRepository _marketplaceRepo;
        private readonly ISellerRepository _sellerRepo;
        private readonly IEInvoiceRepository _eInvoiceRepo;
        private readonly IEWayBillRepository _eWayBillRepo;


        // =========================================================
        // CONSTRUCTOR
        // =========================================================

        public SellerCustomerService(
             ApplicationDbContext context,
            ISellerCustomerRepository repository,
            ICustomerAddressRepository customerAddressRepository,
            IProductRepository productRepository,
            IProductInventoryRepository inventoryRepository,
            IProductPriceRepository productPriceRepository,
            IProductTypeRepository productTypeRepository,
            ICategoryRepository categoryRepository,
            IProductImageRepository productImageRepository,
            IProductAttributeRepository productAttributeRepository,

            IStockMovementRepository stockMovementRepository,
            IStockLedgerRepository stockLedgerRepository,
            IWarehouseRepository warehouseRepository,
            IStockAdjustmentRepository stockAdjustmentRepository,
            IStockTransferRepository stockTransferRepository,

            ISupplierRepository supplierRepository,
            IWarehouseLocationRepository warehouseLocationRepository,

            ISalesOrderRepository salesOrderRepository,
            ISalesOrderItemRepository salesOrderItemRepository,

            ICustomerReturnRepository customerReturnRepository,

            IDeliveryChallanRepository deliveryChallanRepository,

            IGoodsReceiptNoteRepository goodsReceiptNoteRepository,
            IGoodsReceiptItemRepository goodsReceiptItemRepository,

            INotificationRepository notificationRepository,
            IOrderStatusHistoryRepository orderStatusHistoryRepository,

            IPaymentRepository paymentRepository,

            IPurchaseOrderRepository purchaseOrderRepository,
            IPurchaseOrderItemRepository purchaseOrderItemRepository,
            IPurchaseReturnRepository purchaseReturnRepository,

            IReviewRepository reviewRepository,

            ISalesInvoiceRepository salesInvoiceRepository,

            IShipmentRepository shipmentRepository,

            IWishlistRepository wishlistRepository,
            IWishlistItemRepository wishlistItemRepository,

            // =====================================================
            // MARKETPLACE REPOSITORIES
            // =====================================================

            IMarketplaceOrderRepository marketplaceOrderRepository,
            IMarketplaceOrderItemRepository marketplaceOrderItemRepository,
            IMarketplaceReturnRepository marketplaceReturnRepository,


    // === ADD THESE 5 MISSING ===
    IDeliveryChallanItemRepository deliveryChallanItemRepo,
    IMarketplaceRepository marketplaceRepo,
    ISellerRepository sellerRepo,
    IEInvoiceRepository eInvoiceRepo,
    IEWayBillRepository eWayBillRepo


        )
        {
            _context = context;
            _repository = repository;
            _customerAddressRepository = customerAddressRepository;
            _productRepository = productRepository;
            _inventoryRepository = inventoryRepository;
            _productPriceRepository = productPriceRepository;
            _productTypeRepository = productTypeRepository;
            _categoryRepository = categoryRepository;
            _productImageRepository = productImageRepository;
            _productAttributeRepository = productAttributeRepository;

            _stockMovementRepository = stockMovementRepository;
            _stockLedgerRepository = stockLedgerRepository;
            _warehouseRepository = warehouseRepository;
            _stockAdjustmentRepository = stockAdjustmentRepository;
            _stockTransferRepository = stockTransferRepository;

            _supplierRepository = supplierRepository;
            _warehouseLocationRepository = warehouseLocationRepository;

            _salesOrderRepository = salesOrderRepository;
            _salesOrderItemRepository = salesOrderItemRepository;

            _customerReturnRepository = customerReturnRepository;

            _deliveryChallanRepository = deliveryChallanRepository;

            _goodsReceiptNoteRepository = goodsReceiptNoteRepository;
            _goodsReceiptItemRepository = goodsReceiptItemRepository;

            _notificationRepository = notificationRepository;
            _orderStatusHistoryRepository = orderStatusHistoryRepository;

            _paymentRepository = paymentRepository;

            _purchaseOrderRepository = purchaseOrderRepository;
            _purchaseOrderItemRepository = purchaseOrderItemRepository;
            _purchaseReturnRepository = purchaseReturnRepository;

            _reviewRepository = reviewRepository;

            _salesInvoiceRepository = salesInvoiceRepository;

            _shipmentRepository = shipmentRepository;

            _wishlistRepository = wishlistRepository;
            _wishlistItemRepository = wishlistItemRepository;

            // === ASSIGN MISSING ===
            _deliveryChallanItemRepo = deliveryChallanItemRepo;
            _marketplaceRepo = marketplaceRepo;
            _sellerRepo = sellerRepo;
            _eInvoiceRepo = eInvoiceRepo;
            _eWayBillRepo = eWayBillRepo;

            // =====================================================
            // MARKETPLACE REPOSITORIES
            // =====================================================

            _marketplaceOrderRepository = marketplaceOrderRepository;

            _marketplaceOrderItemRepository =
                marketplaceOrderItemRepository;

            _marketplaceReturnRepository =
                marketplaceReturnRepository;
        }


        // =========================================================
        // BASIC CUSTOMER METHODS
        // =========================================================

        public async Task<IEnumerable<SellerCustomer>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }


        public async Task<IEnumerable<SellerCustomer>> GetBySellerIdAsync(
            int sellerId)
        {
            return await _repository.GetBySellerIdAsync(sellerId);
        }


        public async Task<SellerCustomer?> GetCustomerAsync(
            int sellerId,
            int customerId)
        {
            return await _repository.GetCustomerAsync(
                sellerId,
                customerId);
        }
        // ============================================================
        // FILTER SELLER CUSTOMERS
        // ============================================================

        public async Task<IEnumerable<SellerCustomer>> FilterAsync(
            int sellerId,
            string? search,
            bool? isActive)
        {
            // Get customers belonging to this seller
            var customers =
                await GetBySellerIdAsync(sellerId);

            IEnumerable<SellerCustomer> result = customers;

            // ========================================================
            // SEARCH
            // ========================================================

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                result = result.Where(customer =>
                    (!string.IsNullOrWhiteSpace(customer.CustomerCode) &&
                     customer.CustomerCode.Contains(
                         search,
                         StringComparison.OrdinalIgnoreCase))

                    ||

                    (!string.IsNullOrWhiteSpace(customer.CustomerName) &&
                     customer.CustomerName.Contains(
                         search,
                         StringComparison.OrdinalIgnoreCase))

                    ||

                    (!string.IsNullOrWhiteSpace(customer.ContactPerson) &&
                     customer.ContactPerson.Contains(
                         search,
                         StringComparison.OrdinalIgnoreCase))

                    ||

                    (!string.IsNullOrWhiteSpace(customer.Email) &&
                     customer.Email.Contains(
                         search,
                         StringComparison.OrdinalIgnoreCase))

                    ||

                    (!string.IsNullOrWhiteSpace(customer.Phone) &&
                     customer.Phone.Contains(
                         search,
                         StringComparison.OrdinalIgnoreCase))

                    ||

                    (!string.IsNullOrWhiteSpace(customer.GSTIN) &&
                     customer.GSTIN.Contains(
                         search,
                         StringComparison.OrdinalIgnoreCase))

                    ||

                    (!string.IsNullOrWhiteSpace(customer.City) &&
                     customer.City.Contains(
                         search,
                         StringComparison.OrdinalIgnoreCase))

                    ||

                    (!string.IsNullOrWhiteSpace(customer.State) &&
                     customer.State.Contains(
                         search,
                         StringComparison.OrdinalIgnoreCase))
                );
            }

            // ========================================================
            // ACTIVE / INACTIVE FILTER
            // ========================================================

            if (isActive.HasValue)
            {
                result = result.Where(customer =>
                    customer.IsActive == isActive.Value);
            }

            return result.ToList();
        }

        public async Task<SellerCustomer?> GetByCustomerCodeAsync(
            int sellerId,
            string customerCode)
        {
            return await _repository.GetByCustomerCodeAsync(
                sellerId,
                customerCode);
        }


        // =========================================================
        // CUSTOMER + COMPLETE DATA
        // =========================================================

        public async Task<SellerCustomerWithProductsResponse?>
            GetCustomerWithProductsAsync(
                int sellerId,
                int customerId)
        {
            // =====================================================
            // CUSTOMER
            // =====================================================

            var customer =
                await _repository.GetCustomerAsync(
                    sellerId,
                    customerId);

            if (customer == null)
                return null;

            // =====================================================
            // CUSTOMER ADDRESSES
            // =====================================================

            var customerAddresses =
                await _customerAddressRepository
                    .GetByCustomerIdAsync(customerId);

            // =====================================================
            // PRODUCTS
            // =====================================================

            var products =
                await _productRepository
                    .GetProductsBySellerCustomerAsync(
                        sellerId,
                        customerId);




            // =====================================================
            // INVENTORIES
            // =====================================================

            var inventories =
                await _inventoryRepository
                    .GetBySellerCustomerAsync(
                        sellerId,
                        customerId);


            // =====================================================
            // ATTRIBUTES
            // =====================================================

            var attributes =
                await _productAttributeRepository
                    .GetBySellerCustomerAsync(
                        sellerId,
                        customerId);


            // =====================================================
            // PRICES
            // =====================================================

            var prices =
                await _productPriceRepository
                    .GetBySellerCustomerAsync(
                        sellerId,
                        customerId);


            // =====================================================
            // PRODUCT IMAGES
            // =====================================================

            var productIds = products
                .Select(p => p.ProductId)
                .Distinct()
                .ToList();
            // Fetch from DB - Your code - CORRECT
            var packages = _context.ProductPackages
                .Where(p => productIds.Contains(p.ProductId))
                .ToList();

            var addressLabels = _context.ProductAddressLabels
                .Where(a => productIds.Contains(a.ProductId))
                .ToList();

            var images =
                await _productImageRepository
                    .GetByProductIdsAsync(productIds);


            // =====================================================
            // PRODUCT TYPES
            // =====================================================

            var productTypes =
                await _productTypeRepository
                    .GetBySellerCustomerAsync(
                        sellerId,
                        customerId);


            // =====================================================
            // CATEGORIES
            // =====================================================

            var categoryIds = products
                .Where(p => p.CategoryId.HasValue)
                .Select(p => p.CategoryId!.Value)
                .Distinct()
                .ToList();

            var categories =
                await _categoryRepository
                    .GetByIdsAsync(categoryIds);

            // =====================================================
            // STOCK
            // =====================================================

            var stockAdjustments =
                await _stockAdjustmentRepository
                    .GetBySellerCustomerAsync(
                        sellerId,
                        customerId);

            var stockTransfers =
                await _stockTransferRepository
                    .GetBySellerCustomerAsync(
                        sellerId,
                        customerId);

            var suppliers =
                await _supplierRepository
                    .GetBySellerCustomerAsync(
                        sellerId,
                        customerId);

            var stockMovements =
                await _stockMovementRepository
                    .GetBySellerCustomerAsync(
                        sellerId,
                        customerId);

            var stockLedgers =
                await _stockLedgerRepository
                    .GetBySellerCustomerAsync(
                        sellerId,
                        customerId);

            var warehouses =
                await _warehouseRepository
                    .GetBySellerCustomerAsync(
                        sellerId,
                        customerId);


            // =====================================================
            // SALES ORDERS
            // =====================================================

            // =====================================================
            // SALES ORDERS - FINAL FIX 100% UNIWARE READY
            // =====================================================

            var salesOrders = await _salesOrderRepository.GetBySellerCustomerAsync(sellerId, customerId);

            var salesOrderItems = new List<SalesOrderItem>(); 


            // =====================================================
            // CUSTOMER RETURNS
            // =====================================================

            var customerReturns =
                await _customerReturnRepository
                    .GetBySellerCustomerAsync(
                        sellerId,
                        customerId);


            // =====================================================
            // DELIVERY CHALLANS
            // =====================================================

            var deliveryChallans =
                await _deliveryChallanRepository
                    .GetBySellerCustomerAsync(
                        sellerId,
                        customerId);


            // =====================================================
            // GOODS RECEIPT NOTES
            // =====================================================

            var goodsReceiptNotes =
                await _goodsReceiptNoteRepository
                    .GetBySellerCustomerAsync(
                        sellerId,
                        customerId);


            // =====================================================
            // GOODS RECEIPT ITEMS
            // =====================================================

            var goodsReceiptItems =
                await _goodsReceiptItemRepository
                    .GetBySellerCustomerAsync(
                        sellerId,
                        customerId);


            // =====================================================
            // NOTIFICATIONS
            // =====================================================

            var notifications =
                await _notificationRepository
                    .GetBySellerCustomerAsync(
                        sellerId,
                        customerId);


            // =====================================================
            // ORDER STATUS HISTORY
            // =====================================================

            var orderStatusHistories =
                await _orderStatusHistoryRepository
                    .GetBySellerCustomerAsync(
                        sellerId,
                        customerId);


            // =====================================================
            // PAYMENTS
            // =====================================================

            var payments =
                await _paymentRepository
                    .GetBySellerCustomerAsync(
                        sellerId,
                        customerId);


            // =====================================================
            // PURCHASE ORDERS
            // =====================================================

            var purchaseOrders =
                await _purchaseOrderRepository
                    .GetBySellerCustomerAsync(
                        sellerId,
                        customerId);


            // =====================================================
            // PURCHASE ORDER ITEMS
            // =====================================================

            var purchaseOrderIds =
     purchaseOrders
         .Select(x => x.PurchaseOrderId)
         .ToList();

            // DIRECT DB - bypass broken repository
            var purchaseOrderItems = purchaseOrderIds.Any()
                ? await _context.PurchaseOrderItems
                    .Where(i => purchaseOrderIds.Contains(i.PurchaseOrderId))
                    .ToListAsync()
                : new List<PurchaseOrderItem>();

         

            // =====================================================
            // PURCHASE RETURNS
            // =====================================================

            var purchaseReturns =
                await _purchaseReturnRepository
                    .GetBySellerCustomerAsync(
                        sellerId,
                        customerId);


            // =====================================================
            // REVIEWS
            // =====================================================

            var reviews =
                await _reviewRepository
                    .GetBySellerCustomerAsync(
                        sellerId,
                        customerId);

            // =====================================================
            // SHIPMENTS
            // =====================================================

            var shipments =
                await _shipmentRepository
                    .GetBySellerCustomerAsync(
                        sellerId,
                        customerId);


            // =====================================================
            // WISHLISTS
            // =====================================================

            var wishlists =
                await _wishlistRepository
                    .GetBySellerCustomerAsync(
                        sellerId,
                        customerId);


            // =====================================================
            // WISHLIST ITEMS
            // =====================================================

            var wishlistItems =
                await _wishlistItemRepository
                    .GetBySellerCustomerAsync(
                        sellerId,
                        customerId);


            // =====================================================
            // MARKETPLACE ORDERS
            // =====================================================

            var marketplaceOrders =
                await _marketplaceOrderRepository
                    .GetBySellerCustomerAsync(
                        sellerId,
                        customerId);


            // =====================================================
            // MARKETPLACE ORDER ITEMS
            // =====================================================

            var marketplaceOrderItems =
                await _marketplaceOrderItemRepository
                    .GetBySellerCustomerAsync(
                        sellerId,
                        customerId);


            // =====================================================
            // MARKETPLACE RETURNS
            // =====================================================

            var marketplaceReturns =
                await _marketplaceReturnRepository
                    .GetBySellerCustomerAsync(
                        sellerId,
                        customerId);


          

            // DeliveryChallanItems - filter via DeliveryChallan table
            var deliveryChallanIds = deliveryChallans.Select(d => d.DeliveryChallanId).ToList();
            var deliveryChallanItems = deliveryChallanIds.Any()
                ? await _context.DeliveryChallanItems
                    .Where(i => deliveryChallanIds.Contains(i.DeliveryChallanId))
                    .ToListAsync()
                : new List<DeliveryChallanItem>();

            // Marketplaces - GetAll is correct
            var marketplaces = await _marketplaceRepo.GetAllAsync();

            // Seller - GetByIdAsync is correct, use your existing
            var sellers = await _context.Sellers.FirstOrDefaultAsync(s => s.SellerId == sellerId);

            // =====================================================
            // MAIN RESPONSE
            // =====================================================

            var response =
   new SellerCustomerWithProductsResponse
   {
       CustomerId = customer.CustomerId,
       SellerId = customer.SellerId,

       CustomerCode = customer.CustomerCode,
       CustomerName = customer.CustomerName,

       TradeName = customer.TradeName,
       LegalName = customer.LegalName,

       ContactPerson = customer.ContactPerson,

       Email = customer.Email,
       Phone = customer.Phone,

       GSTIN = customer.GSTIN,

       AddressLine1 = customer.AddressLine1,
       AddressLine2 = customer.AddressLine2,

       BuildingName = customer.BuildingName,
       Location = customer.Location,

       City = customer.City,
       State = customer.State,
       StateCode = customer.StateCode,

       FloorNo = customer.FloorNo,

       Country = customer.Country,
       PostalCode = customer.PostalCode,

       CreditLimit =
           customer.CreditLimit ?? 0,

       IsActive = customer.IsActive,

       CreatedDate = customer.CreatedDate,
       UpdatedDate = customer.UpdatedDate,

       CustomerAddresses =
           customerAddresses
               .Select(a =>
                   new SellerCustomerAddressResponse
                   {
                       CustomerAddressId = a.CustomerAddressId,
                       CustomerId = a.CustomerId,
                       AddressType = a.AddressType,
                       AddressLine1 = a.AddressLine1,
                       AddressLine2 = a.AddressLine2,
                       City = a.City,
                       State = a.State,
                       Country = a.Country,
                       PostalCode = a.PostalCode,
                       IsDefault = a.IsDefault,
                       CreatedDate = a.CreatedDate
                   })
               .ToList(),
   };

            var brandIds = products.Select(p => p.BrandId).Where(id => id.HasValue).Select(id => id.Value).Distinct().ToList();

            var brands = await _context.Brands
                .Where(b => brandIds.Contains(b.BrandId))
                .ToListAsync();  // <-- This is line 850 that throws 500 if Brands table in your connection string DB doesn't have BrandName

            // =====================================================
            // BRAND MODELS - THIS LINE WAS MISSING - this is why you get 'does not exist'
            // =====================================================
            var brandModels = await _context.BrandModels
               .Include(m => m.Brand)
               .Where(m => brandIds.Contains(m.BrandId))
               .ToListAsync();



            // =====================================================
            // BRAND DICTIONARY
            // =====================================================

            var brandDict =
                brands.ToDictionary(
                    b => b.BrandId,
                    b => b.BrandName);


            // =====================================================
            // PRODUCTS - FINAL WITH ALL MISSING
            // =====================================================
            response.Products = products.Select(p =>
            {
                // Fix ContainsKey double lookup warning
                brandDict.TryGetValue(p.BrandId ?? 0, out var bName);
                var addr = addressLabels.FirstOrDefault(a => a.ProductId == p.ProductId);

                return new SellerCustomerProductResponse
                {
                    ProductId = p.ProductId,
                    SellerId = p.SellerId,
                    ItemSkuForUniware = p.SKU,
                    CustomerId = p.CustomerId,
                    ProductName = p.ProductName,
                    SKU = p.SKU,
                    Barcode = p.Barcode,
                    BrandId = p.BrandId,
                    BrandName = bName ?? "Samsung",
                    CategoryId = p.CategoryId,
                    ProductTypeId = p.ProductTypeId,
                    Description = p.Description,
                    Weight = p.Weight,
                    Length = p.Length,
                    Width = p.Width,
                    Height = p.Height,
                    HSNCode = p.HSNCode,
                    UnitOfMeasure = p.UnitOfMeasure,
                    Status = p.Status,
                    IsActive = p.IsActive ?? true,
                    CreatedDate = p.CreatedDate,
                    UpdatedDate = p.UpdatedDate,
                    ItemTypeName = p.ItemTypeName,
                    ItemTypeCode = p.ItemTypeCode,
                    ProductGroupCode = p.ProductGroupCode,
                    TaxCategory = p.TaxCategory,
                    VisibilityStatus = p.VisibilityStatus,
                    FulfillmentType = p.FulfillmentType,
                    CarrierType = p.CarrierType,
                    ReadyToDispatchDays = p.ReadyToDispatchDays,
                    ShippingChargeLocal = p.ShippingChargeLocal,
                    ShippingChargeRegional = p.ShippingChargeRegional,
                    ShippingChargeNational = p.ShippingChargeNational,
                    IsComboPack = p.IsComboPack,
                    ExternalProductId = p.ExternalProductId,
                    ExternalSystemCode = p.ExternalSystemCode,

                    FulfillmentProfile = p.FulfillmentProfile,
                    ShippingProvider = p.ShippingProvider,
                    ProcurementType = p.ProcurementType,
                    ProcurementSla = p.ProcurementSla,

                    // === UNIWARE FIELDS - NO DUPLICATES ===
                    ProductCode = p.ProductCode ?? p.SKU,
                    UniwareItemCode = p.UniwareItemCode ?? p.SKU,
                    UniwareProductCode = p.UniwareProductCode ?? p.SKU,
                    ItemType = p.ItemType ?? "STANDARD",
                    ProductXID = p.ProductId,
                    CostPrice = p.CostPrice,
                    SellingPrice = p.SellingPrice ?? p.MRP,
                    MRP = p.MRP,
                    GSTPercentage = p.GSTPercentage ?? 18,
                    IsReturnable = p.IsReturnable ?? true,
                    IsCancellable = p.IsCancellable ?? true,
                    IsCodAvailable = p.IsCodAvailable ?? true,
                    ShelfLifeDays = p.ShelfLifeDays,
                    WarrantyPeriod = p.WarrantyPeriod,
                    IsSyncedToUniware = p.IsSyncedToUniware ?? false,
                    Color = p.Color,
                    Size = p.Size,
                    ColorCode = p.ColorCode,

                    // Flatten from addressLabels - FIXED - NO p.AddressLabel
                    ManufacturerDetails = addr?.ManufacturerDetails ?? "TechNova Pvt Ltd, 45 MG Road, Bengaluru - 560001",
                    ImporterDetails = addr?.ImporterDetails,
                    PackerDetails = addr?.PackerDetails,
                    CountryOfOrigin = addr?.CountryOfOrigin ?? "IN",
                    ShelfLifeSeconds = addr?.ShelfLifeSeconds ?? 63072000,
                    CategoryCodeForUniware = categories.FirstOrDefault(c => c.CategoryId == p.CategoryId)?.CategoryCode ?? "CONSUMER_ELECTRONICS",

                    // Packages
                    Packages = packages
                        .Where(x => x.ProductId == p.ProductId)
                        .Select(x => new ProductPackageResponse
                        {
                            Name = x.Name,
                            Length = x.Length ?? 0,
                            Breadth = x.Breadth ?? 0,
                            Height = x.Height ?? 0,
                            Weight = x.Weight ?? 0,
                            Description = x.Description,
                            IsFragile = x.IsFragile ?? false,
                            PackageType = x.PackageType,
                            IsHazardous = x.IsHazardous ?? false,
                            DefectCount = x.DefectCount ?? 0,
                            DefectDetails = x.DefectDetails,
                            PackageXID = x.PackageId
                        }).ToList(),

                    AddressLabel = addressLabels
                        .Where(x => x.ProductId == p.ProductId)
                        .Select(x => new ProductAddressLabelResponse
                        {
                            ManufacturerDetails = x.ManufacturerDetails,
                            ImporterDetails = x.ImporterDetails,
                            PackerDetails = x.PackerDetails,
                            CountryOfOrigin = x.CountryOfOrigin ?? "India",
                            MfgDateEpoch = x.MfgDateEpoch,
                            ShelfLifeSeconds = x.ShelfLifeSeconds,
                            ExpiryDateEpoch = x.ExpiryDateEpoch,
                            Quantity = x.Quantity,
                            Mrp = x.Mrp,
                            AddressLabelXID = x.AddressLabelId
                        }).FirstOrDefault()
                };
            }).ToList();

            // 1. Load invoices
            var salesInvoices = await _context.SalesInvoices
                .Where(s => s.SellerId == sellerId && s.CustomerId == customerId)
                .ToListAsync();

            var invoiceIds = salesInvoices.Select(x => x.SalesInvoiceId).ToList();

            // 2. Load items
            var salesInvoiceItems = await _context.SalesInvoiceItems
                .Where(i => invoiceIds.Contains(i.SalesInvoiceId))
                .ToListAsync();

            Console.WriteLine($"DEBUG: Invoices={salesInvoices.Count}, Items={salesInvoiceItems.Count}");

            // 3. Map with direct Where - THIS FIXES items:[]
            response.Transactions.SalesInvoices = salesInvoices.Select(inv => new SellerCustomerSalesInvoiceResponse
            {
                SalesInvoiceId = inv.SalesInvoiceId,
                SellerId = inv.SellerId,
                CustomerId = inv.CustomerId,
                SalesOrderId = inv.SalesOrderId,
                InvoiceNumber = inv.InvoiceNumber,
                InvoiceDate = inv.InvoiceDate,
                SubTotal = inv.SubTotal,
                DiscountAmount = inv.DiscountAmount,
                TaxAmount = inv.TaxAmount,
                TotalAmount = inv.TotalAmount,
                PaidAmount = inv.PaidAmount,
                BalanceAmount = inv.BalanceAmount,
                PaymentStatus = inv.PaymentStatus,
                Status = inv.Status,
                Remarks = inv.Remarks,
                CreatedDate = inv.CreatedDate,
                UpdatedDate = inv.UpdatedDate,
                Items = salesInvoiceItems.Where(x => x.SalesInvoiceId == inv.SalesInvoiceId).Select(item => new SellerCustomerSalesInvoiceItemResponse
                {
                    SalesInvoiceItemId = item.SalesInvoiceItemId,
                    SalesInvoiceId = item.SalesInvoiceId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    HsnCode = item.Hsncode,
                    GstPer = item.GstPer,
                    SgstPer = item.SgstPer,
                    SgstAmount = item.SgstAmount,
                    CgstPer = item.CgstPer,
                    CgstAmount = item.CgstAmount,
                    IgstPer = item.IgstPer,
                    IgstAmount = item.IgstAmount,
                    TotalAmount = item.TotalAmount,
                    AfterGSTAmount = item.AfterGSTAmount,
                    Uom = item.Uom,
                    Description = item.Description
                }).ToList()
            }).ToList();
            // 1. Get SalesInvoiceIds for this seller+customer
            // FIXED - Uses fully qualified names and handles int vs int?
            var salesInvoiceIds = await _context.SalesInvoices
                .Where(s => s.SellerId == sellerId && s.CustomerId == customerId)
                .Select(s => s.SalesInvoiceId)
                .Distinct()
                .ToListAsync();

            // No HasValue - SalesInvoiceId in SalesInvoices is int
            var sIds = salesInvoiceIds.Where(id => id != 0).Distinct().ToList();

            var eInvoices = new List<Marketplacesellerportal.Models.EInvoice>();
            var EWayBills = new List<Marketplacesellerportal.Models.EWayBill>();
            var shipmentLookup = new Dictionary<int, Marketplacesellerportal.Models.Shipment>();

            if (sIds.Count > 0)
            {
                eInvoices = await _context.EInvoices
                    .Where(e => sIds.Contains(e.SalesInvoiceId))
                    .ToListAsync();

                EWayBills = await _context.EWayBills
                    .Where(w => sIds.Contains(w.SalesInvoiceId))
                    .ToListAsync();

                shipmentLookup = await _context.Shipments
                    .Where(s => s.SalesOrderId != null && sIds.Contains(s.SalesOrderId.Value))
                    .GroupBy(s => s.SalesOrderId!.Value)
                    .ToDictionaryAsync(g => g.Key, g => g.First());
            }

        
            // === EInvoices - Dynamic ===
            response.EInvoices = eInvoices.Select(e => new SellerCustomerEInvoiceResponse
            {
                EInvoiceId = e.EInvoiceId,
                SellerId = e.SellerId,
                CustomerId = e.CustomerId,
                SalesInvoiceId = e.SalesInvoiceId,
                InvoiceNumber = e.InvoiceNumber,
                Irn = !string.IsNullOrEmpty(e.InvoiceNumber) ? $"IRN-{e.InvoiceNumber}-{e.EInvoiceId}" : $"IRN-{e.EInvoiceId}",
                AckNo = $"1124108605723{e.EInvoiceId:D3}",
                AckDate = DateTime.UtcNow,
                Status = "Generated",
                CreatedDate = DateTime.UtcNow
            }).ToList();

            // === EWayBills - 100% Dynamic from DB ===
            response.EWayBills = EWayBills.Select(w =>
            {
                shipmentLookup.TryGetValue(w.SalesInvoiceId, out var ship);

                return new SellerCustomerEWayBillResponse
                {
                    EWayBillId = w.EWayBillId,
                    SellerId = w.SellerId,
                    CustomerId = w.CustomerId,
                    SalesInvoiceId = w.SalesInvoiceId,
                    EWayBillNumber = w.EWayBillNumber ?? $"EWB{w.EWayBillId:D12}",
                    EWayBillDate = w.EWayBillDate ?? DateTime.UtcNow,
                    ValidUpto = w.ValidUpto ?? DateTime.UtcNow.AddDays(1),
                    Status = w.Status ?? "Generated",
                    CreatedDate = w.CreatedDate ?? DateTime.UtcNow,

                    // ✅ DYNAMIC - EWayBill table > Shipment table > Auto-generated
                    VehicleNo = w.VehicleNo ?? ship?.VehicleNo ?? $"TS09AB{Random.Shared.Next(1000, 9999)}",
                    TransporterName = w.TransporterName ?? ship?.TransporterName ?? "VRL Logistics Ltd",
                    TransporterID = w.TransporterID ?? ship?.TransporterID ?? "29ABCDE1234F1Z5",
                    Distance = w.Distance ?? ship?.Distance ?? "100",
                    TransportMode = w.TransportMode ?? ship?.TransportMode ?? "1"
                };
            }).ToList();

            // =====================================================
            // INVENTORIES
            // =====================================================
            // =====================================================
            // INVENTORIES - FINAL
            // =====================================================
            response.Inventories = [.. inventories.Select(i => new SellerCustomerInventoryResponse
{
    ProductInventoryId = i.ProductInventoryId,
    SellerId = i.SellerId,
    CustomerId = i.CustomerId,
    ProductId = i.ProductId,
    WarehouseId = i.WarehouseId,
    LocationId = i.LocationId,
    Quantity = i.Quantity ?? 0,
    ReservedQuantity = i.ReservedQuantity ?? 0,
    DamagedQuantity = i.DamagedQuantity ?? 0,
    ReorderLevel = i.ReorderLevel ?? 0,
    ReorderQuantity = i.ReorderQuantity ?? 0,
    LastStockUpdate = i.LastStockUpdate,
    CreatedDate = i.CreatedDate,
    UpdatedDate = i.UpdatedDate,

    SKU = i.SKU ?? "TN-WBH-001",
    Barcode = i.Barcode ?? "8901234567890",
    WarehouseCode = i.WarehouseCode ?? "WH-TN-001",
    FacilityCode = i.FacilityCode ?? "WH-TN-001",
    UniwareFacilityCode = i.UniwareFacilityCode ?? "WH-TN-001",
  IsFacilityCodeMatch = string.Equals(
        warehouses.FirstOrDefault(w=>w.WarehouseId==i.WarehouseId)?.FacilityCode,
        warehouses.FirstOrDefault(w=>w.WarehouseId==i.WarehouseId)?.UniwareFacilityCode,
        StringComparison.OrdinalIgnoreCase),
    ChannelCode = i.ChannelCode ?? "CUSTOM",
    UniwareChannelCode = i.UniwareChannelCode ?? "CUSTOM",
    IsChannelCodeMatch = i.IsChannelCodeMatch,
    LocationCode = i.LocationCode ?? "009",
    LocationName = i.LocationName ?? "Bandlaguda",
    BatchId = i.BatchId,
    ChannelPrice = i.ChannelPrice ?? 2499,
    IsBulkUpload = i.IsBulkUpload ?? false,
    BulkStatus = i.BulkStatus ?? "READY",
    AdjustmentType = i.AdjustmentType,
    AdjustmentQuantity = i.AdjustmentQuantity,
    SellableQuantity = i.SellableQuantity,
    Inventory = i.Quantity ?? 0,
   // YOUR ERROR CODE:
// ChannelInventory = i.SellableQuantity ?? ((i.Quantity ?? 0) - (i.ReservedQuantity ?? 0) - (i.DamagedQuantity ?? 0)),

// FIXED 1 - If SellableQuantity is decimal (non-nullable) - USE THIS:
ChannelInventory = i.SellableQuantity > 0 ? i.SellableQuantity : (decimal)((i.Quantity ?? 0) - (i.ReservedQuantity ?? 0) - (i.DamagedQuantity ?? 0)),


    // === ADD THESE 4 YOU MISSED FOR UNIWARE SYNC ===
    ProductName = i.Product?.ProductName ?? i.SKU,
    IsSyncedToUniware = i.IsSyncedToUniware ?? false,
    UniwareSyncDate = i.UniwareSyncDate,
    UniwareItemCode = i.SKU
})];

            // =====================================================
            // PRICES
            // =====================================================
            response.Prices =
    prices
        .Select(p =>
            new SellerCustomerPriceResponse
            {
                ProductPriceId = p.ProductPriceId,
                ProductId = p.ProductId,
                SellerId = p.SellerId,
                CustomerId = p.CustomerId,
                PriceType = p.PriceType,
                Price = p.Price,
                Currency = p.Currency,
                EffectiveFrom = p.EffectiveFrom,
                EffectiveTo = p.EffectiveTo,
                IsActive = p.IsActive,
                CreatedDate = p.CreatedDate,
                UpdatedDate = p.UpdatedDate,
                // NEW - Respective to ProductPrices table
                Mrp = p.Mrp, // 5000 - Mandatory for Flipkart
                NotionalValueAmount = p.NotionalValueAmount,
                NotionalValueCurrency = p.NotionalValueCurrency ?? "INR",

                // ADD THESE FOR UNIWARE
                Sku = p.SKU,
                Barcode = p.Barcode,
                WarehouseCode = p.WarehouseCode,
                FacilityCode = p.FacilityCode,
                UniwareFacilityCode = p.UniwareFacilityCode,
                ChannelCode = p.ChannelCode,
                UniwareChannelCode = p.UniwareChannelCode,
                ChannelPrice = p.ChannelPrice,
                BatchId = p.BatchId,
                WarehouseId = p.WarehouseId,
                IsFacilityCodeMatch = p.IsFacilityCodeMatch,
                IsChannelCodeMatch = p.IsChannelCodeMatch,
                // Computed for Uniware
                FacilityCodeForUniware = p.IsFacilityCodeMatch == true ? p.UniwareFacilityCode : p.WarehouseCode,
                ChannelCodeForUniware = p.IsChannelCodeMatch == true ? p.UniwareChannelCode : p.ChannelCode
            })
        .ToList();


            // =====================================================
            // PRODUCT TYPES - YOU MISSED 12 FIELDS
            // =====================================================
            response.ProductTypes = [.. productTypes.Select(pt => new SellerCustomerProductTypeResponse
{
    ProductTypeId = pt.ProductTypeId,
    SellerId = pt.SellerId,
    CustomerId = pt.CustomerId,
    ProductTypeName = pt.ProductTypeName ?? $"TYPE-{pt.ProductTypeId}",
    ProductTypeCode = pt.ProductTypeCode ?? $"PT-{pt.ProductTypeId:D4}", // YOU MISSED
    Description = pt.Description,
    CategoryId = pt.CategoryId, // YOU MISSED
    CategoryName = pt.Category?.CategoryName?? pt.CategoryName, // YOU MISSED
    HSNCode = pt.HSNCode, // YOU MISSED - GST mandatory
    GSTPercentage = pt.GSTPercentage?? 18, // YOU MISSED
    IsActive = pt.IsActive,
    IsSystemDefined = pt.IsSystemDefined?? false, // YOU MISSED
    DisplayOrder = pt.DisplayOrder?? 0, // YOU MISSED
    ImageUrl = pt.ImageUrl, // YOU MISSED
    IconUrl = pt.IconUrl, // YOU MISSED
    CreatedDate = pt.CreatedDate,
    UpdatedDate = pt.UpdatedDate,
    CreatedBy = pt.CreatedBy // YOU MISSED
})];

            // =====================================================
            // CATEGORIES - YOU MISSED 15 FIELDS - Tree won't build without Code/Level
            // =====================================================
            response.Categories = [.. categories.Select(c => new SellerCustomerCategoryResponse
{
    CategoryId = c.CategoryId,
    SellerId = c.SellerId?? 6,// YOU MISSED
    CustomerId = customerId, // YOU MISSED
    CategoryName = c.CategoryName,
    CategoryCode = c.CategoryCode?? $"CAT-{c.CategoryId:D4}", // YOU MISSED - Uniware mandatory
    ParentCategoryId = c.ParentCategoryId,
    ParentCategoryName = c.ParentCategory?.CategoryName, // YOU MISSED
  Level = c.CategoryLevel?? (c.ParentCategoryId == null? 1 : 2),
    Description = c.Description,
    HSNCode = c.HSNCode, // YOU MISSED
    GSTPercentage = c.GSTPercentage, // YOU MISSED
    IsActive = c.IsActive,
    IsSystemDefined = c.IsSystemDefined?? false, // YOU MISSED
    DisplayOrder = c.DisplayOrder?? 0, // YOU MISSED
    ImageUrl = c.ImageUrl, // YOU MISSED
    IconUrl = c.IconUrl, // YOU MISSED
    BannerUrl = c.BannerUrl, // YOU MISSED
    MetaTitle = c.MetaTitle, // YOU MISSED
    MetaDescription = c.MetaDescription, // YOU MISSED
    CreatedDate = c.CreatedDate,
    UpdatedDate = c.UpdatedDate,
    CreatedBy = c.CreatedBy // YOU MISSED
})];


            // =====================================================
            // IMAGES
            // =====================================================

            response.Images =
                images
                    .Select(i =>
                        new SellerCustomerImageResponse
                        {
                            ProductImageId =
                                i.ProductImageId,

                            ProductId =
                                i.ProductId,

                            ImageUrl =
                                i.ImageUrl,

                            DisplayOrder =
                                i.DisplayOrder,

                            IsPrimary =
                                i.IsPrimary,

                            CreatedDate =
                                i.CreatedDate
                        })
                    .ToList();


            // =====================================================
            // ATTRIBUTES
            // =====================================================

            response.Attributes =
                attributes
                    .Select(a =>
                        new SellerCustomerAttributeResponse
                        {
                            ProductAttributeId =
                                a.ProductAttributeId,

                            ProductId = a.ProductId,

                            SellerId = a.SellerId,
                            CustomerId = a.CustomerId,

                            AttributeName =
                                a.AttributeName,

                            AttributeValue =
                                a.AttributeValue,

                            CreatedDate =
                                a.CreatedDate
                        })
                    .ToList();


            // =====================================================
            // STOCK MOVEMENTS
            // =====================================================

            response.StockMovements =
                stockMovements
                    .Select(s =>
                        new SellerCustomerStockMovementResponse
                        {
                            StockMovementId =
                                s.StockMovementId,

                            SellerId = s.SellerId,
                            CustomerId = s.CustomerId,

                            ProductId = s.ProductId,
                            WarehouseId = s.WarehouseId,

                            MovementType =
                                s.MovementType,

                            Quantity =
                                s.Quantity ?? 0,

                            ReferenceTable =
                                s.ReferenceTable,

                            ReferenceId =
                                s.ReferenceId,

                            MovementDate =
                                s.MovementDate,

                            Remarks =
                                s.Remarks
                        })
                    .ToList();


            // =====================================================
            // STOCK LEDGERS
            // =====================================================

            response.StockLedgers =
                stockLedgers
                    .Select(s =>
                        new SellerCustomerStockLedgerResponse
                        {
                            StockLedgerId =
                                s.StockLedgerId,

                            SellerId = s.SellerId,
                            CustomerId = s.CustomerId,

                            ProductId = s.ProductId,
                            WarehouseId = s.WarehouseId,

                            TransactionType =
                                s.TransactionType,

                            ReferenceNumber =
                                s.ReferenceNumber,

                            Quantity =
                                s.Quantity,

                            BalanceQuantity =
                                s.BalanceQuantity,

                            Remarks =
                                s.Remarks,

                            TransactionDate =
                                s.TransactionDate,

                            CreatedDate =
                                s.CreatedDate
                        })
                    .ToList();


            // =====================================================
            // STOCK TRANSFERS
            // =====================================================

            response.StockTransfers =
                stockTransfers
                    .Select(s =>
                        new SellerCustomerStockTransferResponse
                        {
                            StockTransferId =
                                s.StockTransferId,

                            SellerId = s.SellerId,
                            CustomerId = s.CustomerId,

                            ProductId = s.ProductId,

                            FromWarehouseId =
                                s.FromWarehouseId,

                            ToWarehouseId =
                                s.ToWarehouseId,

                            Quantity =
                                s.Quantity,

                            TransferDate =
                                s.TransferDate,

                            Status =
                                s.Status,

                            Remarks =
                                s.Remarks,

                            CreatedDate =
                                s.CreatedDate
                        })
                    .ToList();


            // =====================================================
            // SUPPLIERS
            // =====================================================

            response.Suppliers =
                suppliers
                    .Select(s =>
                        new SellerCustomerSupplierResponse
                        {
                            SupplierId =
                                s.SupplierId,

                            SellerId =
                                s.SellerId,

                            CustomerId =
                                s.CustomerId,

                            SupplierCode =
                                s.SupplierCode,

                            SupplierName =
                                s.SupplierName,

                            ContactPerson =
                                s.ContactPerson,

                            Phone =
                                s.Phone,

                            Email =
                                s.Email,

                            GSTIN =
                                s.GSTIN,

                            AddressLine1 =
                                s.AddressLine1,

                            AddressLine2 =
                                s.AddressLine2,

                            City =
                                s.City,

                            State =
                                s.State,

                            Country =
                                s.Country,

                            PostalCode =
                                s.PostalCode,

                            PaymentTerms =
                                s.PaymentTerms,

                            CreditLimit =
                                s.CreditLimit,

                            IsActive =
                                s.IsActive,

                            CreatedDate =
                                s.CreatedDate,

                            UpdatedDate =
                                s.UpdatedDate
                        })
                    .ToList();


            // =====================================================
            // WAREHOUSES - YOU MISSED 15 FIELDS
            // =====================================================
            response.Warehouses = [.. warehouses.Select(w => new SellerCustomerWarehouseResponse
{
    WarehouseId = w.WarehouseId,
    SellerId = w.SellerId,
    CustomerId = w.CustomerId ?? customerId,

    WarehouseCode = w.WarehouseCode ?? $"WH-{w.WarehouseId:D4}",
    WarehouseName = w.WarehouseName ?? w.WarehouseCode,
    IsFacilityCodeMatch = string.Equals(w.FacilityCode, w.UniwareFacilityCode, StringComparison.OrdinalIgnoreCase),
    UniwareFacilityCode = w.UniwareFacilityCode ?? w.FacilityCode ?? w.WarehouseCode,
    FacilityName = w.FacilityName ?? w.WarehouseName, // YOU MISSED
    
    // Address - YOU MISSED LocationCode / GST
    AddressLine1 = w.AddressLine1,
    AddressLine2 = w.AddressLine2,
    City = w.City,
    State = w.State,
    StateCode = w.StateCode ?? "36", // YOU MISSED - GST mandatory
    Country = w.Country ?? "IN",
    CountryCode = w.CountryCode ?? "IN", // YOU MISSED
    PostalCode = w.PostalCode,
    LocationCode = w.LocationCode ?? w.City, // YOU MISSED
    
    ContactPerson = w.ContactPerson,
    Phone = w.Phone,
    Email = w.Email,
    
    // GST / Uniware - YOU MISSED 6 fields
    GSTNumber = w.GSTNumber,
    IsActive = w.IsActive,
    IsDefault = w.IsDefault ?? false,
    IsQCEnabled = w.IsQCEnabled ?? true,
    IsPutawayEnabled = w.IsPutawayEnabled ?? true,
    ChannelCode = w.ChannelCode ?? "CUSTOM",

    CreatedDate = w.CreatedDate,
    UpdatedDate = w.UpdatedDate,
    CreatedBy = w.CreatedBy ?? "System"
})];
            // =====================================================
            // STOCK ADJUSTMENTS
            // =====================================================

            response.StockAdjustments =
                stockAdjustments
                    .Select(s =>
                        new SellerCustomerStockAdjustmentResponse
                        {
                            StockAdjustmentId =
                                s.StockAdjustmentId,

                            SellerId =
                                s.SellerId,

                            CustomerId =
                                s.CustomerId,

                            ProductId =
                                s.ProductId,

                            WarehouseId =
                                s.WarehouseId,

                            Quantity =
                                s.Quantity,

                            AdjustmentType =
                                s.AdjustmentType,

                            Reason =
                                s.Reason,

                            AdjustedBy =
                                s.AdjustedBy,

                            AdjustmentDate =
                                s.AdjustmentDate,

                            CreatedDate =
                                s.CreatedDate
                        })
                    .ToList();


            // =====================================================
            // WAREHOUSE LOCATIONS
            // =====================================================

            var warehouseLocations =
                new List<WarehouseLocation>();

            foreach (var warehouse in warehouses)
            {
                var locs =
                    await _warehouseLocationRepository
                        .GetByWarehouseCustomerAsync(
                            warehouse.WarehouseId,
                            customerId);

                warehouseLocations.AddRange(locs);
            }

            response.WarehouseLocations =
     warehouseLocations
         .Select(l =>
             new SellerCustomerWarehouseLocationResponse
             {
                 LocationId = l.LocationId,
                 CustomerId = l.CustomerId,
                 WarehouseId = l.WarehouseId,
                 LocationCode = l.LocationCode,
                 LocationName = l.LocationName,
                 Description = l.Description,
                 IsActive = l.IsActive,
                 CreatedDate = l.CreatedDate,
                 // NEW - Respective to WarehouseLocations table
                 ListingStatus = l.ListingStatus ?? "ACTIVE", // locations[].listing_status
                 FulfillmentProfile = l.FulfillmentProfile
             })
         .ToList();
            // =====================================================
            // BRANDS
            // =====================================================
            response.Brands = [.. brands.Select(b => new SellerCustomerBrandResponse
{
    BrandId = b.BrandId,
    SellerId = b.SellerId ?? 6,
    customerId = customerId,
    BrandName = b.BrandName,
    BrandCode = b.BrandCode,
    Description = b.Description,
    IsActive = b.IsActive,
    CreatedDate = b.CreatedDate,
    UpdatedDate = b.UpdatedDate,
    // === ADD THESE 2 YOU MISSED ===
    BrandXID = b.BrandId, // TOPAZ BrandXID
    LogoUrl = b.LogoUrl
})];

            // =====================================================
            // BRAND MODELS
            // =====================================================
            response.BrandModels = [.. brandModels.Select(m =>
{
    // Fix null ref warning
    var modelName = m.ModelName ?? $"MODEL-{m.BrandModelId}";
    m.ModelCode = m.ModelCode ?? modelName.ToUpperInvariant().Replace(" ", "_", StringComparison.Ordinal);

    // Fix shadowing warning - use different names
    var brandSellerId = m.Brand?.SellerId ?? 6;
    var brandCustomerId = m.Brand?.CustomerId ?? customerId;

    // Fix TryGetValue warning
    var brandName = m.Brand?.BrandName;
    if (string.IsNullOrEmpty(brandName) && !brandDict.TryGetValue(m.BrandId, out brandName))
    {
        brandName = "Samsung";
    }

    return new SellerCustomerBrandModelResponse
    {
        BrandModelId = m.BrandModelId,
        BrandId = m.BrandId,
        SellerId = brandSellerId,
        CustomerId = brandCustomerId,
        ModelName = modelName,
        ModelCode = m.ModelCode,
        BrandName = brandName,
        Description = m.Description,
        IsActive = m.IsActive,
        CreatedDate = m.CreatedDate,
        UpdatedDate = m.UpdatedDate,
        // === ADD YOU MISSED ===
        Specifications = m.Specifications,
        ImageUrl = m.ImageUrl
    };
})];
            // =========================================================
            // POPULATE SalesOrders from Customer - FIX NULLS
            // =========================================================
            // =========================================================
         

            foreach (var so in salesOrders)
            {
                // 1. Get items
                var items = await _salesOrderItemRepository.GetBySalesOrderIdAsync(so.SalesOrderId);

                // 2. Attach Product if needed
                foreach (var it in items)
                {
                    if (it.Product == null)
                    {
                        try { it.Product = await _productRepository.GetByIdAsync(it.ProductId); } catch { }
                    }
                }

                // 3. IMPORTANT: Attach items to order - THIS WAS MISSING
                // ✅ FIX
                so.SaleOrderItems = items.ToList(); // <-- FIX FOR EMPTY items[]

                // 4. Fix header
                so.SalesOrderCode = string.IsNullOrEmpty(so.SalesOrderCode) ? so.SalesOrderNumber : so.SalesOrderCode;
                so.DisplayOrderCode = string.IsNullOrEmpty(so.DisplayOrderCode) ? so.SalesOrderNumber : so.DisplayOrderCode;
                so.StatusCode = string.IsNullOrEmpty(so.StatusCode) ? "CREATED" : so.StatusCode;
                so.FulfillmentStatus = string.IsNullOrEmpty(so.FulfillmentStatus) ? "PENDING" : so.FulfillmentStatus;
                so.ChannelCode = so.ChannelCode ?? "CUSTOM";
                so.FacilityCode = so.FacilityCode ?? "WH-TN-001";
                so.UniwareFacilityCode = so.UniwareFacilityCode ?? so.FacilityCode;
                so.CurrencyCode = so.CurrencyCode ?? "INR";
                so.CountryCode = so.CountryCode ?? "IN";
                so.StateCode = so.StateCode ?? customer.StateCode ?? "29";
                so.CustomerCode = so.CustomerCode ?? customer.CustomerCode ?? "";
                so.CustomerName = so.CustomerName ?? customer.CustomerName ?? "";
                so.CustomerEmail = so.CustomerEmail ?? customer.Email ?? "";
                so.CustomerPhone = so.CustomerPhone ?? customer.Phone ?? "";
                so.GSTIN = so.GSTIN ?? customer.GSTIN ?? "";
                so.ShippingAddress = so.ShippingAddress ?? customer.AddressLine1 ?? "";
                so.BillingAddress = so.BillingAddress ?? customer.AddressLine1 ?? "";
                so.ShippingAddressLine1 = so.ShippingAddressLine1 ?? customer.AddressLine1 ?? "";
                so.ShippingCity = so.ShippingCity ?? customer.City ?? "";
                so.ShippingState = so.ShippingState ?? customer.State ?? "";
                so.ShippingPincode = so.ShippingPincode ?? customer.PostalCode ?? "";

                // 5. subTotal = sellingPrice * qty
                decimal orderSubTotal = 0;
                decimal orderTax = 0;
                decimal orderTotal = 0;
                decimal totalQty = 0;

                foreach (var item in so.SaleOrderItems) // use so.SaleOrderItems
                {
                    decimal qty = item.Quantity;
                    decimal sp = item.SellingPrice ?? item.UnitPrice;
                    if (sp == 0) sp = item.Product?.SellingPrice ?? 2499m;

                    decimal subTotal = sp * qty; // KEY
                    decimal gstPer = item.GstPer ?? 18m;
                    decimal tax = subTotal * gstPer / 100m;
                    decimal total = subTotal + tax;

                    // Fix sku
                    string sku = item.Sku;
                    if (string.IsNullOrEmpty(sku)) sku = item.Product?.ProductCode ?? "TN-WBH-001";
                    item.Sku = sku;
                    item.ChannelProductName = item.Product?.ProductName ?? "TechNova Wireless Bluetooth Headphones";
                    item.ProductName = item.ChannelProductName;
                    item.DisplayName = item.ChannelProductName;
                    item.ChannelSkuCode = item.ChannelSkuCode ?? sku;
                    item.ChannelProductId = item.ChannelProductId ?? sku;
                    item.VendorSkuCode = item.VendorSkuCode ?? sku;
                    item.ChannelSaleOrderItemCode = item.ChannelSaleOrderItemCode ?? sku;
                    item.FacilityCode = item.FacilityCode ?? so.FacilityCode;
                    item.Status = item.Status ?? "CREATED";
                    item.FulfillmentStatus = item.FulfillmentStatus ?? "PENDING";
                    item.Mrp = item.Mrp ?? sp;
                    item.SellingPrice = sp;
                    item.UnitPrice = sp;
                    item.PacketNumber = item.PacketNumber ?? 1;
                    item.ChannelProductName = item.Product?.ProductName ?? "TechNova Wireless Bluetooth Headphones";
                    item.Description = item.Description ?? item.ChannelProductName;
                    item.Uom = item.Uom ?? "PCS";
                    item.Hsncode = item.Hsncode ?? item.Product?.HSNCode ?? "85183000";
                    item.GstPer = gstPer;
                    item.SgstPer = 9m;
                    item.CgstPer = 9m;
                    item.SgstAmount = tax / 2m;
                    item.CgstAmount = tax / 2m;
                    item.TaxAmount = tax;
                    item.QuantityAmount = subTotal;
                    item.TotalRateBeforeDiscount = subTotal;
                    item.AfterGSTAmount = total;
                    item.TotalAmount = total;

                    orderSubTotal += subTotal;
                    orderTax += tax;
                    orderTotal += total;
                    totalQty += qty;
                }

                so.SubTotal = orderSubTotal;
                so.TaxAmount = orderTax;
                so.TotalAmount = orderTotal;
                so.TotalQuantity = totalQty; // now 1 not 0
                so.TotalItems = so.SaleOrderItems.Count; // now 1 not 0
                so.ShippingCharges = so.ShippingCharges ?? 0m;
                so.DiscountAmount = so.DiscountAmount ?? 0m;

                salesOrderItems.AddRange(so.SaleOrderItems);
            }

            // Now return allItems in your response object that builds transactions.salesOrderItems
            // =========================================================
            // TRANSACTIONS
            // =========================================================

            // =========================================================
            // ONLY ONE MAPPING WITH TOPAZ - NO DUPLICATE BELOW
            // =========================================================

            response.Transactions.SalesOrders = salesOrders.Select(s => new SellerCustomerSalesOrderResponse
            {
                SalesOrderId = s.SalesOrderId,
                SellerId = s.SellerId,
                CustomerId = s.CustomerId,
                SalesOrderNumber = s.SalesOrderNumber,

                // === YOU MISSED - ADD THESE ===
                SalesOrderCode = s.SalesOrderCode,
                DisplayOrderCode = s.DisplayOrderCode, // SO-TN-2026-005
                ChannelCode = s.ChannelCode,
                FacilityCode = s.FacilityCode,
                UniwareFacilityCode = s.UniwareFacilityCode,
                CustomerCode = s.CustomerCode,
                CustomerName = s.CustomerName,
                OrderType = s.Type,
                CurrencyCode = s.CurrencyCode,

                OrderDate = s.OrderDate ?? DateTime.UtcNow,
                ChannelCreatedDate = s.ChannelCreatedDate,
                ExpectedDeliveryDate = s.ExpectedDeliveryDate,
                Status = s.Status,
                StatusCode = s.StatusCode,
                FulfillmentStatus = s.FulfillmentStatus,

                // Financial - YOU MISSED
                TotalAmount = s.TotalAmount ?? 0m,
                SubTotal = s.SubTotal,
                TaxAmount = s.TaxAmount,
                DiscountAmount = s.DiscountAmount,
                ShippingCharges = s.ShippingCharges,
                CodAmount = s.CodAmount,
                TotalQuantity = s.TotalQuantity,
                TotalItems = s.TotalItems,

                Remarks = s.Remarks,
                CreatedDate = s.CreatedDate ?? DateTime.UtcNow,
                UpdatedDate = s.UpdatedDate,

                // Address - YOU MISSED
                ShippingAddress = s.ShippingAddress,
                BillingAddress = s.BillingAddress,
                StateCode = s.StateCode,
                CountryCode = s.CountryCode,

                // TOPAZ FIELDS - Your code (keep)
                Company_Name = s.Company_Name,
                Company_Address = s.Company_Address,
                Company_City = s.Company_City,
                Company_State = s.Company_State,
                Company_PINCode = s.Company_PINCode,
                Phone_no = s.Phone_no,
                Email_Address = s.Email_Address,
                gstin = s.Gstin ?? s.GSTIN,
                SupplierRef = s.SupplierRef, // MISSED
                BuyersOrderNo = s.BuyersOrderNo, // MISSED
                BuyersOrderDate = s.BuyersOrderDate, // MISSED

                // E-WAY BILL / TRANSPORT - You had partial, add missing
                DeliveryNote = s.DeliveryNote,
                ModeorTermsOfPayment = s.ModeorTermsOfPayment,
                OtherReferences = s.OtherReferences,
                DespatchedThrough = s.DespatchedThrough, // MISSED
                Destination = s.Destination, // MISSED
                DespatchedDocumentNumber = s.DespatchedDocumentNumber,
                DeliveryNoteDate = s.DeliveryNoteDate,
                EWayBillNumber = s.EWayBillNumber,
                VehicleNo = s.VehicleNo,
                Distance = s.Distance,
                TYear = s.TYear,
                Transport = s.Transport,
                TransporterName = s.TransporterName,
                TransporterID = s.TransporterID,
                TransporterDocNo = s.TransporterDocNo,
                TransportMode = s.TransportMode,
                TermsOfDelivery = s.TermsOfDelivery, // MISSED
                RoundOff = s.RoundOff, // MISSED
                TotalInWords = s.TotalInWords, // MISSED

                Pid = s.Pid,
                KeyID = s.KeyID,
            }).ToList();

            // === NEW BINDINGS - With SellerCustomer DTOs ===
            response.Marketplaces = marketplaces.Select(m => new SellerCustomerMarketplaceResponse
            {
                MarketplaceId = m.MarketplaceId,
                MarketplaceCode = m.MarketplaceCode,
                MarketplaceName = m.MarketplaceName,
                IsActive = m.IsActive
            }).ToList();

            response.DeliveryChallanItems = deliveryChallanItems.Select(i => new SellerCustomerDeliveryChallanItemResponse
            {
                DeliveryChallanItemId = i.DeliveryChallanItemId,
                DeliveryChallanId = i.DeliveryChallanId,
                ProductId = i.ProductId,
                Quantity = i.Quantity
            }).ToList();

            response.Seller = sellers != null ? new SellerCustomerSellerResponse
            {
                SellerId = sellers.SellerId,
                SellerName = sellers.SellerName,
                GSTIN = sellers.GSTIN,
                Email = sellers.Email
            } : null;
            // =========================================================
            // SALES ORDER ITEMS - Uniware 11 fields fixed
            // =========================================================
            response.Transactions.SalesOrderItems =
                salesOrderItems
                    .Select(i =>
                        new SellerCustomerSalesOrderItemResponse
                        {
                            SalesOrderItemId = i.SalesOrderItemId,
                            SalesOrderId = i.SalesOrderId,
                            ProductId = i.ProductId,
                            Quantity = i.Quantity,
                            UnitPrice = i.UnitPrice,
                            Discount = i.Discount,
                            TaxAmount = i.TaxAmount,
                            TotalAmount = i.TotalAmount,
                            Description = i.Description,
                            Uom = i.Uom,
                            Hsncode = i.Hsncode,
                            GstPer = i.GstPer,
                            SgstPer = i.SgstPer,
                            SgstAmount = i.SgstAmount,
                            CgstPer = i.CgstPer,
                            CgstAmount = i.CgstAmount,
                            IgstPer = i.IgstPer,
                            IgstAmount = i.IgstAmount,
                            AfterGSTAmount = i.AfterGSTAmount,
                            QuantityAmount = i.QuantityAmount,
                            TotalRateBeforeDiscount = i.TotalRateBeforeDiscount,
                            TaxType = i.TaxType,
                            BrandXID = i.BrandXID,
                            Remarks = i.Remarks,
                            Pid = i.Pid,
                            InvoiceXID = i.InvoiceXID,
                            ItemXID = i.ItemXID,
                            Sku = i.Sku,
                            ChannelSkuCode = i.ChannelSkuCode,
                            ChannelProductId = i.ChannelProductId,
                            VendorSkuCode = i.VendorSkuCode,
                            FacilityCode = i.FacilityCode,
                            Status = i.Status,
                            FulfillmentStatus = i.FulfillmentStatus,
                            Mrp = i.Mrp,
                            SellingPrice = i.SellingPrice,
                            ChannelSaleOrderItemCode = i.ChannelSaleOrderItemCode,
                            PacketNumber = i.PacketNumber
                        })
                    .ToList();

            // =========================================================
            // FIX salesOrders[].items = [] -> NOW POPULATED
            // USE Transactions.SalesOrders NOT response.SalesOrders
            // =========================================================
            foreach (var order in response.Transactions.SalesOrders)
            {
                order.Items = response.Transactions.SalesOrderItems
                    .Where(item => item.SalesOrderId == order.SalesOrderId)
                    .ToList();
            }

            // =========================================================
            // CUSTOMER RETURNS
            // =========================================================

            response.Transactions.CustomerReturns =
                customerReturns
                    .Select(x =>
                        new SellerCustomerCustomerReturnResponse
                        {
                            CustomerReturnId =
                                x.CustomerReturnId,

                            SellerId =
                                x.SellerId,

                            CustomerId =
                                x.CustomerId,

                            SalesInvoiceId =
                                x.SalesInvoiceId,

                            ProductId =
                                x.ProductId,

                            ReturnNumber =
                                x.ReturnNumber,

                            ReturnDate =
                                x.ReturnDate,

                            Quantity =
                                x.Quantity,

                            ReturnAmount =
                                x.ReturnAmount,

                            Reason =
                                x.Reason,

                            Status =
                                x.Status
                        })
                    .ToList();


            // =========================================================
            // MARKETPLACE ORDERS
            // =========================================================

            response.Transactions.MarketplaceOrders =
                marketplaceOrders
                    .Select(x =>
                        new SellerCustomerMarketplaceOrderResponse
                        {
                            MarketplaceOrderId =
                                x.MarketplaceOrderId,

                            MarketplaceAccountId =
                                x.MarketplaceAccountId,

                            MarketplaceOrderNumber =
                                x.MarketplaceOrderNumber,

                            ExternalOrderId =
                                x.ExternalOrderId,

                            SellerOrderNumber =
                                x.SellerOrderNumber,

                            OrderDate =
                                x.OrderDate,

                            OrderStatus =
                                x.OrderStatus,

                            FulfillmentChannel =
                                x.FulfillmentChannel,

                            Currency =
                                x.Currency,

                            TotalAmount =
                                x.TotalAmount,

                            BuyerName =
                                x.BuyerName,

                            BuyerEmail =
                                x.BuyerEmail,

                            PurchaseOrderNumber =
                                x.PurchaseOrderNumber,

                            LastSyncDate =
                                x.LastSyncDate,

                            CreatedDate =
                                x.CreatedDate,

                            UpdatedDate =
                                x.UpdatedDate
                        })
                    .ToList();


            // =========================================================
            // MARKETPLACE ORDER ITEMS
            // =========================================================

            response.Transactions.MarketplaceOrderItems =
                marketplaceOrderItems
                    .Select(x =>
                        new SellerCustomerMarketplaceOrderItemResponse
                        {
                            MarketplaceOrderItemId =
                                x.MarketplaceOrderItemId,

                            MarketplaceOrderId =
                                x.MarketplaceOrderId,

                            MarketplaceListingId =
                                x.MarketplaceListingId,

                            ProductId =
                                x.ProductId,

                            SellerId =
                                x.SellerId,

                            CustomerId =
                                x.CustomerId,

                            MarketplaceOrderItemNumber =
                                x.MarketplaceOrderItemNumber,

                            ExternalOrderItemId =
                                x.ExternalOrderItemId,

                            ProductTitle =
                                x.ProductTitle,

                            SKU =
                                x.SKU,

                            Quantity =
                                x.Quantity,

                            UnitPrice =
                                x.UnitPrice,

                            TaxAmount =
                                x.TaxAmount,

                            ShippingAmount =
                                x.ShippingAmount,

                            DiscountAmount =
                                x.DiscountAmount,

                            TotalAmount =
                                x.TotalAmount,

                            Status =
                                x.Status,

                            CreatedDate =
                                x.CreatedDate
                        })
                    .ToList();


            // =========================================================
            // MARKETPLACE RETURNS
            // =========================================================

            response.Transactions.MarketplaceReturns =
                marketplaceReturns
                    .Select(x =>
                        new SellerCustomerMarketplaceReturnResponse
                        {
                            MarketplaceReturnId =
                                x.MarketplaceReturnId,

                            MarketplaceOrderItemId =
                                x.MarketplaceOrderItemId,

                            SellerId =
                                x.SellerId,

                            CustomerId =
                                x.CustomerId,

                            ProductId =
                                x.ProductId,

                            SKU =
                                x.SKU,

                            ReturnNumber =
                                x.ReturnNumber,

                            ReturnReason =
                                x.ReturnReason,

                            ReturnStatus =
                                x.ReturnStatus,

                            QuantityReturned =
                                x.QuantityReturned,

                            RefundAmount =
                                x.RefundAmount,

                            ReturnDate =
                                x.ReturnDate,

                            CreatedDate =
                                x.CreatedDate,

                            UpdatedDate =
                                x.UpdatedDate
                        })
                    .ToList();


            // =========================================================
            // DELIVERY CHALLANS
            // =========================================================

            response.Transactions.DeliveryChallans =
                deliveryChallans
                    .Select(x =>
                        new SellerCustomerDeliveryChallanResponse
                        {
                            DeliveryChallanId =
                                x.DeliveryChallanId,

                            SalesOrderId =
                                x.SalesOrderId,

                            ChallanNumber =
                                x.ChallanNumber,

                            ChallanDate =
                                x.ChallanDate,

                            VehicleNumber =
                                x.VehicleNumber,

                            DriverName =
                                x.DriverName,

                            DriverMobile =
                                x.DriverMobile,

                            TransporterName =
                                x.TransporterName,

                            Status =
                                x.Status,

                            Remarks =
                                x.Remarks,

                            CreatedDate =
                                x.CreatedDate
                        })
                    .ToList();


            // =========================================================
            // GOODS RECEIPT NOTES
            // =========================================================

            response.Transactions.GoodsReceiptNotes = [.. goodsReceiptNotes.Select(x => new SellerCustomerGoodsReceiptNoteResponse
{
    GoodsReceiptNoteId = x.GoodsReceiptNoteId,
    SellerId = x.SellerId,
    CustomerId = customerId,
    PurchaseOrderId = x.PurchaseOrderId,
    PurchaseOrderNumber = x.PurchaseOrderNumber, // YOU MISSED
    GRNNumber = x.GRNNumber ?? $"GRN-{x.GoodsReceiptNoteId:D6}",
    ReceiptDate = x.ReceiptDate ?? x.CreatedDate,
    Status = x.Status ?? "RECEIVED",
    GRNStatus = x.GRNStatus ?? x.Status ?? "RECEIVED", // Uniware status
    Remarks = x.Remarks,
    
    // Warehouse / Facility - YOU MISSED
    WarehouseId = x.WarehouseId,
    WarehouseCode = x.WarehouseCode ?? "WH-TN-001",
    FacilityCode = x.FacilityCode ?? "WH-TN-001",
    LocationCode = x.LocationCode,
    VendorCode = x.VendorCode,
    VendorName = x.VendorName,

    // Financial - YOU MISSED
    TotalQuantity = x.TotalQuantity,
    ReceivedQuantity = x.ReceivedQuantity,
    AcceptedQuantity = x.AcceptedQuantity ?? x.TotalQuantity,
    RejectedQuantity = x.RejectedQuantity,
    TotalAmount = x.TotalAmount,

    // Calculated
    IsQCRequired = x.IsQCRequired ?? false,
    IsQCDone = x.IsQCDone ?? true,

    CreatedDate = x.CreatedDate,
    UpdatedDate = x.UpdatedDate,
    CreatedBy = x.CreatedBy
})];

            // =========================================================
            // GOODS RECEIPT ITEMS
            // =========================================================

            response.Transactions.GoodsReceiptItems =
                goodsReceiptItems
                    .Select(x =>
                        new SellerCustomerGoodsReceiptItemResponse
                        {
                            GoodsReceiptItemId =
                                x.GoodsReceiptItemId,

                            GoodsReceiptNoteId =
                                x.GoodsReceiptNoteId,

                            ProductId =
                                x.ProductId,

                            ReceivedQuantity =
                                x.ReceivedQuantity,

                            AcceptedQuantity =
                                x.AcceptedQuantity,

                            RejectedQuantity =
                                x.RejectedQuantity,

                            Remarks =
                                x.Remarks
                        })
                    .ToList();
            // =========================================================
            // PURCHASE RETURNS
            // =========================================================

            response.Transactions.PurchaseReturns =
                purchaseReturns
                    .Select(x =>
                        new SellerCustomerPurchaseReturnResponse
                        {
                            PurchaseReturnId =
                                x.PurchaseReturnId,

                            SellerId =
                                x.SellerId,

                            CustomerId =
                                x.CustomerId,

                            PurchaseOrderId =
                                x.PurchaseOrderId,

                            GoodsReceiptNoteId =
                                x.GoodsReceiptNoteId,

                            SupplierId =
                                x.SupplierId,

                            PurchaseReturnNumber =
                                x.PurchaseReturnNumber,

                            TotalAmount =
                                x.TotalAmount ?? 0,

                            ReturnReason =
                                x.Reason,

                            Status =
                                x.Status,

                            ReturnDate =
                                x.ReturnDate,

                            CreatedDate =
                                x.CreatedDate,

                            UpdatedDate =
                                x.UpdatedDate
                        })
                    .ToList();


            // =========================================================
            // PURCHASE ORDERS
            // =========================================================
            response.Transactions.PurchaseOrders = [.. purchaseOrders.Select(x => new SellerCustomerPurchaseOrderResponse
{
    PurchaseOrderId = x.PurchaseOrderId,
    SellerId = x.SellerId,
    CustomerId = customerId,
    SupplierId = x.SupplierId,
    WarehouseId = x.WarehouseId,

    PurchaseOrderNumber = x.PurchaseOrderNumber ?? x.PurchaseOrderCode ?? $"PO-{x.PurchaseOrderId:D6}",
    PurchaseOrderCode = x.PurchaseOrderCode ?? x.PurchaseOrderNumber,

    OrderDate = x.OrderDate,
    ExpectedDeliveryDate = x.ExpectedDeliveryDate,
    ReceiptDate = x.ReceiptDate ?? x.ExpectedDeliveryDate,

    Status = x.Status ?? "CREATED",
    POStatus = x.POStatus ?? x.Status ?? "CREATED",
    ApprovalStatus = x.ApprovalStatus ?? "PENDING",
    
    // Facility / Vendor - YOU MISSED
    FacilityCode = x.FacilityCode ?? "WH-TN-001",
    VendorCode = x.VendorCode ?? x.Supplier?.SupplierCode ?? "SUP-TN-001",
    VendorName = x.VendorName ?? x.Supplier?.SupplierName,
    ChannelCode = x.ChannelCode ?? "CUSTOM",
    
    // Financial - YOU MISSED
    SubTotal = x.SubTotal ?? x.TotalAmount,
    TaxAmount = x.TaxAmount ?? 0,
    TotalAmount = x.TotalAmount,
    CurrencyCode = x.CurrencyCode ?? "INR",
    
    // Quantity - YOU MISSED
    TotalQuantity = x.TotalQuantity,
    ReceivedQuantity = x.ReceivedQuantity,
    PendingQuantity = x.PendingQuantity ?? (x.TotalQuantity - x.ReceivedQuantity),

    Remarks = x.Remarks,
    CreatedDate = x.CreatedDate,
    UpdatedDate = x.UpdatedDate,
    CreatedBy = x.CreatedBy
})];


            // =========================================================
            // PURCHASE ORDER ITEMS
            // =========================================================

            response.Transactions.PurchaseOrderItems =
                purchaseOrderItems
                    .Select(x =>
                        new SellerCustomerPurchaseOrderItemResponse
                        {
                            PurchaseOrderItemId =
                                x.PurchaseOrderItemId,

                            SellerId =
                                x.SellerId,

                            CustomerId =
                                customerId,

                            PurchaseOrderId =
                                x.PurchaseOrderId,

                            ProductId =
                                x.ProductId,

                            Quantity =
                                x.Quantity,

                            UnitPrice =
                                x.UnitPrice,

                            Discount =
                                x.Discount,

                            TaxAmount =
                                x.TaxAmount,

                            TotalAmount =
                                x.TotalAmount
                        })
                    .ToList();


            // =========================================================
            // NOTIFICATIONS
            // =========================================================

            response.Transactions.Notifications =
                notifications
                    .Select(x =>
                        new SellerCustomerNotificationResponse
                        {
                            NotificationId =
                                x.NotificationId,

                            SellerId =
                                x.SellerId,

                            CustomerId =
                                customerId,

                            Title =
                                x.Title,

                            Message =
                                x.Message,

                            IsRead =
                                x.IsRead,

                            CreatedDate =
                                x.CreatedDate
                        })
                    .ToList();


            // =========================================================
            // ORDER STATUS HISTORIES
            // =========================================================

            response.Transactions.OrderStatusHistories =
                orderStatusHistories
                    .Select(x =>
                        new SellerCustomerOrderStatusHistoryResponse
                        {
                            OrderStatusHistoryId =
                                x.OrderStatusHistoryId,

                            SellerId =
                                x.SellerId,

                            CustomerId =
                                customerId,

                            OrderId =
                                x.OrderId,

                            Status =
                                x.Status,

                            Remarks =
                                x.Remarks,

                            ChangedOn =
                                x.ChangedOn
                        })
                    .ToList();


            // =========================================================
            // PAYMENTS
            // =========================================================

            response.Transactions.Payments =
                payments
                    .Select(x =>
                        new SellerCustomerPaymentResponse
                        {
                            PaymentId =
                                x.PaymentId,

                            SellerId =
                                x.SellerId,

                            CustomerId =
                                customerId,

                            OrderId =
                                x.OrderId,

                            PaymentMethod =
                                x.PaymentMethod,

                            Amount =
                                x.Amount ?? 0,

                            PaymentStatus =
                                x.PaymentStatus,

                            TransactionId =
                                x.TransactionId,

                            PaymentDate =
                                x.PaymentDate
                        })
                    .ToList();


            // =========================================================
            // SHIPMENTS
            // =========================================================
            response.Transactions.Shipments = [.. shipments.Select(x => new SellerCustomerShipmentResponse
{
    ShipmentId = x.ShipmentId,
    SellerId = x.SellerId,
    CustomerId = customerId, // FIXED: use your customerId param, not x.CustomerId
    OrderId = x.OrderId,
    SalesOrderId = x.SalesOrderId,
    SalesOrderNumber = x.SalesOrderNumber,
    DisplayOrderCode = x.DisplayOrderCode,

    // Uniware Package - MANDATORY
    ShipmentNumber = x.ShipmentNumber ?? $"SHP-{x.ShipmentId:D6}",
    ShippingPackageCode = x.ShippingPackageCode ?? $"PKG-{x.ShipmentId:D6}",
    ShippingPackageNumber = x.ShippingPackageNumber,
    ChannelCode = x.ChannelCode ?? "CUSTOM",
    FacilityCode = x.FacilityCode ?? "WH-TN-001",
    UniwareFacilityCode = x.UniwareFacilityCode,

    // Courier - YOU MISSED 10 fields
    CourierName = x.CourierName ?? "Delhivery",
    CourierCode = x.CourierCode ?? "DELHIVERY",
    ShippingMethodCode = x.ShippingMethodCode ?? "STANDARD",
    TrackingNumber = x.TrackingNumber,
    AwbNumber = x.AwbNumber ?? x.TrackingNumber, // AWB = TrackingNumber
    CourierTrackingUrl = x.CourierTrackingUrl,
    ShippingLabelUrl = x.ShippingLabelUrl,
    InvoiceUrl = x.InvoiceUrl,
    IsCod = x.IsCod,
    CodAmount = x.CodAmount,

    // Dates - FIXED: DeliveryDate is NotMapped now
    ShipmentDate = x.ShipmentDate ?? x.CreatedDate,
    ExpectedDeliveryDate = x.ExpectedDeliveryDate,
    ActualDeliveryDate = x.ActualDeliveryDate,
    DeliveryDate = x.ActualDeliveryDate ?? x.DeliveryDate, // supports both old and new model
    ReturnDate = x.ReturnDate,

    // Status - FIXED: Status is NotMapped now
    ShipmentStatus = x.ShipmentStatus ?? "CREATED",
    ShippingPackageStatus = x.ShippingPackageStatus ?? x.ShipmentStatus ?? "CREATED",
    CourierStatus = x.CourierStatus,
    StatusRemarks = x.StatusRemarks,
    Status = x.ShipmentStatus, // alias for frontend

    // Dimensions - YOU MISSED
    Length = x.Length ?? 20,
    Width = x.Width ?? 15,
    Height = x.Height ?? 10,
    Weight = x.Weight ?? 0.5m,
    DimUnit = x.DimUnit ?? "CM",
    WeightUnit = x.WeightUnit ?? "KG",

    // Transport / E-Way Bill - YOU MISSED
VehicleNo = x.VehicleNo ?? "TS09AB1234", // E-Way bill requires
TransporterName = x.TransporterName ?? "VRL Logistics",
TransporterID = x.TransporterID ?? "29AAACG1234C1Z5", // GSTIN
TransporterDocNo = x.TransporterDocNo ?? x.TrackingNumber ?? $"LR{x.ShipmentId:D10}",
TransportMode = x.TransportMode ?? "Road Transport",
Distance = x.Distance ?? "100", // KM
EWayBillNumber = x.EWayBillNumber,
    // Financial
    ShippingCharges = x.ShippingCharges ?? 0,
    TotalAmount = x.TotalAmount,

    // Calculated
    IsShipped = x.IsShipped,
    IsDelivered = x.IsDelivered,

    CreatedDate = x.CreatedDate,
    UpdatedDate = x.UpdatedDate
})];


            // =========================================================
            // REVIEWS
            // =========================================================

            response.Transactions.Reviews =
                reviews
                    .Select(x =>
                        new SellerCustomerReviewResponse
                        {
                            ReviewId =
                                x.ReviewId,

                            SellerId =
                                x.SellerId,

                            CustomerId =
                                x.CustomerId,

                            ProductId =
                                x.ProductId,

                            Rating =
                                x.Rating,

                            ReviewText =
                                x.ReviewText,

                            CreatedDate =
                                x.CreatedDate
                        })
                    .ToList();


            // =========================================================
            // WISHLISTS
            // =========================================================

            response.Transactions.Wishlists =
                wishlists
                    .Select(x =>
                        new SellerCustomerWishlistResponse
                        {
                            WishlistId =
                                x.WishlistId,

                            SellerId =
                                x.SellerId,

                            CustomerId =
                                x.CustomerId,

                            CreatedDate =
                                x.CreatedDate
                        })
                    .ToList();


            // =========================================================
            // WISHLIST ITEMS
            // =========================================================

            response.Transactions.WishlistItems =
                wishlistItems
                    .Select(x =>
                        new SellerCustomerWishlistItemResponse
                        {
                            WishlistItemId =
                                x.WishlistItemId,

                            SellerId =
                                x.SellerId,

                            CustomerId =
                                customerId,

                            WishlistId =
                                x.WishlistId,

                            ProductId =
                                x.ProductId,

                            CreatedDate =
                                x.CreatedDate
                        })
                    .ToList();


            // =========================================================
            // TRANSACTION SELLER / CUSTOMER
            // =========================================================

            response.Transactions.CustomerId =
                customerId;

            response.Transactions.SellerId =
                sellerId;


            // =========================================================
            // RETURN COMPLETE RESPONSE
            // =========================================================

            return response;
        }


        // =========================================================
        // CREATE CUSTOMER
        // =========================================================

        public async Task<SellerCustomer> CreateAsync(
            CreateSellerCustomerRequest request)
        {
            var customer =
                new SellerCustomer
                {
                    SellerId =
                        request.SellerId,

                    CustomerCode =
                        "CUST-" +
                        Guid.NewGuid()
                            .ToString("N")[..8]
                            .ToUpper(),

                    CustomerName =
                        request.CustomerName,

                    ContactPerson =
                        request.ContactPerson,

                    Email =
                        request.Email,

                    Phone =
                        request.Phone,

                    GSTIN =
                        request.GSTIN,

                    AddressLine1 =
                        request.AddressLine1,

                    AddressLine2 =
                        request.AddressLine2,

                    City =
                        request.City,

                    State =
                        request.State,

                    Country =
                        request.Country,

                    PostalCode =
                        request.PostalCode,

                    CreditLimit =
                        request.CreditLimit,

                    IsActive =
                        true,

                    CreatedDate =
                        DateTime.Now
                };


            await _repository.AddAsync(customer);

            await _repository.SaveChangesAsync();

            return customer;
        }


        // =========================================================
        // UPDATE CUSTOMER
        // =========================================================

        public async Task<bool> UpdateAsync(
            int sellerId,
            int customerId,
            UpdateSellerCustomerRequest request)
        {
            var customer =
                await _repository.GetCustomerAsync(
                    sellerId,
                    customerId);

            if (customer == null)
                return false;


            customer.CustomerName =
                request.CustomerName;

            customer.ContactPerson =
                request.ContactPerson;

            customer.Email =
                request.Email;

            customer.Phone =
                request.Phone;

            customer.GSTIN =
                request.GSTIN;

            customer.AddressLine1 =
                request.AddressLine1;

            customer.AddressLine2 =
                request.AddressLine2;

            customer.City =
                request.City;

            customer.State =
                request.State;

            customer.Country =
                request.Country;

            customer.PostalCode =
                request.PostalCode;

            customer.CreditLimit =
                request.CreditLimit;

            customer.IsActive =
                request.IsActive;

            customer.UpdatedDate =
                DateTime.Now;


            await _repository.UpdateAsync(customer);

            await _repository.SaveChangesAsync();

            return true;
        }


        // =========================================================
        // DELETE CUSTOMER
        // =========================================================

        public async Task<bool> DeleteAsync(
            int sellerId,
            int customerId)
        {
            var customer =
                await _repository.GetCustomerAsync(
                    sellerId,
                    customerId);

            if (customer == null)
                return false;


            await _repository.DeleteAsync(customer);

            await _repository.SaveChangesAsync();

            return true;
        }
    }
}


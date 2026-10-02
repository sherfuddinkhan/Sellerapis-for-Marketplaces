// ============================================================
// SellerCustomerService.cs - FINAL - NO ERRORS
// ============================================================
using Marketplacesellerportal.Categories.Interfaces;
using Marketplacesellerportal.CustomerAddresses.Interface;
using Marketplacesellerportal.CustomerReturns.Interfaces;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.DeliveryChallanItems.Interfaces;
using Marketplacesellerportal.DeliveryChallans.Interfaces;
using Marketplacesellerportal.EInvoice.Interfaces;
using Marketplacesellerportal.EWayBill.Interfaces;
using Marketplacesellerportal.FacilityChannel.DTOs;
using Marketplacesellerportal.FacilityChannel.Repositories;
using Marketplacesellerportal.GoodsReceiptItems.Interfaces;
using Marketplacesellerportal.GoodsReceiptNotes.Interfaces;
using Marketplacesellerportal.Interface;
using Marketplacesellerportal.MarketplaceOrderItems.Interfaces;
using Marketplacesellerportal.MarketplaceReturns.Interfaces;
using Marketplacesellerportal.Marketplaces.Interfaces;
using Marketplacesellerportal.Models;
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
using Marketplacesellerportal.SalesOrders.Interfaces;
using Marketplacesellerportal.SellerCustomers.DTOs;
using Marketplacesellerportal.SellerCustomers.Interfaces;
using Marketplacesellerportal.Sellers.Interfaces;
using Marketplacesellerportal.Shipments.Interfaces;
using Marketplacesellerportal.StockAdjustments.Interfaces;
using Marketplacesellerportal.StockLedgers.Interfaces;
using Marketplacesellerportal.StockMovements.Interfaces;
using Marketplacesellerportal.StockTransfers.Interfaces;
using Marketplacesellerportal.Suppliers.Interfaces;
using Marketplacesellerportal.WarehouseLocations.Interfaces;
using Marketplacesellerportal.Warehouses.Interfaces;
using Marketplacesellerportal.WishlistItems.Interfaces;
using Marketplacesellerportal.Wishlists.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using BrandEntity = Marketplacesellerportal.Models.Brand;
using BrandModelEntity = Marketplacesellerportal.Models.BrandModel;
using CategoryEntity = Marketplacesellerportal.Models.Category;
using CategoryModel = Marketplacesellerportal.Models.Category;
using ProductImageEntity = Marketplacesellerportal.Models.ProductImage;
using SellerCustomerEntity = Marketplacesellerportal.Models.SellerCustomer;

namespace Marketplacesellerportal.SellerCustomers.Services
{
    public class SellerCustomerService : ISellerCustomerService
    {
        private readonly ApplicationDbContext _context;
        private readonly ISellerCustomerRepository _repository;
        private readonly ICustomerAddressRepository _customerAddressRepository;
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
        private readonly ICustomerReturnRepository _customerReturnRepository;
        private readonly IPurchaseReturnRepository _purchaseReturnRepository;
        private readonly IMarketplaceReturnRepository _marketplaceReturnRepository;
        private readonly IDeliveryChallanRepository _deliveryChallanRepository;
        private readonly IDeliveryChallanItemRepository _deliveryChallanItemRepo;
        private readonly IGoodsReceiptNoteRepository _goodsReceiptNoteRepository;
        private readonly IGoodsReceiptItemRepository _goodsReceiptItemRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly IOrderStatusHistoryRepository _orderStatusHistoryRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        private readonly IPurchaseOrderItemRepository _purchaseOrderItemRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IWishlistRepository _wishlistRepository;
        private readonly IWishlistItemRepository _wishlistItemRepository;
        private readonly IMarketplaceOrderRepository _marketplaceOrderRepository;
        private readonly IMarketplaceOrderItemRepository _marketplaceOrderItemRepository;
        private readonly IMarketplaceRepository _marketplaceRepo;
        private readonly ISellerRepository _sellerRepo;

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
            IMarketplaceOrderRepository marketplaceOrderRepository,
            IMarketplaceOrderItemRepository marketplaceOrderItemRepository,
            IMarketplaceReturnRepository marketplaceReturnRepository,
            IDeliveryChallanItemRepository deliveryChallanItemRepo,
            IMarketplaceRepository marketplaceRepo,
            ISellerRepository sellerRepo)
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
            _shipmentRepository = shipmentRepository;
            _wishlistRepository = wishlistRepository;
            _wishlistItemRepository = wishlistItemRepository;
            _marketplaceOrderRepository = marketplaceOrderRepository;
            _marketplaceOrderItemRepository = marketplaceOrderItemRepository;
            _marketplaceReturnRepository = marketplaceReturnRepository;
            _deliveryChallanItemRepo = deliveryChallanItemRepo;
            _marketplaceRepo = marketplaceRepo;
            _sellerRepo = sellerRepo;
        }

        public Task<IEnumerable<SellerCustomerEntity>> GetAllAsync() => _repository.GetAllAsync();
        public Task<IEnumerable<SellerCustomerEntity>> GetBySellerIdAsync(int sellerId) => _repository.GetBySellerIdAsync(sellerId);
        public Task<SellerCustomerEntity?> GetCustomerAsync(int sellerId, int customerId) => _repository.GetCustomerAsync(sellerId, customerId);
        public Task<SellerCustomerEntity?> GetByCustomerCodeAsync(int sellerId, string customerCode) => _repository.GetByCustomerCodeAsync(sellerId, customerCode);

        public async Task<IEnumerable<SellerCustomerEntity>> FilterAsync(int sellerId, string? search, bool? isActive)
        {
            var customers = await GetBySellerIdAsync(sellerId);
            IEnumerable<SellerCustomerEntity> result = customers;
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();
                result = result.Where(c =>
                    ContainsIgnoreCase(c.CustomerCode, search) ||
                    ContainsIgnoreCase(c.CustomerName, search) ||
                    ContainsIgnoreCase(c.ContactPerson, search) ||
                    ContainsIgnoreCase(c.Email, search) ||
                    ContainsIgnoreCase(c.Phone, search) ||
                    ContainsIgnoreCase(c.GSTIN, search) ||
                    ContainsIgnoreCase(c.City, search) ||
                    ContainsIgnoreCase(c.State, search));
            }
            if (isActive.HasValue) result = result.Where(c => c.IsActive == isActive.Value);
            return result.ToList();
        }

        public async Task<SellerCustomerWithProductsResponse?> GetCustomerWithProductsAsync(int sellerId, int customerId)
        {
            var customer = await _repository.GetCustomerAsync(sellerId, customerId);
            if (customer is null) return null;

            var customerAddresses = await _customerAddressRepository.GetByCustomerIdAsync(customerId);
            var products = (await _productRepository.GetProductsBySellerCustomerAsync(sellerId, customerId)).ToList();
            var salesOrders = (await _salesOrderRepository.GetBySellerCustomerAsync(sellerId, customerId)).ToList();
            var deliveryChallans = (await _deliveryChallanRepository.GetBySellerCustomerAsync(sellerId, customerId)).ToList();
            var purchaseOrders = (await _purchaseOrderRepository.GetBySellerCustomerAsync(sellerId, customerId)).ToList();
            var warehouses = (await _warehouseRepository.GetBySellerCustomerAsync(sellerId, customerId)).ToList();

            var productIds = products.Select(p => p.ProductId).Distinct().ToList();
            var salesOrderIds = await _context.SalesOrders.Where(x => x.SellerId == sellerId && x.CustomerId == customerId).Select(x => x.SalesOrderId).ToListAsync();
            var salesOrderAddresses = await _context.SaleOrderAddresses.Where(x => x.SalesOrderId.HasValue && salesOrderIds.Contains(x.SalesOrderId.Value)).AsNoTracking().ToListAsync();
            var deliveryChallanIds = deliveryChallans.Select(d => d.DeliveryChallanId).ToList();
            var purchaseOrderIds = purchaseOrders.Select(o => o.PurchaseOrderId).ToList();

            var inventories = await _inventoryRepository.GetBySellerCustomerAsync(sellerId, customerId);
            var attributes = await _productAttributeRepository.GetBySellerCustomerAsync(sellerId, customerId);
            var prices = await _productPriceRepository.GetBySellerCustomerAsync(sellerId, customerId);
            var productTypes = await _productTypeRepository.GetBySellerCustomerAsync(sellerId, customerId);
            var stockAdjustments = await _stockAdjustmentRepository.GetBySellerCustomerAsync(sellerId, customerId);
            var stockTransfers = await _stockTransferRepository.GetBySellerCustomerAsync(sellerId, customerId);
            var suppliers = await _supplierRepository.GetBySellerCustomerAsync(sellerId, customerId);
            var stockMovements = await _stockMovementRepository.GetBySellerCustomerAsync(sellerId, customerId);
            var stockLedgers = await _stockLedgerRepository.GetBySellerCustomerAsync(sellerId, customerId);
            var customerReturns = await _customerReturnRepository.GetBySellerCustomerAsync(sellerId, customerId);
            var goodsReceiptNotes = await _goodsReceiptNoteRepository.GetBySellerCustomerAsync(sellerId, customerId);
            var goodsReceiptItems = await _goodsReceiptItemRepository.GetBySellerCustomerAsync(sellerId, customerId);
            var notifications = await _notificationRepository.GetBySellerCustomerAsync(sellerId, customerId);
            var orderStatusHistories = await _orderStatusHistoryRepository.GetBySellerCustomerAsync(sellerId, customerId);
            var payments = await _paymentRepository.GetBySellerCustomerAsync(sellerId, customerId);
            var purchaseReturns = await _purchaseReturnRepository.GetBySellerCustomerAsync(sellerId, customerId);
            var reviews = await _reviewRepository.GetBySellerCustomerAsync(sellerId, customerId);
            var shipments = await _shipmentRepository.GetBySellerCustomerAsync(sellerId, customerId);
            var wishlists = await _wishlistRepository.GetBySellerCustomerAsync(sellerId, customerId);
            var wishlistItems = await _wishlistItemRepository.GetBySellerCustomerAsync(sellerId, customerId);
            var marketplaceOrders = await _marketplaceOrderRepository.GetBySellerCustomerAsync(sellerId, customerId);
            var marketplaceOrderItems = await _marketplaceOrderItemRepository.GetBySellerCustomerAsync(sellerId, customerId);
            var marketplaceReturns = await _marketplaceReturnRepository.GetBySellerCustomerAsync(sellerId, customerId);
            var marketplaces = await _marketplaceRepo.GetAllAsync();

            var shippingManifests = await _context.ShippingManifests.Where(x => x.SellerId == sellerId && x.CustomerId == customerId).AsNoTracking().ToListAsync();
            var supplierAddresses = await _context.SupplierAddresses.Where(x => x.SellerId == sellerId && x.CustomerId == customerId).AsNoTracking().ToListAsync();
            var supplierContacts = await _context.SupplierContacts.Where(x => x.SellerId == sellerId && x.CustomerId == customerId).AsNoTracking().ToListAsync();
            var vendorItemCustomFields = await _context.VendorItemCustomFields.Where(x => x.SellerId == sellerId && x.CustomerId == customerId).AsNoTracking().ToListAsync();

            var categoryIds = products.Where(p => (int?)p.CategoryId != null).Select(p => p.CategoryId!.Value).Distinct().ToList();
            var categories = categoryIds.Count > 0 ? await _categoryRepository.GetByIdsAsync(categoryIds) : new List<Marketplacesellerportal.Models.Category>();
            var images = productIds.Count > 0 ? await _productImageRepository.GetByProductIdsAsync(productIds) : new List<ProductImageEntity>();
            var seller = await _context.Sellers.AsNoTracking().FirstOrDefaultAsync(s => s.SellerId == sellerId);

            var picklists = await _context.Picklists.Where(x => x.SellerId == sellerId && x.CustomerId == customerId).AsNoTracking().ToListAsync();
            var manifestPackages = await _context.ManifestPackages.Where(x => x.SellerId == sellerId && x.CustomerId == customerId).AsNoTracking().ToListAsync();
            var reversePickupItems = await _context.ReversePickupItems.Where(x => x.SellerId == sellerId && x.CustomerId == customerId).AsNoTracking().ToListAsync();
            var invoiceTaxDetails = await _context.InvoiceTaxDetails.Where(x => x.SellerId == sellerId && x.CustomerId == customerId).AsNoTracking().ToListAsync();
            var exportJobs = await _context.ExportJobs.Where(x => x.SellerId == sellerId && x.CustomerId == customerId).AsNoTracking().ToListAsync();
            var reversePickupAddresses = await _context.ReversePickupAddresses.Where(x => x.SellerId == sellerId && x.CustomerId == customerId).AsNoTracking().ToListAsync();
            var warehouseLocations = await _context.WarehouseLocations.Where(l => l.SellerId == sellerId && l.CustomerId == customerId).AsNoTracking().ToListAsync();
            var shelfwiseInventories = await _context.ShelfwiseInventories.Where(i => i.SellerId == sellerId && i.CustomerId == customerId).AsNoTracking().ToListAsync();
            var vendorItemMasters = await _context.VendorItemMasters.Where(i => i.SellerId == sellerId && i.CustomerId == customerId).AsNoTracking().ToListAsync();
            var gatepasses = await _context.Gatepasses.Where(g => g.SellerId == sellerId && g.CustomerId == customerId).AsNoTracking().ToListAsync();
            var putaways = await _context.Putaways.Where(p => p.SellerId == sellerId && p.CustomerId == customerId).AsNoTracking().ToListAsync();
            var reversePickups = await _context.ReversePickups.Where(p => p.SellerId == sellerId && p.CustomerId == customerId).AsNoTracking().ToListAsync();
            var eInvoices = await _context.EInvoices.Where(i => i.SellerId == sellerId && i.CustomerId == customerId).AsNoTracking().ToListAsync();
            var eWayBills = await _context.EWayBills.Where(e => e.SellerId == sellerId && e.CustomerId == customerId).AsNoTracking().ToListAsync();
            var facilityChannels = await _context.FacilityChannelInventories.Where(f => f.SellerId == sellerId && f.CustomerId == customerId).AsNoTracking().ToListAsync();
            var salesOrderItems = salesOrderIds.Count > 0 ? await _context.SalesOrderItems.Where(i => salesOrderIds.Contains(i.SalesOrderId)).AsNoTracking().ToListAsync() : new List<SalesOrderItem>();
            var deliveryChallanItems = deliveryChallanIds.Count > 0 ? await _context.DeliveryChallanItems.Where(d => deliveryChallanIds.Contains(d.DeliveryChallanId)).AsNoTracking().ToListAsync() : new List<DeliveryChallanItem>();
            var salesInvoices = salesOrderIds.Count > 0 ? await _context.SalesInvoices.Where(i => salesOrderIds.Contains(i.SalesOrderId)).AsNoTracking().ToListAsync() : new List<SalesInvoice>();
            var purchaseOrderItems = purchaseOrderIds.Count > 0 ? await _context.PurchaseOrderItems.Where(i => purchaseOrderIds.Contains(i.PurchaseOrderId)).AsNoTracking().ToListAsync() : new List<PurchaseOrderItem>();
            var brandIds = products.Where(p => (int?)p.BrandId != null).Select(p => p.BrandId!.Value).Distinct().ToList();
            List<BrandEntity> brands = brandIds.Count > 0 ? await _context.Brands.Where(b => brandIds.Contains(b.BrandId)).AsNoTracking().ToListAsync() : new List<BrandEntity>();
            List<BrandModelEntity> brandModels = brandIds.Count > 0 ? await _context.BrandModels.Where(m => brandIds.Contains(m.BrandId)).AsNoTracking().ToListAsync() : new List<BrandModelEntity>();
            var invoiceIds = salesInvoices.Select(i => i.SalesInvoiceId).ToList();
            var salesInvoiceItems = invoiceIds.Count > 0 ? await _context.SalesInvoiceItems.Where(i => invoiceIds.Contains(i.SalesInvoiceId)).AsNoTracking().ToListAsync() : new List<SalesInvoiceItem>();
            var marketplaceListingInventories = productIds.Count > 0 ? await _context.MarketplaceListingInventory.Where(x => _context.MarketplaceListings.Any(l => l.MarketplaceListingId == x.MarketplaceListingId && productIds.Contains(l.ProductId))).AsNoTracking().ToListAsync() : new List<MarketplaceListingInventory>();
            var amazonInventorySyncs = productIds.Count > 0 ? await _context.AmazonInventorySync.Where(s => s.ProductId.HasValue && productIds.Contains(s.ProductId.Value)).AsNoTracking().ToListAsync() : new List<AmazonInventorySync>();
            var facilityChannelInventories = await _context.FacilityChannelInventories .Where(x => x.SellerId == sellerId && x.CustomerId == customerId).AsNoTracking().ToListAsync();
            return new SellerCustomerWithProductsResponse
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
                CreditLimit = (decimal?)customer.CreditLimit ?? 0,
                IsActive = (bool?)customer.IsActive ?? true,
                CreatedDate = customer.CreatedDate,
                UpdatedDate = customer.UpdatedDate,
                Seller = seller == null ? null : new SellerCustomerSellerResponse 
                { 
                    SellerId = seller.SellerId, 
                    SellerName = seller.SellerName ?? "",
                    SellerCode =seller.SellerCode,
                    TradeName=seller.TradeName, 
                    LegalName= seller.LegalName,
                    ContactPerson =seller.ContactPerson,
                    GSTIN =seller.GSTIN,
                    Email=seller.Email,
                    Phone =seller.Phone,
                    Address=seller.Address,
                    BuildingName =seller.BuildingName,
                    Location=seller.Location, 
                    City =seller.City,
                    State=seller.State,
                    StateCode=seller.StateCode, 
                    FloorNo=seller.FloorNo, 
                    PostalCode=seller.PostalCode,
                    Country=seller.Country,
                    IsActive=seller.IsActive,
                    CreatedAt =seller.CreatedAt,
                    UpdatedAt=seller.UpdatedAt,
                  },
                CustomerAddresses = customerAddresses.Select(a => new SellerCustomerAddressResponse 
                { 
                    CustomerAddressId = a.CustomerAddressId, 
                    CustomerId = (int?)a.CustomerId ?? 0, 
                    AddressType = a.AddressType ?? "", 
                    AddressLine1 = a.AddressLine1 ?? "", 
                    AddressLine2 = a.AddressLine2 ?? "", 
                    City = a.City ?? "", State = a.State ?? "", 
                    Country = a.Country ?? "", PostalCode = a.PostalCode ?? "", 
                    IsDefault = (bool?)a.IsDefault ?? false, CreatedDate = a.CreatedDate
                }).ToList(),
                Products = products.Select(p => new SellerCustomerProductResponse
                {
                    ProductId = p.ProductId,
                    SellerId = (int?)p.SellerId ?? 0,
                    CustomerId = (int?)p.CustomerId ?? 0,
                    ProductName = p.ProductName ?? "",
                    SKU = p.SKU ?? "",
                    ItemCode = p.SKU ?? "",
                    Barcode = p.Barcode,
                    BrandId = (int?)p.BrandId,
                    BrandName = brands.FirstOrDefault(b => b.BrandId == (int?)p.BrandId)?.BrandName,
                    CategoryId = (int?)p.CategoryId,
                    ProductTypeId = (int?)p.ProductTypeId,
                    Description = p.Description,
                    Weight = (decimal?)p.Weight,
                    Length = (decimal?)p.Length,
                    Width = (decimal?)p.Width,
                    Height = (decimal?)p.Height,
                    HSNCode = p.HSNCode,
                    UnitOfMeasure = p.UnitOfMeasure,
                    Status = p.Status,
                    IsActive = (bool?)p.IsActive ?? true,
                    CreatedDate = p.CreatedDate,
                    UpdatedDate = p.UpdatedDate,
                    TaxCategory = p.TaxCategory,
                    VisibilityStatus = p.VisibilityStatus,
                    FulfillmentType = p.FulfillmentType,
                    CarrierType = p.CarrierType,
                    ReadyToDispatchDays = (int?)p.ReadyToDispatchDays,
                    ShippingChargeLocal = (int?)p.ShippingChargeLocal,
                    ShippingChargeRegional = (int?)p.ShippingChargeRegional,
                    ShippingChargeNational = (int?)p.ShippingChargeNational,
                    IsComboPack = (bool?)p.IsComboPack ?? false,
                    ExternalProductId = p.ExternalProductId,
                    ExternalSystemCode = p.ExternalSystemCode,
                    ScanIdentifier = p.ScanIdentifier,
                    MinOrderSize = (int?)p.MinOrderSize,
                    Features = p.Features,
                    ProductPageUrl = p.ProductPageUrl,
                    TaxTypeCode = p.TaxTypeCode,
                    BrandCode = p.BrandCode,
                    ItemTypeCode = p.ItemTypeCode,
                    ProductDetailFieldsJson = p.ProductDetailFieldsJson,
                    ItemTypeName = p.ItemTypeName,
                    ProductGroupCode = p.ProductGroupCode,
                    FulfillmentProfile = p.FulfillmentProfile,
                    ShippingProvider = p.ShippingProvider,
                    ProcurementType = p.ProcurementType,
                    ProcurementSla = (int?)p.ProcurementSla,
                    ItemType = p.ItemType,
                    CostPrice = (decimal?)p.CostPrice,
                    SellingPrice = (decimal?)p.SellingPrice,
                    MRP = (decimal?)p.Mrp,
                    GSTPercentage = (decimal?)p.GSTPercentage,
                    IsReturnable = (bool?)p.IsReturnable ?? true,
                    IsCancellable = (bool?)p.IsCancellable ?? true,
                    IsCodAvailable = (bool?)p.IsCodAvailable ?? true,
                    ShelfLifeDays = (int?)p.ShelfLifeDays,
                    WarrantyPeriod = p.WarrantyPeriod,
                    Color = p.Color,
                    Size = p.Size,
                    ColorCode = p.ColorCode,
                    ManufacturerDetails = p.ManufacturerDetails,
                    ImporterDetails = p.ImporterDetails,
                    PackerDetails = p.PackerDetails,
                    CountryOfOrigin = p.CountryOfOrigin,
                    ShelfLifeSeconds = (long?)p.ShelfLifeSeconds,
                    ItemSku = p.SKU ?? "",
                    CategoryCode = p.CategoryCode,
                    Brand = brands.FirstOrDefault(b => b.BrandId == (int?)p.BrandId)?.BrandName ?? "Samsung"
                }).ToList(),
                Inventories = inventories.Select(x => new SellerCustomerInventoryResponse
                {
                    ProductInventoryId = x.ProductInventoryId,
                    SellerId = (int?)x.SellerId ?? 0,
                    CustomerId = (int?)x.CustomerId ?? 0,
                    ProductId = (int?)x.ProductId ?? 0,
                    WarehouseId = (int?)x.WarehouseId,
                    LocationId = (int?)x.LocationId,
                    Quantity = (decimal?)x.Quantity ?? 0m,
                    ReservedQuantity = (decimal?)x.ReservedQuantity ?? 0m,
                    DamagedQuantity = (decimal?)x.DamagedQuantity ?? 0m,
                    ReorderLevel = (decimal?)x.ReorderLevel ?? 0m,
                    ReorderQuantity = (decimal?)x.ReorderQuantity ?? 0m,
                    LastStockUpdate = x.LastStockUpdate,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                    SKU = x.SKU,
                    Barcode = x.Barcode,
                    ProductName = x.ProductName,
                    WarehouseCode = x.WarehouseCode,
                    FacilityCode = x.FacilityCode,
                    ChannelCode = x.ChannelCode,
                    LocationCode = x.LocationCode,
                    LocationName = x.LocationName,
                    BatchId = x.BatchId,
                    ChannelPrice = x.ChannelPrice,
                    BulkStatus = x.BulkStatus,
                    AdjustmentType = x.AdjustmentType,
                    AdjustmentQuantity = x.AdjustmentQuantity,
                    SellableQuantity = (decimal?)x.SellableQuantity ?? 0m,
                    Inventory = (decimal?)x.Inventory ?? 0m,
                    ChannelInventory = (decimal?)x.ChannelInventory ?? 0m,
                }).ToList(),
                Prices = prices.Select(x => new SellerCustomerPriceResponse
                {
                    ProductPriceId = x.ProductPriceId,

                    ProductId = (int?)x.ProductId ?? 0,

                    SellerId = (int?)x.SellerId ?? 0,

                    CustomerId = (int?)x.CustomerId ?? 0,

                    PriceType = x.PriceType ?? "",

                    Price = (decimal?)x.Price ?? 0m,

                    Currency = x.Currency,

                    EffectiveFrom = x.EffectiveFrom,

                    EffectiveTo = x.EffectiveTo,

                    IsActive = x.IsActive,

                    CreatedDate = x.CreatedDate,

                    UpdatedDate = x.UpdatedDate,

                    Mrp = (decimal?)x.Mrp,

                    NotionalValueAmount = (decimal?)x.NotionalValueAmount,

                    NotionalValueCurrency = x.NotionalValueCurrency ?? "INR",

                    Sku = x.SKU,

                    Barcode = x.Barcode,

                    WarehouseCode = x.WarehouseCode,

                    FacilityCode = x.FacilityCode,

                    ChannelCode = x.ChannelCode,

                    ChannelPrice = (decimal?)x.ChannelPrice,

                    BatchId = x.BatchId,

                    WarehouseId = (int?)x.WarehouseId,

                    IsFacilityCodeMatch = x.IsFacilityCodeMatch,

                    IsChannelCodeMatch = x.IsChannelCodeMatch

                }).ToList(),
                ProductTypes = productTypes.Select(x => new SellerCustomerProductTypeResponse
                {
                    ProductTypeId = x.ProductTypeId,

                    SellerId = (int?)x.SellerId ?? 0,

                    CustomerId = (int?)x.CustomerId ?? 0,

                    ProductTypeName = x.ProductTypeName ?? string.Empty,

                    Description = x.Description,

                    IsActive = x.IsActive,

                    CreatedDate = x.CreatedDate,

                    UpdatedDate = x.UpdatedDate,

                    ProductTypeCode = x.ProductTypeCode,

                    CategoryId = (int?)x.CategoryId,

                    CategoryName = x.CategoryName,

                    HSNCode = x.HSNCode,

                    GSTPercentage = (decimal?)x.GSTPercentage,

                    IsSystemDefined = x.IsSystemDefined,

                    DisplayOrder = (int?)x.DisplayOrder,

                    ImageUrl = x.ImageUrl,

                    IconUrl = x.IconUrl,

                    CreatedBy = x.CreatedBy

                }).ToList(),
                Categories = categories.Select(x => new SellerCustomerCategoryResponse
                {
                    CategoryId = x.CategoryId,

                    CategoryName = x.CategoryName ?? string.Empty,

                    ParentCategoryId = (int?)x.ParentCategoryId,

                    Description = x.Description,

                    IsActive = (bool?)x.IsActive ?? true,

                    CreatedDate = x.CreatedDate,

                    UpdatedDate = x.UpdatedDate,

                    SellerId = (int?)x.SellerId ?? 0,

                    CustomerId = (int?)x.CustomerId ?? 0,

                    CategoryCode = x.CategoryCode,

                    ParentCategoryName = x.ParentCategoryName,

                    Level = (int?)x.Level,

                    HSNCode = x.HSNCode,

                    GSTPercentage = (decimal?)x.GSTPercentage,

                    IsSystemDefined = x.IsSystemDefined,

                    DisplayOrder = (int?)x.DisplayOrder,

                    ImageUrl = x.ImageUrl,

                    IconUrl = x.IconUrl,

                    BannerUrl = x.BannerUrl,

                    MetaTitle = x.MetaTitle,

                    MetaDescription = x.MetaDescription,

                    CreatedBy = x.CreatedBy

                }).ToList(),
                Images = images.Select(x => new SellerCustomerImageResponse
                {
                    ProductImageId = x.ProductImageId,

                    SellerId = (int?)x.SellerId ?? 0,

                    CustomerId = (int?)x.CustomerId ?? 0,

                    ProductId = (int?)x.ProductId ?? 0,

                    ImageUrl = x.ImageUrl ?? string.Empty,

                    DisplayOrder = (int?)x.DisplayOrder,

                    IsPrimary = (bool?)x.IsPrimary ?? false,

                    CreatedDate = x.CreatedDate

                }).ToList(),
                FacilityChannels = facilityChannels.Select(x => new SellerCustomerFacilityChannelInventoryResponse
                {
                    Id = x.Id,

                    SellerId = (int?)x.SellerId ?? 0,

                    CustomerId = (int?)x.CustomerId ?? 0,

                    ProductId = (int?)x.ProductId ?? 0,

                    SkuCode = x.SkuCode ?? string.Empty,

                    FacilityCode = x.FacilityCode ?? string.Empty,

                    ChannelCode = x.ChannelCode ?? string.Empty,

                    SellableQuantity = (int?)x.SellableQuantity ?? 0

                }).ToList(),
                Attributes = attributes.Select(x => new SellerCustomerAttributeResponse
                {
                    ProductAttributeId = x.ProductAttributeId,

                    ProductId = (int?)x.ProductId ?? 0,

                    SellerId = (int?)x.SellerId ?? 0,

                    CustomerId = (int?)x.CustomerId ?? 0,

                    AttributeName = x.AttributeName ?? string.Empty,

                    AttributeValue = x.AttributeValue ?? string.Empty,

                    CreatedDate = x.CreatedDate

                }).ToList(),
                StockMovements = stockMovements.Select(x => new SellerCustomerStockMovementResponse
                {
                    StockMovementId = x.StockMovementId,

                    SellerId = (int?)x.SellerId ?? 0,

                    CustomerId = (int?)x.CustomerId ?? 0,

                    ProductId = (int?)x.ProductId ?? 0,

                    WarehouseId = (int?)x.WarehouseId ?? 0,

                    MovementType = x.MovementType,

                    Quantity = (decimal?)x.Quantity ?? 0m,

                    ReferenceTable = x.ReferenceTable,

                    ReferenceId = (int?)x.ReferenceId,

                    MovementDate = x.MovementDate,

                    Remarks = x.Remarks

                }).ToList(),
                StockLedgers = stockLedgers.Select(x => new SellerCustomerStockLedgerResponse
                {
                    StockLedgerId = x.StockLedgerId,

                    SellerId = (int?)x.SellerId ?? 0,

                    CustomerId = (int?)x.CustomerId ?? 0,

                    ProductId = (int?)x.ProductId ?? 0,

                    WarehouseId = (int?)x.WarehouseId ?? 0,

                    TransactionType = x.TransactionType ?? string.Empty,

                    ReferenceNumber = x.ReferenceNumber,

                    Quantity = (decimal?)x.Quantity ?? 0m,

                    BalanceQuantity = (decimal?)x.BalanceQuantity ?? 0m,

                    Remarks = x.Remarks,

                    TransactionDate = x.TransactionDate,

                    CreatedDate = x.CreatedDate

                }).ToList(),
                Warehouses = warehouses.Select(x => new SellerCustomerWarehouseResponse
                {
                    WarehouseId = x.WarehouseId,

                    SellerId = (int?)x.SellerId ?? 0,

                    CustomerId = (int?)x.CustomerId,

                    WarehouseCode = x.WarehouseCode ?? string.Empty,

                    FacilityCode = x.FacilityCode,

                    WarehouseName = x.WarehouseName ?? string.Empty,

                    FacilityName = x.FacilityName,

                    FacilityType = x.FacilityType,

                    LocationCode = x.LocationCode,

                    AddressLine1 = x.AddressLine1,

                    AddressLine2 = x.AddressLine2,

                    City = x.City,

                    State = x.State,

                    StateCode = x.StateCode,

                    Country = x.Country,

                    CountryCode = x.CountryCode,

                    PostalCode = x.PostalCode,

                    ContactPerson = x.ContactPerson,

                    Phone = x.Phone,

                    Email = x.Email,

                    GSTNumber = x.GSTNumber,

                    Pan = x.Pan,

                    Arn = x.Arn,

                    TinNo = x.TinNo,

                    IsActive = x.IsActive,

                    IsDefault = x.IsDefault,

                    IsQCEnabled = x.IsQCEnabled,

                    IsPutawayEnabled = x.IsPutawayEnabled,

                    ChannelCode = x.ChannelCode,

                    IsFacilityCodeMatch = x.IsFacilityCodeMatch,

                    TotalInventory = x.TotalInventory,

                    SellableInventory = x.SellableInventory,

                    CreatedDate = x.CreatedDate,

                    UpdatedDate = x.UpdatedDate,

                    CreatedBy = x.CreatedBy

                }).ToList(),
                WarehouseLocations = warehouseLocations.Select(x => new SellerCustomerWarehouseLocationResponse
                {
                    LocationId = x.LocationId,

                    CustomerId = (int?)x.CustomerId,

                    WarehouseId = (int?)x.WarehouseId ?? 0,

                    LocationCode = x.LocationCode ?? string.Empty,

                    LocationName = x.LocationName ?? string.Empty,

                    Description = x.Description,

                    IsActive = x.IsActive,

                    CreatedDate = x.CreatedDate,

                    ListingStatus = x.ListingStatus ?? "ACTIVE",

                    FulfillmentProfile = x.FulfillmentProfile

                }).ToList(),
                StockAdjustments = stockAdjustments.Select(x => new SellerCustomerStockAdjustmentResponse
                {
                    StockAdjustmentId = x.StockAdjustmentId,

                    SellerId = (int?)x.SellerId ?? 0,

                    CustomerId = (int?)x.CustomerId ?? 0,

                    ProductId = (int?)x.ProductId ?? 0,

                    WarehouseId = (int?)x.WarehouseId ?? 0,

                    Quantity = (decimal?)x.Quantity ?? 0m,

                    AdjustmentType = x.AdjustmentType ?? string.Empty,

                    Reason = x.Reason,

                    AdjustedBy = x.AdjustedBy,

                   // AdjustmentDate = x.AdjustmentDate,

                    //CreatedDate = x.CreatedDate

                }).ToList(),
                StockTransfers = stockTransfers.Select(x => new SellerCustomerStockTransferResponse
                {
                    StockTransferId = x.StockTransferId,

                    SellerId = (int?)x.SellerId ?? 0,

                    CustomerId = (int?)x.CustomerId ?? 0,

                    ProductId = (int?)x.ProductId ?? 0,

                    FromWarehouseId = (int?)x.FromWarehouseId ?? 0,

                    ToWarehouseId = (int?)x.ToWarehouseId ?? 0,

                    Quantity = (decimal?)x.Quantity ?? 0m,

                    TransferDate = x.TransferDate,

                    Status = x.Status,

                    Remarks = x.Remarks,

                    CreatedDate = x.CreatedDate

                }).ToList(),
                Suppliers = suppliers.Select(x => new SellerCustomerSupplierResponse
                {
                    SupplierId = x.SupplierId,

                    SellerId = (int?)x.SellerId ?? 0,

                    CustomerId = (int?)x.CustomerId ?? 0,

                    SupplierCode = x.SupplierCode ?? string.Empty,

                    SupplierName = x.SupplierName ?? string.Empty,

                    ContactPerson = x.ContactPerson,

                    Phone = x.Phone,

                    Email = x.Email,

                    GSTIN = x.GSTIN,

                    AddressLine1 = x.AddressLine1,

                    AddressLine2 = x.AddressLine2,

                    City = x.City,

                    State = x.State,

                    Country = x.Country,

                    PostalCode = x.PostalCode,

                    PaymentTerms = x.PaymentTerms,

                    CreditLimit = (decimal?)x.CreditLimit,

                    IsActive = x.IsActive,

                    CreatedDate = x.CreatedDate,

                    UpdatedDate = x.UpdatedDate

                }).ToList(),
                Brands = brands.Select(x => new SellerCustomerBrandResponse
                {
                    BrandId = x.BrandId,

                    BrandName = x.BrandName ?? string.Empty,

                    BrandCode = x.BrandCode ?? string.Empty,

                    Description = x.Description,

                    SellerId = (int?)x.SellerId,

                    //customerId = (int?)x.customerId,

                    IsActive = (bool?)x.IsActive ?? false,

                    CreatedDate = x.CreatedDate,

                    //BrandXID = (int?)x.BrandXID,

                    LogoUrl = x.LogoUrl,

                    BrandImageUrl = x.LogoUrl,

                    UpdatedDate = x.UpdatedDate

                }).ToList(),
                BrandModels = brandModels.Select(x => new SellerCustomerBrandModelResponse
                {
                    BrandModelId = x.BrandModelId,

                    BrandId = (int?)x.BrandId ?? 0,

                    SellerId = (int?)x.SellerId ?? 0,

                    CustomerId = (int?)x.CustomerId ?? 0,

                    ModelName = x.ModelName ?? string.Empty,

                    ModelCode = x.ModelCode ?? string.Empty,

                    BrandName = x.BrandName,

                    Description = x.Description,

                    IsActive = (bool?)x.IsActive ?? false,

                    CreatedDate = x.CreatedDate,

                    UpdatedDate = x.UpdatedDate,

                    Specifications = x.Specifications,

                    ImageUrl = x.ImageUrl

                }).ToList(),
                Marketplaces = marketplaces.Select(x => new SellerCustomerMarketplaceResponse 
                { 
                    MarketplaceId = x.MarketplaceId,
                    MarketplaceCode = x.MarketplaceCode ?? "", 
                    MarketplaceName = x.MarketplaceName ?? "" 
                }).ToList(),
                DeliveryChallanItems = deliveryChallanItems.Select(x => new SellerCustomerDeliveryChallanItemResponse 
                { 
                    DeliveryChallanItemId = x.DeliveryChallanItemId, 
                    DeliveryChallanId = x.DeliveryChallanId, 
                    ProductId = (int?)x.ProductId ?? 0, 
                    Quantity = (int?)x.Quantity ?? 0 
                }).ToList(),
                EInvoices = eInvoices.Select(x => new SellerCustomerEInvoiceResponse
                {
                    EInvoiceId = x.EInvoiceId,

                    SellerId = (int?)x.SellerId ?? 0,

                    CustomerId = (int?)x.CustomerId ?? 0,

                    SalesInvoiceId = (int?)x.SalesInvoiceId ?? 0,

                    InvoiceNumber = x.InvoiceNumber,

                    Irn = x.IRN,

                    AckNo = x.AckNo,

                    AckDate = x.AckDate,

                    SignedInvoice = x.SignedInvoice,

                    SignedQrCode = x.SignedQrCode,

                    Status = x.Status,

                    CreatedDate = x.CreatedDate

                }).ToList(),
                EWayBills = eWayBills.Select(x => new SellerCustomerEWayBillResponse
                {
                    EWayBillId = x.EWayBillId,

                    SellerId = (int?)x.SellerId ?? 0,

                    CustomerId = (int?)x.CustomerId ?? 0,

                    SalesInvoiceId = (int?)x.SalesInvoiceId ?? 0,

                    EWayBillNumber = x.EWayBillNumber,

                    EWayBillDate = x.EWayBillDate,

                    ValidUpto = x.ValidUpto,

                    Status = x.Status,

                    CreatedDate = x.CreatedDate,

                    VehicleNo = x.VehicleNo,

                    TransporterName = x.TransporterName,

                    TransporterID = x.TransporterID,

                    TransporterDocNo = x.TransporterDocNo,

                    TransportMode = x.TransportMode,

                    Distance = x.Distance,

                   // InvoiceNumber = x.SalesInvoiceId,

                }).ToList(),
                ShelfwiseInventories = shelfwiseInventories.Select(x => new SellerCustomerShelfwiseInventoryResponse
                {
                    ShelfwiseInventoryId = x.ShelfwiseInventoryId,

                    SellerId = (int?)x.SellerId ?? 0,

                    CustomerId = (int?)x.CustomerId ?? 0,

                    FacilityCode = x.FacilityCode ?? string.Empty,

                    ShelfCode = x.ShelfCode ?? string.Empty,

                    ItemSkuCode = x.ItemSkuCode ?? string.Empty,

                    Quantity = (int?)x.Quantity ?? 0,

                    BatchCode = x.BatchCode,

                    ExpiryDate = x.ExpiryDate,

                    InventoryType = x.InventoryType,

                    LocationCode = x.LocationCode,

                    CreatedDate = x.CreatedDate,

                    UpdatedDate = x.UpdatedDate,

                    // ===== ADDITIONAL DB FIELDS =====
                    Mrp = (decimal?)x.Mrp,

                    Mfd = (long?)x.Mfd,

                    VendorCode = x.VendorCode,

                    VendorBatchNumber = x.VendorBatchNumber,

                    LotNumber = x.LotNumber,

                    TransferToShelfCode = x.TransferToShelfCode,

                    Sla = (int?)x.Sla,

                    Remarks = x.Remarks,

                    WarehouseId = (int?)x.WarehouseId

                }).ToList(),
                VendorItemMasters = vendorItemMasters.Select(x => new SellerCustomerVendorItemMasterResponse
                {
                    VendorItemMasterId = x.VendorItemMasterId,

                    VendorId = (int?)x.VendorId ?? 0,

                    SellerId = (int?)x.SellerId ?? 0,

                    CustomerId = (int?)x.CustomerId ?? 0,

                    VendorSkuCode = x.VendorSkuCode ?? string.Empty,

                    ItemSkuCode = x.ItemSkuCode ?? string.Empty,

                    CostPrice = (decimal?)x.CostPrice ?? 0m,

                    ProductId = (int?)x.ProductId,

                    IsActive = (bool?)x.IsActive ?? false,

                    CreatedDate = x.CreatedDate,

                    UpdatedDate = x.UpdatedDate

                }).ToList(),
                Gatepasses = gatepasses.Select(x => new SellerCustomerGatepassResponse
                {
                    GatepassId = x.GatepassId,

                    SellerId = (int?)x.SellerId ?? 0,

                    CustomerId = (int?)x.CustomerId ?? 0,

                    FacilityCode = x.FacilityCode ?? string.Empty,

                    Facility = x.Facility,

                    GatepassCode = x.GatepassCode,

                    ItemSkuCode = x.ItemSkuCode,

                    Quantity = (int?)x.Quantity,

                    Reason = x.Reason,

                    Status = x.Status,

                    CreatedDate = x.CreatedDate

                }).ToList(),
                Putaways = putaways.Select(x => new SellerCustomerPutawayResponse
                {
                    PutawayId = x.PutawayId,

                    SellerId = (int?)x.SellerId ?? 0,

                    CustomerId = (int?)x.CustomerId ?? 0,

                    FacilityCode = x.FacilityCode ?? string.Empty,

                    ShelfCode = x.ShelfCode ?? string.Empty,

                    PutawayCode = x.PutawayCode,

                    ItemTypeSkuCode = x.ItemTypeSkuCode ?? string.Empty,

                    PutawayQuantity = (int?)x.PutawayQuantity,

                    BatchCode = x.BatchCode,

                    InventoryType = x.InventoryType,

                    PutawayType = x.PutawayType,

                    StatusCode = x.StatusCode,

                    CreatedDate = x.CreatedDate

                }).ToList(),
                ReversePickups = reversePickups.Select(x => new SellerCustomerReversePickupResponse
                {
                    ReversePickupId = x.ReversePickupId,

                    SellerId = (int?)x.SellerId ?? 0,

                    CustomerId = (int?)x.CustomerId ?? 0,

                    ReversePickupNo = x.ReversePickupNo,

                    FacilityCode = x.FacilityCode,

                    ItemSkuCode = x.ItemSkuCode,

                    ReversePickupStatus = x.ReversePickupStatus,

                    SaleOrderCode = x.SaleOrderCode ?? string.Empty,

                    SaleOrderItemCode = x.SaleOrderItemCode ?? string.Empty,

                    ReturnReason = x.ReturnReason,

                    ChannelName = x.ChannelName,

                    //Status = x.Status,

                    TrackingNo = x.TrackingNo,

                    CreatedDate = x.CreatedDate,

                    UpdatedDate = x.UpdatedDate

                }).ToList(),
                ReversePickupItems = reversePickupItems.Select(x => new SellerCustomerReversePickupItemResponse
                {
              

                    ReversePickupItemId = x.Id,

                    ReversePickupId = (int?)x.ReversePickupId ?? 0,

                  

                    SellerId = (int?)x.SellerId ?? 0,

                    CustomerId = (int?)x.CustomerId ?? 0,


                    SaleOrderItemCode = x.SaleOrderItemCode,

              
                   // SkuCode = x.ItemSku,

                    ItemSku = x.ItemSku,

                

                    Reason = x.Reason,

              

                   // Quantity = (decimal?)x.Quantity,

                  

                    //FacilityCode = x.FacilityCode,

                    //BinCode = x.BinCode,

                    

                    TotalPrice = (decimal?)x.TotalPrice ?? 0m,

                    SellingPrice = (decimal?)x.SellingPrice ?? 0m,

                    Discount = (decimal?)x.Discount ?? 0m

                }).ToList(),
                Picklists = picklists.Select(x => new SellerCustomerPicklistResponse
                {
                    PicklistId = x.PicklistId,

                    PicklistCode = x.PicklistCode ?? string.Empty,

                    Destination = x.Destination,

                    ShippingPackageCodes = x.ShippingPackageCodes,

                    SellerId = (int?)x.SellerId ?? 0,

                    CustomerId = (int?)x.CustomerId ?? 0,

                    CreatedDate = x.CreatedDate

                }).ToList(),
                ManifestPackages = manifestPackages.Select(x => new SellerCustomerManifestPackageResponse 
                { 
                    ManifestPackageId = x.ManifestPackageId, 
                    SellerId = (int?)x.SellerId ?? 0, 
                    CustomerId = (int?)x.CustomerId ?? 0, 
                    ShippingPackageCode = x.ShippingPackageCode ?? "" 
                }).ToList(),
                InvoiceTaxDetails = invoiceTaxDetails.Select(x => new SellerCustomerInvoiceTaxDetailResponse
                {
                    InvoiceTaxDetailId = x.InvoiceTaxDetailId,

                    SellerId = (int?)x.SellerId ?? 0,

                    CustomerId = (int?)x.CustomerId ?? 0,

                    SalesInvoiceId = (int?)x.SalesInvoiceId,

                    ChannelProductId = x.ChannelProductId,

                    TaxPercentage = (decimal?)x.TaxPercentage,

                    CentralGst = (decimal?)x.CentralGst,

                    StateGst = (decimal?)x.StateGst,

                    IntegratedGst = (decimal?)x.IntegratedGst,

                    CompensationCess = (decimal?)x.CompensationCess

                }).ToList(),
                ReversePickupAddresses = reversePickupAddresses.Select(x => new SellerCustomerReversePickupAddressResponse
                {
                    // =========================================================
                    // PRIMARY KEY
                    // =========================================================

                    ReversePickupAddressId = x.Id,

                    // =========================================================
                    // SELLER / CUSTOMER
                    // =========================================================

                    SellerId = (int?)x.SellerId,

                    CustomerId = (int?)x.CustomerId,

                    // =========================================================
                    // REVERSE PICKUP
                    // =========================================================

                    ReversePickupId = (int?)x.ReversePickupId,

                    // =========================================================
                    // ADDRESS DETAILS
                    // =========================================================

                    AddressType = x.AddressType,

                    AddressLine1 = x.AddressLine1,

                    City = x.City,

                    Pincode = x.Pincode,

                    // =========================================================
                    // CONTACT DETAILS
                    // =========================================================

                    Phone = x.Phone

                }).ToList(),
                ExportJobs = exportJobs.Select(x => new SellerCustomerExportJobResponse
                {
                    ExportJobId = x.ExportJobId,

                    JobCode = x.JobCode ?? string.Empty,

                    ExportJobTypeName = x.ExportJobTypeName,

                    SellerId = (int?)x.SellerId ?? 0,

                    CustomerId = (int?)x.CustomerId ?? 0,

                    ExportColums = x.ExportColums,

                    ExportFilters = x.ExportFilters,

                    ScheduleTime = x.ScheduleTime,

                    NotificationEmail = x.NotificationEmail,

                    Frequency = x.Frequency,

                    ReportName = x.ReportName,

                    Status = x.Status

                }).ToList(),
                SalesOrderAddresses = salesOrderAddresses.Select(x => new SellerCustomerSaleOrderAddressResponse
                {
                    SaleOrderAddressId = x.AddressId,

                    SalesOrderId = (int?)x.SalesOrderId ?? 0,

                   //SellerId = (int?)x.SellerId ,

                    //CustomerId = (int?)x.CustomerId ?? 0,

                    Name = x.Name,

                    AddressLine1 = x.AddressLine1,

                    AddressLine2 = x.AddressLine2,

                    City = x.City,

                    State = x.State,

                    StateCode = x.StateCode,

                    CountryCode = x.CountryCode,

                    Pincode = x.Pincode,

                    Phone = x.Phone,

                    Email = x.Email,

                    //AddressType = x.AddressType,

                    //FacilityCode = x.FacilityCode,

                    //ChannelCode = x.ChannelCode

                }).ToList(),
                MarketplaceListingInventories = marketplaceListingInventories.Select(x => new SellerCustomerMarketplaceListingInventoryResponse
                {
                    MarketplaceListingInventoryId = x.MarketplaceListingInventoryId,

                    MarketplaceListingId = x.MarketplaceListingId,

                    //ProductId = x.ProductId,

                    //MarketplaceSKU = x.MarketplaceSKU ?? string.Empty,

                  //  ListingStatus = x.ListingStatus ?? string.Empty,

                    AvailableQuantity = (decimal?)x.AvailableQuantity ?? 0m,

                    ReservedQuantity = (decimal?)x.ReservedQuantity ?? 0m,

                    InboundQuantity = (decimal?)x.InboundQuantity ?? 0m,

                    LastInventorySync = x.LastInventorySync,

                    CreatedDate = x.CreatedDate

                }).ToList(),
                AmazonInventorySyncs = amazonInventorySyncs.Select(x => new SellerCustomerAmazonInventorySyncResponse
                {
                    InventorySyncId = x.InventorySyncId,

                    AmazonAccountId = (int?)x.AmazonAccountId ?? 0,

                    ProductId = (int?)x.ProductId ?? 0,

                    SKU = x.SKU ?? string.Empty,

                    ASIN = x.ASIN ?? string.Empty,

                    MarketplaceId = x.MarketplaceId ?? string.Empty,

                    AvailableQuantity = (int?)x.AvailableQuantity ?? 0,

                    ReservedQuantity = (int?)x.ReservedQuantity ?? 0,

                    InboundQuantity = (int?)x.InboundQuantity ?? 0,

                    LastSyncDate = x.LastSyncDate,

                    JsonData = x.JsonData ?? string.Empty

                }).ToList(),
                ShippingManifests = shippingManifests.Select(x => new SellerCustomerShippingManifestResponse 
                { 
                    ShippingManifestId = x.ShippingManifestId, 
                    SellerId = (int?)x.SellerId ?? 0, 
                    CustomerId = (int?)x.CustomerId ?? 0, 
                    ManifestNumber = x.ManifestNumber ?? "", 
                    Status = x.Status ?? "", 
                    CreatedDate = x.CreatedDate 
                }).ToList(),
                SupplierAddresses = supplierAddresses.Select(x => new SellerCustomerSupplierAddressResponse 
                { 
                    SupplierAddressId = x.SupplierAddressId, 
                    SellerId = (int?)x.SellerId ?? 0, 
                    CustomerId = (int?)x.CustomerId ?? 0, 
                    SupplierId = (int?)x.SupplierId ?? 0, 
                    AddressLine1 = x.AddressLine1 ?? "", 
                    City = x.City ?? "", 
                    State = x.StateCode ?? "" 
                }).ToList(),
                SupplierContacts = supplierContacts.Select(x => new SellerCustomerSupplierContactResponse 
                { 
                    SupplierContactId = x.SupplierContactId, 
                    SellerId = (int?)x.SellerId ?? 0, 
                    CustomerId = (int?)x.CustomerId ?? 0, 
                    SupplierId = (int?)x.SupplierId ?? 0, 
                    ContactName = x.ContactName ?? "",
                    Email = x.Email ?? "", 
                    Phone = x.Phone ?? "" 
                }).ToList(),
                VendorItemCustomFields = vendorItemCustomFields.Select(x => new SellerCustomerVendorItemCustomFieldResponse 
                { 
                    VendorItemCustomFieldId = x.VendorItemCustomFieldId, 
                    SellerId = (int?)x.SellerId ?? 0, 
                    CustomerId = (int?)x.CustomerId ?? 0, 
                    VendorItemMasterId = (int?)x.VendorItemMasterId ?? 0, 
                    FieldName = x.Name ?? "", 
                    FieldValue = x.Value ?? "" 
                }).ToList(),
                Transactions = new SellerCustomerTransactionResponse
                {
                    CustomerId = customerId,
                    SellerId = sellerId,
                    CustomerReturns = customerReturns.Select(x => new SellerCustomerCustomerReturnResponse
                    {
                        CustomerReturnId = x.CustomerReturnId,

                        SalesInvoiceId = (int?)x.SalesInvoiceId ?? 0,

                        ProductId = (int?)x.ProductId ?? 0,

                        ReturnNumber = x.ReturnNumber ?? string.Empty,

                        ReturnDate = x.ReturnDate,

                        Quantity = (decimal?)x.Quantity ?? 0m,

                        ReturnAmount = (decimal?)x.ReturnAmount ?? 0m,

                        TotalAmount = (decimal?)x.TotalAmount ?? 0m,

                        Remarks = x.Remarks,

                        Reason = x.Reason,

                        Status = x.Status,

                        CreatedDate = x.CreatedDate,

                        SellerId = (int?)x.SellerId ?? 0,

                        CustomerId = (int?)x.CustomerId ?? 0

                    }).ToList(),
                    DeliveryChallans = deliveryChallans.Select(x => new SellerCustomerDeliveryChallanResponse
                    {
                        DeliveryChallanId = x.DeliveryChallanId,

                        SellerId = (int?)x.SellerId ?? 0,

                        CustomerId = (int?)x.CustomerId ?? 0,

                        ChallanNumber = x.ChallanNumber,

                        ChallanDate = x.ChallanDate,

                        VehicleNumber = x.VehicleNumber,

                        DriverName = x.DriverName,

                        DriverMobile = x.DriverMobile,

                        TransporterName = x.TransporterName,

                        SalesOrderId = (int?)x.SalesOrderId,

                        Status = x.Status,

                        //DeliveryAddress = x.DeliveryAddress,

                        Remarks = x.Remarks,

                        CreatedDate = x.CreatedDate,

                        //UpdatedDate = x.UpdatedDate

                    }).ToList(),
                    GoodsReceiptItems = goodsReceiptItems.Select(x => new SellerCustomerGoodsReceiptItemResponse
                    {
                        GoodsReceiptItemId = x.GoodsReceiptItemId,

                        GoodsReceiptNoteId = (int?)x.GoodsReceiptNoteId ?? 0,

                        ProductId = (int?)x.ProductId ?? 0,

                        PurchaseOrderItemId = (int?)x.PurchaseOrderItemId ?? 0,

                        SellerId = (int?)x.SellerId ?? 0,

                        CustomerId = (int?)x.CustomerId ?? 0,

                        SupplierId = (int?)x.SupplierId ?? 0,

                        LineNumber = (int?)x.LineNumber ?? 0,

                        // =========================================================
                        // QUANTITY
                        // =========================================================

                        ReceivedQuantity = (decimal?)x.ReceivedQuantity ?? 0m,

                        Quantity = (decimal?)x.ReceivedQuantity ?? 0m,

                        AcceptedQuantity = (decimal?)x.AcceptedQuantity,

                        RejectedQuantity = (decimal?)x.RejectedQuantity,

                        // =========================================================
                        // PRICE
                        // =========================================================

                        UnitPrice = (decimal?)x.UnitPrice ?? 0m,

                        TotalAmount = (decimal?)x.TotalAmount ?? 0m,

                        Mrp = (decimal?)x.Mrp,

                        Cost = (decimal?)x.Cost,

                        AdditionalCost = (decimal?)x.AdditionalCost ?? 0m,

                        // =========================================================
                        // UNIWARE / ITEM DETAILS
                        // =========================================================

                        SkuCode = x.SkuCode,

                        ItemCode = x.ItemCode,

                        BatchCode = x.BatchCode,

                        VendorBatchNumber = x.VendorBatchNumber,

                        VendorCode = x.VendorCode,

                        FacilityCode = x.FacilityCode,

                        ChannelCode = x.ChannelCode,

                        BinCode = x.BinCode,

                        ShelfCode = x.ShelfCode,

                        SyncStatus = x.SyncStatus,

                        // =========================================================
                        // DATES
                        // =========================================================

                        ManufacturingDate = x.ManufacturingDate,

                        ExpiryDate = x.ExpiryDate,

                        // =========================================================
                        // ADDITIONAL DETAILS
                        // =========================================================

                        ItemDetailCode = x.ItemDetailCode,

                        Status = x.Status,

                        Remarks = x.Remarks,

                        SerialCodes = TryParseList(x.SerialCodesJson),

                        //CreatedDate = x.CreatedDate

                    }).ToList(),
                    GoodsReceiptNotes = goodsReceiptNotes.Select(x => new SellerCustomerGoodsReceiptNoteResponse
                    {
                        GoodsReceiptNoteId = x.GoodsReceiptNoteId,

                        SellerId = (int?)x.SellerId ?? 0,

                        CustomerId = (int?)x.CustomerId ?? 0,

                        PurchaseOrderId = (int?)x.PurchaseOrderId ?? 0,

                        PurchaseOrderNumber = x.PurchaseOrderNumber,

                        GRNNumber = x.GRNNumber,

                        ReceiptDate = x.ReceiptDate,

                        Status = x.Status,

                        GRNStatus = x.GRNStatus,

                        Remarks = x.Remarks,

                        // =========================================================
                        // WAREHOUSE / FACILITY
                        // =========================================================

                        WarehouseId = (int?)x.WarehouseId,

                        WarehouseCode = x.WarehouseCode,

                        FacilityCode = x.FacilityCode,

                        LocationCode = x.LocationCode,

                        // =========================================================
                        // VENDOR
                        // =========================================================

                        VendorCode = x.VendorCode,

                        VendorName = x.VendorName,

                        // =========================================================
                        // QUANTITY
                        // =========================================================

                        TotalQuantity = (decimal?)x.TotalQuantity,

                        ReceivedQuantity = (decimal?)x.ReceivedQuantity,

                        AcceptedQuantity = (decimal?)x.AcceptedQuantity,

                        RejectedQuantity = (decimal?)x.RejectedQuantity,

                        // =========================================================
                        // AMOUNT
                        // =========================================================

                        TotalAmount = (decimal?)x.TotalAmount,

                        // =========================================================
                        // QUALITY CONTROL
                        // =========================================================

                        IsQCRequired = x.IsQCRequired,

                        IsQCDone = x.IsQCDone,

                        // =========================================================
                        // AUDIT
                        // =========================================================

                        CreatedDate = x.CreatedDate,

                        UpdatedDate = x.UpdatedDate,

                        CreatedBy = x.CreatedBy

                    }).ToList(),
                    Notifications = notifications.Select(x => new SellerCustomerNotificationResponse
                    {
                        NotificationId = x.NotificationId,

                        SellerId = (int?)x.SellerId ?? 0,

                        CustomerId = (int?)x.CustomerId ?? 0,

                       // NotificationType = x.NotificationType,

                        Title = x.Title,

                        Message = x.Message,

                        IsRead = (bool?)x.IsRead ?? false,

                        //ReadDate = x.ReadDate,

                        CreatedDate = x.CreatedDate

                    }).ToList(),
                    OrderStatusHistories = orderStatusHistories.Select(x => new SellerCustomerOrderStatusHistoryResponse
                    {
                        OrderStatusHistoryId = x.OrderStatusHistoryId,

                        SellerId = (int?)x.SellerId ?? 0,

                        CustomerId = (int?)x.CustomerId ?? 0,

                        OrderId = (int?)x.OrderId ?? 0,

                        Status = x.Status,

                        ChangedOn = x.ChangedOn,

                        //SalesOrderId = (int?)x.SalesOrderId,

                        //PreviousStatus = x.PreviousStatus,

                        //NewStatus = x.NewStatus,

                        //Remarks = x.Remarks,

                        //StatusDate = x.StatusDate,

                        //CreatedDate = x.CreatedDate

                    }).ToList(),
                    Payments = payments.Select(x => new SellerCustomerPaymentResponse
                    {
                        PaymentId = x.PaymentId,

                        SellerId = (int?)x.SellerId ?? 0,

                        CustomerId = (int?)x.CustomerId ?? 0,

                       // SalesOrderId = (int?)x.SalesOrderId,

                       // SalesInvoiceId = (int?)x.SalesInvoiceId,

                        Amount = (decimal?)x.Amount ?? 0m,

                        OrderId = (int?)x.OrderId ?? 0,

                        TransactionId = x.TransactionId,

                        PaymentMethod = x.PaymentMethod,

                        PaymentStatus = x.PaymentStatus,

                        PaymentDate = x.PaymentDate,

                       // TransactionReference = x.TransactionReference,

                       // Remarks = x.Remarks,

                        //CreatedDate = x.CreatedDate,

                        UpdatedDate = x.UpdatedDate

                    }).ToList(),
                    PurchaseOrders = purchaseOrders.Select(x => new SellerCustomerPurchaseOrderResponse
                    {
                        PurchaseOrderId = x.PurchaseOrderId,

                        SellerId = (int?)x.SellerId ?? 0,

                        CustomerId = (int?)x.CustomerId ?? 0,

                        SupplierId = (int?)x.SupplierId,

                        WarehouseId = (int?)x.WarehouseId,

                       // OrderNumber = x.OrderNumber,

                        OrderDate = x.OrderDate,

                        ExpectedDeliveryDate = x.ExpectedDeliveryDate,

                        PurchaseOrderNumber = x.PurchaseOrderNumber,

                        Status = x.Status,

                        TotalAmount = (decimal?)x.TotalAmount,

                        //Currency = x.Currency,

                        Remarks = x.Remarks,

                        CreatedDate = x.CreatedDate,

                        UpdatedDate = x.UpdatedDate,

                        PurchaseOrderCode = x.PurchaseOrderCode,

                        ReceiptDate = x.ReceiptDate,

                        POStatus = x.POStatus,

                        ApprovalStatus = x.ApprovalStatus,

                        FacilityCode = x.FacilityCode,

                        VendorCode = x.VendorCode,

                        VendorName = x.VendorName,

                        ChannelCode = x.ChannelCode,

                        SubTotal = (decimal?)x.SubTotal,

                        TaxAmount = (decimal?)x.TaxAmount,

                        CurrencyCode = x.CurrencyCode,

                        TotalQuantity = (decimal?)x.TotalQuantity,

                        ReceivedQuantity = (decimal?)x.ReceivedQuantity,

                        PendingQuantity = (decimal?)x.PendingQuantity,

                        CreatedBy = x.CreatedBy

                    }).ToList(),
                    PurchaseOrderItems = purchaseOrderItems.Select(x => new SellerCustomerPurchaseOrderItemResponse
                    {
                        PurchaseOrderItemId = x.PurchaseOrderItemId,

                        PurchaseOrderId = (int?)x.PurchaseOrderId ?? 0,

                        SellerId = (int?)x.SellerId ?? 0,

                        CustomerId = (int?)x.CustomerId ?? 0,

                        ProductId = (int?)x.ProductId ?? 0,

                        Quantity = (decimal?)x.Quantity ?? 0m,

                        UnitPrice = (decimal?)x.UnitPrice ?? 0m,

                        Discount = (decimal?)x.Discount,

                        TaxAmount = (decimal?)x.TaxAmount,

                        TotalAmount = (decimal?)x.TotalAmount ?? 0m,

                       // Remarks = x.Remarks,

                        // CreatedDate = x.CreatedDate

                    }).ToList(),
                    PurchaseReturns = purchaseReturns.Select(x => new SellerCustomerPurchaseReturnResponse
                    {
                        PurchaseReturnId = x.PurchaseReturnId,

                        // =========================================================
                        // SELLER / CUSTOMER
                        // =========================================================

                        SellerId = (int?)x.SellerId ?? 0,

                        CustomerId = (int?)x.CustomerId ?? 0,

                        // =========================================================
                        // REFERENCES
                        // =========================================================

                        PurchaseOrderId = (int?)x.PurchaseOrderId,

                        GoodsReceiptNoteId = (int?)x.GoodsReceiptNoteId,

                        SupplierId = (int?)x.SupplierId,

                        // =========================================================
                        // RETURN IDENTIFICATION
                        // =========================================================

                        PurchaseReturnNumber = x.PurchaseReturnNumber,

                        // =========================================================
                        // FINANCIAL INFORMATION
                        // =========================================================

                        TotalAmount = (decimal?)x.TotalAmount ?? 0m,

                        // =========================================================
                        // RETURN INFORMATION
                        // =========================================================

                        // ReturnReason = x.ReturnReason,

                        Status = x.Status,

                        ReturnDate = x.ReturnDate,

                        // =========================================================
                        // AUDIT
                        // =========================================================

                        CreatedDate = x.CreatedDate,

                        UpdatedDate = x.UpdatedDate

                    }).ToList(),
                    Reviews = reviews.Select(x => new SellerCustomerReviewResponse
                    {
                        ReviewId = x.ReviewId,

                        SellerId = (int?)x.SellerId ?? 0,

                        CustomerId = (int?)x.CustomerId ?? 0,

                        ProductId = (int?)x.ProductId ?? 0,

                        //SalesOrderId = (int?)x.SalesOrderId,

                        Rating = (int?)x.Rating ?? 0,

                        ReviewText = x.ReviewText,

                        //IsApproved = (bool?)x.IsApproved ?? false,

                        //ReviewDate = x.ReviewDate,

                        //CreatedDate = x.CreatedDate,

                        //UpdatedDate = x.UpdatedDate

                    }).ToList(),
                    SalesOrders = salesOrders.Select(x => new SellerCustomerSalesOrderResponse
                    {
                        // =====================================================
                        // BASIC SALES ORDER
                        // =====================================================

                        SalesOrderId = x.SalesOrderId,

                        SellerId = (int?)x.SellerId ?? 0,

                        CustomerId = (int?)x.CustomerId ?? 0,

                        SalesOrderNumber = x.SalesOrderNumber ?? string.Empty,

                        SalesOrderCode = x.SalesOrderCode,

                        DisplayOrderCode = x.DisplayOrderCode,

                        ChannelCode = x.ChannelCode,

                        FacilityCode = x.FacilityCode,

                        CustomerCode = x.CustomerCode,

                        CustomerName = x.CustomerName,

                        //OrderType = x.OrderType,

                        CurrencyCode = x.CurrencyCode,

                        // =====================================================
                        // ORDER DATES / STATUS
                        // =====================================================

                            // OrderDate = x.OrderDate,

                        ChannelCreatedDate = x.ChannelCreatedDate,

                        ExpectedDeliveryDate = x.ExpectedDeliveryDate,

                        Status = x.Status ?? string.Empty,

                        StatusCode = x.StatusCode,

                        FulfillmentStatus = x.FulfillmentStatus,

                        // =====================================================
                        // FINANCIAL BREAKDOWN
                        // =====================================================

                        TotalAmount = (decimal?)x.TotalAmount ?? 0m,

                        SubTotal = (decimal?)x.SubTotal,

                        TaxAmount = (decimal?)x.TaxAmount,

                        DiscountAmount = (decimal?)x.DiscountAmount,

                        ShippingCharges = (decimal?)x.ShippingCharges,

                        CodAmount = (decimal?)x.CodAmount,

                        TotalQuantity = (decimal?)x.TotalQuantity,

                        TotalItems = (int?)x.TotalItems,

                        // =====================================================
                        // AUDIT / REMARKS
                        // =====================================================

                        Remarks = x.Remarks,

                       // CreatedDate = x.CreatedDate,

                        UpdatedDate = x.UpdatedDate,

                        // =====================================================
                        // ADDRESS
                        // =====================================================

                        ShippingAddress = x.ShippingAddress,

                        BillingAddress = x.BillingAddress,

                        StateCode = x.StateCode,

                        CountryCode = x.CountryCode,

                        // =====================================================
                        // TOPAZ COMPANY DETAILS
                        // =====================================================

                        Company_Name = x.Company_Name,

                        Company_Address = x.Company_Address,

                        Company_City = x.Company_City,

                        Company_State = x.Company_State,

                        Company_PINCode = x.Company_PINCode,

                        Phone_no = x.Phone_no,

                        Email_Address = x.Email_Address,

                        //gstin = x.gstin,

                        // =====================================================
                        // TOPAZ ORDER DETAILS
                        // =====================================================

                        SupplierRef = x.SupplierRef,

                        BuyersOrderNo = x.BuyersOrderNo,

                        BuyersOrderDate = x.BuyersOrderDate,

                        DespatchedThrough = x.DespatchedThrough,

                        Destination = x.Destination,

                        TermsOfDelivery = x.TermsOfDelivery,

                        RoundOff = (decimal?)x.RoundOff,

                        TotalInWords = x.TotalInWords,

                       // Company_PAN = x.Company_PAN,

                        //Company_CIN = x.Company_CIN,

                        // =====================================================
                        // DELIVERY / PAYMENT / SHIPPING
                        // =====================================================

                        DeliveryNote = x.DeliveryNote,

                        ModeorTermsOfPayment = x.ModeorTermsOfPayment,

                        OtherReferences = x.OtherReferences,

                        DespatchedDocumentNumber = x.DespatchedDocumentNumber,

                        DeliveryNoteDate = x.DeliveryNoteDate,

                        EWayBillNumber = x.EWayBillNumber,

                        VehicleNo = x.VehicleNo,

                        Distance = x.Distance,

                        TYear = x.TYear,

                        Transport = x.Transport,

                        TransporterName = x.TransporterName,

                        TransporterID = x.TransporterID,

                        TransporterDocNo = x.TransporterDocNo,

                        TransportMode = x.TransportMode,

                        // =====================================================
                        // TOPAZ IDENTIFIERS
                        // =====================================================

                        Pid = (int?)x.Pid,

                        KeyID = (int?)x.KeyID

                    }).ToList(),
                    SalesOrderItems = salesOrderItems.Select(i => MapSalesOrderItem(i)).ToList(),
                    SalesInvoices = salesInvoices.Select(s => new SellerCustomerSalesInvoiceResponse
                    {
                        // =====================================================
                        // BASIC INVOICE
                        // =====================================================

                        SalesInvoiceId = s.SalesInvoiceId,

                        SellerId = (int?)s.SellerId ?? 0,

                        CustomerId = (int?)s.CustomerId ?? 0,

                        SalesOrderId = (int?)s.SalesOrderId ?? 0,

                        InvoiceNumber = s.InvoiceNumber ?? string.Empty,

                        InvoiceDate = s.InvoiceDate,

                        // =====================================================
                        // FINANCIAL
                        // =====================================================

                        SubTotal = (decimal?)s.SubTotal ?? 0m,

                        DiscountAmount = (decimal?)s.DiscountAmount ?? 0m,

                        TaxAmount = (decimal?)s.TaxAmount ?? 0m,

                        TotalAmount = (decimal?)s.TotalAmount ?? 0m,

                        PaidAmount = (decimal?)s.PaidAmount ?? 0m,

                        BalanceAmount = (decimal?)s.BalanceAmount ?? 0m,

                        // =====================================================
                        // STATUS
                        // =====================================================

                        PaymentStatus = s.PaymentStatus,

                        Status = s.Status,

                        Remarks = s.Remarks,

                        // =====================================================
                        // AUDIT
                        // =====================================================

                        CreatedDate = s.CreatedDate,

                        UpdatedDate = s.UpdatedDate,

                        // =====================================================
                        // INVOICE ITEMS
                        // =====================================================

                        Items = salesInvoiceItems.Where(ii => ii.SalesInvoiceId == s.SalesInvoiceId).Select(ii => new SellerCustomerSalesInvoiceItemResponse
                         {
                             SalesInvoiceItemId = ii.SalesInvoiceItemId,

                             SalesInvoiceId = (int?)ii.SalesInvoiceId ?? 0,

                               ProductId = (int?)ii.ProductId ?? 0,

                                Quantity = (decimal?)ii.Quantity ?? 0m,

                                 UnitPrice = (decimal?)ii.UnitPrice ?? 0m,

                                HsnCode = ii.Hsncode ?? string.Empty,

        GstPer = (decimal?)ii.GstPer,

        SgstPer = (decimal?)ii.SgstPer,

        SgstAmount = (decimal?)ii.SgstAmount,

        CgstPer = (decimal?)ii.CgstPer,

        CgstAmount = (decimal?)ii.CgstAmount,

        IgstPer = (decimal?)ii.IgstPer,

        IgstAmount = (decimal?)ii.IgstAmount,

        TotalAmount = (decimal?)ii.TotalAmount ?? 0m,

        AfterGSTAmount = (decimal?)ii.AfterGSTAmount,

        Uom = ii.Uom ?? string.Empty,

                            Description = ii.Description ?? string.Empty

    })
    .ToList()

                    }).ToList(),
                    Shipments = shipments.Select(x => new SellerCustomerShipmentResponse
                    {
                        // =====================================================
                        // BASIC SHIPMENT
                        // =====================================================

                        ShipmentId = x.ShipmentId,

                        SellerId = (int?)x.SellerId ?? 0,

                        CustomerId = (int?)x.CustomerId ?? 0,

                        SalesOrderId = (int?)x.SalesOrderId,

                        DeliveryChallanId = (int?)x.DeliveryChallanId,

                        ShipmentNumber = x.ShipmentNumber,

                        ReturnDate = x.ReturnDate,

                        OrderId = (int?)x.OrderId ?? 0,

                        CourierName = x.CourierName,

                        TrackingNumber = x.TrackingNumber,

                        ShipmentDate = x.ShipmentDate,

                        DeliveryDate = x.DeliveryDate,

                        ShipmentStatus = x.ShipmentStatus,

                       // CarrierName = x.CarrierName,

                        Status = x.Status,

                        // =====================================================
                        // AUDIT
                        // =====================================================

                        CreatedBy = x.CreatedBy,

                        UpdatedBy = x.UpdatedBy,

                        ExpectedDeliveryDate = x.ExpectedDeliveryDate,

                        ActualDeliveryDate = x.ActualDeliveryDate,

                        CreatedDate = x.CreatedDate,

                        UpdatedDate = x.UpdatedDate,

                        // =====================================================
                        // UNIWARE / ORDER DETAILS
                        // =====================================================

                        SalesOrderNumber = x.SalesOrderNumber,

                        DisplayOrderCode = x.DisplayOrderCode,

                        ShippingPackageCode = x.ShippingPackageCode,

                        ShippingPackageNumber = x.ShippingPackageNumber,

                        ChannelCode = x.ChannelCode,

                        FacilityCode = x.FacilityCode,

                        // =====================================================
                        // COURIER / SHIPPING
                        // =====================================================

                        CourierCode = x.CourierCode,

                        ShippingMethodCode = x.ShippingMethodCode,

                        AwbNumber = x.AwbNumber,

                        CourierTrackingUrl = x.CourierTrackingUrl,

                        ShippingLabelUrl = x.ShippingLabelUrl,

                        InvoiceUrl = x.InvoiceUrl,

                        // =====================================================
                        // COD / PACKAGE
                        // =====================================================

                        IsCod = (bool?)x.IsCod ?? false,

                        CodAmount = (decimal?)x.CodAmount,

                        ShippingPackageStatus = x.ShippingPackageStatus,

                        Length = (decimal?)x.Length,

                        Width = (decimal?)x.Width,

                        Height = (decimal?)x.Height,

                        Weight = (decimal?)x.Weight,

                        IsShipped = (bool?)x.IsShipped ?? false,

                        IsDelivered = (bool?)x.IsDelivered ?? false,

                        ShippingAddress = x.ShippingAddress,

                        // =====================================================
                        // DIMENSION / WEIGHT UNITS
                        // =====================================================

                        DimUnit = x.DimUnit,

                        WeightUnit = x.WeightUnit,

                        // =====================================================
                        // TRANSPORT / E-WAY BILL
                        // =====================================================

                        VehicleNo = x.VehicleNo,

                        TransporterName = x.TransporterName,

                        TransporterID = x.TransporterID,

                        TransporterDocNo = x.TransporterDocNo,

                        TransportMode = x.TransportMode,

                        Distance = x.Distance,

                        EWayBillNumber = x.EWayBillNumber,

                        // =====================================================
                        // SHIPPING FINANCIALS
                        // =====================================================

                        ShippingCharges = (decimal?)x.ShippingCharges,

                        TotalAmount = (decimal?)x.TotalAmount,

                        // =====================================================
                        // UNIWARE STATUS
                        // =====================================================

                        CourierStatus = x.CourierStatus,

                        StatusRemarks = x.StatusRemarks

                    }).ToList(),
                    Wishlists = wishlists.Select(x => new SellerCustomerWishlistResponse
                    {
                        WishlistId = x.WishlistId,

                        SellerId = (int?)x.SellerId ?? 0,

                        CustomerId = (int?)x.CustomerId ?? 0,

                        WishlistName = x.WishlistName,

                        IsActive = (bool?)x.IsActive ?? false,

                        CreatedDate = x.CreatedDate,

                        UpdatedDate = x.UpdatedDate

                    }).ToList(),
                    WishlistItems = wishlistItems.Select(x => new SellerCustomerWishlistItemResponse
                    {
                        WishlistItemId = x.WishlistItemId,

                        WishlistId = (int?)x.WishlistId ?? 0,

                        SellerId = (int?)x.SellerId ?? 0,

                        CustomerId = (int?)x.CustomerId ?? 0,

                        ProductId = (int?)x.ProductId ?? 0,

                        //AddedDate = x.AddedDate,

                        CreatedDate = x.CreatedDate

                    }).ToList(),
                    MarketplaceOrders = marketplaceOrders.Select(x => new SellerCustomerMarketplaceOrderResponse
                    {
                        MarketplaceOrderId = x.MarketplaceOrderId,

                        MarketplaceAccountId = (int?)x.MarketplaceAccountId,

                        MarketplaceOrderNumber = x.MarketplaceOrderNumber,

                        ExternalOrderId = x.ExternalOrderId,

                        SellerOrderNumber = x.SellerOrderNumber,

                        OrderDate = x.OrderDate,

                        OrderStatus = x.OrderStatus,

                        FulfillmentChannel = x.FulfillmentChannel,

                        Currency = x.Currency,

                        TotalAmount = (decimal?)x.TotalAmount,

                        BuyerName = x.BuyerName,

                        BuyerEmail = x.BuyerEmail,

                        PurchaseOrderNumber = x.PurchaseOrderNumber,

                        LastSyncDate = x.LastSyncDate,

                        CreatedDate = x.CreatedDate,

                        UpdatedDate = x.UpdatedDate

                    }).ToList(),
                    MarketplaceOrderItems = marketplaceOrderItems.Select(x => new SellerCustomerMarketplaceOrderItemResponse
                    {
                        MarketplaceOrderItemId = x.MarketplaceOrderItemId,

                        MarketplaceOrderId = (int?)x.MarketplaceOrderId,

                        MarketplaceListingId = (int?)x.MarketplaceListingId,

                        ProductId = (int?)x.ProductId,

                        SellerId = (int?)x.SellerId,

                        CustomerId = (int?)x.CustomerId,

                        MarketplaceOrderItemNumber = x.MarketplaceOrderItemNumber,

                        ExternalOrderItemId = x.ExternalOrderItemId,

                        ProductTitle = x.ProductTitle,

                        SKU = x.SKU,

                        Quantity = (int?)x.Quantity,

                        UnitPrice = (decimal?)x.UnitPrice,

                        TaxAmount = (decimal?)x.TaxAmount,

                        ShippingAmount = (decimal?)x.ShippingAmount,

                        DiscountAmount = (decimal?)x.DiscountAmount,

                        TotalAmount = (decimal?)x.TotalAmount,

                        Status = x.Status,

                        CreatedDate = x.CreatedDate

                    }).ToList(),
                    MarketplaceReturns = marketplaceReturns.Select(x => new SellerCustomerMarketplaceReturnResponse
                    {
                        MarketplaceReturnId = x.MarketplaceReturnId,

                        MarketplaceOrderItemId = (int?)x.MarketplaceOrderItemId,

                        SellerId = (int?)x.SellerId,

                        CustomerId = (int?)x.CustomerId,

                        ProductId = (int?)x.ProductId,

                        SKU = x.SKU,

                        ReturnNumber = x.ReturnNumber,

                        ReturnReason = x.ReturnReason,

                        ReturnStatus = x.ReturnStatus,

                        QuantityReturned = (int?)x.QuantityReturned,

                        RefundAmount = (decimal?)x.RefundAmount,

                        ReturnDate = x.ReturnDate,

                        CreatedDate = x.CreatedDate,

                        UpdatedDate = x.UpdatedDate

                    }).ToList(),
                }
            };
        }
        public async Task<SellerCustomerEntity> CreateAsync(CreateSellerCustomerRequest request)
        {
            var entity = new SellerCustomerEntity
            {
                SellerId = request.SellerId,
                CustomerCode = "CUST-" + Guid.NewGuid().ToString("N")[..8].ToUpper(),
                CustomerName = request.CustomerName.Trim(),
                ContactPerson = request.ContactPerson?.Trim(),
                Email = request.Email?.Trim().ToLowerInvariant(),
                Phone = request.Phone?.Trim(),
                GSTIN = request.GSTIN?.Trim().ToUpperInvariant(),
                AddressLine1 = request.AddressLine1?.Trim(),
                AddressLine2 = request.AddressLine2?.Trim(),
                City = request.City?.Trim(),
                State = request.State?.Trim(),
                Country = request.Country?.Trim(),
                PostalCode = request.PostalCode?.Trim(),
                CreditLimit = request.CreditLimit,
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            };
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(int sellerId, int customerId, UpdateSellerCustomerRequest request)
        {
            var entity = await _repository.GetCustomerAsync(sellerId, customerId);
            if (entity is null) return false;
            entity.CustomerName = request.CustomerName.Trim();
            entity.ContactPerson = request.ContactPerson?.Trim();
            entity.Email = request.Email?.Trim().ToLowerInvariant();
            entity.Phone = request.Phone?.Trim();
            entity.GSTIN = request.GSTIN?.Trim().ToUpperInvariant();
            entity.AddressLine1 = request.AddressLine1?.Trim();
            entity.AddressLine2 = request.AddressLine2?.Trim();
            entity.City = request.City?.Trim();
            entity.State = request.State?.Trim();
            entity.Country = request.Country?.Trim();
            entity.PostalCode = request.PostalCode?.Trim();
            entity.CreditLimit = request.CreditLimit;
            entity.IsActive = request.IsActive;
            entity.UpdatedDate = DateTime.UtcNow;
            await _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int sellerId, int customerId)
        {
            var entity = await _repository.GetCustomerAsync(sellerId, customerId);
            if (entity is null) return false;
            await _repository.DeleteAsync(entity);
            await _repository.SaveChangesAsync();
            return true;
        }

        private static bool ContainsIgnoreCase(string? source, string search) => !string.IsNullOrWhiteSpace(source) && source.Contains(search, StringComparison.OrdinalIgnoreCase);
        private static List<string> TryParseList(string? json)
        {
            if (string.IsNullOrWhiteSpace(json)) return [];
            try { return JsonSerializer.Deserialize<List<string>>(json) ?? []; } catch { return []; }
        }
        private static SellerCustomerSalesOrderItemResponse MapSalesOrderItem(SalesOrderItem item) => new()
        {
            SalesOrderItemId = item.SalesOrderItemId,
            SalesOrderId = item.SalesOrderId,
            ProductId = item.ProductId,
            Sku = item.Sku,
            ProductName = item.ProductName,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice,
            Discount = item.Discount,
            TaxAmount = item.TaxAmount,
            TotalAmount = item.TotalAmount
        };
    }
}
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
using System.Text.Json;
// FIX: SellerCustomer and ProductImage are both namespace + type
using BrandEntity = Marketplacesellerportal.Models.Brand;
using BrandModelEntity = Marketplacesellerportal.Models.BrandModel;
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
            var salesOrderIds = await _context.SalesOrders
           .Where(x =>
               x.SellerId == sellerId &&
               x.CustomerId == customerId)
           .Select(x => x.SalesOrderId)
           .ToListAsync();

            var salesOrderAddresses = await _context.SaleOrderAddresses
                .Where(x =>
                    x.SalesOrderId.HasValue &&
                    salesOrderIds.Contains(x.SalesOrderId.Value))
                .AsNoTracking()
                .ToListAsync();
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

            var categoryIds = products.Where(p => p.CategoryId.HasValue).Select(p => p.CategoryId!.Value).Distinct().ToList();
            var categories = categoryIds.Count > 0 ? await _categoryRepository.GetByIdsAsync(categoryIds) : [];

            IEnumerable<ProductImageEntity> images = productIds.Count > 0 ? await _productImageRepository.GetByProductIdsAsync(productIds) : [];
            var seller = await _context.Sellers.AsNoTracking().FirstOrDefaultAsync(s => s.SellerId == sellerId);

            var picklists = await _context.Picklists.Where(x => x.SellerId == sellerId && x.CustomerId == customerId).AsNoTracking().ToListAsync();
           
            var manifestPackages = await _context.ManifestPackages.Where(x => x.SellerId == sellerId && x.CustomerId == customerId).AsNoTracking().ToListAsync();
            var reversePickupItems = await _context.ReversePickupItems.Where(x => x.SellerId == sellerId && x.CustomerId == customerId).AsNoTracking().ToListAsync();
            var invoiceTaxDetails = await _context.InvoiceTaxDetails.Where(x => x.SellerId == sellerId && x.CustomerId == customerId).AsNoTracking().ToListAsync();
            var exportJobs = await _context.ExportJobs.Where(x => x.SellerId == sellerId && x.CustomerId == customerId).AsNoTracking().ToListAsync();
            var reversePickupAddresses = await _context.ReversePickupAddresses
     .Where(x =>
         x.SellerId == sellerId &&
         x.CustomerId == customerId)
     .AsNoTracking()
     .ToListAsync();
            var warehouseLocations = await _context.WarehouseLocations.Where(l => l.SellerId == sellerId && l.CustomerId == customerId).AsNoTracking().ToListAsync();
            var shelfwiseInventories = await _context.ShelfwiseInventories.Where(i => i.SellerId == sellerId && i.CustomerId == customerId).AsNoTracking().ToListAsync();
            var vendorItemMasters = await _context.VendorItemMasters.Where(i => i.SellerId == sellerId && i.CustomerId == customerId).AsNoTracking().ToListAsync();
            var gatepasses = await _context.Gatepasses.Where(g => g.SellerId == sellerId && g.CustomerId == customerId).AsNoTracking().ToListAsync();
            var putaways = await _context.Putaways.Where(p => p.SellerId == sellerId && p.CustomerId == customerId).AsNoTracking().ToListAsync();
            var reversePickups = await _context.ReversePickups.Where(p => p.SellerId == sellerId && p.CustomerId == customerId).AsNoTracking().ToListAsync();
            var eInvoices = await _context.EInvoices.Where(i => i.SellerId == sellerId && i.CustomerId == customerId).AsNoTracking().ToListAsync();
            var eWayBills = await _context.EWayBills.Where(e => e.SellerId == sellerId && e.CustomerId == customerId).AsNoTracking().ToListAsync();

            var salesOrderItems = salesOrderIds.Count > 0 ? await _context.SalesOrderItems.Where(i => salesOrderIds.Contains(i.SalesOrderId)).AsNoTracking().ToListAsync() : [];
            var deliveryChallanItems = deliveryChallanIds.Count > 0 ? await _context.DeliveryChallanItems.Where(d => deliveryChallanIds.Contains(d.DeliveryChallanId)).AsNoTracking().ToListAsync() : [];
            var salesInvoices = salesOrderIds.Count > 0 ? await _context.SalesInvoices.Where(i => salesOrderIds.Contains(i.SalesOrderId)).AsNoTracking().ToListAsync() : [];
            var purchaseOrderItems = purchaseOrderIds.Count > 0 ? await _context.PurchaseOrderItems.Where(i => purchaseOrderIds.Contains(i.PurchaseOrderId)).AsNoTracking().ToListAsync() : [];

            var brandIds = products.Where(p => p.BrandId.HasValue).Select(p => p.BrandId!.Value).Distinct().ToList();
            List<BrandEntity> brands = brandIds.Count > 0 ? await _context.Brands.Where(b => brandIds.Contains(b.BrandId)).AsNoTracking().ToListAsync() : [];
            List<BrandModelEntity> brandModels = brandIds.Count > 0 ? await _context.BrandModels.Where(m => brandIds.Contains(m.BrandId)).AsNoTracking().ToListAsync() : [];

            var invoiceIds = salesInvoices.Select(i => i.SalesInvoiceId).ToList();
            var salesInvoiceItems = invoiceIds.Count > 0 ? await _context.SalesInvoiceItems.Where(i => invoiceIds.Contains(i.SalesInvoiceId)).AsNoTracking().ToListAsync() : [];

            var marketplaceListingInventories = productIds.Count > 0
                ? await _context.MarketplaceListingInventory.Where(x => _context.MarketplaceListings.Any(l => l.MarketplaceListingId == x.MarketplaceListingId && productIds.Contains(l.ProductId))).AsNoTracking().ToListAsync()
                : [];
            var amazonInventorySyncs = productIds.Count > 0
                ? await _context.AmazonInventorySync.Where(s => s.ProductId.HasValue && productIds.Contains(s.ProductId.Value)).AsNoTracking().ToListAsync()
                : [];

            var response = new SellerCustomerWithProductsResponse
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
                CreditLimit = customer.CreditLimit ?? 0,
                IsActive = customer.IsActive,
                CreatedDate = customer.CreatedDate,
                UpdatedDate = customer.UpdatedDate,
                Seller = seller == null ? null : new SellerCustomerSellerResponse { SellerId = seller.SellerId, SellerName = seller.SellerName },
                CustomerAddresses = customerAddresses.Select(a => new SellerCustomerAddressResponse { CustomerAddressId = a.CustomerAddressId, CustomerId = a.CustomerId, AddressType = a.AddressType, AddressLine1 = a.AddressLine1, AddressLine2 = a.AddressLine2, City = a.City, State = a.State, Country = a.Country, PostalCode = a.PostalCode, IsDefault = a.IsDefault, CreatedDate = a.CreatedDate }).ToList(),
                Products = products.Select(p => new SellerCustomerProductResponse { ProductId = p.ProductId, SellerId = p.SellerId, CustomerId = p.CustomerId, ProductName = p.ProductName ?? "", SKU = p.SKU ?? "", BrandId = p.BrandId, BrandName = brands.FirstOrDefault(b => b.BrandId == p.BrandId)?.BrandName, CategoryId = p.CategoryId, ProductTypeId = p.ProductTypeId, Description = p.Description, HSNCode = p.HSNCode, Status = p.Status, IsActive = p.IsActive ?? true }).ToList(),
                Inventories = inventories.Select(x => new SellerCustomerInventoryResponse { ProductInventoryId = x.ProductInventoryId, SellerId = x.SellerId, CustomerId = x.CustomerId, ProductId = x.ProductId, Quantity = x.Quantity ?? 0m }).ToList(),
                Prices = prices.Select(x => new SellerCustomerPriceResponse { ProductPriceId = x.ProductPriceId, ProductId = x.ProductId, SellerId = x.SellerId, CustomerId = x.CustomerId, Price = x.Price }).ToList(),
                ProductTypes = productTypes.Select(x => new SellerCustomerProductTypeResponse { ProductTypeId = x.ProductTypeId, SellerId = x.SellerId, CustomerId = x.CustomerId, ProductTypeName = x.ProductTypeName }).ToList(),
                Categories = categories.Select(x => new SellerCustomerCategoryResponse { CategoryId = x.CategoryId, CategoryName = x.CategoryName, SellerId = x.SellerId ?? 0, CustomerId = x.CustomerId ?? 0, IsActive = x.IsActive }).ToList(),
                Images = images.Select(x => new SellerCustomerImageResponse { ProductImageId = x.ProductImageId, SellerId = x.SellerId, CustomerId = x.CustomerId, ProductId = x.ProductId, ImageUrl = x.ImageUrl, IsPrimary = x.IsPrimary }).ToList(),
                Attributes = attributes.Select(x => new SellerCustomerAttributeResponse { ProductAttributeId = x.ProductAttributeId, ProductId = x.ProductId, SellerId = x.SellerId, CustomerId = x.CustomerId, AttributeName = x.AttributeName, AttributeValue = x.AttributeValue }).ToList(),
                StockMovements = stockMovements.Select(x => new SellerCustomerStockMovementResponse { StockMovementId = x.StockMovementId, SellerId = x.SellerId, CustomerId = x.CustomerId, ProductId = x.ProductId, Quantity = x.Quantity ?? 0m }).ToList(),
                StockLedgers = stockLedgers.Select(x => new SellerCustomerStockLedgerResponse { StockLedgerId = x.StockLedgerId, SellerId = x.SellerId, CustomerId = x.CustomerId, ProductId = x.ProductId, Quantity = x.Quantity }).ToList(),
                Warehouses = warehouses.Select(x => new SellerCustomerWarehouseResponse { WarehouseId = x.WarehouseId, SellerId = x.SellerId, CustomerId = x.CustomerId, WarehouseCode = x.WarehouseCode, WarehouseName = x.WarehouseName }).ToList(),
                WarehouseLocations = warehouseLocations.Select(x => new SellerCustomerWarehouseLocationResponse { LocationId = x.LocationId, CustomerId = x.CustomerId, WarehouseId = x.WarehouseId, LocationCode = x.LocationCode, LocationName = x.LocationName }).ToList(),
                StockAdjustments = stockAdjustments.Select(x => new SellerCustomerStockAdjustmentResponse { StockAdjustmentId = x.StockAdjustmentId, SellerId = x.SellerId, CustomerId = x.CustomerId, ProductId = x.ProductId, Quantity = x.Quantity }).ToList(),
                StockTransfers = stockTransfers.Select(x => new SellerCustomerStockTransferResponse { StockTransferId = x.StockTransferId, SellerId = x.SellerId, CustomerId = x.CustomerId, ProductId = x.ProductId, Quantity = x.Quantity, Status = x.Status }).ToList(),
                Suppliers = suppliers.Select(x => new SellerCustomerSupplierResponse { SupplierId = x.SupplierId, SellerId = x.SellerId, CustomerId = x.CustomerId, SupplierName = x.SupplierName }).ToList(),
                Brands = brands.Select(x => new SellerCustomerBrandResponse { BrandId = x.BrandId, BrandName = x.BrandName ?? "", BrandCode = x.BrandCode ?? "" }).ToList(),
                BrandModels = brandModels.Select(x => new SellerCustomerBrandModelResponse { BrandModelId = x.BrandModelId, BrandId = x.BrandId, ModelName = x.ModelName ?? "" }).ToList(),
                Marketplaces = marketplaces.Select(x => new SellerCustomerMarketplaceResponse { MarketplaceId = x.MarketplaceId, MarketplaceCode = x.MarketplaceCode ?? "", MarketplaceName = x.MarketplaceName ?? "" }).ToList(),
                DeliveryChallanItems = deliveryChallanItems.Select(x => new SellerCustomerDeliveryChallanItemResponse { DeliveryChallanItemId = x.DeliveryChallanItemId, DeliveryChallanId = x.DeliveryChallanId, ProductId = x.ProductId, Quantity = x.Quantity }).ToList(),
                EInvoices = eInvoices.Select(x => new SellerCustomerEInvoiceResponse { EInvoiceId = x.EInvoiceId, SellerId = x.SellerId, CustomerId = x.CustomerId, Irn = x.IRN }).ToList(),
                EWayBills = eWayBills.Select(x => new SellerCustomerEWayBillResponse { EWayBillId = x.EWayBillId, SellerId = x.SellerId, CustomerId = x.CustomerId, EWayBillNumber = x.EWayBillNumber }).ToList(),
                ShelfwiseInventories = shelfwiseInventories.Select(x => new SellerCustomerShelfwiseInventoryResponse { ShelfwiseInventoryId = x.ShelfwiseInventoryId, SellerId = x.SellerId, CustomerId = x.CustomerId, ItemSkuCode = x.ItemSkuCode ?? "", Quantity = x.Quantity }).ToList(),
                VendorItemMasters = vendorItemMasters.Select(x => new SellerCustomerVendorItemMasterResponse { VendorItemMasterId = x.VendorItemMasterId, VendorId = x.VendorId, SellerId = x.SellerId, CustomerId = x.CustomerId, ItemSkuCode = x.ItemSkuCode }).ToList(),
                Gatepasses = gatepasses.Select(x => new SellerCustomerGatepassResponse { GatepassId = x.GatepassId, SellerId = x.SellerId, CustomerId = x.CustomerId, GatepassCode = x.GatepassCode }).ToList(),
                Putaways = putaways.Select(x => new SellerCustomerPutawayResponse { PutawayId = x.PutawayId, SellerId = x.SellerId, CustomerId = x.CustomerId, PutawayCode = x.PutawayCode }).ToList(),
                ReversePickups = reversePickups.Select(x => new SellerCustomerReversePickupResponse { ReversePickupId = x.ReversePickupId, SellerId = x.SellerId, CustomerId = x.CustomerId, ReversePickupNo = x.ReversePickupNo }).ToList(),
                ReversePickupItems = reversePickupItems.Select(x => new SellerCustomerReversePickupItemResponse { ReversePickupItemId = x.Id, SellerId = x.SellerId, CustomerId = x.CustomerId, ReversePickupId = x.ReversePickupId, ItemSku = x.ItemSku }).ToList(),
                Picklists = picklists.Select(x => new SellerCustomerPicklistResponse { PicklistId = x.PicklistId, PicklistCode = x.PicklistCode, SellerId = x.SellerId, CustomerId = x.CustomerId }).ToList(),
                ManifestPackages = manifestPackages.Select(x => new SellerCustomerManifestPackageResponse { ManifestPackageId = x.ManifestPackageId, SellerId = x.SellerId, CustomerId = x.CustomerId, ShippingPackageCode = x.ShippingPackageCode }).ToList(),
                InvoiceTaxDetails = invoiceTaxDetails.Select(x => new SellerCustomerInvoiceTaxDetailResponse { InvoiceTaxDetailId = x.InvoiceTaxDetailId, SellerId = x.SellerId, CustomerId = x.CustomerId, SalesInvoiceId = x.SalesInvoiceId }).ToList(),
                ReversePickupAddresses = reversePickupAddresses
    .Select(x => new SellerCustomerReversePickupAddressResponse
    {
        ReversePickupAddressId = x.Id,
        SellerId = x.SellerId,
        CustomerId = x.CustomerId,
        ReversePickupId = x.ReversePickupId,
        City = x.City
    })
    .ToList(),
                ExportJobs = exportJobs.Select(x => new SellerCustomerExportJobResponse { ExportJobId = x.ExportJobId, SellerId = x.SellerId, CustomerId = x.CustomerId, JobCode = x.JobCode, Status = x.Status }).ToList(),
                SalesOrderAddresses = salesOrderAddresses
    .Select(x => new SellerCustomerSaleOrderAddressResponse
    {
        SaleOrderAddressId = x.AddressId,
        SalesOrderId = x.SalesOrderId ?? 0,
        City = x.City
    })
    .ToList(),
                MarketplaceListingInventories = marketplaceListingInventories.Select(x => new SellerCustomerMarketplaceListingInventoryResponse { MarketplaceListingInventoryId = x.MarketplaceListingInventoryId, MarketplaceListingId = x.MarketplaceListingId, AvailableQuantity = x.AvailableQuantity ?? 0m }).ToList(),
                AmazonInventorySyncs = amazonInventorySyncs.Select(x => new SellerCustomerAmazonInventorySyncResponse { InventorySyncId = x.InventorySyncId, ProductId = x.ProductId ?? 0, SKU = x.SKU ?? "", ASIN = x.ASIN ?? "" }).ToList(),
                Transactions = new SellerCustomerTransactionResponse
                {
                    CustomerId = customerId,
                    SellerId = sellerId,
                    CustomerReturns = customerReturns.Select(x => new SellerCustomerCustomerReturnResponse { CustomerReturnId = x.CustomerReturnId, SellerId = x.SellerId, CustomerId = x.CustomerId, ReturnNumber = x.ReturnNumber, ReturnDate = x.ReturnDate, Quantity = x.Quantity, Status = x.Status }).ToList(),
                    DeliveryChallans = deliveryChallans.Select(x => new SellerCustomerDeliveryChallanResponse { DeliveryChallanId = x.DeliveryChallanId, SellerId = x.SellerId, CustomerId = x.CustomerId, ChallanNumber = x.ChallanNumber, ChallanDate = x.ChallanDate, Status = x.Status }).ToList(),
                    GoodsReceiptItems = goodsReceiptItems.Select(x => new SellerCustomerGoodsReceiptItemResponse { GoodsReceiptItemId = x.GoodsReceiptItemId, GoodsReceiptNoteId = x.GoodsReceiptNoteId, ProductId = x.ProductId, SellerId = x.SellerId, CustomerId = x.CustomerId, Quantity = x.ReceivedQuantity, SerialCodes = TryParseList(x.SerialCodesJson), CreatedDate = DateTime.UtcNow }).ToList(),
                    GoodsReceiptNotes = goodsReceiptNotes.Select(x => new SellerCustomerGoodsReceiptNoteResponse { GoodsReceiptNoteId = x.GoodsReceiptNoteId, SellerId = x.SellerId, CustomerId = x.CustomerId, GRNNumber = x.GRNNumber, ReceiptDate = x.ReceiptDate, Status = x.Status }).ToList(),
                    Notifications = notifications.Select(x => new SellerCustomerNotificationResponse { NotificationId = x.NotificationId, SellerId = x.SellerId, CustomerId = x.CustomerId ?? 0, Title = x.Title, IsRead = x.IsRead }).ToList(),
                    OrderStatusHistories = orderStatusHistories.Select(x => new SellerCustomerOrderStatusHistoryResponse { OrderStatusHistoryId = x.OrderStatusHistoryId, SellerId = x.SellerId, CustomerId = x.CustomerId, Status = x.Status, ChangedOn = x.ChangedOn }).ToList(),
                    Payments = payments.Select(x => new SellerCustomerPaymentResponse { PaymentId = x.PaymentId, SellerId = x.SellerId, CustomerId = x.CustomerId, Amount = x.Amount ?? 0m, PaymentStatus = x.PaymentStatus }).ToList(),
                    PurchaseOrders = purchaseOrders.Select(x => new SellerCustomerPurchaseOrderResponse { PurchaseOrderId = x.PurchaseOrderId, SellerId = x.SellerId, CustomerId = x.CustomerId, PurchaseOrderNumber = x.PurchaseOrderNumber, OrderDate = x.OrderDate, Status = x.Status, TotalAmount = x.TotalAmount }).ToList(),
                    PurchaseOrderItems = purchaseOrderItems.Select(x => new SellerCustomerPurchaseOrderItemResponse { PurchaseOrderItemId = x.PurchaseOrderItemId, PurchaseOrderId = x.PurchaseOrderId, ProductId = x.ProductId, Quantity = x.Quantity }).ToList(),
                    PurchaseReturns = purchaseReturns.Select(x => new SellerCustomerPurchaseReturnResponse { PurchaseReturnId = x.PurchaseReturnId, SellerId = x.SellerId, CustomerId = x.CustomerId, PurchaseReturnNumber = x.PurchaseReturnNumber, TotalAmount = x.TotalAmount ?? 0m, Status = x.Status }).ToList(),
                    Reviews = reviews.Select(x => new SellerCustomerReviewResponse { ReviewId = x.ReviewId, SellerId = x.SellerId, CustomerId = x.CustomerId, ProductId = x.ProductId, Rating = x.Rating }).ToList(),
                    SalesOrders = salesOrders.Select(x => new SellerCustomerSalesOrderResponse { SalesOrderId = x.SalesOrderId, SellerId = x.SellerId, CustomerId = x.CustomerId, SalesOrderNumber = x.SalesOrderNumber ?? "", TotalAmount = x.TotalAmount ?? 0m }).ToList(),
                    SalesOrderItems = salesOrderItems.Select(i => MapSalesOrderItem(i)).ToList(),
                    SalesInvoices = salesInvoices.Select(s => new SellerCustomerSalesInvoiceResponse { SalesInvoiceId = s.SalesInvoiceId, SellerId = s.SellerId, CustomerId = s.CustomerId, InvoiceNumber = s.InvoiceNumber ?? "", TotalAmount = s.TotalAmount, Items = salesInvoiceItems.Where(ii => ii.SalesInvoiceId == s.SalesInvoiceId).Select(ii => new SellerCustomerSalesInvoiceItemResponse { SalesInvoiceItemId = ii.SalesInvoiceItemId, SalesInvoiceId = ii.SalesInvoiceId, ProductId = ii.ProductId, Quantity = ii.Quantity }).ToList() }).ToList(),
                    Shipments = shipments.Select(x => new SellerCustomerShipmentResponse { ShipmentId = x.ShipmentId, SellerId = x.SellerId, CustomerId = x.CustomerId, ShipmentNumber = x.ShipmentNumber, TrackingNumber = x.TrackingNumber }).ToList(),
                    Wishlists = wishlists.Select(x => new SellerCustomerWishlistResponse { WishlistId = x.WishlistId, SellerId = x.SellerId, CustomerId = x.CustomerId, WishlistName = x.WishlistName }).ToList(),
                    WishlistItems = wishlistItems.Select(x => new SellerCustomerWishlistItemResponse { WishlistItemId = x.WishlistItemId, WishlistId = x.WishlistId, ProductId = x.ProductId }).ToList(),
                    MarketplaceOrders = marketplaceOrders.Select(x => new SellerCustomerMarketplaceOrderResponse { MarketplaceOrderId = x.MarketplaceOrderId, MarketplaceOrderNumber = x.MarketplaceOrderNumber, OrderStatus = x.OrderStatus }).ToList(),
                    MarketplaceOrderItems = marketplaceOrderItems.Select(x => new SellerCustomerMarketplaceOrderItemResponse { MarketplaceOrderItemId = x.MarketplaceOrderItemId, MarketplaceOrderId = x.MarketplaceOrderId, SKU = x.SKU, Quantity = x.Quantity }).ToList(),
                    MarketplaceReturns = marketplaceReturns.Select(x => new SellerCustomerMarketplaceReturnResponse { MarketplaceReturnId = x.MarketplaceReturnId, ReturnNumber = x.ReturnNumber, ReturnStatus = x.ReturnStatus }).ToList()
                }
            };
            return response;
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
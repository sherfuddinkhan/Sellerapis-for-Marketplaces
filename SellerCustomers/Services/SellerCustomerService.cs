// ============================================================
// SellerCustomerService.cs
// ============================================================
// Purpose:
//   Provides SellerCustomer CRUD operations and returns the
//   complete Seller + Customer + Product + Transaction view.
//
// Main responsibilities:
//   1. SellerCustomer CRUD
//   2. Customer filtering
//   3. Customer addresses
//   4. Products and product metadata
//   5. Inventory and pricing
//   6. Stock / warehouse information
//   7. Sales orders and invoices
//   8. Purchase orders
//   9. Returns
//  10. Shipments
//  11. Marketplace transactions
//  12. E-Invoices
//  13. E-Way Bills
//  14. Supporting transaction information
//
// Important:
//   - SellerId and CustomerId are always used together when
//     retrieving seller-customer-specific transactional data.
//   - BrandModelEntity is used to avoid the BrandModel namespace
//     versus class-name conflict.
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
using Marketplacesellerportal.SalesOrderItems.Interfaces;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// ============================================================
// TYPE ALIASES
// ============================================================
//
// BrandModel exists as a namespace/type combination in the
// project. The alias prevents:
//
//     'BrandModel' is a namespace but is used like a type
//
// ============================================================
using BrandEntity = Marketplacesellerportal.Models.Brand;
using BrandModelEntity = Marketplacesellerportal.Models.BrandModel;
using ProductEntity = Marketplacesellerportal.Models.Product;

using MarketplaceReturnEntity =
    Marketplacesellerportal.Models.MarketplaceReturn;

//using MarketplaceOrderEntity =
  //  Marketplacesellerportal.Models.MarketplaceOrder;

//using MarketplaceOrderItemEntity =
  //  Marketplacesellerportal.Models.MarketplaceOrderItem;


// ============================================================
// NAMESPACE
// ============================================================

namespace Marketplacesellerportal.SellerCustomers.Services
{
    public class SellerCustomerService : ISellerCustomerService
    {
        // ========================================================
        // DATABASE
        // ========================================================

        private readonly ApplicationDbContext _context;

        // ========================================================
        // SELLER CUSTOMER
        // ========================================================

        private readonly ISellerCustomerRepository _repository;

        private readonly ICustomerAddressRepository
            _customerAddressRepository;

        // ========================================================
        // PRODUCT
        // ========================================================

        private readonly IProductRepository
            _productRepository;

        private readonly IProductInventoryRepository
            _inventoryRepository;

        private readonly IProductPriceRepository
            _productPriceRepository;

        private readonly IProductTypeRepository
            _productTypeRepository;

        private readonly ICategoryRepository
            _categoryRepository;

        private readonly IProductImageRepository
            _productImageRepository;

        private readonly IProductAttributeRepository
            _productAttributeRepository;

        // ========================================================
        // STOCK
        // ========================================================

        private readonly IStockMovementRepository
            _stockMovementRepository;

        private readonly IStockLedgerRepository
            _stockLedgerRepository;

        private readonly IWarehouseRepository
            _warehouseRepository;

        private readonly IStockAdjustmentRepository
            _stockAdjustmentRepository;

        private readonly IStockTransferRepository
            _stockTransferRepository;

        // ========================================================
        // SUPPLIER / WAREHOUSE
        // ========================================================

        private readonly ISupplierRepository
            _supplierRepository;

        private readonly IWarehouseLocationRepository
            _warehouseLocationRepository;

        // ========================================================
        // SALES
        // ========================================================

        private readonly ISalesOrderRepository
            _salesOrderRepository;

        private readonly ISalesOrderItemRepository
            _salesOrderItemRepository;

        private readonly ISalesInvoiceRepository
            _salesInvoiceRepository;

        // ========================================================
        // RETURNS
        // ========================================================

        private readonly ICustomerReturnRepository
            _customerReturnRepository;

        private readonly IPurchaseReturnRepository
            _purchaseReturnRepository;

        private readonly IMarketplaceReturnRepository
            _marketplaceReturnRepository;

        // ========================================================
        // DELIVERY
        // ========================================================

        private readonly IDeliveryChallanRepository
            _deliveryChallanRepository;

        private readonly IDeliveryChallanItemRepository
            _deliveryChallanItemRepo;

        // ========================================================
        // GOODS RECEIPT
        // ========================================================

        private readonly IGoodsReceiptNoteRepository
            _goodsReceiptNoteRepository;

        private readonly IGoodsReceiptItemRepository
            _goodsReceiptItemRepository;

        // ========================================================
        // NOTIFICATIONS / HISTORY / PAYMENTS
        // ========================================================

        private readonly INotificationRepository
            _notificationRepository;

        private readonly IOrderStatusHistoryRepository
            _orderStatusHistoryRepository;

        private readonly IPaymentRepository
            _paymentRepository;

        // ========================================================
        // PURCHASE
        // ========================================================

        private readonly IPurchaseOrderRepository
            _purchaseOrderRepository;

        private readonly IPurchaseOrderItemRepository
            _purchaseOrderItemRepository;

        // ========================================================
        // REVIEWS
        // ========================================================

        private readonly IReviewRepository
            _reviewRepository;

        // ========================================================
        // SHIPMENTS
        // ========================================================

        private readonly IShipmentRepository
            _shipmentRepository;

        // ========================================================
        // WISHLISTS
        // ========================================================

        private readonly IWishlistRepository
            _wishlistRepository;

        private readonly IWishlistItemRepository
            _wishlistItemRepository;

        // ========================================================
        // MARKETPLACE
        // ========================================================

        private readonly IMarketplaceOrderRepository
            _marketplaceOrderRepository;

        private readonly IMarketplaceOrderItemRepository
            _marketplaceOrderItemRepository;

        private readonly IMarketplaceRepository
            _marketplaceRepo;

        // ========================================================
        // SELLER
        // ========================================================

        private readonly ISellerRepository
            _sellerRepo;

        // ========================================================
        // E-INVOICE / E-WAY BILL
        // ========================================================

        private readonly IEInvoiceRepository
            _eInvoiceRepo;

        private readonly IEWayBillRepository
            _eWayBillRepo;


        // ========================================================
        // CONSTRUCTOR
        // ========================================================

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

            IMarketplaceOrderRepository marketplaceOrderRepository,
            IMarketplaceOrderItemRepository marketplaceOrderItemRepository,
            IMarketplaceReturnRepository marketplaceReturnRepository,

            IDeliveryChallanItemRepository deliveryChallanItemRepo,

            IMarketplaceRepository marketplaceRepo,
            ISellerRepository sellerRepo,

            IEInvoiceRepository eInvoiceRepo,
            IEWayBillRepository eWayBillRepo)
        {
            _context = context;

            _repository = repository;

            _customerAddressRepository =
                customerAddressRepository;

            _productRepository =
                productRepository;

            _inventoryRepository =
                inventoryRepository;

            _productPriceRepository =
                productPriceRepository;

            _productTypeRepository =
                productTypeRepository;

            _categoryRepository =
                categoryRepository;

            _productImageRepository =
                productImageRepository;

            _productAttributeRepository =
                productAttributeRepository;

            _stockMovementRepository =
                stockMovementRepository;

            _stockLedgerRepository =
                stockLedgerRepository;

            _warehouseRepository =
                warehouseRepository;

            _stockAdjustmentRepository =
                stockAdjustmentRepository;

            _stockTransferRepository =
                stockTransferRepository;

            _supplierRepository =
                supplierRepository;

            _warehouseLocationRepository =
                warehouseLocationRepository;

            _salesOrderRepository =
                salesOrderRepository;

            _salesOrderItemRepository =
                salesOrderItemRepository;

            _customerReturnRepository =
                customerReturnRepository;

            _deliveryChallanRepository =
                deliveryChallanRepository;

            _goodsReceiptNoteRepository =
                goodsReceiptNoteRepository;

            _goodsReceiptItemRepository =
                goodsReceiptItemRepository;

            _notificationRepository =
                notificationRepository;

            _orderStatusHistoryRepository =
                orderStatusHistoryRepository;

            _paymentRepository =
                paymentRepository;

            _purchaseOrderRepository =
                purchaseOrderRepository;

            _purchaseOrderItemRepository =
                purchaseOrderItemRepository;

            _purchaseReturnRepository =
                purchaseReturnRepository;

            _reviewRepository =
                reviewRepository;

            _salesInvoiceRepository =
                salesInvoiceRepository;

            _shipmentRepository =
                shipmentRepository;

            _wishlistRepository =
                wishlistRepository;

            _wishlistItemRepository =
                wishlistItemRepository;

            _marketplaceOrderRepository =
                marketplaceOrderRepository;

            _marketplaceOrderItemRepository =
                marketplaceOrderItemRepository;

            _marketplaceReturnRepository =
                marketplaceReturnRepository;

            _deliveryChallanItemRepo =
                deliveryChallanItemRepo;

            _marketplaceRepo =
                marketplaceRepo;

            _sellerRepo =
                sellerRepo;

            _eInvoiceRepo =
                eInvoiceRepo;

            _eWayBillRepo =
                eWayBillRepo;
        }


        // ========================================================
        // BASIC SELLER CUSTOMER OPERATIONS
        // ========================================================

        public async Task<IEnumerable<SellerCustomer>>
            GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }


        public async Task<IEnumerable<SellerCustomer>>
            GetBySellerIdAsync(int sellerId)
        {
            return await _repository
                .GetBySellerIdAsync(sellerId);
        }


        public async Task<SellerCustomer?>
            GetCustomerAsync(
                int sellerId,
                int customerId)
        {
            return await _repository
                .GetCustomerAsync(
                    sellerId,
                    customerId);
        }


        // ========================================================
        // CUSTOMER FILTER
        // ========================================================

        public async Task<IEnumerable<SellerCustomer>>
            FilterAsync(
                int sellerId,
                string? search,
                bool? isActive)
        {
            var customers =
                await GetBySellerIdAsync(sellerId);

            IEnumerable<SellerCustomer> result =
                customers;

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                result = result.Where(customer =>
                    ContainsIgnoreCase(
                        customer.CustomerCode,
                        search)

                    ||

                    ContainsIgnoreCase(
                        customer.CustomerName,
                        search)

                    ||

                    ContainsIgnoreCase(
                        customer.ContactPerson,
                        search)

                    ||

                    ContainsIgnoreCase(
                        customer.Email,
                        search)

                    ||

                    ContainsIgnoreCase(
                        customer.Phone,
                        search)

                    ||

                    ContainsIgnoreCase(
                        customer.GSTIN,
                        search)

                    ||

                    ContainsIgnoreCase(
                        customer.City,
                        search)

                    ||

                    ContainsIgnoreCase(
                        customer.State,
                        search)
                );
            }

            if (isActive.HasValue)
            {
                result = result.Where(
                    customer =>
                        customer.IsActive ==
                        isActive.Value);
            }

            return result.ToList();
        }


        // ========================================================
        // CUSTOMER CODE LOOKUP
        // ========================================================

        public async Task<SellerCustomer?>
            GetByCustomerCodeAsync(
                int sellerId,
                string customerCode)
        {
            return await _repository
                .GetByCustomerCodeAsync(
                    sellerId,
                    customerCode);
        }


        // ========================================================
        // COMPLETE SELLER CUSTOMER DETAILS
        // ========================================================

        public async Task<SellerCustomerWithProductsResponse?> GetCustomerWithProductsAsync(
     int sellerId,
     int customerId)
        {
            // ============================================================
            // CUSTOMER
            // ============================================================

            var customer =
                await _repository.GetCustomerAsync(
                    sellerId,
                    customerId);

            if (customer == null)
                return null;

            var customerAddresses =
                await _customerAddressRepository.GetByCustomerIdAsync(
                    customerId);


            // ============================================================
            // PRODUCTS
            // ============================================================

            var products =
                await _productRepository.GetProductsBySellerCustomerAsync(
                    sellerId,
                    customerId);

            var productIds =
                products
                    .Select(p => p.ProductId)
                    .Distinct()
                    .ToList();


            // ============================================================
            // PRODUCT RELATED DATA
            // ============================================================

            var inventories =
                await _inventoryRepository.GetBySellerCustomerAsync(
                    sellerId,
                    customerId);

            var attributes =
                await _productAttributeRepository.GetBySellerCustomerAsync(
                    sellerId,
                    customerId);

            var prices =
                await _productPriceRepository.GetBySellerCustomerAsync(
                    sellerId,
                    customerId);

            var images =
                await _productImageRepository.GetByProductIdsAsync(
                    productIds);

            var productTypes =
                await _productTypeRepository.GetBySellerCustomerAsync(
                    sellerId,
                    customerId);

            var categoryIds =
                products
                    .Where(p => p.CategoryId.HasValue)
                    .Select(p => p.CategoryId!.Value)
                    .Distinct()
                    .ToList();

            var categories =
                await _categoryRepository.GetByIdsAsync(
                    categoryIds);


            // ============================================================
            // STOCK
            // ============================================================

            var stockAdjustments =
                await _stockAdjustmentRepository.GetBySellerCustomerAsync(
                    sellerId,
                    customerId);

            var stockTransfers =
                await _stockTransferRepository.GetBySellerCustomerAsync(
                    sellerId,
                    customerId);

            var suppliers =
                await _supplierRepository.GetBySellerCustomerAsync(
                    sellerId,
                    customerId);

            var stockMovements =
                await _stockMovementRepository.GetBySellerCustomerAsync(
                    sellerId,
                    customerId);

            var stockLedgers =
                await _stockLedgerRepository.GetBySellerCustomerAsync(
                    sellerId,
                    customerId);

            var warehouses =
                await _warehouseRepository.GetBySellerCustomerAsync(
                    sellerId,
                    customerId);


            // ============================================================
            // SALES / TRANSACTIONS
            // ============================================================

            var salesOrders =
                await _salesOrderRepository.GetBySellerCustomerAsync(
                    sellerId,
                    customerId);

            var customerReturns =
                await _customerReturnRepository.GetBySellerCustomerAsync(
                    sellerId,
                    customerId);

            var deliveryChallans =
                await _deliveryChallanRepository.GetBySellerCustomerAsync(
                    sellerId,
                    customerId);

            var goodsReceiptNotes =
                await _goodsReceiptNoteRepository.GetBySellerCustomerAsync(
                    sellerId,
                    customerId);

            var goodsReceiptItems =
                await _goodsReceiptItemRepository.GetBySellerCustomerAsync(
                    sellerId,
                    customerId);

            var notifications =
                await _notificationRepository.GetBySellerCustomerAsync(
                    sellerId,
                    customerId);

            var orderStatusHistories =
                await _orderStatusHistoryRepository.GetBySellerCustomerAsync(
                    sellerId,
                    customerId);

            var payments =
                await _paymentRepository.GetBySellerCustomerAsync(
                    sellerId,
                    customerId);

            var purchaseOrders =
                await _purchaseOrderRepository.GetBySellerCustomerAsync(
                    sellerId,
                    customerId);

            var purchaseReturns =
                await _purchaseReturnRepository.GetBySellerCustomerAsync(
                    sellerId,
                    customerId);

            var reviews =
                await _reviewRepository.GetBySellerCustomerAsync(
                    sellerId,
                    customerId);

            var shipments =
                await _shipmentRepository.GetBySellerCustomerAsync(
                    sellerId,
                    customerId);

            var wishlists =
                await _wishlistRepository.GetBySellerCustomerAsync(
                    sellerId,
                    customerId);

            var wishlistItems =
                await _wishlistItemRepository.GetBySellerCustomerAsync(
                    sellerId,
                    customerId);

            var marketplaceOrders =
                await _marketplaceOrderRepository.GetBySellerCustomerAsync(
                    sellerId,
                    customerId);

            var marketplaceOrderItems =
                await _marketplaceOrderItemRepository.GetBySellerCustomerAsync(
                    sellerId,
                    customerId);

            var marketplaceReturns =
                await _marketplaceReturnRepository.GetBySellerCustomerAsync(
                    sellerId,
                    customerId);


            // ============================================================
            // PRODUCT PACKAGES
            // ============================================================

            var packages =
                productIds.Count > 0
                    ? await _context.ProductPackages
                        .Where(p =>
                            productIds.Contains(
                                p.ProductId))
                        .AsNoTracking()
                        .ToListAsync()
                    : new List<ProductPackage>();


            // ============================================================
            // ADDRESS LABELS
            // ============================================================

            var addressLabels =
                productIds.Count > 0
                    ? await _context.ProductAddressLabels
                        .Where(l =>
                            productIds.Contains(
                                l.ProductId))
                        .AsNoTracking()
                        .ToListAsync()
                    : new List<ProductAddressLabel>();


            // ============================================================
            // DELIVERY CHALLAN ITEMS
            // ============================================================

            var deliveryChallanIds = await _context.DeliveryChallans
     .Where(d => d.SellerId == sellerId && d.CustomerId == customerId)
     .Select(d => d.DeliveryChallanId)
     .ToListAsync();
            var salesOrderIds = await _context.SalesOrders
  .Where(o => o.SellerId == sellerId && o.CustomerId == customerId)
  .Select(o => o.SalesOrderId)
  .ToListAsync();

            var deliveryChallanItems = salesOrderIds.Count > 0 || deliveryChallanIds.Count > 0
               ? await _context.DeliveryChallanItems
                   .Where(dci => deliveryChallanIds.Contains(dci.DeliveryChallanId))
                   .AsNoTracking()
                   .ToListAsync()
                : new List<DeliveryChallanItem>();
            var salesOrderItems = salesOrderIds.Count > 0
   ? await _context.SalesOrderItems
       .Where(item => salesOrderIds.Contains(item.SalesOrderId))
       .AsNoTracking()
       .ToListAsync()
    : new List<SalesOrderItem>();


            // ============================================================
            // MARKETPLACES
            // ============================================================

            var marketplaces =
                await _marketplaceRepo.GetAllAsync();


            // ============================================================
            // SELLER
            // ============================================================

            var seller =
                await _context.Sellers
                    .AsNoTracking()
                    .FirstOrDefaultAsync(
                        s => s.SellerId == sellerId);


            // ============================================================
            // BRANDS
            // ============================================================

            var brandIds =
                products
                    .Where(p => p.BrandId.HasValue)
                    .Select(p => p.BrandId!.Value)
                    .Distinct()
                    .ToList();

            List<BrandEntity> brands = new();
            List<BrandModelEntity> brandModels = new();

            if (brandIds.Count > 0)
            {
                brands =
                    await _context.Brands
                        .Where(b =>
                            brandIds.Contains(
                                b.BrandId))
                        .AsNoTracking()
                        .ToListAsync();

                brandModels =
                    await _context.BrandModels
                        .Where(m =>
                            brandIds.Contains(
                                m.BrandId))
                        .AsNoTracking()
                        .ToListAsync();
            }


            // ============================================================
            // SALES ORDER ITEMS
            // ============================================================


     


            // ============================================================
            // PURCHASE ORDER ITEMS
            // ============================================================

            var purchaseOrderIds =
                purchaseOrders
                    .Select(o => o.PurchaseOrderId)
                    .ToList();

            var purchaseOrderItems =
                purchaseOrderIds.Count > 0
                    ? await _context.PurchaseOrderItems
                        .Where(i =>
                            purchaseOrderIds.Contains(
                                i.PurchaseOrderId))
                        .AsNoTracking()
                        .ToListAsync()
                    : new List<PurchaseOrderItem>();


            // ============================================================
            // SALES INVOICES
            // ============================================================

            // ============================================================
            // SALES INVOICES - FIXED
            // ============================================================
            var salesInvoices = salesOrderIds.Count > 0
               ? await _context.SalesInvoices
                   .Where(i => salesOrderIds.Contains(i.SalesOrderId)) // FIX: use SalesOrderId, not SellerId
                   .AsNoTracking()
                   .ToListAsync()
                : new List<SalesInvoice>();

            var invoiceIds =
                salesInvoices
                    .Select(i => i.SalesInvoiceId)
                    .ToList();

            var salesInvoiceItems =
                invoiceIds.Count > 0
                    ? await _context.SalesInvoiceItems
                        .Where(i =>
                            invoiceIds.Contains(
                                i.SalesInvoiceId))
                        .AsNoTracking()
                        .ToListAsync()
                    : new List<SalesInvoiceItem>();


            // ============================================================
            // WAREHOUSE LOCATIONS
            // ============================================================

            // ============================================================
            // WAREHOUSE LOCATIONS - FIXED
            // ============================================================
            var warehouseLocations = await _context.WarehouseLocations
               .Where(l => l.SellerId == sellerId && l.CustomerId == customerId) // add CustomerId
               .AsNoTracking()
               .ToListAsync();

            // ============================================================
            // SHELFWISE INVENTORIES
            // ============================================================

            var shelfwiseInventories =
                await _context.ShelfwiseInventories
                    .Where(i =>
                        i.SellerId == sellerId &&
                        i.CustomerId == customerId)
                    .AsNoTracking()
                    .ToListAsync();


            // ============================================================
            // VENDOR ITEM MASTERS
            // ============================================================

            var vendorItemMasters =
                await _context.VendorItemMasters
                    .Where(i =>
                        i.SellerId == sellerId &&
                        i.CustomerId == customerId)
                    .AsNoTracking()
                    .ToListAsync();


            // ============================================================
            // GATEPASSES
            // ============================================================

            var gatepasses =
                await _context.Gatepasses
                    .Where(g =>
                        g.SellerId == sellerId &&
                        g.CustomerId == customerId)
                    .AsNoTracking()
                    .ToListAsync();


            // ============================================================
            // PUTAWAYS
            // ============================================================

            var putaways =
                await _context.Putaways
                    .Where(p =>
                        p.SellerId == sellerId &&
                        p.CustomerId == customerId)
                    .AsNoTracking()
                    .ToListAsync();


            // ============================================================
            // REVERSE PICKUPS
            // ============================================================

            var reversePickups =
                await _context.ReversePickups
                    .Where(p =>
                        p.SellerId == sellerId &&
                        p.CustomerId == customerId)
                    .AsNoTracking()
                    .ToListAsync();


            // ============================================================
            // MARKETPLACE LISTING INVENTORIES
            // ============================================================

            var marketplaceListingInventories =
         productIds.Count > 0
             ? await _context.MarketplaceListingInventory
                 .Where(x =>
                     _context.MarketplaceListings.Any(l =>
                         l.MarketplaceListingId == x.MarketplaceListingId &&
                         productIds.Contains(l.ProductId)))
                 .AsNoTracking()
                 .ToListAsync()
             : new List<MarketplaceListingInventory>();


            // ============================================================
            // AMAZON INVENTORY SYNCS
            // ============================================================

            var amazonInventorySyncs =
                productIds.Count > 0
                    ? await _context.AmazonInventorySync
                        .Where(s =>
                            s.ProductId.HasValue &&
                            productIds.Contains(
                                s.ProductId.Value))
                        .AsNoTracking()
                        .ToListAsync()
                    : new List<AmazonInventorySync>();


            // ============================================================
            // E-INVOICES
            // ============================================================

            var eInvoices =
                await _context.EInvoices
                    .Where(i =>
                        i.SellerId == sellerId &&
                        i.CustomerId == customerId)
                    .AsNoTracking()
                    .ToListAsync();


            // ============================================================
            // E-WAY BILLS
            // ============================================================

            var eWayBills =
                await _context.EWayBills
                    .Where(e =>
                        e.SellerId == sellerId &&
                        e.CustomerId == customerId)
                    .AsNoTracking()
                    .ToListAsync();


            // ============================================================
            // BUILD MAIN RESPONSE
            // ============================================================

            var response =
                new SellerCustomerWithProductsResponse
                {
                    CustomerId =
                        customer.CustomerId,

                    SellerId =
                        customer.SellerId,

                    CustomerCode =
                        customer.CustomerCode,

                    CustomerName =
                        customer.CustomerName,

                    TradeName =
                        customer.TradeName,

                    LegalName =
                        customer.LegalName,

                    ContactPerson =
                        customer.ContactPerson,

                    Email =
                        customer.Email,

                    Phone =
                        customer.Phone,

                    GSTIN =
                        customer.GSTIN,

                    AddressLine1 =
                        customer.AddressLine1,

                    AddressLine2 =
                        customer.AddressLine2,

                    BuildingName =
                        customer.BuildingName,

                    Location =
                        customer.Location,

                    City =
                        customer.City,

                    State =
                        customer.State,

                    StateCode =
                        customer.StateCode,

                    FloorNo =
                        customer.FloorNo,

                    Country =
                        customer.Country,

                    PostalCode =
                        customer.PostalCode,

                    CreditLimit =
                        customer.CreditLimit ?? 0,

                    IsActive =
                        customer.IsActive,

                    CreatedDate =
                        customer.CreatedDate,

                    UpdatedDate =
                        customer.UpdatedDate,

                    CustomerAddresses =
                        customerAddresses
                            .Select(a =>
                                new SellerCustomerAddressResponse
                                {
                                    CustomerAddressId =
                                        a.CustomerAddressId,

                                    CustomerId =
                                        a.CustomerId,

                                    AddressType =
                                        a.AddressType,

                                    AddressLine1 =
                                        a.AddressLine1,

                                    AddressLine2 =
                                        a.AddressLine2,

                                    City =
                                        a.City,

                                    State =
                                        a.State,

                                    Country =
                                        a.Country,

                                    PostalCode =
                                        a.PostalCode,

                                    IsDefault =
                                        a.IsDefault,

                                    CreatedDate =
                                        a.CreatedDate
                                })
                            .ToList(),

                    Products =
                        products
                            .Select(product =>
                            {
                                var label =
                                    addressLabels.FirstOrDefault(
                                        l =>
                                            l.ProductId ==
                                            product.ProductId);

                                var brandName =
                                    brands
                                        .FirstOrDefault(
                                            b =>
                                                b.BrandId ==
                                                product.BrandId)
                                        ?.BrandName;

                                return new SellerCustomerProductResponse
                                {
                                    ProductId =
                                        product.ProductId,

                                    SellerId =
                                        product.SellerId,

                                    CustomerId =
                                        product.CustomerId,

                                    ProductName =
                                        product.ProductName ?? "",

                                    SKU =
                                        product.SKU ?? "",

                                    BrandId =
                                        product.BrandId,

                                    BrandName =
                                        brandName,

                                    CategoryId =
                                        product.CategoryId,

                                    ProductTypeId =
                                        product.ProductTypeId,

                                    Description =
                                        product.Description,

                                    HSNCode =
                                        product.HSNCode,

                                    Status =
                                        product.Status,

                                    IsActive =
                                        product.IsActive ?? true
                                };
                            })
                            .ToList()
                };


            // ============================================================
            // TRANSACTIONS
            // ============================================================

            response.Transactions =
      new SellerCustomerTransactionResponse
      {
          // ============================================================
          // CUSTOMER / SELLER
          // ============================================================

          CustomerId = customerId,
          SellerId = sellerId,


          // ============================================================
          // CUSTOMER RETURNS
          // ============================================================

          CustomerReturns =
              customerReturns
                  .Select(x =>
                      new SellerCustomerCustomerReturnResponse
                      {
                          CustomerReturnId = x.CustomerReturnId,

                          SellerId = x.SellerId,
                          CustomerId = x.CustomerId,

                          SalesInvoiceId = x.SalesInvoiceId,
                          ProductId = x.ProductId,

                          ReturnNumber = x.ReturnNumber,
                          ReturnDate = x.ReturnDate,

                          Quantity = x.Quantity,
                          ReturnAmount = x.ReturnAmount,

                          Reason = x.Reason,
                          Status = x.Status,

                          CreatedDate = x.CreatedDate
                      })
                  .ToList(),


          // ============================================================
          // DELIVERY CHALLANS
          // ============================================================

          DeliveryChallans =
              deliveryChallans
                  .Select(x =>
                      new SellerCustomerDeliveryChallanResponse
                      {
                          DeliveryChallanId = x.DeliveryChallanId,

                          SellerId = x.SellerId,
                          CustomerId = x.CustomerId,

                          ChallanNumber = x.ChallanNumber,
                          ChallanDate = x.ChallanDate,

                          VehicleNumber = x.VehicleNumber,
                          DriverName = x.DriverName,
                          DriverMobile = x.DriverMobile,

                          TransporterName = x.TransporterName,

                          SalesOrderId = x.SalesOrderId,

                          Status = x.Status,

                          DeliveryAddress = null,

                          Remarks = x.Remarks,

                          CreatedDate = x.CreatedDate,
                          UpdatedDate = null
                      })
                  .ToList(),


          // ============================================================
          // GOODS RECEIPT ITEMS
          // ============================================================

          GoodsReceiptItems =
              goodsReceiptItems
                  .Select(x =>
                      new SellerCustomerGoodsReceiptItemResponse
                      {
                          GoodsReceiptItemId =
                              x.GoodsReceiptItemId,

                          ProductId =
                              x.ProductId,

                          ReceivedQuantity =
                              x.ReceivedQuantity,

                          GoodsReceiptNoteId =
                              x.GoodsReceiptNoteId,

                          SellerId =
                              x.SellerId,

                          CustomerId =
                              x.CustomerId,

                          Quantity =
                              x.ReceivedQuantity,

                          AcceptedQuantity =
                              x.AcceptedQuantity,

                          RejectedQuantity =
                              x.RejectedQuantity,

                          Remarks =
                              x.Remarks,

                          CreatedDate = null
                      })
                  .ToList(),


          // ============================================================
          // GOODS RECEIPT NOTES
          // ============================================================

          GoodsReceiptNotes =
              goodsReceiptNotes
                  .Select(x =>
                      new SellerCustomerGoodsReceiptNoteResponse
                      {
                          GoodsReceiptNoteId =
                              x.GoodsReceiptNoteId,

                          SellerId =
                              x.SellerId,

                          CustomerId =
                              x.CustomerId,

                          PurchaseOrderId =
                              x.PurchaseOrderId,

                          PurchaseOrderNumber =
                              x.PurchaseOrderNumber,

                          GRNNumber =
                              x.GRNNumber,

                          ReceiptDate =
                              x.ReceiptDate,

                          Status =
                              x.Status,

                          GRNStatus =
                              x.GRNStatus,

                          Remarks =
                              x.Remarks,

                          WarehouseId =
                              x.WarehouseId,

                          WarehouseCode =
                              x.WarehouseCode,

                          FacilityCode =
                              x.FacilityCode,

                          LocationCode =
                              x.LocationCode,

                          VendorCode =
                              x.VendorCode,

                          VendorName =
                              x.VendorName,

                          TotalQuantity =
                              x.TotalQuantity,

                          ReceivedQuantity =
                              x.ReceivedQuantity,

                          AcceptedQuantity =
                              x.AcceptedQuantity,

                          RejectedQuantity =
                              x.RejectedQuantity,

                          TotalAmount =
                              x.TotalAmount,

                          IsQCRequired =
                              x.IsQCRequired,

                          IsQCDone =
                              x.IsQCDone,

                          CreatedDate =
                              x.CreatedDate,

                          UpdatedDate =
                              x.UpdatedDate,

                          CreatedBy =
                              x.CreatedBy
                      })
                  .ToList(),


          // ============================================================
          // NOTIFICATIONS
          // ============================================================

          Notifications =
              notifications
                  .Select(x =>
                      new SellerCustomerNotificationResponse
                      {
                          NotificationId =
                              x.NotificationId,

                          SellerId =
                              x.SellerId,

                          CustomerId =
                              x.CustomerId ?? 0,

                          NotificationType = null,

                          Title =
                              x.Title,

                          Message =
                              x.Message,

                          IsRead =
                              x.IsRead,

                          ReadDate = null,

                          CreatedDate =
                              x.CreatedDate
                      })
                  .ToList(),


          // ============================================================
          // ORDER STATUS HISTORY
          // ============================================================

          OrderStatusHistories =
              orderStatusHistories
                  .Select(x =>
                      new SellerCustomerOrderStatusHistoryResponse
                      {
                          OrderStatusHistoryId =
                              x.OrderStatusHistoryId,

                          SellerId =
                              x.SellerId,

                          CustomerId =
                              x.CustomerId,

                          OrderId =
                              x.OrderId,

                          Status =
                              x.Status,

                          ChangedOn =
                              x.ChangedOn,

                          SalesOrderId = null,

                          PreviousStatus = null,
                          NewStatus = null,

                          Remarks =
                              x.Remarks,

                          StatusDate =
                              x.ChangedOn,

                          CreatedDate =
                              x.Timestamp
                      })
                  .ToList(),


          // ============================================================
          // PAYMENTS
          // ============================================================

          Payments =
              payments
                  .Select(x =>
                      new SellerCustomerPaymentResponse
                      {
                          PaymentId =
                              x.PaymentId,

                          SellerId =
                              x.SellerId,

                          CustomerId =
                              x.CustomerId,

                          SalesOrderId = null,
                          SalesInvoiceId = null,

                          Amount =
                              x.Amount ?? 0m,

                          OrderId =
                              x.OrderId,

                          TransactionId =
                              x.TransactionId,

                          PaymentMethod =
                              x.PaymentMethod,

                          PaymentStatus =
                              x.PaymentStatus,

                          PaymentDate =
                              x.PaymentDate,

                          TransactionReference = null,
                          Remarks = null,

                          CreatedDate = null,

                          UpdatedDate =
                              x.UpdatedDate
                      })
                  .ToList(),


          // ============================================================
          // PURCHASE ORDERS
          // ============================================================

          PurchaseOrders =
              purchaseOrders
                  .Select(x =>
                      new SellerCustomerPurchaseOrderResponse
                      {
                          PurchaseOrderId =
                              x.PurchaseOrderId,

                          SellerId =
                              x.SellerId,

                          CustomerId =
                              x.CustomerId,

                          SupplierId =
                              x.SupplierId,

                          WarehouseId =
                              x.WarehouseId,

                          OrderNumber =
                              x.PurchaseOrderNumber,

                          PurchaseOrderNumber =
                              x.PurchaseOrderNumber,

                          PurchaseOrderCode =
                              x.PurchaseOrderCode,

                          OrderDate =
                              x.OrderDate,

                          ExpectedDeliveryDate =
                              x.ExpectedDeliveryDate,

                          ReceiptDate =
                              x.ReceiptDate,

                          Status =
                              x.Status,

                          POStatus =
                              x.POStatus,

                          ApprovalStatus =
                              x.ApprovalStatus,

                          TotalAmount =
                              x.TotalAmount,

                          SubTotal =
                              x.SubTotal,

                          TaxAmount =
                              x.TaxAmount,

                          Currency =
                              x.CurrencyCode,

                          CurrencyCode =
                              x.CurrencyCode,

                          Remarks =
                              x.Remarks,

                          FacilityCode =
                              x.FacilityCode,

                          VendorCode =
                              x.VendorCode,

                          VendorName =
                              x.VendorName,

                          ChannelCode =
                              x.ChannelCode,

                          TotalQuantity =
                              x.TotalQuantity,

                          ReceivedQuantity =
                              x.ReceivedQuantity,

                          PendingQuantity =
                              x.PendingQuantity,

                          CreatedDate =
                              x.CreatedDate,

                          UpdatedDate =
                              x.UpdatedDate,

                          CreatedBy =
                              x.CreatedBy
                      })
                  .ToList(),


          // ============================================================
          // PURCHASE ORDER ITEMS
          // ============================================================

          PurchaseOrderItems =
              purchaseOrderItems
                  .Select(x =>
                      new SellerCustomerPurchaseOrderItemResponse
                      {
                          PurchaseOrderItemId =
                              x.PurchaseOrderItemId,

                          PurchaseOrderId =
                              x.PurchaseOrderId,

                          SellerId =
                              x.SellerId,

                          CustomerId =
                              x.CustomerId,

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
                              x.TotalAmount,

                          Remarks = null,

                          CreatedDate = null
                      })
                  .ToList(),


          // ============================================================
          // PURCHASE RETURNS
          // ============================================================

          PurchaseReturns =
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
                              x.TotalAmount ?? 0m,

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
                  .ToList(),


          // ============================================================
          // REVIEWS
          // ============================================================

          Reviews =
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

                          SalesOrderId = null,

                          Rating =
                              x.Rating,

                          ReviewText =
                              x.ReviewText,

                          IsApproved =
                              string.Equals(
                                  x.Status,
                                  "APPROVED",
                                  StringComparison.OrdinalIgnoreCase),

                          ReviewDate =
                              x.CreatedDate,

                          CreatedDate =
                              x.CreatedDate,

                          UpdatedDate = null
                      })
                  .ToList(),


          // ============================================================
          // SALES ORDERS
          // ============================================================

          SalesOrders =
              salesOrders
                  .Select(x =>
                      new SellerCustomerSalesOrderResponse
                      {
                          SalesOrderId =
                              x.SalesOrderId,

                          SellerId =
                              x.SellerId,

                          CustomerId =
                              x.CustomerId,

                          SalesOrderNumber =
                              x.SalesOrderNumber ?? string.Empty,


                          // ------------------------------------------------
                          // UNIWARE / CHANNEL
                          // ------------------------------------------------

                          SalesOrderCode =
                              x.SalesOrderCode,

                          DisplayOrderCode =
                              x.DisplayOrderCode,

                          ChannelCode =
                              x.ChannelCode,

                          FacilityCode =
                              x.FacilityCode,

                          UniwareFacilityCode =
                              x.UniwareFacilityCode,

                          CustomerCode =
                              x.CustomerCode,

                          CustomerName =
                              x.CustomerName,

                          OrderType =
                              x.Type,

                          CurrencyCode =
                              x.CurrencyCode,


                          // ------------------------------------------------
                          // DATES / STATUS
                          // ------------------------------------------------

                          OrderDate =
                              x.OrderDate ?? DateTime.UtcNow,

                          ChannelCreatedDate =
                              x.ChannelCreatedDate,

                          ExpectedDeliveryDate =
                              x.ExpectedDeliveryDate,

                          Status =
                              x.Status ?? string.Empty,

                          StatusCode =
                              x.StatusCode,

                          FulfillmentStatus =
                              x.FulfillmentStatus,


                          // ------------------------------------------------
                          // FINANCIAL
                          // ------------------------------------------------

                          TotalAmount =
                              x.TotalAmount ?? 0m,

                          SubTotal =
                              x.SubTotal,

                          TaxAmount =
                              x.TaxAmount,

                          DiscountAmount =
                              x.DiscountAmount,

                          ShippingCharges =
                              x.ShippingCharges,

                          CodAmount =
                              x.CodAmount,

                          TotalQuantity =
                              x.TotalQuantity,

                          TotalItems =
                              x.TotalItems,


                          // ------------------------------------------------
                          // GENERAL
                          // ------------------------------------------------

                          Remarks =
                              x.Remarks,

                          CreatedDate =
                              x.CreatedDate ?? DateTime.UtcNow,

                          UpdatedDate =
                              x.UpdatedDate,


                          // ------------------------------------------------
                          // ADDRESS
                          // ------------------------------------------------

                          ShippingAddress =
                              x.ShippingAddress,

                          BillingAddress =
                              x.BillingAddress,

                          StateCode =
                              x.StateCode,

                          CountryCode =
                              x.CountryCode,


                          // ------------------------------------------------
                          // TOPAZ - COMPANY
                          // ------------------------------------------------

                          Company_Name =
                              x.Company_Name,

                          Company_Address =
                              x.Company_Address,

                          Company_City =
                              x.Company_City,

                          Company_State =
                              x.Company_State,

                          Company_PINCode =
                              x.Company_PINCode,

                          Phone_no =
                              x.Phone_no,

                          Email_Address =
                              x.Email_Address,

                          gstin =
                              x.GSTIN,

                          Company_PAN = null,
                          Company_CIN = null,


                          // ------------------------------------------------
                          // TOPAZ - ORDER / DELIVERY
                          // ------------------------------------------------

                          SupplierRef =
                              x.SupplierRef,

                          BuyersOrderNo =
                              x.BuyersOrderNo,

                          BuyersOrderDate =
                              x.BuyersOrderDate,

                          DespatchedThrough =
                              x.DespatchedThrough,

                          Destination =
                              x.Destination,

                          TermsOfDelivery =
                              x.TermsOfDelivery,

                          RoundOff =
                              x.RoundOff,

                          TotalInWords =
                              x.TotalInWords,

                          DeliveryNote =
                              x.DeliveryNote,

                          ModeorTermsOfPayment =
                              x.ModeorTermsOfPayment,

                          OtherReferences =
                              x.OtherReferences,

                          DespatchedDocumentNumber =
                              x.DespatchedDocumentNumber,

                          DeliveryNoteDate =
                              x.DeliveryNoteDate,

                          EWayBillNumber =
                              x.EWayBillNumber,

                          VehicleNo =
                              x.VehicleNo,

                          Distance =
                              x.Distance,

                          TYear =
                              x.TYear,

                          Transport =
                              x.Transport,

                          TransporterName =
                              x.TransporterName,

                          TransporterID =
                              x.TransporterID,

                          TransporterDocNo =
                              x.TransporterDocNo,

                          TransportMode =
                              x.TransportMode,


                          // ------------------------------------------------
                          // IDS
                          // ------------------------------------------------

                          Pid =
                              x.Pid,

                          KeyID =
                              x.KeyID,


                          // ------------------------------------------------
                          // SALES ORDER ITEMS
                          // ------------------------------------------------

                          Items =
                              x.SaleOrderItems
                                  .Select(item =>
                                      new SellerCustomerSalesOrderItemResponse
                                      {
                                          SalesOrderItemId =
                                              item.SalesOrderItemId,

                                          SalesOrderId =
                                              item.SalesOrderId,

                                          ProductId =
                                              item.ProductId,

                                          Sku =
                                              item.Sku,

                                          ChannelSkuCode =
                                              item.ChannelSkuCode,

                                          ChannelProductId =
                                              item.ChannelProductId,

                                          VendorSkuCode =
                                              item.VendorSkuCode,

                                          ChannelProductName =
                                              item.ChannelProductName,

                                          FacilityCode =
                                              item.FacilityCode,

                                          Status =
                                              item.Status,

                                          FulfillmentStatus =
                                              item.FulfillmentStatus,

                                          Mrp =
                                              item.Mrp,

                                          SellingPrice =
                                              item.SellingPrice,

                                          ChannelSaleOrderItemCode =
                                              item.ChannelSaleOrderItemCode,

                                          PacketNumber =
                                              item.PacketNumber,

                                          ItemTypeCode = null,

                                          ProductName =
                                              item.ProductName,

                                          DisplayName =
                                              item.DisplayName,

                                          WarehouseId = null,

                                          TransferPrice = null,

                                          Weight = null,

                                          Quantity =
                                              item.Quantity,

                                          UnitPrice =
                                              item.UnitPrice,

                                          Discount =
                                              item.Discount,

                                          DiscountPer =
                                              (item.Quantity *
                                               item.UnitPrice) > 0
                                                  ? (item.Discount /
                                                     (item.Quantity *
                                                      item.UnitPrice)) * 100
                                                  : 0,

                                          TaxAmount =
                                              item.TaxAmount,

                                          TotalAmount =
                                              item.TotalAmount,

                                          SubTotal =
                                              item.SubTotal,

                                          Description =
                                              item.Description,

                                          Uom =
                                              item.Uom,

                                          Hsncode =
                                              item.Hsncode,

                                          GstPer =
                                              item.GstPer,

                                          SgstPer =
                                              item.SgstPer,

                                          SgstAmount =
                                              item.SgstAmount,

                                          CgstPer =
                                              item.CgstPer,

                                          CgstAmount =
                                              item.CgstAmount,

                                          IgstPer =
                                              item.IgstPer,

                                          IgstAmount =
                                              item.IgstAmount,

                                          CessPer = null,
                                          CessAmount = null,

                                          AfterGSTAmount =
                                              item.AfterGSTAmount,

                                          QuantityAmount =
                                              item.QuantityAmount,

                                          TotalRateBeforeDiscount =
                                              item.TotalRateBeforeDiscount,

                                          Rate =
                                              item.UnitPrice,

                                          TaxType =
                                              item.TaxType,

                                          BrandXID =
                                              item.BrandXID,

                                          Remarks =
                                              item.Remarks,

                                          Pid =
                                              item.Pid,

                                          InvoiceXID =
                                              item.InvoiceXID,

                                          ItemXID =
                                              item.ItemXID,

                                          BatchNo = null,

                                          ExpiryDate =
                                              item.ExpDate
                                      })
                                  .ToList()
                      })
                  .ToList(),


          // ============================================================
          // SALES ORDER ITEMS - FLAT COLLECTION
          // ============================================================
          // This is the important addition.
          // It uses the separately queried salesOrderItems list.
          // ============================================================

          SalesOrderItems =
              salesOrderItems
                  .Select(item =>
                      new SellerCustomerSalesOrderItemResponse
                      {
                          SalesOrderItemId =
                              item.SalesOrderItemId,

                          SalesOrderId =
                              item.SalesOrderId,

                          ProductId =
                              item.ProductId,

                          Sku =
                              item.Sku,

                          ChannelSkuCode =
                              item.ChannelSkuCode,

                          ChannelProductId =
                              item.ChannelProductId,

                          VendorSkuCode =
                              item.VendorSkuCode,

                          ChannelProductName =
                              item.ChannelProductName,

                          FacilityCode =
                              item.FacilityCode,

                          Status =
                              item.Status,

                          FulfillmentStatus =
                              item.FulfillmentStatus,

                          Mrp =
                              item.Mrp,

                          SellingPrice =
                              item.SellingPrice,

                          ChannelSaleOrderItemCode =
                              item.ChannelSaleOrderItemCode,

                          PacketNumber =
                              item.PacketNumber,

                          ItemTypeCode = null,

                          ProductName =
                              item.ProductName,

                          DisplayName =
                              item.DisplayName,

                          WarehouseId = null,

                          TransferPrice = null,

                          Weight = null,

                          Quantity =
                              item.Quantity,

                          UnitPrice =
                              item.UnitPrice,

                          Discount =
                              item.Discount,

                          DiscountPer =
                              (item.Quantity *
                               item.UnitPrice) > 0
                                  ? (item.Discount /
                                     (item.Quantity *
                                      item.UnitPrice)) * 100
                                  : 0,

                          TaxAmount =
                              item.TaxAmount,

                          TotalAmount =
                              item.TotalAmount,

                          SubTotal =
                              item.SubTotal,

                          Description =
                              item.Description,

                          Uom =
                              item.Uom,

                          Hsncode =
                              item.Hsncode,

                          GstPer =
                              item.GstPer,

                          SgstPer =
                              item.SgstPer,

                          SgstAmount =
                              item.SgstAmount,

                          CgstPer =
                              item.CgstPer,

                          CgstAmount =
                              item.CgstAmount,

                          IgstPer =
                              item.IgstPer,

                          IgstAmount =
                              item.IgstAmount,

                          CessPer = null,
                          CessAmount = null,

                          AfterGSTAmount =
                              item.AfterGSTAmount,

                          QuantityAmount =
                              item.QuantityAmount,

                          TotalRateBeforeDiscount =
                              item.TotalRateBeforeDiscount,

                          Rate =
                              item.UnitPrice,

                          TaxType =
                              item.TaxType,

                          BrandXID =
                              item.BrandXID,

                          Remarks =
                              item.Remarks,

                          Pid =
                              item.Pid,

                          InvoiceXID =
                              item.InvoiceXID,

                          ItemXID =
                              item.ItemXID,

                          BatchNo = null,

                          ExpiryDate =
                              item.ExpDate
                      })
                  .ToList(),

          SalesInvoices =
    salesInvoices
        .Select(x =>
            new SellerCustomerSalesInvoiceResponse
            {
                SalesInvoiceId = x.SalesInvoiceId,

                SellerId = x.SellerId,
                CustomerId = x.CustomerId,

                SalesOrderId = x.SalesOrderId,

                InvoiceNumber =
                    x.InvoiceNumber ?? string.Empty,

                InvoiceDate =
                    x.InvoiceDate,

                // These are decimal, not decimal?
                SubTotal =
                    x.SubTotal,

                DiscountAmount =
                    x.DiscountAmount,

                TaxAmount =
                    x.TaxAmount,

                TotalAmount =
                    x.TotalAmount,

                PaidAmount =
                    x.PaidAmount,

                BalanceAmount =
                    x.BalanceAmount,

                PaymentStatus =
                    x.PaymentStatus,

                Status =
                    x.Status,

                Remarks =
                    x.Remarks,

                CreatedDate =
                    x.CreatedDate,

                UpdatedDate =
                    x.UpdatedDate,

                // Items will be populated separately
                Items = new List<SellerCustomerSalesInvoiceItemResponse>()
            })
        .ToList(),

          // ============================================================
          // SHIPMENTS
          // ============================================================

          Shipments =
              shipments
                  .Select(x =>
                      new SellerCustomerShipmentResponse
                      {
                          ShipmentId =
                              x.ShipmentId,

                          SellerId =
                              x.SellerId,

                          CustomerId =
                              x.CustomerId,

                          SalesOrderId =
                              x.SalesOrderId,

                          DeliveryChallanId =
                              x.DeliveryChallanId,

                          ShipmentNumber =
                              x.ShipmentNumber,

                          ReturnDate =
                              x.ReturnDate,

                          OrderId =
                              x.OrderId,

                          CourierName =
                              x.CourierName,

                          TrackingNumber =
                              x.TrackingNumber,

                          ShipmentDate =
                              x.ShipmentDate,

                          DeliveryDate =
                              x.DeliveryDate,

                          ShipmentStatus =
                              x.ShipmentStatus,

                          CarrierName = null,

                          Status =
                              x.Status,

                          ExpectedDeliveryDate =
                              x.ExpectedDeliveryDate,

                          ActualDeliveryDate =
                              x.ActualDeliveryDate,

                          SalesOrderNumber =
                              x.SalesOrderNumber,

                          DisplayOrderCode =
                              x.DisplayOrderCode,

                          ShippingPackageCode =
                              x.ShippingPackageCode,

                          ShippingPackageNumber =
                              x.ShippingPackageNumber,

                          ChannelCode =
                              x.ChannelCode,

                          FacilityCode =
                              x.FacilityCode,

                          UniwareFacilityCode =
                              x.UniwareFacilityCode,

                          CourierCode =
                              x.CourierCode,

                          ShippingMethodCode =
                              x.ShippingMethodCode,

                          AwbNumber =
                              x.AwbNumber,

                          CourierTrackingUrl =
                              x.CourierTrackingUrl,

                          ShippingLabelUrl =
                              x.ShippingLabelUrl,

                          InvoiceUrl =
                              x.InvoiceUrl,

                          IsCod =
                              x.IsCod,

                          CodAmount =
                              x.CodAmount,

                          ShippingPackageStatus =
                              x.ShippingPackageStatus,

                          Length =
                              x.Length,

                          Width =
                              x.Width,

                          Height =
                              x.Height,

                          Weight =
                              x.Weight,

                          DimUnit =
                              x.DimUnit,

                          WeightUnit =
                              x.WeightUnit,

                          IsShipped =
                              x.IsShipped,

                          IsDelivered =
                              x.IsDelivered,

                          ShippingAddress =
                              x.ShippingAddress,

                          CreatedDate =
                              x.CreatedDate,

                          UpdatedDate =
                              x.UpdatedDate,

                          VehicleNo =
                              x.VehicleNo,

                          TransporterName =
                              x.TransporterName,

                          TransporterID =
                              x.TransporterID,

                          TransporterDocNo =
                              x.TransporterDocNo,

                          TransportMode =
                              x.TransportMode,

                          Distance =
                              x.Distance,

                          EWayBillNumber =
                              x.EWayBillNumber,

                          ShippingCharges =
                              x.ShippingCharges,

                          TotalAmount =
                              x.TotalAmount,

                          CourierStatus =
                              x.CourierStatus,

                          StatusRemarks =
                              x.StatusRemarks,

                          CreatedBy =
                              x.CreatedBy,

                          UpdatedBy =
                              x.UpdatedBy
                      })
                  .ToList(),


          // ============================================================
          // WISHLISTS
          // ============================================================

          Wishlists =
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

                          WishlistName =
                              x.WishlistName,

                          IsActive =
                              x.IsActive,

                          CreatedDate =
                              x.CreatedDate,

                          UpdatedDate =
                              x.UpdatedDate
                      })
                  .ToList(),


          // ============================================================
          // WISHLIST ITEMS
          // ============================================================

          WishlistItems =
              wishlistItems
                  .Select(x =>
                      new SellerCustomerWishlistItemResponse
                      {
                          WishlistItemId =
                              x.WishlistItemId,

                          WishlistId =
                              x.WishlistId,

                          SellerId =
                              x.SellerId,

                          CustomerId =
                              x.CustomerId,

                          ProductId =
                              x.ProductId,

                          AddedDate = null,

                          CreatedDate =
                              x.CreatedDate
                      })
                  .ToList(),


          // ============================================================
          // MARKETPLACE ORDERS
          // ============================================================

          MarketplaceOrders =
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
                  .ToList(),


          // ============================================================
          // MARKETPLACE ORDER ITEMS
          // ============================================================

          MarketplaceOrderItems =
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
                  .ToList(),


          // ============================================================
          // MARKETPLACE RETURNS
          // ============================================================

          MarketplaceReturns =
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
                  .ToList()
      };


            // ============================================================
            // INVENTORIES
            // ============================================================
            response.Inventories =
      inventories
          .Select(x =>
              new SellerCustomerInventoryResponse
              {
                  ProductInventoryId = x.ProductInventoryId,

                  SellerId = x.SellerId,

                  CustomerId = x.CustomerId,

                  ProductId = x.ProductId,

                  WarehouseId = x.WarehouseId,

                  LocationId = x.LocationId,

                  Quantity = x.Quantity ?? 0m,

                  ReservedQuantity = x.ReservedQuantity ?? 0m,

                  DamagedQuantity = x.DamagedQuantity ?? 0m,

                  ReorderLevel = x.ReorderLevel ?? 0m,

                  ReorderQuantity = x.ReorderQuantity ?? 0m,

                  LastStockUpdate = x.LastStockUpdate,

                  CreatedDate = x.CreatedDate,

                  UpdatedDate = x.UpdatedDate,

                  SKU = x.SKU,

                  Barcode = x.Barcode,

                  WarehouseCode = x.WarehouseCode,

                  FacilityCode = x.FacilityCode,

                  UniwareFacilityCode = x.UniwareFacilityCode,

                  IsFacilityCodeMatch = x.IsFacilityCodeMatch,

                  ChannelCode = x.ChannelCode,

                  UniwareChannelCode = x.UniwareChannelCode,

                  IsChannelCodeMatch = x.IsChannelCodeMatch,

                  LocationCode = x.LocationCode,

                  LocationName = x.LocationName,

                  BatchId = x.BatchId,

                  ChannelPrice = x.ChannelPrice,

                  IsBulkUpload = x.IsBulkUpload ?? false,

                  BulkStatus = x.BulkStatus,

                  AdjustmentType = x.AdjustmentType,

                  AdjustmentQuantity = x.AdjustmentQuantity,

                  SellableQuantity = x.SellableQuantity,

                  Inventory = x.Inventory,

                  ChannelInventory = x.ChannelInventory,

                  ProductName = x.ProductName,

                  IsSyncedToUniware = x.IsSyncedToUniware,

                  UniwareSyncDate = x.UniwareSyncDate,

                  UniwareItemCode = null
              })
          .ToList();

            // ============================================================
            // PRICES
            // ============================================================
            response.Prices =
     prices
         .Select(x =>
             new SellerCustomerPriceResponse
             {
                 ProductPriceId = x.ProductPriceId,

                 ProductId = x.ProductId,

                 SellerId = x.SellerId,

                 CustomerId = x.CustomerId,

                 PriceType = x.PriceType,

                 Price = x.Price,

                 Currency = x.Currency,

                 EffectiveFrom = x.EffectiveFrom,

                 EffectiveTo = x.EffectiveTo,

                 IsActive = x.IsActive,

                 CreatedDate = x.CreatedDate,

                 UpdatedDate = x.UpdatedDate,

                 Mrp = x.Mrp,

                 NotionalValueAmount = x.NotionalValueAmount,

                 NotionalValueCurrency = x.NotionalValueCurrency,

                 Sku = x.SKU,

                 Barcode = x.Barcode,

                 WarehouseCode = x.WarehouseCode,

                 FacilityCode = x.FacilityCode,

                 UniwareFacilityCode = x.UniwareFacilityCode,

                 ChannelCode = x.ChannelCode,

                 UniwareChannelCode = x.UniwareChannelCode,

                 ChannelPrice = x.ChannelPrice,

                 BatchId = x.BatchId,

                 WarehouseId = x.WarehouseId,

                 IsFacilityCodeMatch = x.IsFacilityCodeMatch,

                 IsChannelCodeMatch = x.IsChannelCodeMatch,

                 FacilityCodeForUniware = null,

                 ChannelCodeForUniware = null
             })
         .ToList();


            // ============================================================
            // PRODUCT TYPES
            // ============================================================

            response.ProductTypes =
     productTypes
         .Select(x =>
             new SellerCustomerProductTypeResponse
             {
                 ProductTypeId = x.ProductTypeId,

                 SellerId = x.SellerId,

                 CustomerId = x.CustomerId,

                 ProductTypeName = x.ProductTypeName,

                 Description = x.Description,

                 IsActive = x.IsActive,

                 CreatedDate = x.CreatedDate,

                 UpdatedDate = x.UpdatedDate,

                 ProductTypeCode = x.ProductTypeCode,

                 CategoryId = x.CategoryId,

                 CategoryName = x.CategoryName,

                 HSNCode = x.HSNCode,

                 GSTPercentage = x.GSTPercentage,

                 IsSystemDefined = x.IsSystemDefined,

                 DisplayOrder = x.DisplayOrder,

                 ImageUrl = x.ImageUrl,

                 IconUrl = x.IconUrl,

                 CreatedBy = x.CreatedBy
             })
         .ToList();


            // ============================================================
            // CATEGORIES
            // ============================================================
            response.Categories =
         categories
             .Select(x =>
                 new SellerCustomerCategoryResponse
                 {
                     CategoryId = x.CategoryId,

                     CategoryName = x.CategoryName,

                     ParentCategoryId = x.ParentCategoryId,

                     Description = x.Description,

                     IsActive = x.IsActive,

                     CreatedDate = x.CreatedDate,

                     UpdatedDate = x.UpdatedDate,

                     SellerId = x.SellerId ?? 0,

                     CustomerId = x.CustomerId ?? 0,

                     CategoryCode = x.CategoryCode,

                     ParentCategoryName = x.ParentCategoryName,

                     Level = x.Level,

                     HSNCode = x.HSNCode,

                     GSTPercentage = x.GSTPercentage,

                     IsSystemDefined = x.IsSystemDefined,

                     DisplayOrder = x.DisplayOrder,

                     ImageUrl = x.ImageUrl,

                     IconUrl = x.IconUrl,

                     BannerUrl = x.BannerUrl,

                     MetaTitle = x.MetaTitle,

                     MetaDescription = x.MetaDescription,

                     CreatedBy = x.CreatedBy
                 })
             .ToList();


            // ============================================================
            // IMAGES
            // ============================================================

            response.Images =
      images
          .Select(x =>
              new SellerCustomerImageResponse
              {
                  ProductImageId = x.ProductImageId,

                  SellerId = x.SellerId,
                  CustomerId = x.CustomerId,

                  ProductId = x.ProductId,

                  ImageUrl = x.ImageUrl,

                  DisplayOrder = x.DisplayOrder,

                  IsPrimary = x.IsPrimary,

                  CreatedDate = x.CreatedDate
              })
          .ToList();


            // ============================================================
            // ATTRIBUTES
            // ============================================================
            response.Attributes =
                attributes
                    .Select(x =>
                        new SellerCustomerAttributeResponse
                        {
                            ProductAttributeId = x.ProductAttributeId,

                            ProductId = x.ProductId,

                            SellerId = x.SellerId,

                            CustomerId = x.CustomerId,

                            AttributeName = x.AttributeName,

                            AttributeValue = x.AttributeValue,

                            CreatedDate = x.CreatedDate
                        })
                    .ToList();


            // ============================================================
            // STOCK MOVEMENTS
            // ============================================================

            response.StockMovements =
             stockMovements
                 .Select(x =>
                     new SellerCustomerStockMovementResponse
                     {
                         StockMovementId = x.StockMovementId,

                         SellerId = x.SellerId,
                         CustomerId = x.CustomerId,

                         ProductId = x.ProductId,
                         WarehouseId = x.WarehouseId,

                         MovementType = x.MovementType,

                         Quantity = x.Quantity ?? 0m,

                         ReferenceTable = x.ReferenceTable,
                         ReferenceId = x.ReferenceId,

                         MovementDate = x.MovementDate,

                         Remarks = x.Remarks
                     })
                 .ToList();


            // ============================================================
            // STOCK LEDGERS
            // ============================================================

            response.StockLedgers =
               stockLedgers
                   .Select(x =>
                       new SellerCustomerStockLedgerResponse
                       {
                           StockLedgerId = x.StockLedgerId,

                           SellerId = x.SellerId,
                           CustomerId = x.CustomerId,

                           ProductId = x.ProductId,
                           WarehouseId = x.WarehouseId,

                           TransactionType = x.TransactionType,

                           ReferenceNumber = x.ReferenceNumber,

                           Quantity = x.Quantity,

                           BalanceQuantity = x.BalanceQuantity,

                           Remarks = x.Remarks,

                           TransactionDate = x.TransactionDate,

                           CreatedDate = x.CreatedDate
                       })
                   .ToList();


            // ============================================================
            // WAREHOUSES
            // ============================================================

            response.Warehouses =
    warehouses
        .Select(x =>
            new SellerCustomerWarehouseResponse
            {
                WarehouseId = x.WarehouseId,
                SellerId = x.SellerId,
                CustomerId = x.CustomerId,

                WarehouseCode = x.WarehouseCode,
                FacilityCode = x.FacilityCode,
                UniwareFacilityCode = x.UniwareFacilityCode,
                WarehouseName = x.WarehouseName,
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
            })
        .ToList();


            // ============================================================
            // WAREHOUSE LOCATIONS
            // ============================================================
            response.WarehouseLocations =
                warehouseLocations
                    .Select(x =>
                        new SellerCustomerWarehouseLocationResponse
                        {
                            LocationId = x.LocationId,
                            CustomerId = x.CustomerId,
                            WarehouseId = x.WarehouseId,
                            LocationCode = x.LocationCode,
                            LocationName = x.LocationName,
                            Description = x.Description,
                            IsActive = x.IsActive,
                            CreatedDate = x.CreatedDate,
                            ListingStatus = x.ListingStatus,
                            FulfillmentProfile = x.FulfillmentProfile
                        })
                    .ToList();


            // ============================================================
            // STOCK ADJUSTMENTS
            // ============================================================

            response.StockAdjustments =
      stockAdjustments
          .Select(x =>
              new SellerCustomerStockAdjustmentResponse
              {
                  StockAdjustmentId = x.StockAdjustmentId,
                  SellerId = x.SellerId,
                  CustomerId = x.CustomerId,
                  ProductId = x.ProductId,
                  WarehouseId = x.WarehouseId,
                  Quantity = x.Quantity,
                  AdjustmentType = x.AdjustmentType,
                  Reason = x.Reason,
                  AdjustedBy = x.AdjustedBy,
                  AdjustmentDate = x.AdjustmentDate,
                  CreatedDate = x.CreatedDate
              })
          .ToList();


            // ============================================================
            // STOCK TRANSFERS
            // ============================================================

            response.StockTransfers =
           stockTransfers
               .Select(x =>
                   new SellerCustomerStockTransferResponse
                   {
                       StockTransferId = x.StockTransferId,
                       SellerId = x.SellerId,
                       CustomerId = x.CustomerId,
                       ProductId = x.ProductId,
                       FromWarehouseId = x.FromWarehouseId,
                       ToWarehouseId = x.ToWarehouseId,
                       Quantity = x.Quantity,
                       TransferDate = x.TransferDate,
                       Status = x.Status,
                       Remarks = x.Remarks,
                       CreatedDate = x.CreatedDate
                   })
               .ToList();


            // ============================================================
            // SUPPLIERS
            // ============================================================

            response.Suppliers =
     suppliers
         .Select(x =>
             new SellerCustomerSupplierResponse
             {
                 SupplierId = x.SupplierId,
                 SellerId = x.SellerId,
                 CustomerId = x.CustomerId,
                 SupplierCode = x.SupplierCode,
                 SupplierName = x.SupplierName,
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
                 CreditLimit = x.CreditLimit,
                 IsActive = x.IsActive,
                 CreatedDate = x.CreatedDate,
                 UpdatedDate = x.UpdatedDate
             })
         .ToList();


            // ============================================================
            // BRANDS
            // ============================================================

            response.Brands =
     brands
         .Select(x =>
             new SellerCustomerBrandResponse
             {
                 BrandId = x.BrandId,
                 BrandName = x.BrandName ?? string.Empty,
                 BrandCode = x.BrandCode ?? string.Empty,
                 Description = x.Description,
                 SellerId = x.SellerId,
                 customerId = x.CustomerId,
                 IsActive = x.IsActive,
                 CreatedDate = x.CreatedDate,
                 BrandXID = x.BrandId,
                 LogoUrl = x.LogoUrl,
                 BrandImageUrl = x.LogoUrl,
                 UpdatedDate = x.UpdatedDate
             })
         .ToList();


            // ============================================================
            // BRAND MODELS
            // ============================================================

            response.BrandModels =
      brandModels
          .Select(x =>
              new SellerCustomerBrandModelResponse
              {
                  BrandModelId = x.BrandModelId,
                  BrandId = x.BrandId,
                  SellerId = x.SellerId ?? 0,
                  CustomerId = x.CustomerId ?? 0,
                  ModelName = x.ModelName ?? string.Empty,
                  ModelCode = x.ModelCode ?? string.Empty,
                  BrandName = x.BrandName,
                  Description = x.Description,
                  IsActive = x.IsActive,
                  CreatedDate = x.CreatedDate,
                  UpdatedDate = x.UpdatedDate,
                  Specifications = x.Specifications,
                  ImageUrl = x.ImageUrl
              })
          .ToList();


            // ============================================================
            // MARKETPLACES
            // ============================================================

            response.Marketplaces =
       marketplaces
           .Select(x =>
               new SellerCustomerMarketplaceResponse
               {
                   MarketplaceId = x.MarketplaceId,
                   MarketplaceCode = x.MarketplaceCode ?? string.Empty,
                   MarketplaceName = x.MarketplaceName ?? string.Empty,
                   IsActive = x.IsActive
               })
           .ToList();


            // ============================================================
            // DELIVERY CHALLAN ITEMS
            // ============================================================

            response.DeliveryChallanItems =
                deliveryChallanItems
                    .Select(x =>
                        new SellerCustomerDeliveryChallanItemResponse
                        {
                            DeliveryChallanItemId =
                                x.DeliveryChallanItemId,

                            DeliveryChallanId =
                                x.DeliveryChallanId,

                            ProductId =
                                x.ProductId,

                            Quantity =
                                x.Quantity
                        })
                    .ToList();

            // ============================================================
            // E-INVOICES
            // ============================================================

            response.EInvoices =
                eInvoices
                    .Select(x =>
                        new SellerCustomerEInvoiceResponse
                        {
                            EInvoiceId = x.EInvoiceId,
                            SellerId = x.SellerId,
                            CustomerId = x.CustomerId,
                            SalesInvoiceId = x.SalesInvoiceId,
                            InvoiceNumber = x.InvoiceNumber,
                            Irn = x.IRN,
                            AckNo = x.AckNo,
                            AckDate = x.AckDate,
                            SignedInvoice = x.SignedInvoice,
                            SignedQrCode = x.SignedQrCode,
                            Status = x.Status,
                            CreatedDate = x.CreatedDate
                        })
                    .ToList();


            // ============================================================
            // E-WAY BILLS
            // ============================================================

            response.EWayBills =
                eWayBills
                    .Select(x =>
                        new SellerCustomerEWayBillResponse
                        {
                            EWayBillId = x.EWayBillId,
                            SellerId = x.SellerId,
                            CustomerId = x.CustomerId,
                            SalesInvoiceId = x.SalesInvoiceId,
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
                        })
                    .ToList();


            // ============================================================
            // SHELFWISE INVENTORIES
            // ============================================================

            response.ShelfwiseInventories =
                shelfwiseInventories
                    .Select(x =>
                        new SellerCustomerShelfwiseInventoryResponse
                        {
                            ShelfwiseInventoryId = x.ShelfwiseInventoryId,
                            SellerId = x.SellerId,
                            CustomerId = x.CustomerId,
                            FacilityCode = x.FacilityCode ?? string.Empty,
                            ShelfCode = x.ShelfCode ?? string.Empty,
                            ItemSkuCode = x.ItemSkuCode ?? string.Empty,
                            Quantity = x.Quantity,
                            BatchCode = x.BatchCode,
                            ExpiryDate = x.ExpiryDate,
                            InventoryType = x.InventoryType,
                            LocationCode = x.LocationCode,
                            CreatedDate = x.CreatedDate,
                            UpdatedDate = x.UpdatedDate
                        })
                    .ToList();


            // ============================================================
            // VENDOR ITEM MASTERS
            // ============================================================

            response.VendorItemMasters =
                vendorItemMasters
                    .Select(x =>
                        new SellerCustomerVendorItemMasterResponse
                        {
                            VendorItemMasterId = x.VendorItemMasterId,
                            VendorId = x.VendorId,
                            SellerId = x.SellerId,
                            CustomerId = x.CustomerId,
                            VendorSkuCode = x.VendorSkuCode,
                            ItemSkuCode = x.ItemSkuCode,
                            CostPrice = x.CostPrice,
                            ProductId = x.ProductId,
                            IsActive = x.IsActive,
                            CreatedDate = x.CreatedDate,
                            UpdatedDate = x.UpdatedDate
                        })
                    .ToList();


            // ============================================================
            // GATEPASSES
            // ============================================================

            response.Gatepasses =
                gatepasses
                    .Select(x =>
                        new SellerCustomerGatepassResponse
                        {
                            GatepassId = x.GatepassId,
                            SellerId = x.SellerId,
                            CustomerId = x.CustomerId,
                            FacilityCode = x.FacilityCode,
                            Facility = x.Facility,
                            GatepassCode = x.GatepassCode,
                            ItemSkuCode = x.ItemSkuCode,
                            Quantity = x.Quantity,
                            Reason = x.Reason,
                            Status = x.Status,
                            CreatedDate = x.CreatedDate
                        })
                    .ToList();


            // ============================================================
            // PUTAWAYS
            // ============================================================

            response.Putaways =
                putaways
                    .Select(x =>
                        new SellerCustomerPutawayResponse
                        {
                            PutawayId = x.PutawayId,
                            SellerId = x.SellerId,
                            CustomerId = x.CustomerId,
                            FacilityCode = x.FacilityCode,
                            ShelfCode = x.ShelfCode,
                            PutawayCode = x.PutawayCode,
                            ItemTypeSkuCode = x.ItemTypeSkuCode,
                            PutawayQuantity = x.PutawayQuantity,
                            BatchCode = x.BatchCode,
                            InventoryType = x.InventoryType,
                            PutawayType = x.PutawayType,
                            StatusCode = x.StatusCode,
                            CreatedDate = x.CreatedDate
                        })
                    .ToList();


            // ============================================================
            // REVERSE PICKUPS
            // ============================================================

            response.ReversePickups =
                reversePickups
                    .Select(x =>
                        new SellerCustomerReversePickupResponse
                        {
                            ReversePickupId = x.ReversePickupId,
                            SellerId = x.SellerId,
                            CustomerId = x.CustomerId,
                            ReversePickupNo = x.ReversePickupNo,
                            FacilityCode = x.FacilityCode,
                            ItemSkuCode = x.ItemSkuCode,
                            ReversePickupStatus = x.ReversePickupStatus,
                            SaleOrderCode = x.SaleOrderCode,
                            SaleOrderItemCode = x.SaleOrderItemCode,
                            ReturnReason = x.ReturnReason,
                            ChannelName = x.ChannelName,
                            TrackingNo = x.TrackingNo,
                            CreatedDate = x.CreatedDate
                        })
                    .ToList();


            // ============================================================
            // MARKETPLACE LISTING INVENTORIES
            // ============================================================

            response.MarketplaceListingInventories =
                marketplaceListingInventories
                    .Select(x =>
                        new SellerCustomerMarketplaceListingInventoryResponse
                        {
                            MarketplaceListingInventoryId = x.MarketplaceListingInventoryId,
                            MarketplaceListingId = x.MarketplaceListingId,
                            ProductId = 0,
                            MarketplaceSKU = string.Empty,
                            ListingStatus = string.Empty,
                            AvailableQuantity = x.AvailableQuantity ?? 0m,
                            ReservedQuantity = x.ReservedQuantity ?? 0m,
                            InboundQuantity = x.InboundQuantity ?? 0m,
                            LastInventorySync = x.LastInventorySync,
                            CreatedDate = x.CreatedDate
                        })
                    .ToList();


            // ============================================================
            // AMAZON INVENTORY SYNCS
            // ============================================================

            response.AmazonInventorySyncs =
                amazonInventorySyncs
                    .Select(x =>
                        new SellerCustomerAmazonInventorySyncResponse
                        {
                            InventorySyncId = x.InventorySyncId,
                            AmazonAccountId = x.AmazonAccountId,
                            ProductId = x.ProductId ?? 0,
                            SKU = x.SKU ?? string.Empty,
                            ASIN = x.ASIN ?? string.Empty,
                            MarketplaceId = x.MarketplaceId ?? string.Empty,
                            AvailableQuantity = x.AvailableQuantity ?? 0,
                            ReservedQuantity = x.ReservedQuantity ?? 0,
                            InboundQuantity = x.InboundQuantity ?? 0,
                            LastSyncDate = x.LastSyncDate,
                            JsonData = x.JsonData ?? string.Empty
                        })
                    .ToList();


            // ============================================================
            // RETURN
            // ============================================================

            return response;
        }




        // ========================================================
        // CREATE SELLER CUSTOMER
        // ========================================================

        public async Task<SellerCustomer>
            CreateAsync(
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


        // ========================================================
        // UPDATE SELLER CUSTOMER
        // ========================================================

        public async Task<bool>
            UpdateAsync(
                int sellerId,
                int customerId,
                UpdateSellerCustomerRequest request)
        {
            var customer =
                await _repository.GetCustomerAsync(
                    sellerId,
                    customerId);

            if (customer == null)
            {
                return false;
            }


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


            await _repository.UpdateAsync(
                customer);

            await _repository.SaveChangesAsync();

            return true;
        }


        // ========================================================
        // DELETE SELLER CUSTOMER
        // ========================================================

        public async Task<bool>
            DeleteAsync(
                int sellerId,
                int customerId)
        {
            var customer =
                await _repository.GetCustomerAsync(
                    sellerId,
                    customerId);

            if (customer == null)
            {
                return false;
            }


            await _repository.DeleteAsync(
                customer);

            await _repository.SaveChangesAsync();

            return true;
        }


        // ========================================================
        // PRIVATE HELPER
        // ========================================================

        private static bool ContainsIgnoreCase(
            string? source,
            string search)
        {
            return !string.IsNullOrWhiteSpace(source)
                   &&
                   source.Contains(
                       search,
                       StringComparison.OrdinalIgnoreCase);
        }


        // ========================================================
        // SAFE RESPONSE PROPERTY SETTER
        // ========================================================
        //
        // Some fields are optional in the response DTO.
        // Instead of:
        //
        //     try { ... } catch { }
        //
        // we explicitly check whether the property exists.
        //
        // This prevents errors from being silently swallowed.
        // ========================================================

        private static void SetResponseProperty(
            object response,
            string propertyName,
            object? value)
        {
            var property =
                response.GetType()
                    .GetProperty(propertyName);

            if (property == null)
            {
                return;
            }

            if (!property.CanWrite)
            {
                return;
            }

            property.SetValue(
                response,
                value);
        }
    }
}
// =========================================================
// SellerCustomerService.cs
// =========================================================

using Marketplacesellerportal.Brand.Interfaces;
using Marketplacesellerportal.BrandModel.Interfaces;
using Marketplacesellerportal.Categories.Interfaces;
using Marketplacesellerportal.CustomerReturns.Interfaces;
using Marketplacesellerportal.DeliveryChallans.Interfaces;
using Marketplacesellerportal.GoodsReceiptItems.Interfaces;
using Marketplacesellerportal.GoodsReceiptNotes.Interfaces;
using Marketplacesellerportal.Interface;
using Marketplacesellerportal.MarketplaceOrderItems.Interfaces;
using Marketplacesellerportal.MarketplaceReturns.Interfaces;

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

using BrandEntity = Marketplacesellerportal.Models.Brand;

namespace Marketplacesellerportal.SellerCustomers.Services
{
    public class SellerCustomerService : ISellerCustomerService
    {
        // =========================================================
        // REPOSITORIES
        // =========================================================

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

        private readonly IBrandModelRepository _brandModelRepository;
        private readonly IBrandRepository _brandRepository;


        // =========================================================
        // MARKETPLACE REPOSITORIES
        // =========================================================

        private readonly IMarketplaceOrderRepository _marketplaceOrderRepository;

        private readonly IMarketplaceOrderItemRepository
            _marketplaceOrderItemRepository;

        private readonly IMarketplaceReturnRepository
            _marketplaceReturnRepository;


        // =========================================================
        // CONSTRUCTOR
        // =========================================================

        public SellerCustomerService(
            ISellerCustomerRepository repository,

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

            IBrandModelRepository brandModelRepository,
            IBrandRepository brandRepository,

            // =====================================================
            // MARKETPLACE REPOSITORIES
            // =====================================================

            IMarketplaceOrderRepository marketplaceOrderRepository,
            IMarketplaceOrderItemRepository marketplaceOrderItemRepository,
            IMarketplaceReturnRepository marketplaceReturnRepository
        )
        {
            _repository = repository;

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

            _brandModelRepository = brandModelRepository;
            _brandRepository = brandRepository;


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
            // PRODUCTS
            // =====================================================

            var products =
                await _productRepository
                    .GetProductsBySellerCustomerAsync(
                        sellerId,
                        customerId);


            // =====================================================
            // BRANDS
            // =====================================================

            var brandIds = products
                .Where(p => p.BrandId.HasValue)
                .Select(p => p.BrandId!.Value)
                .Distinct()
                .ToList();

            var brands = new List<BrandEntity>();

            foreach (var brandId in brandIds)
            {
                var brand =
                    await _brandRepository.GetByIdAsync(
                        brandId);

                if (brand != null)
                    brands.Add(brand);
            }


            // =====================================================
            // BRAND MODELS
            // =====================================================

            var brandModels =
                await _brandModelRepository
                    .GetByBrandIdsAsync(brandIds);


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

            var salesOrders =
                await _salesOrderRepository
                    .GetBySellerCustomerAsync(
                        sellerId,
                        customerId);

            var salesOrderItems =
                new List<SalesOrderItem>();

            foreach (var so in salesOrders)
            {
                var items =
                    await _salesOrderItemRepository
                        .GetBySalesOrderIdAsync(
                            so.SalesOrderId);

                salesOrderItems.AddRange(items);
            }


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

            var purchaseOrderItems =
                await _purchaseOrderItemRepository
                    .GetByPurchaseOrdersAsync(
                        sellerId,
                        customerId,
                        purchaseOrderIds);


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
            // SALES INVOICES
            // =====================================================

            var salesInvoices =
                await _salesInvoiceRepository
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
                    UpdatedDate = customer.UpdatedDate
                };


            // =====================================================
            // BRAND DICTIONARY
            // =====================================================

            var brandDict =
                brands.ToDictionary(
                    b => b.BrandId,
                    b => b.BrandName);


            // =====================================================
            // PRODUCTS
            // =====================================================

            response.Products =
                products
                    .Select(p =>
                        new SellerCustomerProductResponse
                        {
                            ProductId = p.ProductId,

                            SellerId = p.SellerId,
                            CustomerId = p.CustomerId,

                            ProductName = p.ProductName,

                            SKU = p.SKU,
                            Barcode = p.Barcode,

                            BrandId = p.BrandId,

                            BrandName =
                                p.BrandId.HasValue &&
                                brandDict.ContainsKey(
                                    p.BrandId.Value)
                                    ? brandDict[p.BrandId.Value]
                                    : "Samsung",

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
                            IsActive = p.IsActive,

                            CreatedDate = p.CreatedDate,
                            UpdatedDate = p.UpdatedDate
                        })
                    .ToList();


            // =====================================================
            // INVENTORIES
            // =====================================================

            response.Inventories =
                inventories
                    .Select(i =>
                        new SellerCustomerInventoryResponse
                        {
                            ProductInventoryId =
                                i.ProductInventoryId,

                            SellerId = i.SellerId,
                            CustomerId = i.CustomerId,

                            ProductId = i.ProductId,

                            WarehouseId = i.WarehouseId,
                            LocationId = i.LocationId,

                            Quantity = i.Quantity ?? 0,
                            ReservedQuantity =
                                i.ReservedQuantity ?? 0,

                            DamagedQuantity =
                                i.DamagedQuantity ?? 0,

                            ReorderLevel =
                                i.ReorderLevel ?? 0,

                            ReorderQuantity =
                                i.ReorderQuantity ?? 0,

                            LastStockUpdate =
                                i.LastStockUpdate,

                            CreatedDate = i.CreatedDate,
                            UpdatedDate = i.UpdatedDate
                        })
                    .ToList();


            // =====================================================
            // PRICES
            // =====================================================

            response.Prices =
                prices
                    .Select(p =>
                        new SellerCustomerPriceResponse
                        {
                            ProductPriceId =
                                p.ProductPriceId,

                            ProductId = p.ProductId,

                            SellerId = p.SellerId,
                            CustomerId = p.CustomerId,

                            PriceType = p.PriceType,

                            Price = p.Price,

                            Currency = p.Currency,

                            EffectiveFrom =
                                p.EffectiveFrom,

                            EffectiveTo =
                                p.EffectiveTo,

                            IsActive = p.IsActive,

                            CreatedDate = p.CreatedDate,
                            UpdatedDate = p.UpdatedDate
                        })
                    .ToList();


            // =====================================================
            // PRODUCT TYPES
            // =====================================================

            response.ProductTypes =
                productTypes
                    .Select(pt =>
                        new SellerCustomerProductTypeResponse
                        {
                            ProductTypeId =
                                pt.ProductTypeId,

                            SellerId = pt.SellerId,
                            CustomerId = pt.CustomerId,

                            ProductTypeName =
                                pt.ProductTypeName,

                            Description = pt.Description,

                            IsActive = pt.IsActive,

                            CreatedDate = pt.CreatedDate,
                            UpdatedDate = pt.UpdatedDate
                        })
                    .ToList();


            // =====================================================
            // CATEGORIES
            // =====================================================

            response.Categories =
                categories
                    .Select(c =>
                        new SellerCustomerCategoryResponse
                        {
                            CategoryId = c.CategoryId,

                            CategoryName =
                                c.CategoryName,

                            ParentCategoryId =
                                c.ParentCategoryId,

                            Description =
                                c.Description,

                            IsActive = c.IsActive,

                            CreatedDate = c.CreatedDate,
                            UpdatedDate = c.UpdatedDate
                        })
                    .ToList();


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
            // WAREHOUSES
            // =====================================================

            response.Warehouses =
                warehouses
                    .Select(w =>
                        new SellerCustomerWarehouseResponse
                        {
                            WarehouseId =
                                w.WarehouseId,

                            SellerId =
                                w.SellerId,

                            CustomerId =
                                w.CustomerId,

                            WarehouseCode =
                                w.WarehouseCode,

                            WarehouseName =
                                w.WarehouseName,

                            AddressLine1 =
                                w.AddressLine1,

                            AddressLine2 =
                                w.AddressLine2,

                            City =
                                w.City,

                            State =
                                w.State,

                            Country =
                                w.Country,

                            PostalCode =
                                w.PostalCode,

                            ContactPerson =
                                w.ContactPerson,

                            Phone =
                                w.Phone,

                            Email =
                                w.Email,

                            CreatedDate =
                                w.CreatedDate,

                            UpdatedDate =
                                w.UpdatedDate
                        })
                    .ToList();


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
                            LocationId =
                                l.LocationId,

                            CustomerId =
                                l.CustomerId,

                            WarehouseId =
                                l.WarehouseId,

                            LocationCode =
                                l.LocationCode,

                            LocationName =
                                l.LocationName,

                            Description =
                                l.Description,

                            IsActive =
                                l.IsActive,

                            CreatedDate =
                                l.CreatedDate
                        })
                    .ToList();


            // =====================================================
            // BRANDS
            // =====================================================

            response.Brands =
                brands
                    .Select(b =>
                        new SellerCustomerBrandResponse
                        {
                            BrandId =
                                b.BrandId,

                            BrandName =
                                b.BrandName,

                            Description =
                                b.Description,

                            IsActive =
                                b.IsActive,

                            CreatedDate =
                                b.CreatedDate,

                            UpdatedDate =
                                b.UpdatedDate
                        })
                    .ToList();


            // =====================================================
            // BRAND MODELS
            // =====================================================

            response.BrandModels =
                brandModels
                    .Select(m =>
                        new SellerCustomerBrandModelResponse
                        {
                            BrandModelId =
                                m.BrandModelId,

                            BrandId =
                                m.BrandId,

                            ModelName =
                                m.ModelName,

                            Description =
                                m.Description,

                            IsActive =
                                m.IsActive,

                            CreatedDate =
                                m.CreatedDate,

                            UpdatedDate =
                                m.UpdatedDate
                        })
                    .ToList();


            // =========================================================
            // TRANSACTIONS
            // =========================================================

            // =========================================================
            // ONLY ONE MAPPING WITH TOPAZ - NO DUPLICATE BELOW
            // =========================================================

            response.Transactions.SalesOrders =
                salesOrders
                    .Select(s =>
                        new SellerCustomerSalesOrderResponse
                        {
                            SalesOrderId =
                                s.SalesOrderId,

                            SellerId =
                                s.SellerId,

                            CustomerId =
                                s.CustomerId,

                            SalesOrderNumber =
                                s.SalesOrderNumber,

                            OrderDate =
                                s.OrderDate,

                            Status =
                                s.Status,

                            TotalAmount =
                                s.TotalAmount,

                            Remarks =
                                s.Remarks,

                            CreatedDate =
                                s.CreatedDate,

                            UpdatedDate =
                                s.UpdatedDate,

                            // TOPAZ FIELDS
                            Company_Name =
                                s.Company_Name,

                            Company_Address =
                                s.Company_Address,

                            Company_City =
                                s.Company_City,

                            Company_State =
                                s.Company_State,

                            Company_PINCode =
                                s.Company_PINCode,

                            Phone_no =
                                s.Phone_no,

                            Email_Address =
                                s.Email_Address,

                            Gstin =
                                s.Gstin,

                            DeliveryNote =
                                s.DeliveryNote,

                            ModeorTermsOfPayment =
                                s.ModeorTermsOfPayment,

                            OtherReferences =
                                s.OtherReferences,

                            DespatchedDocumentNumber =
                                s.DespatchedDocumentNumber,

                            DeliveryNoteDate =
                                s.DeliveryNoteDate,

                            EWayBillNumber =
                                s.EWayBillNumber,

                            VehicleNo =
                                s.VehicleNo,

                            Distance =
                                s.Distance,

                            TYear =
                                s.TYear,

                            Transport =
                                s.Transport,

                            TransporterName =
                                s.TransporterName,

                            TransporterID =
                                s.TransporterID,

                            TransporterDocNo =
                                s.TransporterDocNo,

                            TransportMode =
                                s.TransportMode,

                            StateCode =
                                s.StateCode,

                            Pid =
                                s.Pid,

                            KeyID =
                                s.KeyID
                        })
                    .ToList();


            // =========================================================
            // SALES ORDER ITEMS
            // =========================================================

            response.Transactions.SalesOrderItems =
                salesOrderItems
                    .Select(i =>
                        new SellerCustomerSalesOrderItemResponse
                        {
                            SalesOrderItemId =
                                i.SalesOrderItemId,

                            SalesOrderId =
                                i.SalesOrderId,

                            ProductId =
                                i.ProductId,

                            Quantity =
                                i.Quantity,

                            UnitPrice =
                                i.UnitPrice,

                            Discount =
                                i.Discount,

                            TaxAmount =
                                i.TaxAmount,

                            TotalAmount =
                                i.TotalAmount,

                            Description =
                                i.Description,

                            Uom =
                                i.Uom,

                            Hsncode =
                                i.Hsncode,

                            GstPer =
                                i.GstPer,

                            SgstPer =
                                i.SgstPer,

                            SgstAmount =
                                i.SgstAmount,

                            CgstPer =
                                i.CgstPer,

                            CgstAmount =
                                i.CgstAmount,

                            IgstPer =
                                i.IgstPer,

                            IgstAmount =
                                i.IgstAmount,

                            AfterGSTAmount =
                                i.AfterGSTAmount,

                            QuantityAmount =
                                i.QuantityAmount,

                            TotalRateBeforeDiscount =
                                i.TotalRateBeforeDiscount,

                            TaxType =
                                i.TaxType,

                            BrandXID =
                                i.BrandXID,

                            Remarks =
                                i.Remarks,

                            Pid =
                                i.Pid,

                            InvoiceXID =
                                i.InvoiceXID,

                            ItemXID =
                                i.ItemXID
                        })
                    .ToList();


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

            response.Transactions.GoodsReceiptNotes =
                goodsReceiptNotes
                    .Select(x =>
                        new SellerCustomerGoodsReceiptNoteResponse
                        {
                            GoodsReceiptNoteId =
                                x.GoodsReceiptNoteId,

                            PurchaseOrderId =
                                x.PurchaseOrderId,

                            GRNNumber =
                                x.GRNNumber,

                            ReceiptDate =
                                x.ReceiptDate,

                            Status =
                                x.Status,

                            Remarks =
                                x.Remarks,

                            CreatedDate =
                                x.CreatedDate
                        })
                    .ToList();


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
            // SALES INVOICES
            // =========================================================

            response.Transactions.SalesInvoices =
                salesInvoices
                    .Select(x =>
                        new SellerCustomerSalesInvoiceResponse
                        {
                            SalesInvoiceId =
                                x.SalesInvoiceId,

                            SellerId =
                                sellerId,

                            CustomerId =
                                customerId,

                            SalesOrderId =
                                x.SalesOrderId,

                            InvoiceNumber =
                                x.InvoiceNumber,

                            InvoiceDate =
                                x.InvoiceDate,

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
                                x.UpdatedDate
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

            response.Transactions.PurchaseOrders =
                purchaseOrders
                    .Select(x =>
                        new SellerCustomerPurchaseOrderResponse
                        {
                            PurchaseOrderId =
                                x.PurchaseOrderId,

                            SellerId =
                                x.SellerId,

                            CustomerId =
                                customerId,

                            SupplierId =
                                x.SupplierId,

                            PurchaseOrderNumber =
                                x.PurchaseOrderNumber,

                            OrderDate =
                                x.OrderDate,

                            ExpectedDeliveryDate =
                                x.ExpectedDeliveryDate,

                            Status =
                                x.Status,

                            TotalAmount =
                                x.TotalAmount,

                            Remarks =
                                x.Remarks,

                            CreatedDate =
                                x.CreatedDate,

                            UpdatedDate =
                                x.UpdatedDate
                        })
                    .ToList();


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

            response.Transactions.Shipments =
                shipments
                    .Select(x =>
                        new SellerCustomerShipmentResponse
                        {
                            ShipmentId =
                                x.ShipmentId,

                            SellerId =
                                x.SellerId,

                            CustomerId =
                                customerId,

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
                                x.ShipmentStatus
                        })
                    .ToList();


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


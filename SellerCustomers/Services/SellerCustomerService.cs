
using Marketplacesellerportal.Categories.Interfaces;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductAttributes.Interfaces;
using Marketplacesellerportal.ProductImages.Interfaces;
using Marketplacesellerportal.ProductInventories.Interfaces;
using Marketplacesellerportal.ProductPrices.Interfaces;
using Marketplacesellerportal.Products.Interfaces;
using Marketplacesellerportal.ProductTypes.Interfaces;
using Marketplacesellerportal.SellerCustomers.DTOs;
using Marketplacesellerportal.SellerCustomers.Interfaces;
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
using Marketplacesellerportal.WarehouseLocations.Interfaces;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Marketplacesellerportal.SellerCustomers.Services
{
    public class SellerCustomerService : ISellerCustomerService
    {
        
        private readonly ISellerCustomerRepository _repository;
        private readonly IProductRepository _productRepository;
        private readonly IProductInventoryRepository _inventoryRepository;
        private readonly IProductPriceRepository _productPriceRepository;
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductImageRepository _productImageRepository;
        private readonly IProductAttributeRepository _productAttributeRepository;
        // =========================================================
        // STOCK / WAREHOUSE REPOSITORIES
        // =========================================================

        private readonly IStockMovementRepository _stockMovementRepository;
        private readonly IStockLedgerRepository _stockLedgerRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IStockAdjustmentRepository _stockAdjustmentRepository;
        private readonly IStockTransferRepository _stockTransferRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IWarehouseLocationRepository _warehouseLocationRepository;

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
       IWarehouseLocationRepository warehouseLocationRepository
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
        }
        // =========================================================
        // GET ALL SELLER CUSTOMERS
        // =========================================================
        public async Task<IEnumerable<SellerCustomer>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // =========================================================
        // GET CUSTOMERS BY SELLER
        // =========================================================
        public async Task<IEnumerable<SellerCustomer>> GetBySellerIdAsync(
            int sellerId)
        {
            return await _repository.GetBySellerIdAsync(sellerId);
        }

        // =========================================================
        // GET ONE CUSTOMER BY SELLER + CUSTOMER
        // =========================================================
        public async Task<SellerCustomer?> GetCustomerAsync(int sellerId,int customerId)
        {
            return await _repository.GetCustomerAsync(sellerId,customerId);
        }

        // =========================================================
        // GET CUSTOMER BY CODE
        // =========================================================
        public async Task<SellerCustomer?> GetByCustomerCodeAsync(int sellerId,string customerCode)
        {
            return await _repository.GetByCustomerCodeAsync(sellerId,customerCode);
        }


        // =========================================================
        // GET CUSTOMER WITH PRODUCTS + INVENTORIES
        // =========================================================
        public async Task<SellerCustomerWithProductsResponse?>GetCustomerWithProductsAsync(int sellerId,int customerId)
        {
            // =====================================================
            // GET CUSTOMER
            // =====================================================

            var customer = await _repository.GetCustomerAsync(sellerId,customerId);
            if (customer == null)
                return null;

            // =====================================================
            // GET PRODUCTS
            // Only Seller + Customer products
            // =====================================================

       var products = await _productRepository.GetProductsBySellerCustomerAsync(sellerId,customerId);

            // =====================================================
            // GET INVENTORIES
            // Separate from Products
            // Only Seller + Customer inventories
            // =====================================================
      var inventories = await _inventoryRepository.GetBySellerCustomerAsync(sellerId,customerId);
            // =====================================================
            // GET attributes
            // Separate from Products
            // Only Seller + Customer inventories
            // =====================================================
      var attributes = await _productAttributeRepository.GetBySellerCustomerAsync(sellerId,customerId);
            Console.WriteLine($"ATTRIBUTES FOUND: {attributes.Count()}");

            // =====================================================
            // GET prices
            // Separate from Products
            // Only Seller + Customer inventories
            // =====================================================
            var prices = await _productPriceRepository.GetBySellerCustomerAsync(sellerId, customerId);
            var productIds = products.Select(p => p.ProductId).Distinct().ToList();
            var images = await _productImageRepository.GetByProductIdsAsync(productIds);

            // =====================================================
            // GET productTypes
            // Separate from Products
            // Only Seller + Customer inventories
            // =====================================================
            var productTypes = await _productTypeRepository.GetBySellerCustomerAsync(sellerId,customerId);
            // =====================================================
            // GET categories
            // Separate from Products
            // Only Seller + Customer inventories
            // =====================================================

            var categoryIds = products.Where(p => p.CategoryId.HasValue).Select(p => p.CategoryId!.Value).Distinct().ToList();
            var categories = await _categoryRepository.GetByIdsAsync(categoryIds);
            var stockAdjustments = await _stockAdjustmentRepository.GetBySellerCustomerAsync(sellerId, customerId);
            // =====================================================
            // BUILD CUSTOMER RESPONSE
            // =====================================================
      var stockTransfers = await _stockTransferRepository.GetBySellerCustomerAsync(sellerId, customerId);
      var suppliers =await _supplierRepository.GetBySellerCustomerAsync(sellerId, customerId);
      var stockMovements = await _stockMovementRepository.GetBySellerCustomerAsync(sellerId, customerId);
      var stockLedgers = await _stockLedgerRepository.GetBySellerCustomerAsync(sellerId, customerId);
      var warehouses = await _warehouseRepository.GetBySellerCustomerAsync(sellerId, customerId);
      var response = new SellerCustomerWithProductsResponse
            {
                CustomerId = customer.CustomerId,
                SellerId = customer.SellerId,
                CustomerCode = customer.CustomerCode,
                CustomerName = customer.CustomerName,
                ContactPerson = customer.ContactPerson,
                Email = customer.Email,
                Phone = customer.Phone,
                GSTIN = customer.GSTIN,
                AddressLine1 = customer.AddressLine1,
                AddressLine2 = customer.AddressLine2,
                City = customer.City,
                State = customer.State,
                Country = customer.Country,
                PostalCode = customer.PostalCode,
                CreditLimit = customer.CreditLimit ?? 0,
                IsActive = customer.IsActive,
                CreatedDate = customer.CreatedDate,
                UpdatedDate = customer.UpdatedDate
            };

            // =====================================================
            // MAP PRODUCTS
            // =====================================================

            response.Products = products
                .Select(p => new SellerCustomerProductResponse
                {
                    ProductId = p.ProductId,
                    SellerId = p.SellerId,
                    CustomerId = p.CustomerId,
                    ProductName = p.ProductName,
                    SKU = p.SKU,
                    Barcode = p.Barcode,
                    BrandId = p.BrandId,
                    CategoryId = p.CategoryId,
                    ProductTypeId = p.ProductTypeId,
                    Description = p.Description,
                    BrandName = p.BrandName,
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
            // MAP INVENTORIES
            // Completely separate from Products
            // =====================================================

            response.Inventories = inventories
                .Select(i => new SellerCustomerInventoryResponse
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
                    UpdatedDate = i.UpdatedDate
                })
                .ToList();
            // =====================================================
            // MAP prices
            // Completely separate from Products
            // =====================================================
            response.Prices = prices
    .Select(p => new SellerCustomerPriceResponse
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

        UpdatedDate = p.UpdatedDate
    })
    .ToList();

            // =====================================================
            // MAP productTypes
            // Completely separate from Products
            // =====================================================
            response.ProductTypes = productTypes
    .Select(pt => new SellerCustomerProductTypeResponse
    {
        ProductTypeId = pt.ProductTypeId,

        SellerId = pt.SellerId,

        CustomerId = pt.CustomerId,

        ProductTypeName = pt.ProductTypeName,

        Description = pt.Description,

        IsActive = pt.IsActive,

        CreatedDate = pt.CreatedDate,

        UpdatedDate = pt.UpdatedDate
    })
    .ToList();

            // =====================================================
            // MAP  categories
            // Completely separate from Products
            // =====================================================
            response.Categories = categories
    .Select(c => new SellerCustomerCategoryResponse
    {
        CategoryId = c.CategoryId,

        CategoryName = c.CategoryName,

        ParentCategoryId = c.ParentCategoryId,

        Description = c.Description,

        IsActive = c.IsActive,

        CreatedDate = c.CreatedDate,

        UpdatedDate = c.UpdatedDate
    })
    .ToList();


            // =====================================================
            // MAP images
            // Completely separate from Products
            // =====================================================
            response.Images = images
    .Select(i => new SellerCustomerImageResponse
    {
        ProductImageId = i.ProductImageId,

        ProductId = i.ProductId,

        ImageUrl = i.ImageUrl,

        DisplayOrder = i.DisplayOrder,

        IsPrimary = i.IsPrimary,

        CreatedDate = i.CreatedDate
    })
    .ToList();

            // =====================================================
            // MAP Inventories
            // Completely separate from Products
            // =====================================================

            response.Inventories = inventories
    .Select(i => new SellerCustomerInventoryResponse
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
        UpdatedDate = i.UpdatedDate
    })
    .ToList();

            // =====================================================
            // MAP ATTRIBUTES
            // Completely separate from Products
            // =====================================================

            response.Attributes = attributes
                .Select(a => new SellerCustomerAttributeResponse
                {
                    ProductAttributeId = a.ProductAttributeId,

                    ProductId = a.ProductId,

                    SellerId = a.SellerId,

                    CustomerId = a.CustomerId,

                    AttributeName = a.AttributeName,

                    AttributeValue = a.AttributeValue,

                    CreatedDate = a.CreatedDate
                })
                .ToList();
            // =====================================================
            // MAP STOCK MOVEMENTS
           
            // =====================================================

            response.StockMovements = stockMovements
                .Select(s => new SellerCustomerStockMovementResponse
                {
                    StockMovementId = s.StockMovementId,

                    SellerId = s.SellerId,
                    CustomerId = s.CustomerId,
                    ProductId = s.ProductId,
                    WarehouseId = s.WarehouseId,

                    MovementType = s.MovementType,
                    Quantity = s.Quantity ?? 0,

                    ReferenceTable = s.ReferenceTable,
                    ReferenceId = s.ReferenceId,

                    MovementDate = s.MovementDate,
                    Remarks = s.Remarks
                })
                .ToList();
            // =====================================================
            // MAP STOCK StockLedgers
            // 
            // =====================================================

            response.StockLedgers = stockLedgers
    .Select(s => new SellerCustomerStockLedgerResponse
    {
        StockLedgerId = s.StockLedgerId,

        SellerId = s.SellerId,
        CustomerId = s.CustomerId,
        ProductId = s.ProductId,
        WarehouseId = s.WarehouseId,

        TransactionType = s.TransactionType,
        ReferenceNumber = s.ReferenceNumber,

        Quantity = s.Quantity,
        BalanceQuantity = s.BalanceQuantity,

        Remarks = s.Remarks,

        TransactionDate = s.TransactionDate,
        CreatedDate = s.CreatedDate
    })
    .ToList();

            // =====================================================
            // MAP STOCK StockTransfers
            // 
            // =====================================================

            response.StockTransfers = stockTransfers
    .Select(s => new SellerCustomerStockTransferResponse
    {
        StockTransferId = s.StockTransferId,

        SellerId = s.SellerId,
        CustomerId = s.CustomerId,

        ProductId = s.ProductId,

        FromWarehouseId = s.FromWarehouseId,
        ToWarehouseId = s.ToWarehouseId,

        Quantity = s.Quantity,

        TransferDate = s.TransferDate,

        Status = s.Status,

        Remarks = s.Remarks,

        CreatedDate = s.CreatedDate
    })
    .ToList();
            // =====================================================
            // MAP STOCK Suppliers
            // 
            // =====================================================
            response.Suppliers = suppliers
    .Select(s => new SellerCustomerSupplierResponse
    {
        SupplierId = s.SupplierId,

        SellerId = s.SellerId,
        CustomerId = s.CustomerId,

        SupplierCode = s.SupplierCode,
        SupplierName = s.SupplierName,

        ContactPerson = s.ContactPerson,
        Phone = s.Phone,
        Email = s.Email,
        GSTIN = s.GSTIN,

        AddressLine1 = s.AddressLine1,
        AddressLine2 = s.AddressLine2,
        City = s.City,
        State = s.State,
        Country = s.Country,
        PostalCode = s.PostalCode,

        PaymentTerms = s.PaymentTerms,
        CreditLimit = s.CreditLimit,

        IsActive = s.IsActive,

        CreatedDate = s.CreatedDate,
        UpdatedDate = s.UpdatedDate
    })
    .ToList();
            // =====================================================
            // MAP WAREHOUSES
            // Completely separate from Products / Inventory
            // =====================================================

            response.Warehouses = warehouses
                .Select(w => new SellerCustomerWarehouseResponse
                {
                    WarehouseId = w.WarehouseId,

                    SellerId = w.SellerId,

                    CustomerId = w.CustomerId,

                    WarehouseCode = w.WarehouseCode,

                    WarehouseName = w.WarehouseName,

                    AddressLine1 = w.AddressLine1,

                    AddressLine2 = w.AddressLine2,

                    City = w.City,

                    State = w.State,

                    Country = w.Country,

                    PostalCode = w.PostalCode,

                    ContactPerson = w.ContactPerson,

                    Phone = w.Phone,

                    Email = w.Email,

                    //IsActive = w.IsActive,

                    CreatedDate = w.CreatedDate,

                    UpdatedDate = w.UpdatedDate
                })
                .ToList();

            // =====================================================
            // MAP STOCK ADJUSTMENTS
            // Seller + Customer specific
            // =====================================================

            response.StockAdjustments = stockAdjustments
                .Select(s => new SellerCustomerStockAdjustmentResponse
                {
                    StockAdjustmentId = s.StockAdjustmentId,

                    SellerId = s.SellerId,
                    CustomerId = s.CustomerId,

                    ProductId = s.ProductId,
                    WarehouseId = s.WarehouseId,

                    Quantity = s.Quantity,

                    AdjustmentType = s.AdjustmentType,

                    Reason = s.Reason,

                    AdjustedBy = s.AdjustedBy,

                    AdjustmentDate = s.AdjustmentDate,

                    CreatedDate = s.CreatedDate
                })
                .ToList();

            var warehouseLocations = new List<WarehouseLocation>();

            foreach (var warehouse in warehouses)
            {
                var locations =
                    await _warehouseLocationRepository
                        .GetByWarehouseCustomerAsync(
                            warehouse.WarehouseId,
                            customerId);

                warehouseLocations.AddRange(locations);
            }
            response.WarehouseLocations = warehouseLocations
    .Select(l => new SellerCustomerWarehouseLocationResponse
    {
        LocationId = l.LocationId,
        CustomerId = l.CustomerId,
        WarehouseId = l.WarehouseId,
        LocationCode = l.LocationCode,
        LocationName = l.LocationName,
        Description = l.Description,
        IsActive = l.IsActive,
        CreatedDate = l.CreatedDate
    })
    .ToList();
            // =====================================================
            // RETURN COMPLETE REPORT
            // =====================================================

            return response;
        }

        // =========================================================
        // CREATE CUSTOMER
        // =========================================================
        public async Task<SellerCustomer> CreateAsync(
            CreateSellerCustomerRequest request)
        {
            var customer = new SellerCustomer
            {
                SellerId = request.SellerId,

                CustomerCode =
                    "CUST-" +
                    Guid.NewGuid()
                        .ToString("N")[..8]
                        .ToUpper(),

                // CustomerId is generated by SQL Server

                CustomerName = request.CustomerName,
                ContactPerson = request.ContactPerson,

                Email = request.Email,
                Phone = request.Phone,
                GSTIN = request.GSTIN,

                AddressLine1 = request.AddressLine1,
                AddressLine2 = request.AddressLine2,

                City = request.City,
                State = request.State,
                Country = request.Country,
                PostalCode = request.PostalCode,

                CreditLimit = request.CreditLimit,

                IsActive = true,

                CreatedDate = DateTime.Now
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

            customer.CustomerName = request.CustomerName;
            customer.ContactPerson = request.ContactPerson;

            customer.Email = request.Email;
            customer.Phone = request.Phone;
            customer.GSTIN = request.GSTIN;

            customer.AddressLine1 = request.AddressLine1;
            customer.AddressLine2 = request.AddressLine2;

            customer.City = request.City;
            customer.State = request.State;
            customer.Country = request.Country;
            customer.PostalCode = request.PostalCode;

            customer.CreditLimit = request.CreditLimit;

            customer.IsActive = request.IsActive;

            customer.UpdatedDate = DateTime.Now;

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


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

        public SellerCustomerService(
            ISellerCustomerRepository repository,
            IProductRepository productRepository,
            IProductInventoryRepository inventoryRepository,
            IProductPriceRepository productPriceRepository,
            IProductTypeRepository productTypeRepository,
            ICategoryRepository categoryRepository, 
            IProductImageRepository productImageRepository,
            IProductAttributeRepository productAttributeRepository)
        {
            _repository = repository;
            _productRepository = productRepository;
            _inventoryRepository = inventoryRepository;
            _productPriceRepository = productPriceRepository;
            _productTypeRepository = productTypeRepository;
            _categoryRepository = categoryRepository;
            _productImageRepository = productImageRepository;
            _productAttributeRepository = productAttributeRepository;
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
        public async Task<SellerCustomer?> GetCustomerAsync(
            int sellerId,
            int customerId)
        {
            return await _repository.GetCustomerAsync(
                sellerId,
                customerId);
        }

        // =========================================================
        // GET CUSTOMER BY CODE
        // =========================================================
        public async Task<SellerCustomer?> GetByCustomerCodeAsync(
            int sellerId,
            string customerCode)
        {
            return await _repository.GetByCustomerCodeAsync(
                sellerId,
                customerCode);
        }

        // =========================================================
        // GET CUSTOMER WITH PRODUCTS + INVENTORIES
        // =========================================================
        public async Task<SellerCustomerWithProductsResponse?>
            GetCustomerWithProductsAsync(
                int sellerId,
                int customerId)
        {
            // =====================================================
            // GET CUSTOMER
            // =====================================================

            var customer = await _repository.GetCustomerAsync(
                sellerId,
                customerId);

            if (customer == null)
                return null;

            // =====================================================
            // GET PRODUCTS
            // Only Seller + Customer products
            // =====================================================

            var products =
                await _productRepository
                    .GetProductsBySellerCustomerAsync(
                        sellerId,
                        customerId);

            // =====================================================
            // GET INVENTORIES
            // Separate from Products
            // Only Seller + Customer inventories
            // =====================================================

            var inventories =
                await _inventoryRepository
                    .GetBySellerCustomerAsync(
                        sellerId,
                        customerId);
            // =====================================================
            // GET attributes
            // Separate from Products
            // Only Seller + Customer inventories
            // =====================================================
            var attributes =
    await _productAttributeRepository.GetBySellerCustomerAsync(sellerId,customerId);
            Console.WriteLine(
    $"ATTRIBUTES FOUND: {attributes.Count()}");

            // =====================================================
            // GET prices
            // Separate from Products
            // Only Seller + Customer inventories
            // =====================================================
            var prices =
    await _productPriceRepository
        .GetBySellerCustomerAsync(sellerId, customerId);
            var productIds = products
    .Select(p => p.ProductId)
    .Distinct()
    .ToList();

            var images = await _productImageRepository
                .GetByProductIdsAsync(productIds);
    ;

            // =====================================================
            // GET productTypes
            // Separate from Products
            // Only Seller + Customer inventories
            // =====================================================
            var productTypes =
       await _productTypeRepository
           .GetBySellerCustomerAsync(
               sellerId,
               customerId);
            // =====================================================
            // GET categories
            // Separate from Products
            // Only Seller + Customer inventories
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
            // BUILD CUSTOMER RESPONSE
            // =====================================================

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

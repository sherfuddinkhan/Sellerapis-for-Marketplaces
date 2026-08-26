
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Products.DTOs;
using Marketplacesellerportal.Products.Interfaces;

namespace Marketplacesellerportal.Products.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(
            IProductRepository repository)
        {
            _repository = repository;
        }

        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<IEnumerable<ProductDto>>
            GetAllAsync()
        {
            var products =
                await _repository.GetAllAsync();

            return products.Select(MapToDto);
        }

        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<ProductDto?>
            GetByIdAsync(
                int productId)
        {
            var product =
                await _repository.GetByIdAsync(
                    productId);

            if (product == null)
                return null;

            return MapToDto(product);
        }

        // =========================================================
        // GET BY SKU
        // =========================================================

        public async Task<ProductDto?>
            GetBySKUAsync(
                string sku)
        {
            var product =
                await _repository.GetBySKUAsync(
                    sku);

            if (product == null)
                return null;

            return MapToDto(product);
        }

        // =========================================================
        // GET BY SELLER
        // =========================================================

        public async Task<IEnumerable<ProductDto>>
            GetBySellerIdAsync(
                int sellerId)
        {
            var products =
                await _repository.GetBySellerIdAsync(
                    sellerId);

            return products.Select(MapToDto);
        }

        // =========================================================
        // GET BY CUSTOMER
        // =========================================================

        public async Task<IEnumerable<ProductDto>>
            GetByCustomerIdAsync(
                int customerId)
        {
            var products =
                await _repository.GetByCustomerIdAsync(
                    customerId);

            return products.Select(MapToDto);
        }

        // =========================================================
        // GET BY SELLER + CUSTOMER
        // =========================================================

        public async Task<IEnumerable<ProductDto>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId)
        {
            var products =
                await _repository
                    .GetProductsBySellerCustomerAsync(
                        sellerId,
                        customerId);

            return products.Select(MapToDto);
        }

        // =========================================================
        // GET BY PRODUCT IDS
        // =========================================================

        public async Task<IEnumerable<ProductDto>>
            GetByProductIdsAsync(
                IEnumerable<int> productIds)
        {
            var products =
                await _repository.GetByProductIdsAsync(
                    productIds);

            return products.Select(MapToDto);
        }

        // =========================================================
        // GET BY BRAND
        // =========================================================

        public async Task<IEnumerable<ProductDto>>
            GetByBrandIdAsync(
                int brandId)
        {
            var products =
                await _repository.GetByBrandIdAsync(
                    brandId);

            return products.Select(MapToDto);
        }

        // =========================================================
        // GET BY CATEGORY
        // =========================================================

        public async Task<IEnumerable<ProductDto>>
            GetByCategoryIdAsync(
                int categoryId)
        {
            var products =
                await _repository.GetByCategoryIdAsync(
                    categoryId);

            return products.Select(MapToDto);
        }

        // =========================================================
        // GET BY PRODUCT TYPE
        // =========================================================

        public async Task<IEnumerable<ProductDto>>
            GetByProductTypeIdAsync(
                int productTypeId)
        {
            var products =
                await _repository
                    .GetByProductTypeIdAsync(
                        productTypeId);

            return products.Select(MapToDto);
        }

        // =========================================================
        // CREATE
        // =========================================================

        public async Task<ProductDto>
            CreateAsync(
                CreateProductDto dto)
        {
            // -----------------------------------------------------
            // CHECK SKU
            // -----------------------------------------------------

            if (!string.IsNullOrWhiteSpace(dto.SKU))
            {
                var existingProduct =
                    await _repository.GetBySKUAsync(
                        dto.SKU);

                if (existingProduct != null)
                {
                    throw new InvalidOperationException(
                        $"A product with SKU '{dto.SKU}' already exists.");
                }
            }

            // -----------------------------------------------------
            // CREATE ENTITY
            // -----------------------------------------------------

            var product = new Product
            {
                SellerId =
                    dto.SellerId,

                CustomerId =
                    dto.CustomerId,

                ProductName =
                    dto.ProductName,

                SKU =
                    dto.SKU,

                Barcode =
                    dto.Barcode,

                BrandId =
                    dto.BrandId,

                CategoryId =
                    dto.CategoryId,

                ProductTypeId =
                    dto.ProductTypeId,

                Description =
                    dto.Description,

                Weight =
                    dto.Weight,

                Length =
                    dto.Length,

                Width =
                    dto.Width,

                Height =
                    dto.Height,

                HSNCode =
                    dto.HSNCode,

                UnitOfMeasure =
                    dto.UnitOfMeasure,

                Status =
                    string.IsNullOrWhiteSpace(dto.Status)
                        ? "Active"
                        : dto.Status,

                IsActive =
                    dto.IsActive ?? true,

                CreatedDate =
                    DateTime.Now,

                UpdatedDate =
                    null
            };

            await _repository.AddAsync(
                product);

            await _repository.SaveChangesAsync();

            return MapToDto(product);
        }

        // =========================================================
        // UPDATE
        // =========================================================

        public async Task<ProductDto?>
            UpdateAsync(
                int productId,
                UpdateProductDto dto)
        {
            var product =
                await _repository.GetByIdAsync(
                    productId);

            if (product == null)
                return null;

            // -----------------------------------------------------
            // SKU DUPLICATE CHECK
            // -----------------------------------------------------

            if (!string.IsNullOrWhiteSpace(dto.SKU) &&
                !string.Equals(
                    product.SKU,
                    dto.SKU,
                    StringComparison.OrdinalIgnoreCase))
            {
                var existingProduct =
                    await _repository.GetBySKUAsync(
                        dto.SKU);

                if (existingProduct != null &&
                    existingProduct.ProductId != productId)
                {
                    throw new InvalidOperationException(
                        $"A product with SKU '{dto.SKU}' already exists.");
                }
            }

            // -----------------------------------------------------
            // UPDATE
            // -----------------------------------------------------

            product.ProductName =
                dto.ProductName;

            product.SKU =
                dto.SKU;

            product.Barcode =
                dto.Barcode;

            product.BrandId =
                dto.BrandId;

            product.CategoryId =
                dto.CategoryId;

            product.ProductTypeId =
                dto.ProductTypeId;

            product.Description =
                dto.Description;

            product.Weight =
                dto.Weight;

            product.Length =
                dto.Length;

            product.Width =
                dto.Width;

            product.Height =
                dto.Height;

            product.HSNCode =
                dto.HSNCode;

            product.UnitOfMeasure =
                dto.UnitOfMeasure;

            product.Status =
                dto.Status;

            if (dto.IsActive.HasValue)
            {
                product.IsActive =
                    dto.IsActive.Value;
            }

            product.UpdatedDate =
                DateTime.Now;

            await _repository.UpdateAsync(
                product);

            await _repository.SaveChangesAsync();

            return MapToDto(product);
        }

        // =========================================================
        // DELETE
        // =========================================================

        public async Task<bool>
            DeleteAsync(
                int productId)
        {
            var product =
                await _repository.GetByIdAsync(
                    productId);

            if (product == null)
                return false;

            await _repository.DeleteAsync(
                product);

            await _repository.SaveChangesAsync();

            return true;
        }

        // =========================================================
        // SEARCH + FILTER
        // =========================================================

        public async Task<IEnumerable<ProductDto>>
            SearchAsync(
                string? search,
                string? status,
                bool? isActive,
                int? sellerId,
                int? customerId,
                int? brandId,
                int? categoryId,
                int? productTypeId)
        {
            var products =
                await _repository.SearchAsync(
                    search,
                    status,
                    isActive,
                    sellerId,
                    customerId,
                    brandId,
                    categoryId,
                    productTypeId);

            return products.Select(MapToDto);
        }

        // =========================================================
        // STATISTICS
        // =========================================================

        public async Task<ProductStatistics>
            GetStatisticsAsync()
        {
            return await _repository
                .GetStatisticsAsync();
        }

        // =========================================================
        // PAGINATION
        // =========================================================

        public async Task<(
            IEnumerable<ProductDto> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit)
        {
            var result =
                await _repository.GetPagedAsync(
                    page,
                    limit);

            return (
                result.Items.Select(MapToDto),
                result.TotalCount
            );
        }

        // =========================================================
        // SORTING
        // =========================================================

        public async Task<IEnumerable<ProductDto>>
            GetSortedAsync(
                string? sort)
        {
            var products =
                await _repository.GetSortedAsync(
                    sort);

            return products.Select(MapToDto);
        }

        // =========================================================
        // MAP ENTITY → DTO
        // =========================================================

        private static ProductDto
            MapToDto(Product product)
        {
            return new ProductDto
            {
                ProductId =
                    product.ProductId,

                SellerId =
                    product.SellerId,

                CustomerId =
                    product.CustomerId,

                ProductName =
                    product.ProductName,

                SKU =
                    product.SKU,

                Barcode =
                    product.Barcode,

                BrandId =
                    product.BrandId,

                CategoryId =
                    product.CategoryId,

                ProductTypeId =
                    product.ProductTypeId,

                Description =
                    product.Description,

                Weight =
                    product.Weight,

                Length =
                    product.Length,

                Width =
                    product.Width,

                Height =
                    product.Height,

                HSNCode =
                    product.HSNCode,

                UnitOfMeasure =
                    product.UnitOfMeasure,

                Status =
                    product.Status,

                IsActive =
                    product.IsActive,

                CreatedDate =
                    product.CreatedDate,

                UpdatedDate =
                    product.UpdatedDate
            };
        }
    }
}


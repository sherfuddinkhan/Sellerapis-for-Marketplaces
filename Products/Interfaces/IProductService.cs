
using Marketplacesellerportal.Products.DTOs;

namespace Marketplacesellerportal.Products.Interfaces
{
    public interface IProductService
    {
        // =========================================================
        // BASIC
        // =========================================================

        Task<IEnumerable<ProductDto>>
            GetAllAsync();

        Task<ProductDto?>
            GetByIdAsync(
                int productId);

        Task<ProductDto?>
            GetBySKUAsync(
                string sku);


        // =========================================================
        // RELATIONSHIPS
        // =========================================================

        Task<IEnumerable<ProductDto>>
            GetBySellerIdAsync(
                int sellerId);

        Task<IEnumerable<ProductDto>>
            GetByCustomerIdAsync(
                int customerId);

        Task<IEnumerable<ProductDto>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId);

        Task<IEnumerable<ProductDto>>
            GetByProductIdsAsync(
                IEnumerable<int> productIds);

        Task<IEnumerable<ProductDto>>
            GetByBrandIdAsync(
                int brandId);

        Task<IEnumerable<ProductDto>>
            GetByCategoryIdAsync(
                int categoryId);

        Task<IEnumerable<ProductDto>>
            GetByProductTypeIdAsync(
                int productTypeId);


        // =========================================================
        // CREATE
        // =========================================================

        Task<ProductDto>
            CreateAsync(
                CreateProductDto dto);


        // =========================================================
        // UPDATE
        // =========================================================

        Task<ProductDto?>
            UpdateAsync(
                int productId,
                UpdateProductDto dto);


        // =========================================================
        // DELETE
        // =========================================================

        Task<bool>
            DeleteAsync(
                int productId);


        // =========================================================
        // SEARCH / FILTER
        // =========================================================

        Task<IEnumerable<ProductDto>>
            SearchAsync(
                string? search,
                string? status,
                bool? isActive,
                int? sellerId,
                int? customerId,
                int? brandId,
                int? categoryId,
                int? productTypeId);


        // =========================================================
        // STATISTICS
        // =========================================================

        Task<ProductStatistics>
            GetStatisticsAsync();


        // =========================================================
        // PAGINATION
        // =========================================================

        Task<(
            IEnumerable<ProductDto> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit);


        // =========================================================
        // SORTING
        // =========================================================

        Task<IEnumerable<ProductDto>>
            GetSortedAsync(
                string? sort);
    }
}



using Marketplacesellerportal.Models;
using Marketplacesellerportal.Products.DTOs;
namespace Marketplacesellerportal.Products.Interfaces
{
    public interface IProductRepository
    {
        // =========================================================
        // BASIC
        // =========================================================

        Task<IEnumerable<Product>> GetAllAsync();

        Task<Product?> GetByIdAsync(
            int productId);

        Task<Product?> GetBySKUAsync(
            string sku);


        // =========================================================
        // RELATIONSHIPS
        // =========================================================

        Task<IEnumerable<Product>>
            GetBySellerIdAsync(
                int sellerId);

        Task<IEnumerable<Product>>
            GetByCustomerIdAsync(
                int customerId);

        Task<IEnumerable<Product>>
            GetProductsBySellerCustomerAsync(
                int sellerId,
                int customerId);

        Task<IEnumerable<Product>>
            GetByProductIdsAsync(
                IEnumerable<int> productIds);

        Task<IEnumerable<Product>>
            GetByBrandIdAsync(
                int brandId);

        Task<IEnumerable<Product>>
            GetByCategoryIdAsync(
                int categoryId);

        Task<IEnumerable<Product>>
            GetByProductTypeIdAsync(
                int productTypeId);


        // =========================================================
        // CREATE
        // =========================================================

        Task AddAsync(
            Product product);


        // =========================================================
        // UPDATE
        // =========================================================

        Task UpdateAsync(
            Product product);


        // =========================================================
        // DELETE
        // =========================================================

        Task DeleteAsync(
            Product product);


        // =========================================================
        // SEARCH / FILTER
        // =========================================================

        Task<IEnumerable<Product>>
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
            IEnumerable<Product> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit);


        // =========================================================
        // SORTING
        // =========================================================

        Task<IEnumerable<Product>>
            GetSortedAsync(
                string? sort);


        // =========================================================
        // SAVE
        // =========================================================

        Task SaveChangesAsync();
    }
}


using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductAttributes.DTOs;
using System;

namespace Marketplacesellerportal.ProductAttributes.Interfaces
{
    public interface IProductAttributeRepository
    {
        // =========================================================
        // EXISTING METHODS
        // =========================================================

        Task<IEnumerable<ProductAttribute>> GetAllAsync();

        Task<ProductAttribute?> GetByIdAsync(
            int productAttributeId);

        Task<IEnumerable<ProductAttribute>>
            GetByProductIdAsync(
                int productId);
        Task<IEnumerable<ProductAttribute>>
    GetBySellerCustomerAsync(
        int sellerId,
        int customerId);
        Task<IEnumerable<ProductAttribute>>
    GetByAttributeNameAsync(
        string attributeName);


        Task AddAsync(
            ProductAttribute productAttribute);

        Task UpdateAsync(
            ProductAttribute productAttribute);

        Task DeleteAsync(
            int productAttributeId);

        Task SaveChangesAsync();

        // =========================================================
        // SEARCH
        // GET /api/product-attributes?search=color
        // =========================================================

        Task<IEnumerable<ProductAttribute>>
            SearchAsync(
                string? search);

        // =========================================================
        // STATISTICS
        // GET /api/product-attributes/stats
        // =========================================================

        Task<ProductAttributeStatistics>
            GetStatisticsAsync();

        // =========================================================
        // PAGINATION
        // GET /api/product-attributes?page=1&limit=15
        // =========================================================

        Task<(
            IEnumerable<ProductAttribute> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit);

        // =========================================================
        // SORTING
        // GET /api/product-attributes?sort=name_asc
        // =========================================================

        Task<IEnumerable<ProductAttribute>>
            GetSortedAsync(
                string? sort);
    }
}


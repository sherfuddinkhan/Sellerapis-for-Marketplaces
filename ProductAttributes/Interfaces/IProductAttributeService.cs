using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductAttributes.DTOs;

namespace Marketplacesellerportal.ProductAttributes.Interfaces
{
    public interface IProductAttributeService
    {
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

        // SEARCH
        Task<IEnumerable<ProductAttribute>>
            SearchAsync(
                string? search);

        // STATISTICS
        Task<ProductAttributeStatistics>
            GetStatisticsAsync();

        // PAGINATION
        Task<(IEnumerable<ProductAttribute> Items, int TotalCount)>
            GetPagedAsync(
                int page,
                int limit);

        // SORTING
        Task<IEnumerable<ProductAttribute>>
            GetSortedAsync(
                string? sort);

        // CREATE
        Task<ProductAttribute>
            CreateAsync(
                ProductAttribute productAttribute);

        // UPDATE
        Task<bool>
            UpdateAsync(
                int productAttributeId,
                ProductAttribute productAttribute);

        // DELETE
        Task<bool>
            DeleteAsync(
                int productAttributeId);
    }
}
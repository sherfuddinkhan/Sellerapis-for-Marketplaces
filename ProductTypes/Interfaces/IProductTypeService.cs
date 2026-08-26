
using Marketplacesellerportal.ProductTypes.DTOs;

namespace Marketplacesellerportal.ProductTypes.Interfaces
{
    public interface IProductTypeService
    {
        // =========================================================
        // BASIC
        // =========================================================

        Task<IEnumerable<ProductTypeModel>>
            GetAllAsync();

        Task<ProductTypeModel?>
            GetByIdAsync(
                int productTypeId);

        Task<ProductTypeModel?>
            GetByNameAsync(
                string productTypeName);

        Task<IEnumerable<ProductTypeModel>>
            GetActiveAsync();

        Task<IEnumerable<ProductTypeModel>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId);

        // =========================================================
        // CREATE
        // =========================================================

        Task<ProductTypeModel>
            CreateAsync(
                ProductTypeModel model);

        // =========================================================
        // UPDATE
        // =========================================================

        Task<ProductTypeModel?>
            UpdateAsync(
                int productTypeId,
                ProductTypeModel model);

        // =========================================================
        // DELETE
        // =========================================================

        Task<bool>
            DeleteAsync(
                int productTypeId);

        // =========================================================
        // SEARCH / FILTER
        // =========================================================

        Task<IEnumerable<ProductTypeModel>>
            SearchAsync(
                string? search,
                string? status);

        // =========================================================
        // STATISTICS
        // =========================================================

        Task<ProductTypeStatistics>
            GetStatisticsAsync();

        // =========================================================
        // PAGINATION
        // =========================================================

        Task<(
            IEnumerable<ProductTypeModel> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit);

        // =========================================================
        // SORTING
        // =========================================================

        Task<IEnumerable<ProductTypeModel>>
            GetSortedAsync(
                string? sort);
    }
}


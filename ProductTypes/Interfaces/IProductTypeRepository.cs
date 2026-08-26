
using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductTypes.DTOs;

namespace Marketplacesellerportal.ProductTypes.Interfaces
{
    public interface IProductTypeRepository
    {
        // =========================================================
        // BASIC
        // =========================================================

        Task<IEnumerable<ProductType>>
            GetAllAsync();

        Task<ProductType?>
            GetByIdAsync(
                int productTypeId);

        Task<ProductType?>
            GetByNameAsync(
                string productTypeName);

        Task<IEnumerable<ProductType>>
            GetActiveAsync();


        // =========================================================
        // SELLER + CUSTOMER
        // =========================================================

        Task<IEnumerable<ProductType>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId);


        // =========================================================
        // SEARCH + FILTER
        //
        // search = electronic
        // status = active
        // =========================================================

        Task<IEnumerable<ProductType>>
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
            IEnumerable<ProductType> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit);


        // =========================================================
        // SORTING
        // =========================================================

        Task<IEnumerable<ProductType>>
            GetSortedAsync(
                string? sort);


        // =========================================================
        // CREATE
        // =========================================================

        Task AddAsync(
            ProductType productType);


        // =========================================================
        // UPDATE
        // =========================================================

        Task UpdateAsync(
            ProductType productType);


        // =========================================================
        // DELETE
        // =========================================================

        Task DeleteAsync(
            int productTypeId);


        // =========================================================
        // SAVE
        // =========================================================

        Task SaveChangesAsync();
    }
}


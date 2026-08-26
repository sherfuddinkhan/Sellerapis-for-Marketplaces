using Marketplacesellerportal.Models;
using Marketplacesellerportal.Warehouses.DTOs;

namespace Marketplacesellerportal.Warehouses.Interfaces
{
    public interface IWarehouseService
    {
        // =========================================================
        // BASIC
        // =========================================================

        Task<IEnumerable<Warehouse>> GetAllAsync();

        Task<Warehouse?> GetByIdAsync(
            int warehouseId);

        // =========================================================
        // SELLER
        // =========================================================

        Task<IEnumerable<Warehouse>> GetBySellerIdAsync(
            int sellerId);

        // =========================================================
        // CUSTOMER
        // =========================================================

        Task<IEnumerable<Warehouse>> GetByCustomerIdAsync(
            int customerId);

        // =========================================================
        // SELLER + CUSTOMER
        // =========================================================

        Task<IEnumerable<Warehouse>> GetBySellerCustomerAsync(
            int sellerId,
            int customerId);

        // =========================================================
        // CITY
        // =========================================================

        Task<IEnumerable<Warehouse>> GetByCityAsync(
            string city);

        // =========================================================
        // STATE
        // =========================================================

        Task<IEnumerable<Warehouse>> GetByStateAsync(
            string state);

        // =========================================================
        // SPECIFIC WAREHOUSE
        // =========================================================

        Task<Warehouse?> GetWarehouseAsync(
            int sellerId,
            int customerId,
            int warehouseId);

        // =========================================================
        // SEARCH + FILTER
        // =========================================================

        Task<IEnumerable<Warehouse>> SearchAsync(
            string? search,
            string? status);

        // =========================================================
        // STATISTICS
        // GET /api/warehouses/statistics
        // =========================================================

        Task<WarehouseStatistics> GetStatisticsAsync();

        // =========================================================
        // FILTERS
        // GET /api/warehouses/filters
        // =========================================================

        Task<WarehouseFilters> GetFiltersAsync();

        // =========================================================
        // PAGINATION
        // =========================================================

        Task<(
            IEnumerable<Warehouse> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit);

        // =========================================================
        // SORTING
        // =========================================================

        Task<IEnumerable<Warehouse>> GetSortedAsync(
            string? sort);

        // =========================================================
        // CREATE
        // =========================================================

        Task<Warehouse> CreateAsync(
            Warehouse warehouse);

        // =========================================================
        // UPDATE
        // =========================================================

        Task<bool> UpdateAsync(
            int warehouseId,
            Warehouse warehouse);

        // =========================================================
        // DELETE
        // =========================================================

        Task<bool> DeleteAsync(
            int warehouseId);
    }
}
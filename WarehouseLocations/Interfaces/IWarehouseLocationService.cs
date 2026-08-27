using Marketplacesellerportal.Models;
using Marketplacesellerportal.WarehouseLocations.DTOs;

namespace Marketplacesellerportal.WarehouseLocations.Interfaces
{
    public interface IWarehouseLocationService
    {
        // =====================================================
        // GET ALL
        // =====================================================

        Task<IEnumerable<WarehouseLocation>> GetAllAsync();

        // =====================================================
        // GET BY ID
        // =====================================================

        Task<WarehouseLocation?> GetByIdAsync(
            int locationId);

        // =====================================================
        // GET BY WAREHOUSE
        // =====================================================

        Task<IEnumerable<WarehouseLocation>> GetByWarehouseIdAsync(
            int warehouseId);

        // =====================================================
        // GET BY CUSTOMER
        // =====================================================

        Task<IEnumerable<WarehouseLocation>> GetByCustomerIdAsync(
            int customerId);

        // =====================================================
        // GET BY WAREHOUSE + CUSTOMER
        // =====================================================

        Task<IEnumerable<WarehouseLocation>> GetByWarehouseCustomerAsync(
            int warehouseId,
            int customerId);

        // =====================================================
        // GET SPECIFIC LOCATION
        // =====================================================

        Task<WarehouseLocation?> GetLocationAsync(
            int warehouseId,
            int customerId,
            int locationId);

        // =====================================================
        // SEARCH
        // =====================================================

        Task<IEnumerable<WarehouseLocation>> SearchAsync(
            string search);

        // =====================================================
        // SORT
        // =====================================================

        Task<IEnumerable<WarehouseLocation>> GetSortedAsync(
            string? sort);

        // =====================================================
        // PAGINATION
        // =====================================================

        Task<PagedResult<WarehouseLocation>> GetPagedAsync(
            int page,
            int limit);

        // =====================================================
        // STATISTICS
        // =====================================================

        Task<WarehouseLocationStatistics> GetStatisticsAsync();

        // =====================================================
        // CREATE
        // =====================================================

        Task<WarehouseLocation> CreateAsync(
            WarehouseLocation location);

        // =====================================================
        // UPDATE
        // =====================================================

        Task<bool> UpdateAsync(
            int locationId,
            WarehouseLocation location);

        // =====================================================
        // DELETE
        // =====================================================

        Task<bool> DeleteAsync(
            int locationId);
    }
}
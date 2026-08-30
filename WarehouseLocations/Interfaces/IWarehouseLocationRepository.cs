using Marketplacesellerportal.Models;
using Marketplacesellerportal.WarehouseLocations.DTOs;
namespace Marketplacesellerportal.WarehouseLocations.Interfaces
{
    public interface IWarehouseLocationRepository
    {
        Task<IEnumerable<WarehouseLocation>> GetAllAsync();

        Task<WarehouseLocation?> GetByIdAsync(int locationId);

        Task<IEnumerable<WarehouseLocation>> GetByWarehouseIdAsync(
            int warehouseId);
        Task<IEnumerable<WarehouseLocation>> SearchAsync(
    string search);

        Task<IEnumerable<WarehouseLocation>> GetSortedAsync(
            string? sort);

        Task<PagedResult<WarehouseLocation>> GetPagedAsync(
            int page,
            int limit);

        Task<WarehouseLocationStatistics> GetStatisticsAsync();
        Task<IEnumerable<WarehouseLocation>> GetByCustomerIdAsync(
            int customerId);

        Task<IEnumerable<WarehouseLocation>> GetByWarehouseCustomerAsync(
            int warehouseId,
            int customerId);
        // =====================================================
        // GET ONE LOCATION
        // Warehouse + Customer + Location mapping
        // =====================================================
        Task<WarehouseLocation?> GetLocationAsync(
            int warehouseId,
            int customerId,
            int locationId);
        Task AddAsync(WarehouseLocation location);

        Task UpdateAsync(WarehouseLocation location);

        Task DeleteAsync(int locationId);

        Task SaveChangesAsync();
    }
}
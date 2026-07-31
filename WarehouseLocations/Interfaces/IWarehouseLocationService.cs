using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.WarehouseLocations.Interfaces
{
    public interface IWarehouseLocationService
    {
        Task<IEnumerable<WarehouseLocation>> GetAllAsync();

        Task<WarehouseLocation?> GetByIdAsync(int locationId);

        Task<IEnumerable<WarehouseLocation>> GetByWarehouseIdAsync(int warehouseId);

        Task<WarehouseLocation?> GetLocationAsync(int warehouseId, int locationId);

        Task<WarehouseLocation> CreateAsync(WarehouseLocation location);

        Task<bool> UpdateAsync(int locationId, WarehouseLocation location);

        Task<bool> DeleteAsync(int locationId);
    }
}

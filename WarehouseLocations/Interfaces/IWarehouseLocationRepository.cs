using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.WarehouseLocations.Interfaces
{
    public interface IWarehouseLocationRepository
    {
        Task<IEnumerable<WarehouseLocation>> GetAllAsync();

        Task<WarehouseLocation?> GetByIdAsync(int locationId);

        Task<IEnumerable<WarehouseLocation>> GetByWarehouseIdAsync(int warehouseId);

        Task<WarehouseLocation?> GetLocationAsync(int warehouseId, int locationId);

        Task AddAsync(WarehouseLocation location);

        Task UpdateAsync(WarehouseLocation location);

        Task DeleteAsync(int locationId);

        Task SaveChangesAsync();
    }
}

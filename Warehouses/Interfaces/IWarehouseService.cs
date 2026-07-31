using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Warehouses.Interfaces
{
    public interface IWarehouseService
    {
        Task<IEnumerable<Warehouse>> GetAllAsync();

        Task<Warehouse?> GetByIdAsync(int warehouseId);

        Task<IEnumerable<Warehouse>> GetBySellerIdAsync(int sellerId);

        Task<Warehouse?> GetWarehouseAsync(int sellerId, int warehouseId);

        Task<Warehouse> CreateAsync(Warehouse warehouse);

        Task<bool> UpdateAsync(int warehouseId, Warehouse warehouse);

        Task<bool> DeleteAsync(int warehouseId);
    }
}
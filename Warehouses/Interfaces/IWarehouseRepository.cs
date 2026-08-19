using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Warehouses.Interfaces
{
    public interface IWarehouseRepository
    {
        Task<IEnumerable<Warehouse>> GetAllAsync();

        Task<Warehouse?> GetByIdAsync(int warehouseId);

        Task<IEnumerable<Warehouse>> GetBySellerIdAsync(int sellerId);

        Task<Warehouse?> GetWarehouseAsync(int sellerId, int warehouseId);

        Task AddAsync(Warehouse warehouse);
        Task<IEnumerable<Warehouse>> GetBySellerCustomerAsync(int sellerId,int customerId);
        Task UpdateAsync(Warehouse warehouse);

        Task DeleteAsync(int warehouseId);

        Task SaveChangesAsync();
    }
}

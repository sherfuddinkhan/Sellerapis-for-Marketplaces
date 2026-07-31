using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.ProductInventories.Interfaces
{
    public interface IProductInventoryRepository
    {
        Task<IEnumerable<ProductInventory>> GetAllAsync();

        Task<ProductInventory?> GetByIdAsync(int productInventoryId);

        Task<IEnumerable<ProductInventory>> GetBySellerIdAsync(int sellerId);

        Task<IEnumerable<ProductInventory>> GetByProductIdAsync(int productId);

        Task<IEnumerable<ProductInventory>> GetByWarehouseIdAsync(int warehouseId);

        Task<ProductInventory?> GetInventoryAsync(
            int sellerId,
            int productId,
            int warehouseId,
            int locationId);

        Task AddAsync(ProductInventory productInventory);

        Task UpdateAsync(ProductInventory productInventory);

        Task DeleteAsync(int productInventoryId);

        Task SaveChangesAsync();
    }
}

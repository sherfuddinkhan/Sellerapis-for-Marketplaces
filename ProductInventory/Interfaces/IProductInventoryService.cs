using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.ProductInventories.Interfaces
{
    public interface IProductInventoryService
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

        Task<ProductInventory> CreateAsync(ProductInventory productInventory);

        Task<bool> UpdateAsync(
            int productInventoryId,
            ProductInventory productInventory);

        Task<bool> DeleteAsync(int productInventoryId);
    }
}

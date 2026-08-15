using Marketplacesellerportal.Models;
using Marketplacesellerportal.SharedKernel.Interfaces;

namespace Marketplacesellerportal.ProductInventories.Interfaces
{
    public interface IProductInventoryRepository : IGenericRepository<ProductInventory>
    {
        Task<IEnumerable<ProductInventory>> GetAllAsync();

        Task<ProductInventory?> GetByIdAsync(int productInventoryId);

        Task<IEnumerable<ProductInventory>> GetBySellerIdAsync(int sellerId);

        Task<IEnumerable<ProductInventory>> GetByProductIdAsync(int productId);

        Task<IEnumerable<ProductInventory>> GetByWarehouseIdAsync(int warehouseId);

        Task<ProductInventory?> GetInventoryAsync(int sellerId,int productId,int warehouseId,int locationId);
        Task AddAsync(ProductInventory productInventory);
        Task<IEnumerable<ProductInventory>> GetBySellerCustomerAsync(int sellerId,int customerId);
        Task UpdateAsync(ProductInventory productInventory);

        Task DeleteAsync(int productInventoryId);

        Task SaveChangesAsync();
    }
}

using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductInventories.DTOs;

namespace Marketplacesellerportal.ProductInventories.Interfaces
{
    public interface IProductInventoryRepository
    {
        Task<IEnumerable<ProductInventory>> GetAllAsync();

        Task<ProductInventory?> GetByIdAsync(
            int productInventoryId);

        Task<IEnumerable<ProductInventory>> GetByProductIdAsync(
            int productId);

        Task<IEnumerable<ProductInventory>> GetByProductIdsAsync(
            IEnumerable<int> productIds);

        Task<IEnumerable<ProductInventory>> GetBySellerIdAsync(
            int sellerId);

        Task<IEnumerable<ProductInventory>> GetByWarehouseIdAsync(
            int warehouseId);

        Task<IEnumerable<ProductInventory>> GetBySellerCustomerAsync(
            int sellerId,
            int customerId);

        Task<ProductInventory?> GetInventoryAsync(
            int productId,
            int warehouseId,
            int locationId);

        Task AddAsync(ProductInventory inventory);

        Task UpdateAsync(ProductInventory inventory);

        Task DeleteAsync(int productInventoryId);

        Task SaveChangesAsync();

        Task<IEnumerable<ProductInventory>> SearchAsync(
            string? search,
            string? status);

        Task<ProductInventoryStatistics>
            GetStatisticsAsync();

        Task<(
            IEnumerable<ProductInventory> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit);

        Task<IEnumerable<ProductInventory>>
            GetSortedAsync(string? sort);
    }
}
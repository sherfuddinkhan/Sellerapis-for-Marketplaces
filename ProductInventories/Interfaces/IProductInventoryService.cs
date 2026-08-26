using Marketplacesellerportal.ProductInventories.DTOs;

namespace Marketplacesellerportal.ProductInventories.Interfaces
{
    public interface IProductInventoryService
    {
        Task<IEnumerable<ProductInventoryModel>>
            GetAllAsync();

        Task<ProductInventoryModel?>
            GetByIdAsync(
                int productInventoryId);

        Task<IEnumerable<ProductInventoryModel>>
            GetByProductIdAsync(
                int productId);

        Task<IEnumerable<ProductInventoryModel>>
            GetByProductIdsAsync(
                IEnumerable<int> productIds);

        Task<IEnumerable<ProductInventoryModel>>
            GetBySellerIdAsync(
                int sellerId);

        Task<IEnumerable<ProductInventoryModel>>
            GetByWarehouseIdAsync(
                int warehouseId);

        Task<IEnumerable<ProductInventoryModel>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId);

        Task<ProductInventoryModel?>
            GetInventoryAsync(
                int productId,
                int warehouseId,
                int locationId);

        Task<ProductInventoryModel>
            CreateAsync(
                ProductInventoryModel model);

        Task<bool>
            UpdateAsync(
                int productInventoryId,
                ProductInventoryModel model);

        Task<bool>
            DeleteAsync(
                int productInventoryId);

        Task<IEnumerable<ProductInventoryModel>>
            SearchAsync(
                string? search,
                string? status);

        Task<ProductInventoryStatistics>
            GetStatisticsAsync();

        Task<(
            IEnumerable<ProductInventoryModel> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit);

        Task<IEnumerable<ProductInventoryModel>>
            GetSortedAsync(
                string? sort);
    }
}
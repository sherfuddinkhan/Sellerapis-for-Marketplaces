using MarketplaceOrderItemEntity =
    MarketplaceSellerPortal.Models.MarketplaceOrderItem;

using Marketplacesellerportal.MarketplaceOrderItems.DTOs;

namespace Marketplacesellerportal.MarketplaceOrderItems.Interfaces
{
    public interface IMarketplaceOrderItemRepository
    {
        // =========================================================
        // BASIC
        // =========================================================

        Task<IEnumerable<MarketplaceOrderItemEntity>>
            GetAllAsync();

        Task<MarketplaceOrderItemEntity?>
            GetByIdAsync(
                int marketplaceOrderItemId);


        // =========================================================
        // MARKETPLACE ORDER
        // =========================================================

        Task<IEnumerable<MarketplaceOrderItemEntity>>
            GetByMarketplaceOrderIdAsync(
                int marketplaceOrderId);


        // =========================================================
        // PRODUCT
        // =========================================================

        Task<IEnumerable<MarketplaceOrderItemEntity>>
            GetByProductIdAsync(
                int productId);


        // =========================================================
        // SELLER
        // =========================================================

        Task<IEnumerable<MarketplaceOrderItemEntity>>
            GetBySellerIdAsync(
                int sellerId);


        // =========================================================
        // CUSTOMER
        // =========================================================

        Task<IEnumerable<MarketplaceOrderItemEntity>>
            GetByCustomerIdAsync(
                int customerId);


        // =========================================================
        // SELLER + CUSTOMER
        // =========================================================

        Task<IEnumerable<MarketplaceOrderItemEntity>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId);


        // =========================================================
        // STATUS
        // =========================================================

        Task<IEnumerable<MarketplaceOrderItemEntity>>
            GetByStatusAsync(
                string status);


        // =========================================================
        // SEARCH
        // =========================================================

        Task<IEnumerable<MarketplaceOrderItemEntity>>
            SearchAsync(
                string? search,
                string? status);


        // =========================================================
        // STATISTICS
        // =========================================================

        Task<MarketplaceOrderItemStatistics>
            GetStatisticsAsync();


        // =========================================================
        // PAGINATION
        // =========================================================

        Task<(
            IEnumerable<MarketplaceOrderItemEntity> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit);


        // =========================================================
        // SORTING
        // =========================================================

        Task<IEnumerable<MarketplaceOrderItemEntity>>
            GetSortedAsync(
                string? sort);


        // =========================================================
        // CRUD
        // =========================================================

        Task AddAsync(
            MarketplaceOrderItemEntity item);

        Task UpdateAsync(
            MarketplaceOrderItemEntity item);

        Task DeleteAsync(
            int marketplaceOrderItemId);

        Task SaveChangesAsync();
    }
}
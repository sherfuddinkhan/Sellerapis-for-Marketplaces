using Marketplacesellerportal.Models;
using Marketplacesellerportal.MarketplaceOrderItems.DTOs;

namespace Marketplacesellerportal.MarketplaceOrderItems.Interfaces
{
    public interface IMarketplaceOrderItemRepository
    {
        // =========================================================
        // BASIC
        // =========================================================

        Task<IEnumerable<MarketplaceOrderItem>>
            GetAllAsync();

        Task<MarketplaceOrderItem?>
            GetByIdAsync(
                int marketplaceOrderItemId);


        // =========================================================
        // MARKETPLACE ORDER
        // =========================================================

        Task<IEnumerable<MarketplaceOrderItem>>
            GetByMarketplaceOrderIdAsync(
                int marketplaceOrderId);


        // =========================================================
        // PRODUCT
        // =========================================================

        Task<IEnumerable<MarketplaceOrderItem>>
            GetByProductIdAsync(
                int productId);


        // =========================================================
        // SELLER
        // =========================================================

        Task<IEnumerable<MarketplaceOrderItem>>
            GetBySellerIdAsync(
                int sellerId);


        // =========================================================
        // CUSTOMER
        // =========================================================

        Task<IEnumerable<MarketplaceOrderItem>>
            GetByCustomerIdAsync(
                int customerId);


        // =========================================================
        // SELLER + CUSTOMER
        // =========================================================

        Task<IEnumerable<MarketplaceOrderItem>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId);


        // =========================================================
        // STATUS
        // =========================================================

        Task<IEnumerable<MarketplaceOrderItem>>
            GetByStatusAsync(
                string status);


        // =========================================================
        // SEARCH
        // =========================================================

        Task<IEnumerable<MarketplaceOrderItem>>
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
            IEnumerable<MarketplaceOrderItem> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit);


        // =========================================================
        // SORTING
        // =========================================================

        Task<IEnumerable<MarketplaceOrderItem>>
            GetSortedAsync(
                string? sort);


        // =========================================================
        // CRUD
        // =========================================================

        Task AddAsync(
            MarketplaceOrderItem item);

        Task UpdateAsync(
            MarketplaceOrderItem item);

        Task DeleteAsync(
            int marketplaceOrderItemId);

        Task SaveChangesAsync();
    }
}

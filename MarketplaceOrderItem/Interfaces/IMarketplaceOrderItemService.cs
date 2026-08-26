using Marketplacesellerportal.Models;
using Marketplacesellerportal.MarketplaceOrderItems.DTOs;

namespace Marketplacesellerportal.MarketplaceOrderItems.Interfaces
{
    public interface IMarketplaceOrderItemService
    {
        Task<IEnumerable<MarketplaceOrderItem>>
            GetAllAsync();

        Task<MarketplaceOrderItem?>
            GetByIdAsync(
                int marketplaceOrderItemId);

        Task<IEnumerable<MarketplaceOrderItem>>
            GetByMarketplaceOrderIdAsync(
                int marketplaceOrderId);

        Task<IEnumerable<MarketplaceOrderItem>>
            GetByProductIdAsync(
                int productId);

        Task<IEnumerable<MarketplaceOrderItem>>
            GetBySellerIdAsync(
                int sellerId);

        Task<IEnumerable<MarketplaceOrderItem>>
            GetByCustomerIdAsync(
                int customerId);

        Task<IEnumerable<MarketplaceOrderItem>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId);

        Task<IEnumerable<MarketplaceOrderItem>>
            GetByStatusAsync(
                string status);

        Task<IEnumerable<MarketplaceOrderItem>>
            SearchAsync(
                string? search,
                string? status);

        Task<MarketplaceOrderItemStatistics>
            GetStatisticsAsync();

        Task<(
            IEnumerable<MarketplaceOrderItem> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit);

        Task<IEnumerable<MarketplaceOrderItem>>
            GetSortedAsync(
                string? sort);

        Task<MarketplaceOrderItem>
            CreateAsync(
                MarketplaceOrderItem item);

        Task<bool>
            UpdateAsync(
                int marketplaceOrderItemId,
                MarketplaceOrderItem item);

        Task<bool>
            DeleteAsync(
                int marketplaceOrderItemId);
    }
}

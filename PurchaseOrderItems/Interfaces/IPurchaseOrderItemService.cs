using Marketplacesellerportal.Models;
using Marketplacesellerportal.PurchaseOrderItems.DTOs;

namespace Marketplacesellerportal.PurchaseOrderItems.Interfaces
{
    public interface IPurchaseOrderItemService
    {
        Task<IEnumerable<PurchaseOrderItem>>
            GetAllAsync();

        Task<PurchaseOrderItem?>
            GetByIdAsync(
                int purchaseOrderItemId);

        Task<IEnumerable<PurchaseOrderItem>>
            GetByPurchaseOrderIdAsync(
                int purchaseOrderId);

        Task<PurchaseOrderItem?>
            GetByPurchaseOrderAndItemIdAsync(
                int purchaseOrderId,
                int purchaseOrderItemId);

        Task<IEnumerable<PurchaseOrderItem>>
            GetByPurchaseOrdersAsync(
                int sellerId,
                int customerId,
                List<int> purchaseOrderIds);

        Task<IEnumerable<PurchaseOrderItem>>
            SearchAsync(
                string? search);

        Task<PurchaseOrderItemStatistics>
            GetStatisticsAsync();

        Task<(
            IEnumerable<PurchaseOrderItem> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit);

        Task<IEnumerable<PurchaseOrderItem>>
            GetSortedAsync(
                string? sort);

        Task<PurchaseOrderItem>
            CreateAsync(
                PurchaseOrderItem item);

        Task<bool>
            UpdateAsync(
                int purchaseOrderItemId,
                PurchaseOrderItem item);

        Task<bool>
            DeleteAsync(
                int purchaseOrderItemId);
    }
}
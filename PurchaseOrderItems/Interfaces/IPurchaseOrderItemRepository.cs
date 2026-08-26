using Marketplacesellerportal.Models;
using Marketplacesellerportal.PurchaseOrderItems.DTOs;

namespace Marketplacesellerportal.PurchaseOrderItems.Interfaces
{
    public interface IPurchaseOrderItemRepository
    {
        // =========================================================
        // GET ALL
        // =========================================================

        Task<IEnumerable<PurchaseOrderItem>> GetAllAsync();


        // =========================================================
        // GET BY ID
        // =========================================================

        Task<PurchaseOrderItem?> GetByIdAsync(
            int purchaseOrderItemId);


        // =========================================================
        // GET BY PURCHASE ORDER + ITEM
        // =========================================================

        Task<PurchaseOrderItem?> GetByPurchaseOrderAndItemIdAsync(
            int purchaseOrderId,
            int purchaseOrderItemId);


        // =========================================================
        // GET BY PURCHASE ORDER
        // =========================================================

        Task<IEnumerable<PurchaseOrderItem>> GetByPurchaseOrderIdAsync(
            int purchaseOrderId);


        // =========================================================
        // GET BY SELLER + CUSTOMER + PURCHASE ORDERS
        // =========================================================

        Task<IEnumerable<PurchaseOrderItem>> GetByPurchaseOrdersAsync(
            int sellerId,
            int customerId,
            List<int> purchaseOrderIds);


        // =========================================================
        // SEARCH
        // GET:
        // /api/purchase-order-items?search=sku-882
        // =========================================================

        Task<IEnumerable<PurchaseOrderItem>> SearchAsync(
            string? search);


        // =========================================================
        // STATISTICS
        // GET:
        // /api/purchase-order-items/stats
        // =========================================================

        Task<PurchaseOrderItemStatistics> GetStatisticsAsync();


        // =========================================================
        // PAGINATION
        // GET:
        // /api/purchase-order-items?page=1&limit=25
        // =========================================================

        Task<(
            IEnumerable<PurchaseOrderItem> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit);


        // =========================================================
        // SORTING
        // GET:
        // /api/purchase-order-items?sort=line_no
        // =========================================================

        Task<IEnumerable<PurchaseOrderItem>> GetSortedAsync(
            string? sort);


        // =========================================================
        // CREATE
        // =========================================================

        Task AddAsync(
            PurchaseOrderItem item);


        // =========================================================
        // UPDATE
        // =========================================================

        Task UpdateAsync(
            PurchaseOrderItem item);


        // =========================================================
        // DELETE
        // =========================================================

        Task DeleteAsync(
            int purchaseOrderItemId);


        // =========================================================
        // SAVE
        // =========================================================

        Task SaveChangesAsync();
    }
}
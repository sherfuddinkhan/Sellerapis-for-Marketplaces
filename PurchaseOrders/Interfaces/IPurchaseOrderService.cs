using Marketplacesellerportal.Models;
using Marketplacesellerportal.PurchaseOrders.DTOs;

namespace Marketplacesellerportal.PurchaseOrders.Interfaces
{
    public interface IPurchaseOrderService
    {
        Task<IEnumerable<PurchaseOrder>> GetAllAsync();

        Task<PurchaseOrder?> GetByIdAsync(
            int purchaseOrderId);

        Task<IEnumerable<PurchaseOrder>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId);

        Task<IEnumerable<PurchaseOrder>>
            GetBySupplierIdAsync(
                int supplierId);

        Task<PurchaseOrder?>
            GetBySellerAndPurchaseOrderIdAsync(
                int sellerId,
                int purchaseOrderId);

        Task<PurchaseOrder?>
            GetBySellerSupplierAndPurchaseOrderIdAsync(
                int sellerId,
                int supplierId,
                int purchaseOrderId);

        // SEARCH
        Task<IEnumerable<PurchaseOrder>>
            SearchAsync(string? search);

        // STATISTICS
        Task<PurchaseOrderStatistics>
            GetStatisticsAsync();

        // PAGINATION
        Task<(IEnumerable<PurchaseOrder> Items, int TotalCount)>
            GetPagedAsync(
                int page,
                int limit);

        // STATUS
        Task<IEnumerable<PurchaseOrder>>
            GetByStatusAsync(
                string status);

        // CREATE
        Task<PurchaseOrder>
            CreateAsync(
                PurchaseOrder purchaseOrder);
        Task<IEnumerable<PurchaseOrder>> GetSortedAsync(
    string? sort);
        // UPDATE
        Task<bool>
            UpdateAsync(
                int purchaseOrderId,
                PurchaseOrder purchaseOrder);

        // DELETE
        Task<bool>
            DeleteAsync(
                int purchaseOrderId);
    }
}
using Marketplacesellerportal.Models;
using Marketplacesellerportal.PurchaseOrders.DTOs;

public interface IPurchaseOrderRepository
{
    // =========================================================
    // GET ALL
    // =========================================================

    Task<IEnumerable<PurchaseOrder>> GetAllAsync();

    Task<IEnumerable<PurchaseOrder>> GetSortedAsync(
    string? sort);
    // =========================================================
    // GET BY ID
    // =========================================================

    Task<PurchaseOrder?> GetByIdAsync(
        int purchaseOrderId);


    // =========================================================
    // SELLER + CUSTOMER
    // =========================================================

    Task<IEnumerable<PurchaseOrder>> GetBySellerCustomerAsync(
        int sellerId,
        int customerId);


    // =========================================================
    // SUPPLIER
    // =========================================================

    Task<IEnumerable<PurchaseOrder>> GetBySupplierIdAsync(
        int supplierId);


    // =========================================================
    // SELLER + PURCHASE ORDER
    // =========================================================

    Task<PurchaseOrder?> GetBySellerAndPurchaseOrderIdAsync(
        int sellerId,
        int purchaseOrderId);


    // =========================================================
    // SELLER + SUPPLIER + PURCHASE ORDER
    // =========================================================

    Task<PurchaseOrder?> GetBySellerSupplierAndPurchaseOrderIdAsync(
        int sellerId,
        int supplierId,
        int purchaseOrderId);


    // =========================================================
    // SEARCH
    // GET:
    // /api/purchase-orders?search=PO-5520
    // =========================================================

    Task<IEnumerable<PurchaseOrder>> SearchAsync(
        string? search);


    // =========================================================
    // STATISTICS
    // GET:
    // /api/purchase-orders/stats
    // =========================================================

    Task<PurchaseOrderStatistics> GetStatisticsAsync();


    // =========================================================
    // PAGINATION
    // GET:
    // /api/purchase-orders?page=1&limit=10
    // =========================================================

    Task<(IEnumerable<PurchaseOrder> Items, int TotalCount)>
        GetPagedAsync(
            int page,
            int limit);


    // =========================================================
    // STATUS FILTER
    // GET:
    // /api/purchase-orders?status=pending_approval
    // =========================================================

    Task<IEnumerable<PurchaseOrder>> GetByStatusAsync(
        string status);


    // =========================================================
    // CREATE
    // =========================================================

    Task AddAsync(
        PurchaseOrder purchaseOrder);


    // =========================================================
    // UPDATE
    // =========================================================

    Task UpdateAsync(
        PurchaseOrder purchaseOrder);


    // =========================================================
    // DELETE
    // =========================================================

    Task DeleteAsync(
        int purchaseOrderId);


    // =========================================================
    // SAVE
    // =========================================================

    Task SaveChangesAsync();
}
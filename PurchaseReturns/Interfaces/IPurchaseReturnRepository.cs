using Marketplacesellerportal.Models;
using Marketplacesellerportal.PurchaseReturns.DTOs;

namespace Marketplacesellerportal.PurchaseReturns.Interfaces
{
    public interface IPurchaseReturnRepository
    {
        // =========================================================
        // BASIC
        // =========================================================

        Task<IEnumerable<PurchaseReturn>>
            GetAllAsync();

        Task<PurchaseReturn?>
            GetByIdAsync(
                int purchaseReturnId);


        // =========================================================
        // PURCHASE ORDER
        // =========================================================

        Task<IEnumerable<PurchaseReturn>>
            GetByPurchaseOrderIdAsync(
                int purchaseOrderId);


        // =========================================================
        // SUPPLIER
        // =========================================================

        Task<IEnumerable<PurchaseReturn>>
            GetBySupplierIdAsync(
                int supplierId);


        // =========================================================
        // GOODS RECEIPT NOTE
        // =========================================================

        Task<IEnumerable<PurchaseReturn>>
            GetByGoodsReceiptNoteIdAsync(
                int goodsReceiptNoteId);


        // =========================================================
        // SELLER
        // =========================================================

        Task<IEnumerable<PurchaseReturn>>
            GetBySellerIdAsync(
                int sellerId);


        // =========================================================
        // CUSTOMER
        // =========================================================

        Task<IEnumerable<PurchaseReturn>>
            GetByCustomerIdAsync(
                int customerId);


        // =========================================================
        // SELLER + CUSTOMER
        // =========================================================

        Task<IEnumerable<PurchaseReturn>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId);


        // =========================================================
        // STATUS
        // =========================================================

        Task<IEnumerable<PurchaseReturn>>
            GetByStatusAsync(
                string status);


        // =========================================================
        // SPECIFIC PURCHASE RETURN
        // =========================================================

        Task<PurchaseReturn?>
            GetPurchaseReturnAsync(
                int purchaseOrderId,
                int supplierId,
                int purchaseReturnId);


        // =========================================================
        // SEARCH
        // =========================================================

        Task<IEnumerable<PurchaseReturn>>
            SearchAsync(
                string? search,
                string? status);


        // =========================================================
        // STATISTICS
        // =========================================================

        Task<PurchaseReturnStatistics>
            GetStatisticsAsync();


        // =========================================================
        // PAGINATION
        // =========================================================

        Task<(
            IEnumerable<PurchaseReturn> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit);


        // =========================================================
        // SORTING
        // =========================================================

        Task<IEnumerable<PurchaseReturn>>
            GetSortedAsync(
                string? sort);


        // =========================================================
        // CRUD
        // =========================================================

        Task AddAsync(
            PurchaseReturn purchaseReturn);

        Task UpdateAsync(
            PurchaseReturn purchaseReturn);

        Task DeleteAsync(
            int purchaseReturnId);

        Task SaveChangesAsync();
    }
}
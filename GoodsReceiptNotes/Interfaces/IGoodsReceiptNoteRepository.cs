using Marketplacesellerportal.Models;
using Marketplacesellerportal.GoodsReceiptNotes.DTOs;

namespace Marketplacesellerportal.GoodsReceiptNotes.Interfaces
{
    public interface IGoodsReceiptNoteRepository
    {
        // =========================================================
        // BASIC
        // =========================================================

        Task<IEnumerable<GoodsReceiptNote>>
            GetAllAsync();

        Task<GoodsReceiptNote?>
            GetByIdAsync(
                int goodsReceiptNoteId);


        // =========================================================
        // PURCHASE ORDER
        // =========================================================

        Task<IEnumerable<GoodsReceiptNote>>
            GetByPurchaseOrderIdAsync(
                int purchaseOrderId);


        // =========================================================
        // SELLER
        // =========================================================

        Task<IEnumerable<GoodsReceiptNote>>
            GetBySellerIdAsync(
                int sellerId);


        // =========================================================
        // CUSTOMER
        // =========================================================

        Task<IEnumerable<GoodsReceiptNote>>
            GetByCustomerIdAsync(
                int customerId);


        // =========================================================
        // SUPPLIER
        // =========================================================

        Task<IEnumerable<GoodsReceiptNote>>
            GetBySupplierIdAsync(
                int supplierId);


        // =========================================================
        // SELLER + CUSTOMER
        // =========================================================

        Task<IEnumerable<GoodsReceiptNote>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId);


        // =========================================================
        // STATUS
        // =========================================================

        Task<IEnumerable<GoodsReceiptNote>>
            GetByStatusAsync(
                string status);


        // =========================================================
        // SPECIFIC PURCHASE ORDER + GRN
        // =========================================================

        Task<GoodsReceiptNote?>
            GetByPurchaseOrderAndGRNAsync(
                int purchaseOrderId,
                int goodsReceiptNoteId);


        // =========================================================
        // SEARCH
        //
        // /api/goods-receipt-notes?search=GRN-998
        // /api/goods-receipt-notes?status=inspected
        // =========================================================

        Task<IEnumerable<GoodsReceiptNote>>
            SearchAsync(
                string? search,
                string? status);


        // =========================================================
        // STATISTICS
        //
        // /api/goods-receipt-notes/stats
        // =========================================================

        Task<GoodsReceiptNoteStatistics>
            GetStatisticsAsync();


        // =========================================================
        // PAGINATION
        //
        // /api/goods-receipt-notes?page=1&limit=15
        // =========================================================

        Task<(
            IEnumerable<GoodsReceiptNote> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit);


        // =========================================================
        // SORTING
        //
        // grn_asc
        // grn_desc
        // date_asc
        // date_desc
        // quantity_asc
        // quantity_desc
        // amount_asc
        // amount_desc
        // status_asc
        // status_desc
        // =========================================================

        Task<IEnumerable<GoodsReceiptNote>>
            GetSortedAsync(
                string? sort);


        // =========================================================
        // CREATE
        // =========================================================

        Task AddAsync(
            GoodsReceiptNote goodsReceiptNote);


        // =========================================================
        // UPDATE
        // =========================================================

        Task UpdateAsync(
            GoodsReceiptNote goodsReceiptNote);


        // =========================================================
        // DELETE
        // =========================================================

        Task DeleteAsync(
            int goodsReceiptNoteId);


        // =========================================================
        // SAVE
        // =========================================================

        Task SaveChangesAsync();
    }
}
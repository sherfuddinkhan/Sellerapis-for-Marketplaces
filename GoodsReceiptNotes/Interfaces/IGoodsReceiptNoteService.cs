using Marketplacesellerportal.Models;
using Marketplacesellerportal.GoodsReceiptNotes.DTOs;

namespace Marketplacesellerportal.GoodsReceiptNotes.Interfaces
{
    public interface IGoodsReceiptNoteService
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


        Task<GoodsReceiptNote?>
            GetByPurchaseOrderAndGRNAsync(
                int purchaseOrderId,
                int goodsReceiptNoteId);


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
        // SEARCH
        // =========================================================

        Task<IEnumerable<GoodsReceiptNote>>
            SearchAsync(
                string? search,
                string? status);


        // =========================================================
        // STATISTICS
        // =========================================================

        Task<GoodsReceiptNoteStatistics>
            GetStatisticsAsync();


        // =========================================================
        // PAGINATION
        // =========================================================

        Task<(
            IEnumerable<GoodsReceiptNote> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit);


        // =========================================================
        // SORTING
        // =========================================================

        Task<IEnumerable<GoodsReceiptNote>>
            GetSortedAsync(
                string? sort);


        // =========================================================
        // CRUD
        // =========================================================

        Task<GoodsReceiptNote>
            CreateAsync(
                GoodsReceiptNote grn);


        Task<bool>
            UpdateAsync(
                int goodsReceiptNoteId,
                GoodsReceiptNote grn);


        Task<bool>
            DeleteAsync(
                int goodsReceiptNoteId);
    }
}
using Marketplacesellerportal.Models;
using Marketplacesellerportal.GoodsReceiptItems.DTOs;

namespace Marketplacesellerportal.GoodsReceiptItems.Interfaces
{
    public interface IGoodsReceiptItemRepository
    {
        // =========================================================
        // BASIC
        // =========================================================

        Task<IEnumerable<GoodsReceiptItem>>
            GetAllAsync();

        Task<GoodsReceiptItem?>
            GetByIdAsync(
                int goodsReceiptItemId);


        // =========================================================
        // GOODS RECEIPT NOTE
        // =========================================================

        Task<IEnumerable<GoodsReceiptItem>>
            GetByGoodsReceiptNoteIdAsync(
                int goodsReceiptNoteId);

        Task<GoodsReceiptItem?>
            GetByGoodsReceiptNoteAndItemAsync(
                int goodsReceiptNoteId,
                int goodsReceiptItemId);


        // =========================================================
        // PRODUCT
        // =========================================================

        Task<IEnumerable<GoodsReceiptItem>>
            GetByProductIdAsync(
                int productId);


        // =========================================================
        // SELLER
        // =========================================================

        Task<IEnumerable<GoodsReceiptItem>>
            GetBySellerIdAsync(
                int sellerId);


        // =========================================================
        // CUSTOMER
        // =========================================================

        Task<IEnumerable<GoodsReceiptItem>>
            GetByCustomerIdAsync(
                int customerId);


        // =========================================================
        // SELLER + CUSTOMER
        // =========================================================

        Task<IEnumerable<GoodsReceiptItem>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId);


        // =========================================================
        // SEARCH
        // =========================================================

        Task<IEnumerable<GoodsReceiptItem>>
            SearchAsync(
                string? search);


        // =========================================================
        // STATISTICS
        // =========================================================

        Task<GoodsReceiptNoteItemStatistics>
            GetStatisticsAsync();


        // =========================================================
        // PAGINATION
        // =========================================================

        Task<(
            IEnumerable<GoodsReceiptItem> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit);


        // =========================================================
        // SORTING
        // =========================================================

        Task<IEnumerable<GoodsReceiptItem>>
            GetSortedAsync(
                string? sort);


        // =========================================================
        // CRUD
        // =========================================================

        Task AddAsync(
            GoodsReceiptItem goodsReceiptItem);

        Task UpdateAsync(
            GoodsReceiptItem goodsReceiptItem);

        Task DeleteAsync(
            int goodsReceiptItemId);

        Task SaveChangesAsync();
    }
}


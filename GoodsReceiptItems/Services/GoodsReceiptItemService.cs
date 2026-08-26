using Marketplacesellerportal.Models;
using Marketplacesellerportal.GoodsReceiptItems.DTOs;
using Marketplacesellerportal.GoodsReceiptItems.Interfaces;

namespace Marketplacesellerportal.GoodsReceiptItems.Services
{
    public class GoodsReceiptItemService : IGoodsReceiptItemService
    {
        private readonly IGoodsReceiptItemRepository _repository;

        public GoodsReceiptItemService(
            IGoodsReceiptItemRepository repository)
        {
            _repository = repository;
        }

        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptItem>>
            GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<GoodsReceiptItem?>
            GetByIdAsync(
                int goodsReceiptItemId)
        {
            return await _repository.GetByIdAsync(
                goodsReceiptItemId);
        }

        // =========================================================
        // GET BY GOODS RECEIPT NOTE
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptItem>>
            GetByGoodsReceiptNoteIdAsync(
                int goodsReceiptNoteId)
        {
            return await _repository
                .GetByGoodsReceiptNoteIdAsync(
                    goodsReceiptNoteId);
        }

        // =========================================================
        // GET BY GRN + ITEM
        // =========================================================

        public async Task<GoodsReceiptItem?>
            GetByGoodsReceiptNoteAndItemAsync(
                int goodsReceiptNoteId,
                int goodsReceiptItemId)
        {
            return await _repository
                .GetByGoodsReceiptNoteAndItemAsync(
                    goodsReceiptNoteId,
                    goodsReceiptItemId);
        }

        // =========================================================
        // GET BY PRODUCT
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptItem>>
            GetByProductIdAsync(
                int productId)
        {
            return await _repository
                .GetByProductIdAsync(
                    productId);
        }

        // =========================================================
        // GET BY SELLER
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptItem>>
            GetBySellerIdAsync(
                int sellerId)
        {
            return await _repository
                .GetBySellerIdAsync(
                    sellerId);
        }

        // =========================================================
        // GET BY CUSTOMER
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptItem>>
            GetByCustomerIdAsync(
                int customerId)
        {
            return await _repository
                .GetByCustomerIdAsync(
                    customerId);
        }

        // =========================================================
        // GET BY SELLER + CUSTOMER
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptItem>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId)
        {
            return await _repository
                .GetBySellerCustomerAsync(
                    sellerId,
                    customerId);
        }

        // =========================================================
        // SEARCH
        //
        // Example:
        // /api/goods-receipt-note-items?search=554
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptItem>>
            SearchAsync(
                string? search)
        {
            return await _repository
                .SearchAsync(search);
        }

        // =========================================================
        // STATISTICS
        // =========================================================

        public async Task<GoodsReceiptNoteItemStatistics>
            GetStatisticsAsync()
        {
            return await _repository
                .GetStatisticsAsync();
        }

        // =========================================================
        // PAGINATION
        //
        // Example:
        // /api/goods-receipt-note-items?page=1&limit=25
        // =========================================================

        public async Task<(
            IEnumerable<GoodsReceiptItem> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 25;

            if (limit > 100)
                limit = 100;

            return await _repository
                .GetPagedAsync(
                    page,
                    limit);
        }

        // =========================================================
        // SORTING
        //
        // Example:
        // /api/goods-receipt-note-items?sort=line_number
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptItem>>
            GetSortedAsync(
                string? sort)
        {
            return await _repository
                .GetSortedAsync(sort);
        }

        // =========================================================
        // CREATE
        // =========================================================

        public async Task<GoodsReceiptItem>
            CreateAsync(
                GoodsReceiptItem goodsReceiptItem)
        {
            await _repository.AddAsync(
                goodsReceiptItem);

            await _repository.SaveChangesAsync();

            return goodsReceiptItem;
        }

        // =========================================================
        // UPDATE
        // =========================================================

        public async Task<bool>
            UpdateAsync(
                int goodsReceiptItemId,
                GoodsReceiptItem goodsReceiptItem)
        {
            var existing =
                await _repository.GetByIdAsync(
                    goodsReceiptItemId);

            if (existing == null)
                return false;

            existing.GoodsReceiptNoteId =
                goodsReceiptItem.GoodsReceiptNoteId;

            existing.SellerId =
                goodsReceiptItem.SellerId;

            existing.CustomerId =
                goodsReceiptItem.CustomerId;

            existing.ProductId =
                goodsReceiptItem.ProductId;

            existing.ReceivedQuantity =
                goodsReceiptItem.ReceivedQuantity;

            existing.AcceptedQuantity =
                goodsReceiptItem.AcceptedQuantity;

            existing.RejectedQuantity =
                goodsReceiptItem.RejectedQuantity;

            existing.Remarks =
                goodsReceiptItem.Remarks;

            await _repository.UpdateAsync(
                existing);

            await _repository.SaveChangesAsync();

            return true;
        }

        // =========================================================
        // DELETE
        // =========================================================

        public async Task<bool>
            DeleteAsync(
                int goodsReceiptItemId)
        {
            var existing =
                await _repository.GetByIdAsync(
                    goodsReceiptItemId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(
                goodsReceiptItemId);

            await _repository.SaveChangesAsync();

            return true;
        }
    }
}


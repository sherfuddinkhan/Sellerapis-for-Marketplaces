using Marketplacesellerportal.Models;
using Marketplacesellerportal.GoodsReceiptItems.Interfaces;

namespace Marketplacesellerportal.GoodsReceiptItems.Services
{
    public class GoodsReceiptItemService : IGoodsReceiptItemService
    {
        private readonly IGoodsReceiptItemRepository _repository;

        public GoodsReceiptItemService(IGoodsReceiptItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GoodsReceiptItem>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<GoodsReceiptItem?> GetByIdAsync(int goodsReceiptItemId)
        {
            return await _repository.GetByIdAsync(goodsReceiptItemId);
        }

        public async Task<IEnumerable<GoodsReceiptItem>> GetByGoodsReceiptNoteIdAsync(int goodsReceiptNoteId)
        {
            return await _repository.GetByGoodsReceiptNoteIdAsync(goodsReceiptNoteId);
        }

        public async Task<GoodsReceiptItem?> GetByGoodsReceiptNoteAndItemAsync(
            int goodsReceiptNoteId,
            int goodsReceiptItemId)
        {
            return await _repository.GetByGoodsReceiptNoteAndItemAsync(
                goodsReceiptNoteId,
                goodsReceiptItemId);
        }

        public async Task<GoodsReceiptItem> CreateAsync(GoodsReceiptItem goodsReceiptItem)
        {
            await _repository.AddAsync(goodsReceiptItem);
            await _repository.SaveChangesAsync();

            return goodsReceiptItem;
        }

        public async Task<bool> UpdateAsync(
            int goodsReceiptItemId,
            GoodsReceiptItem goodsReceiptItem)
        {
            var existing = await _repository.GetByIdAsync(goodsReceiptItemId);

            if (existing == null)
                return false;

            existing.GoodsReceiptNoteId = goodsReceiptItem.GoodsReceiptNoteId;
            existing.ProductId = goodsReceiptItem.ProductId;
            existing.ReceivedQuantity = goodsReceiptItem.ReceivedQuantity;
            existing.AcceptedQuantity = goodsReceiptItem.AcceptedQuantity;
            existing.RejectedQuantity = goodsReceiptItem.RejectedQuantity;
            existing.Remarks = goodsReceiptItem.Remarks;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int goodsReceiptItemId)
        {
            var existing = await _repository.GetByIdAsync(goodsReceiptItemId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(goodsReceiptItemId);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}

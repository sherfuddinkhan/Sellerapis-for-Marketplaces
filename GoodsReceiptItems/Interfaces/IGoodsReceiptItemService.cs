using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.GoodsReceiptItems.Interfaces
{
    public interface IGoodsReceiptItemService
    {
        Task<IEnumerable<GoodsReceiptItem>> GetAllAsync();

        Task<GoodsReceiptItem?> GetByIdAsync(int goodsReceiptItemId);

        Task<IEnumerable<GoodsReceiptItem>> GetByGoodsReceiptNoteIdAsync(int goodsReceiptNoteId);

        Task<GoodsReceiptItem?> GetByGoodsReceiptNoteAndItemAsync(
            int goodsReceiptNoteId,
            int goodsReceiptItemId);

        Task<GoodsReceiptItem> CreateAsync(GoodsReceiptItem goodsReceiptItem);

        Task<bool> UpdateAsync(int goodsReceiptItemId, GoodsReceiptItem goodsReceiptItem);

        Task<bool> DeleteAsync(int goodsReceiptItemId);
    }
}

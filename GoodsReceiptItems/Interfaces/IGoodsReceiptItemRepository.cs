using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.GoodsReceiptItems.Interfaces
{
    public interface IGoodsReceiptItemRepository
    {
        Task<IEnumerable<GoodsReceiptItem>> GetAllAsync();

        Task<GoodsReceiptItem?> GetByIdAsync(int goodsReceiptItemId);

        Task<IEnumerable<GoodsReceiptItem>> GetByGoodsReceiptNoteIdAsync(int goodsReceiptNoteId);
        Task<IEnumerable<GoodsReceiptItem>> GetBySellerCustomerAsync(
    int sellerId,
    int customerId);
        Task<GoodsReceiptItem?> GetByGoodsReceiptNoteAndItemAsync(
            int goodsReceiptNoteId,
            int goodsReceiptItemId);

        Task AddAsync(GoodsReceiptItem goodsReceiptItem);

        Task UpdateAsync(GoodsReceiptItem goodsReceiptItem);

        Task DeleteAsync(int goodsReceiptItemId);

        Task SaveChangesAsync();
    }
}

using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.GoodsReceiptNotes.Interfaces
{
    public interface IGoodsReceiptNoteRepository
    {
        Task<IEnumerable<GoodsReceiptNote>> GetAllAsync();

        Task<GoodsReceiptNote?> GetByIdAsync(int goodsReceiptNoteId);

        Task<IEnumerable<GoodsReceiptNote>> GetByPurchaseOrderIdAsync(int purchaseOrderId);

        Task AddAsync(GoodsReceiptNote goodsReceiptNote);
        Task<IEnumerable<GoodsReceiptNote>> GetBySellerCustomerAsync(
    int sellerId,
    int customerId);
        Task UpdateAsync(GoodsReceiptNote goodsReceiptNote);

        Task DeleteAsync(int goodsReceiptNoteId);
        Task<GoodsReceiptNote?> GetByPurchaseOrderAndGRNAsync(
    int purchaseOrderId,
    int goodsReceiptNoteId);

        Task SaveChangesAsync();
    }
}

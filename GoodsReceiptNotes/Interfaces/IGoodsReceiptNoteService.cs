using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.GoodsReceiptNotes.Interfaces
{
    public interface IGoodsReceiptNoteService
    {
        Task<IEnumerable<GoodsReceiptNote>> GetAllAsync();

        Task<GoodsReceiptNote?> GetByIdAsync(int goodsReceiptNoteId);

        Task<IEnumerable<GoodsReceiptNote>> GetByPurchaseOrderIdAsync(int purchaseOrderId);

        Task<GoodsReceiptNote?> GetByPurchaseOrderAndGRNAsync(
            int purchaseOrderId,
            int goodsReceiptNoteId);

        Task<GoodsReceiptNote> CreateAsync(GoodsReceiptNote grn);

        Task<bool> UpdateAsync(
            int goodsReceiptNoteId,
            GoodsReceiptNote grn);

        Task<bool> DeleteAsync(int goodsReceiptNoteId);
        
    }

}

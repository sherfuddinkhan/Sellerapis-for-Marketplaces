using Marketplacesellerportal.Models;
using Marketplacesellerportal.GoodsReceiptNotes.Interfaces;

namespace Marketplacesellerportal.GoodsReceiptNotes.Services
{
    public class GoodsReceiptNotesService : IGoodsReceiptNoteService
    {
        private readonly IGoodsReceiptNoteRepository _repository;

        public GoodsReceiptNotesService(IGoodsReceiptNoteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GoodsReceiptNote>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<GoodsReceiptNote?> GetByIdAsync(int goodsReceiptNoteId)
        {
            return await _repository.GetByIdAsync(goodsReceiptNoteId);
        }

        public async Task<IEnumerable<GoodsReceiptNote>> GetByPurchaseOrderIdAsync(int purchaseOrderId)
        {
            return await _repository.GetByPurchaseOrderIdAsync(purchaseOrderId);
        }

        public async Task<GoodsReceiptNote> CreateAsync(GoodsReceiptNote goodsReceiptNote)
        {
            goodsReceiptNote.CreatedDate = DateTime.Now;

            await _repository.AddAsync(goodsReceiptNote);
            await _repository.SaveChangesAsync();

            return goodsReceiptNote;
        }

        public async Task<bool> UpdateAsync(int goodsReceiptNoteId, GoodsReceiptNote goodsReceiptNote)
        {
            var existing = await _repository.GetByIdAsync(goodsReceiptNoteId);

            if (existing == null)
                return false;

            existing.PurchaseOrderId = goodsReceiptNote.PurchaseOrderId;
            existing.GRNNumber = goodsReceiptNote.GRNNumber;
            existing.ReceiptDate = goodsReceiptNote.ReceiptDate;
            existing.Status = goodsReceiptNote.Status;
            existing.Remarks = goodsReceiptNote.Remarks;
            existing.CreatedDate = goodsReceiptNote.CreatedDate;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int goodsReceiptNoteId)
        {
            var existing = await _repository.GetByIdAsync(goodsReceiptNoteId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(goodsReceiptNoteId);
            await _repository.SaveChangesAsync();

            return true;
        }

  public async Task<GoodsReceiptNote?> GetByPurchaseOrderAndGRNAsync(int purchaseOrderId,int goodsReceiptNoteId)
        {
            return await _repository.GetByPurchaseOrderAndGRNAsync(purchaseOrderId,goodsReceiptNoteId);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.GoodsReceiptNotes.Interfaces;

namespace Marketplacesellerportal.GoodsReceiptNotes.Repositories
{
    public class GoodsReceiptNotesRepository : IGoodsReceiptNoteRepository
    {
        private readonly ApplicationDbContext _context;

        public GoodsReceiptNotesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GoodsReceiptNote>> GetAllAsync()
        {
            return await _context.GoodsReceiptNotes.ToListAsync();
        }

        public async Task<GoodsReceiptNote?> GetByIdAsync(int goodsReceiptNoteId)
        {
            return await _context.GoodsReceiptNotes
                .FirstOrDefaultAsync(x => x.GoodsReceiptNoteId == goodsReceiptNoteId);
        }

        public async Task<IEnumerable<GoodsReceiptNote>> GetByPurchaseOrderIdAsync(int purchaseOrderId)
        {
            return await _context.GoodsReceiptNotes
                .Where(x => x.PurchaseOrderId == purchaseOrderId)
                .ToListAsync();
        }

        public async Task AddAsync(GoodsReceiptNote goodsReceiptNote)
        {
            await _context.GoodsReceiptNotes.AddAsync(goodsReceiptNote);
        }

        public Task UpdateAsync(GoodsReceiptNote goodsReceiptNote)
        {
            _context.GoodsReceiptNotes.Update(goodsReceiptNote);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int goodsReceiptNoteId)
        {
            var entity = await GetByIdAsync(goodsReceiptNoteId);

            if (entity != null)
                _context.GoodsReceiptNotes.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<GoodsReceiptNote?> GetByPurchaseOrderAndGRNAsync(
    int purchaseOrderId,
    int goodsReceiptNoteId)
        {
            return await _context.GoodsReceiptNotes
                .FirstOrDefaultAsync(x =>
                    x.PurchaseOrderId == purchaseOrderId &&
                    x.GoodsReceiptNoteId == goodsReceiptNoteId);
        }
    }
}

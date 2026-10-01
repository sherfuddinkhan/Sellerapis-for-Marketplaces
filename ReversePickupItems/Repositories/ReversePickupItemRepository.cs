using Marketplacesellerportal.Database;
using Marketplacesellerportal.Interfaces;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.ReversePickupItems.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.ReversePickupItems.Repositories
{
    public class ReversePickupItemRepository : IReversePickupItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ReversePickupItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ReversePickupItem>> GetAllAsync()
            => await _context.ReversePickupItems.ToListAsync();

        public async Task<ReversePickupItem?> GetByIdAsync(int id)
            => await _context.ReversePickupItems.FindAsync(id);

        public async Task<ReversePickupItem> CreateAsync(ReversePickupItem entity)
        {
            _context.ReversePickupItems.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(int id, ReversePickupItem entity)
        {
            var existing = await _context.ReversePickupItems.FindAsync(id);
            if (existing == null) return false;

            existing.ReversePickupId = entity.ReversePickupId;
            existing.SaleOrderItemCode = entity.SaleOrderItemCode;
            existing.Reason = entity.Reason;
            existing.ItemSku = entity.ItemSku;
            existing.TotalPrice = entity.TotalPrice;
            existing.SellingPrice = entity.SellingPrice;
            existing.Discount = entity.Discount;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.ReversePickupItems.FindAsync(id);
            if (entity == null) return false;

            _context.ReversePickupItems.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Interfaces;
using Marketplacesellerportal.Models;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.InventoryAdjustments.Repositories
{
    public class InventoryAdjustmentRepository
        : IInventoryAdjustmentRepository
    {
        private readonly ApplicationDbContext _context;

        public InventoryAdjustmentRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<InventoryAdjustment>>
            GetAllAsync()
        {
            return await _context.InventoryAdjustments
                .ToListAsync();
        }

        public async Task<InventoryAdjustment?>
            GetByIdAsync(int id)
        {
            return await _context.InventoryAdjustments
                .FindAsync(id);
        }

        public async Task<InventoryAdjustment>
            CreateAsync(InventoryAdjustment entity)
        {
            _context.InventoryAdjustments.Add(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool>
            UpdateAsync(InventoryAdjustment entity)
        {
            _context.InventoryAdjustments.Update(entity);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool>
            DeleteAsync(int id)
        {
            var entity =
                await _context.InventoryAdjustments
                    .FindAsync(id);

            if (entity == null)
                return false;

            _context.InventoryAdjustments.Remove(entity);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}

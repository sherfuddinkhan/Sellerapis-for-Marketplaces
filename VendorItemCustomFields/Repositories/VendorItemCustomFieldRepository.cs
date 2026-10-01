using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.VendorItemCustomFields.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.VendorItemCustomFields.Repositories
{
    public class VendorItemCustomFieldRepository : IVendorItemCustomFieldRepository
    {
        private readonly ApplicationDbContext _context;

        public VendorItemCustomFieldRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<VendorItemCustomField>> GetAllAsync()
        {
            return await _context.VendorItemCustomFields.ToListAsync();
        }

        public async Task<VendorItemCustomField?> GetByIdAsync(int id)
        {
            return await _context.VendorItemCustomFields.FindAsync(id);
        }

        public async Task<VendorItemCustomField> CreateAsync(VendorItemCustomField entity)
        {
            _context.VendorItemCustomFields.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        // FIXED: now (int id, entity) to match interface
        public async Task<bool> UpdateAsync(int id, VendorItemCustomField entity)
        {
            var existing = await _context.VendorItemCustomFields.FindAsync(id);
            if (existing == null) return false;

            existing.VendorItemMasterId = entity.VendorItemMasterId;
            existing.Name = entity.Name;
            existing.Value = entity.Value;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.VendorItemCustomFields.FindAsync(id);
            if (entity == null) return false;

            _context.VendorItemCustomFields.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Interfaces;
using Marketplacesellerportal.Models;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.Picklists.Repositories
{
    public class PicklistRepository
        : IPicklistRepository
    {
        private readonly ApplicationDbContext _context;

        public PicklistRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Picklist>> GetAllAsync()
            => await _context.Picklists.ToListAsync();

        public async Task<Picklist?> GetByIdAsync(int id)
            => await _context.Picklists.FindAsync(id);

        public async Task<Picklist> CreateAsync(
            Picklist entity)
        {
            _context.Picklists.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<bool> UpdateAsync(Picklist entity)
        {
            var existing = await _context.Picklists
                .FirstOrDefaultAsync(x => x.PicklistCode == entity.PicklistCode);

            if (existing == null)
                return false;

            existing.Destination = entity.Destination;
            existing.ShippingPackageCodes = entity.ShippingPackageCodes;
            existing.CreatedDate = entity.CreatedDate;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(string picklistCode)
        {
            var entity = await _context.Picklists
                .FirstOrDefaultAsync(x => x.PicklistCode == picklistCode);

            if (entity == null)
                return false;

            _context.Picklists.Remove(entity);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Picklist?> GetByCodeAsync(string picklistCode)
        {
            return await _context.Picklists
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.PicklistCode == picklistCode);
        }
    }
}

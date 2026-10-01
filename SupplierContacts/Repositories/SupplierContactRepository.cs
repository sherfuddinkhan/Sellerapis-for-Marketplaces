using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.SupplierContact.Interfaces;
using Microsoft.EntityFrameworkCore;

using SupplierContactModel = Marketplacesellerportal.Models.SupplierContacts;

namespace Marketplacesellerportal.SupplierContact.Repositories
{
    public class SupplierContactRepository : ISupplierContactRepository
    {
        private readonly ApplicationDbContext _context;

        public SupplierContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SupplierContactModel>> GetAllAsync()
        {
            return await _context.SupplierContacts
                .ToListAsync();
        }

        public async Task<SupplierContactModel?> GetByIdAsync(int id)
        {
            return await _context.SupplierContacts
                .FindAsync(id);
        }

        public async Task<SupplierContactModel> CreateAsync(
            SupplierContactModel entity)
        {
            _context.SupplierContacts.Add(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> UpdateAsync(
            SupplierContactModel entity)
        {
            _context.SupplierContacts.Update(entity);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.SupplierContacts
                .FindAsync(id);

            if (entity == null)
                return false;

            _context.SupplierContacts.Remove(entity);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
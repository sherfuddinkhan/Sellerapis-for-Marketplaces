using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.SupplierAddresses.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.SupplierAddresses.Repositories
{
    public class SupplierAddressRepository : ISupplierAddressRepository
    {
        private readonly ApplicationDbContext _context;

        public SupplierAddressRepository(ApplicationDbContext context)
            => _context = context;

        public async Task<List<SupplierAddress>> GetAllAsync()
            => await _context.SupplierAddresses.ToListAsync();

        public async Task<SupplierAddress?> GetByIdAsync(int id)
            => await _context.SupplierAddresses.FindAsync(id);

        public async Task<SupplierAddress> CreateAsync(
            SupplierAddress entity)
        {
            _context.SupplierAddresses.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> UpdateAsync(
            SupplierAddress entity)
        {
            _context.SupplierAddresses.Update(entity);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity =
                await _context.SupplierAddresses.FindAsync(id);

            if (entity == null)
                return false;

            _context.SupplierAddresses.Remove(entity);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}

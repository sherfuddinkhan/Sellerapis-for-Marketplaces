using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Suppliers.Interfaces;

namespace Marketplacesellerportal.Suppliers.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext _context;

        public SupplierRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Supplier?> GetByIdAsync(int supplierId)
        {
            return await _context.Suppliers
                .FirstOrDefaultAsync(x => x.SupplierId == supplierId);
        }

        public async Task<IEnumerable<Supplier>> GetBySellerIdAsync(int sellerId)
        {
            return await _context.Suppliers
                .Where(x => x.SellerId == sellerId)
                .ToListAsync();
        }

        public async Task<Supplier?> GetSupplierAsync(int sellerId, int supplierId)
        {
            return await _context.Suppliers
                .FirstOrDefaultAsync(x =>
                    x.SellerId == sellerId &&
                    x.SupplierId == supplierId);
        }

        public async Task AddAsync(Supplier supplier)
        {
            await _context.Suppliers.AddAsync(supplier);
        }

        public Task UpdateAsync(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int supplierId)
        {
            var supplier = await GetByIdAsync(supplierId);

            if (supplier != null)
                _context.Suppliers.Remove(supplier);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

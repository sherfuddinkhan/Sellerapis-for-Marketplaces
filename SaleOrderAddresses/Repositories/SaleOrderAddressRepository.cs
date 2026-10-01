using Marketplacesellerportal.Database;
using Marketplacesellerportal.Interfaces;
using Marketplacesellerportal.Models;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.SaleOrderAddresses.Repositories
{
    public class SaleOrderAddressRepository
        : ISaleOrderAddressRepository
    {
        private readonly ApplicationDbContext _context;

        public SaleOrderAddressRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SaleOrderAddress>> GetAllAsync()
            => await _context.SaleOrderAddresses.ToListAsync();

        public async Task<SaleOrderAddress?> GetByIdAsync(int id)
            => await _context.SaleOrderAddresses.FindAsync(id);

        public async Task<SaleOrderAddress> CreateAsync(
            SaleOrderAddress entity)
        {
            _context.SaleOrderAddresses.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> UpdateAsync(
            SaleOrderAddress entity)
        {
            _context.SaleOrderAddresses.Update(entity);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity =
                await _context.SaleOrderAddresses.FindAsync(id);

            if (entity == null)
                return false;

            _context.SaleOrderAddresses.Remove(entity);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
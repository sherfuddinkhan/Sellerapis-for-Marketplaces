using Marketplacesellerportal.Database;
using Marketplacesellerportal.Interfaces;
using Marketplacesellerportal.Models;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.Repositories
{
    public class ReversePickupAddressRepository
        : IReversePickupAddressRepository
    {
        private readonly ApplicationDbContext _context;

        public ReversePickupAddressRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ReversePickupAddress>> GetAllAsync()
            => await _context.ReversePickupAddresses.ToListAsync();

        public async Task<ReversePickupAddress?> GetByIdAsync(int id)
            => await _context.ReversePickupAddresses.FindAsync(id);

        public async Task<ReversePickupAddress> CreateAsync(
            ReversePickupAddress entity)
        {
            _context.ReversePickupAddresses.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(
            ReversePickupAddress entity)
        {
            _context.ReversePickupAddresses.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity =
                await _context.ReversePickupAddresses.FindAsync(id);

            if (entity == null)
                return false;

            _context.ReversePickupAddresses.Remove(entity);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}

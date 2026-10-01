using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Interfaces;
using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.ReversePickupAddresses.Service
{
    public class ReversePickupAddressService
        : IReversePickupAddressService
    {
        private readonly ApplicationDbContext _context;

        public ReversePickupAddressService(
            ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<List<ReversePickupAddress>> GetAllAsync()
        {
            return await _context.ReversePickupAddresses
                .AsNoTracking()
                .ToListAsync();
        }

        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<ReversePickupAddress?> GetByIdAsync(int id)
        {
            return await _context.ReversePickupAddresses
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        // =========================================================
        // CREATE
        // =========================================================

        public async Task<ReversePickupAddress> CreateAsync(
            ReversePickupAddress dto)
        {
            var entity = new ReversePickupAddress
            {
                SellerId = dto.SellerId,
                CustomerId = dto.CustomerId,
                ReversePickupId = dto.ReversePickupId,
                AddressType = dto.AddressType,
                AddressLine1 = dto.AddressLine1,
                City = dto.City,
                Pincode = dto.Pincode,
                Phone = dto.Phone
            };

            _context.ReversePickupAddresses.Add(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        // =========================================================
        // UPDATE
        // =========================================================

        public async Task<bool> UpdateAsync(
            int id,
            ReversePickupAddress dto)
        {
            var entity = await _context.ReversePickupAddresses
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            entity.SellerId = dto.SellerId;
            entity.CustomerId = dto.CustomerId;
            entity.ReversePickupId = dto.ReversePickupId;
            entity.AddressType = dto.AddressType;
            entity.AddressLine1 = dto.AddressLine1;
            entity.City = dto.City;
            entity.Pincode = dto.Pincode;
            entity.Phone = dto.Phone;

            await _context.SaveChangesAsync();

            return true;
        }

        // =========================================================
        // DELETE
        // =========================================================

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.ReversePickupAddresses
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            _context.ReversePickupAddresses.Remove(entity);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
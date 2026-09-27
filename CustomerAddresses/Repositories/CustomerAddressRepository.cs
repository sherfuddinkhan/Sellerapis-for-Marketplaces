using Marketplacesellerportal.Models;
using Marketplacesellerportal.CustomerAddresses.Interface;
using Marketplacesellerportal.Database;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.CustomerAddresses.Repositories
{
    public class CustomerAddressRepository
        : ICustomerAddressRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerAddressRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        // ============================================================
        // GET ALL
        // ============================================================

        public async Task<List<CustomerAddress>> GetAllAsync()
        {
            return await _context.CustomerAddresses
                .AsNoTracking()
                .OrderByDescending(x => x.CustomerAddressId)
                .ToListAsync();
        }

        // ============================================================
        // GET BY CUSTOMER ID
        // ============================================================

        public async Task<List<CustomerAddress>> GetByCustomerIdAsync(
            int customerId)
        {
            return await _context.CustomerAddresses
                .AsNoTracking()
                .Where(x => x.CustomerId == customerId)
                .OrderByDescending(x => x.IsDefault)
                .ThenByDescending(x => x.CustomerAddressId)
                .ToListAsync();
        }

        // ============================================================
        // GET BY ID
        // ============================================================

        public async Task<CustomerAddress?> GetByIdAsync(
            int customerAddressId)
        {
            return await _context.CustomerAddresses
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    x => x.CustomerAddressId == customerAddressId);
        }

        // ============================================================
        // CREATE
        // ============================================================

        public async Task<CustomerAddress> CreateAsync(
            CustomerAddress address)
        {
            address.CreatedDate ??= DateTime.Now;

            _context.CustomerAddresses.Add(address);

            await _context.SaveChangesAsync();

            return address;
        }

        // ============================================================
        // UPDATE
        // ============================================================

        public async Task<bool> UpdateAsync(
            CustomerAddress address)
        {
            var existing =
                await _context.CustomerAddresses
                    .FirstOrDefaultAsync(
                        x => x.CustomerAddressId ==
                             address.CustomerAddressId);

            if (existing == null)
                return false;

            existing.CustomerId = address.CustomerId;
            existing.AddressType = address.AddressType;
            existing.AddressLine1 = address.AddressLine1;
            existing.AddressLine2 = address.AddressLine2;
            existing.City = address.City;
            existing.State = address.State;
            existing.Country = address.Country;
            existing.PostalCode = address.PostalCode;
            existing.IsDefault = address.IsDefault;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<CustomerAddress?>
    GetBySellerAndCustomerAsync(
        int sellerId,
        int customerId)
        {
            var sellerCustomerExists =
                await _context.SellerCustomers
                    .AsNoTracking()
                    .AnyAsync(x =>
                        x.SellerId == sellerId &&
                        x.CustomerId == customerId);

            if (!sellerCustomerExists)
            {
                return null;
            }

            return await _context.CustomerAddresses
                .AsNoTracking()
                .Where(x =>
                    x.CustomerId == customerId)
                .OrderByDescending(x => x.CustomerAddressId)
                .FirstOrDefaultAsync();
        }

        // ============================================================
        // DELETE
        // ============================================================

        public async Task<bool> DeleteAsync(
            int customerAddressId)
        {
            var existing =
                await _context.CustomerAddresses
                    .FirstOrDefaultAsync(
                        x => x.CustomerAddressId ==
                             customerAddressId);

            if (existing == null)
                return false;

            _context.CustomerAddresses.Remove(existing);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}

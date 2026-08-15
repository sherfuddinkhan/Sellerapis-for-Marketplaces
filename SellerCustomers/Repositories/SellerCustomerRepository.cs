using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.SellerCustomers.Interfaces;
using Marketplacesellerportal.SharedKernel.Repositories;

namespace Marketplacesellerportal.SellerCustomers.Repositories
{
    public class SellerCustomerRepository
        : GenericRepository<SellerCustomer>,
          ISellerCustomerRepository
    {
        public SellerCustomerRepository(
            ApplicationDbContext context)
            : base(context)
        {
        }

        // =========================================================
        // GET ALL CUSTOMERS FOR A SELLER
        // =========================================================
        public async Task<IEnumerable<SellerCustomer>> GetBySellerIdAsync(
            int sellerId)
        {
            return await _dbSet
                .Where(c => c.SellerId == sellerId)
                .OrderBy(c => c.CustomerId)
                .ToListAsync();
        }

        // =========================================================
        // GET CUSTOMER BY SELLER + CUSTOMER ID
        // =========================================================
        public async Task<SellerCustomer?> GetCustomerAsync(
            int sellerId,
            int customerId)
        {
            return await _dbSet
                .FirstOrDefaultAsync(c =>
                    c.SellerId == sellerId &&
                    c.CustomerId == customerId);
        }

        // =========================================================
        // GET CUSTOMER BY SELLER + CUSTOMER CODE
        // =========================================================
        public async Task<SellerCustomer?> GetByCustomerCodeAsync(
            int sellerId,
            string customerCode)
        {
            return await _dbSet
                .FirstOrDefaultAsync(c =>
                    c.SellerId == sellerId &&
                    c.CustomerCode == customerCode);
        }

        // =========================================================
        // CHECK CUSTOMER CODE
        // =========================================================
        public async Task<bool> CustomerCodeExistsAsync(
            int sellerId,
            string customerCode)
        {
            return await _dbSet
                .AnyAsync(c =>
                    c.SellerId == sellerId &&
                    c.CustomerCode == customerCode);
        }

        // =========================================================
        // GET NEXT CUSTOMER ID
        // =========================================================
        public async Task<int> GetNextCustomerIdAsync(
            int sellerId)
        {
            var maxCustomerId = await _dbSet
                .Where(c => c.SellerId == sellerId)
                .Select(c => (int?)c.CustomerId)
                .MaxAsync();

            return (maxCustomerId ?? 0) + 1;
        }
    }
}
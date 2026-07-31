using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Customers.Interfaces;
using Marketplacesellerportal.SharedKernel.Repositories;

namespace Marketplacesellerportal.Customers.Repositories
{
    public class SellerCustomerRepository
        : GenericRepository<SellerCustomer>, ISellerCustomerRepository
    {
        public SellerCustomerRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<SellerCustomer>> GetBySellerIdAsync(int sellerId)
        {
            return await _dbSet
                .Where(c => c.SellerId == sellerId)
                .ToListAsync();
        }
        public async Task<SellerCustomer?> GetCustomerAsync(int sellerId, int customerId)
        {
            return await _context.SellerCustomers
                .FirstOrDefaultAsync(c =>
                    c.SellerId == sellerId &&
                    c.CustomerId == customerId);
        }

        public async Task<SellerCustomer?> GetByCustomerCodeAsync(string customerCode)
        {
            return await _dbSet
                .FirstOrDefaultAsync(c => c.CustomerCode == customerCode);
        }
    }
}

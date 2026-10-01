using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.SellerCustomers.Interfaces;
using Marketplacesellerportal.SharedKernel.Repositories;
using SellerCustomerEntity = Marketplacesellerportal.Models.SellerCustomer;

namespace Marketplacesellerportal.SellerCustomers.Repositories
{
    public class SellerCustomerRepository : GenericRepository<SellerCustomerEntity>, ISellerCustomerRepository
    {
        private readonly ApplicationDbContext _appContext;

        public SellerCustomerRepository(ApplicationDbContext context) : base(context)
        {
            _appContext = context;
        }

        public new async Task<IEnumerable<SellerCustomerEntity>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<SellerCustomerEntity>> GetBySellerIdAsync(int sellerId)
        {
            return await _dbSet.Where(c => c.SellerId == sellerId)
                .OrderBy(c => c.CustomerId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<SellerCustomerEntity?> GetCustomerAsync(int sellerId, int customerId)
        {
            var customer = await _dbSet.AsNoTracking()
                .FirstOrDefaultAsync(x => x.SellerId == sellerId && x.CustomerId == customerId);

            if (customer == null) return null;

            customer.StockMovements = await _appContext.StockMovements
                .Where(x => x.SellerId == sellerId && x.CustomerId == customerId)
                .OrderByDescending(x => x.MovementDate)
                .ToListAsync();

            customer.StockLedgers = await _appContext.StockLedgers
                .Where(x => x.SellerId == sellerId && x.CustomerId == customerId)
                .OrderByDescending(x => x.TransactionDate)
                .ToListAsync();

            customer.Warehouses = await _appContext.Warehouses
                .Where(x => x.SellerId == sellerId && x.CustomerId == customerId)
                .OrderBy(x => x.WarehouseId)
                .ToListAsync();

            return customer;
        }

        public async Task<SellerCustomerEntity?> GetByCustomerCodeAsync(int sellerId, string customerCode)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.SellerId == sellerId && c.CustomerCode == customerCode);
        }

        public async Task<bool> CustomerCodeExistsAsync(int sellerId, string customerCode)
        {
            return await _dbSet.AnyAsync(c => c.SellerId == sellerId && c.CustomerCode == customerCode);
        }

        public async Task<int> GetNextCustomerIdAsync(int sellerId)
        {
            var maxId = await _dbSet.Where(c => c.SellerId == sellerId).Select(c => (int?)c.CustomerId).MaxAsync();
            return (maxId ?? 0) + 1;
        }
    }
}
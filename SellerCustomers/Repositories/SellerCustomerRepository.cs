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
        private readonly ApplicationDbContext _context;

        public SellerCustomerRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
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
        //
        // Includes:
        // Product
        // Inventory
        // Price
        // ProductType
        // Category
        // Image
        // Attribute
        // StockMovement
        // StockLedger
        // Warehouse
        // =========================================================
        public async Task<SellerCustomer?> GetCustomerAsync(
            int sellerId,
            int customerId)
        {
            // =====================================================
            // 1. GET CUSTOMER
            // =====================================================
            var customer = await _dbSet
                .FirstOrDefaultAsync(c =>
                    c.SellerId == sellerId &&
                    c.CustomerId == customerId);

            if (customer == null)
                return null;


            // =====================================================
            // 2. STOCK MOVEMENTS
            // =====================================================
            customer.StockMovements = await _context.StockMovements
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .OrderByDescending(x => x.MovementDate)
                .ToListAsync();


            // =====================================================
            // 3. STOCK LEDGER
            // =====================================================
            customer.StockLedgers = await _context.StockLedgers
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .OrderByDescending(x => x.TransactionDate)
                .ToListAsync();


            // =====================================================
            // 4. WAREHOUSES
            // =====================================================
            customer.Warehouses = await _context.Warehouses
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .OrderBy(x => x.WarehouseId)
                .ToListAsync();


            // =====================================================
            // RETURN CUSTOMER
            // =====================================================
            return customer;
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
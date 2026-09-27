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
            var customer = await _context.SellerCustomers
                .AsNoTracking()
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .Select(x => new SellerCustomer
                {
                    CustomerId = x.CustomerId,
                    SellerId = x.SellerId,
                    CustomerCode = x.CustomerCode,
                    CustomerName = x.CustomerName,
                    TradeName = x.TradeName,
                    LegalName = x.LegalName,
                    ContactPerson = x.ContactPerson,
                    Email = x.Email,
                    Phone = x.Phone,
                    GSTIN = x.GSTIN,
                    AddressLine1 = x.AddressLine1,
                    AddressLine2 = x.AddressLine2,
                    BuildingName = x.BuildingName,
                    Location = x.Location,
                    City = x.City,
                    State = x.State,
                    StateCode = x.StateCode,
                    FloorNo = x.FloorNo,
                    Country = x.Country,
                    PostalCode = x.PostalCode,
                    CreditLimit = x.CreditLimit,
                    IsActive = x.IsActive,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate
                })
                .FirstOrDefaultAsync();

            if (customer == null)
                return null;

            customer.StockMovements = await _context.StockMovements
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .OrderByDescending(x => x.MovementDate)
                .ToListAsync();

            customer.StockLedgers = await _context.StockLedgers
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .OrderByDescending(x => x.TransactionDate)
                .ToListAsync();

            customer.Warehouses = await _context.Warehouses
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .OrderBy(x => x.WarehouseId)
                .ToListAsync();

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
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Suppliers.DTOs;
using Marketplacesellerportal.Suppliers.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IEnumerable<Supplier>> GetBySellerCustomerAsync(int sellerId,int customerId)
        {
            return await _context.Suppliers
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .ToListAsync();
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
        public async Task<PagedResult<Supplier>> GetPagedAsync(
    int page,
    int limit)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 15;

            var query = _context.Suppliers
                .AsNoTracking();

            var totalCount =
                await query.CountAsync();

            var items =
                await query
                    .OrderBy(x => x.SupplierId)
                    .Skip((page - 1) * limit)
                    .Take(limit)
                    .ToListAsync();

            return new PagedResult<Supplier>
            {
                Page = page,
                Limit = limit,
                TotalCount = totalCount,
                Items = items
            };
        }
        public async Task<IEnumerable<Supplier>> SearchAsync(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return await _context.Suppliers
                    .AsNoTracking()
                    .ToListAsync();
            }

            search = search.Trim().ToLower();

            return await _context.Suppliers
                .AsNoTracking()
                .Where(x =>
                    (x.SupplierCode != null &&
                     x.SupplierCode.ToLower().Contains(search)) ||

                    (x.SupplierName != null &&
                     x.SupplierName.ToLower().Contains(search)) ||

                    (x.ContactPerson != null &&
                     x.ContactPerson.ToLower().Contains(search)) ||

                    (x.Phone != null &&
                     x.Phone.ToLower().Contains(search)) ||

                    (x.Email != null &&
                     x.Email.ToLower().Contains(search)) ||

                    (x.GSTIN != null &&
                     x.GSTIN.ToLower().Contains(search)) ||

                    (x.City != null &&
                     x.City.ToLower().Contains(search)) ||

                    (x.State != null &&
                     x.State.ToLower().Contains(search))
                )
                .ToListAsync();
        }
        public async Task<IEnumerable<Supplier>> GetSortedAsync(
    string? sort)
        {
            var query = _context.Suppliers
                .AsQueryable();

            switch (sort?.ToLower())
            {
                case "name_asc":
                    query = query
                        .OrderBy(x => x.SupplierName);
                    break;

                case "name_desc":
                    query = query
                        .OrderByDescending(x => x.SupplierName);
                    break;

                case "code_asc":
                    query = query
                        .OrderBy(x => x.SupplierCode);
                    break;

                case "code_desc":
                    query = query
                        .OrderByDescending(x => x.SupplierCode);
                    break;

                case "credit_asc":
                    query = query
                        .OrderBy(x => x.CreditLimit);
                    break;

                case "credit_desc":
                    query = query
                        .OrderByDescending(x => x.CreditLimit);
                    break;

                case "newest":
                    query = query
                        .OrderByDescending(x => x.CreatedDate);
                    break;

                case "oldest":
                    query = query
                        .OrderBy(x => x.CreatedDate);
                    break;

                default:
                    query = query
                        .OrderBy(x => x.SupplierId);
                    break;
            }

            return await query.ToListAsync();
        }
        public async Task<SupplierStatistics> GetStatisticsAsync()
        {
            var total =
                await _context.Suppliers.CountAsync();

            var active =
    await _context.Suppliers
        .CountAsync(x => x.IsActive == true);
            var inactive =
                total - active;

            var totalCreditLimit =
                await _context.Suppliers
                    .Select(x => (decimal?)x.CreditLimit)
                    .SumAsync() ?? 0;

            var averageCreditLimit =
                await _context.Suppliers
                    .Select(x => (decimal?)x.CreditLimit)
                    .AverageAsync() ?? 0;

            return new SupplierStatistics
            {
                TotalSuppliers = total,
                ActiveSuppliers = active,
                InactiveSuppliers = inactive,
                TotalCreditLimit = totalCreditLimit,
                AverageCreditLimit = averageCreditLimit
            };
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

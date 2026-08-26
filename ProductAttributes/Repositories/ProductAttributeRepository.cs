using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductAttributes.DTOs;
using Marketplacesellerportal.ProductAttributes.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.ProductAttributes.Repositories
{
    public class ProductAttributeRepository : IProductAttributeRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductAttributeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductAttribute>> GetByProductIdsAsync(
    IEnumerable<int> productIds)
        {
            return await _context.ProductAttributes
                .Where(x => productIds.Contains(x.ProductId))
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductAttribute>>
        GetBySellerCustomerAsync(
            int sellerId,
            int customerId)
        {
            return await _context.ProductAttributes
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .ToListAsync();
        }
        public async Task<IEnumerable<ProductAttribute>> GetBySellerIdAsync(
    int sellerId)
        {
            return await _context.ProductAttributes
                .Where(x => x.SellerId == sellerId)
                .ToListAsync();
        }
       
// =========================================================
// SEARCH
// GET /api/product-attributes?search=color
// =========================================================

public async Task<IEnumerable<ProductAttribute>>
    SearchAsync(string? search)
        {
            var query = _context.ProductAttributes
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                query = query.Where(x =>
                    (x.AttributeName != null &&
                     x.AttributeName.Contains(search)) ||

                    (x.AttributeValue != null &&
                     x.AttributeValue.Contains(search)));
            }

            return await query.ToListAsync();
        }


        // =========================================================
        // STATISTICS
        // GET /api/product-attributes/stats
        // =========================================================

        public async Task<ProductAttributeStatistics> GetStatisticsAsync()
        {
            var query = _context.ProductAttributes
                .AsNoTracking();

            return new ProductAttributeStatistics
            {
                TotalAttributes =
                    await query.CountAsync(),

                ActiveAttributes =
                    await query.CountAsync(x => x.IsActive),

                InactiveAttributes =
                    await query.CountAsync(x => !x.IsActive),

                DistinctProducts =
                    await query
                        .Select(x => x.ProductId)
                        .Distinct()
                        .CountAsync(),

                DistinctAttributeNames =
                    await query
                        .Where(x => x.AttributeName != null)
                        .Select(x => x.AttributeName)
                        .Distinct()
                        .CountAsync()
            };
        }

        
public async Task<IEnumerable<ProductAttribute>>
    GetByAttributeNameAsync(
        string attributeName)
        {
            return await _context.ProductAttributes
                .AsNoTracking()
                .Where(x =>
                    x.AttributeName != null &&
                    x.AttributeName.Contains(attributeName))
                .ToListAsync();
        }


        // =========================================================
        // PAGINATION
        // GET /api/product-attributes?page=1&limit=15
        // =========================================================

        public async Task<(
            IEnumerable<ProductAttribute> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 15;

            if (limit > 100)
                limit = 100;

            var query = _context.ProductAttributes
                .AsNoTracking();

            var totalCount =
                await query.CountAsync();

            var items =
                await query
                    .OrderBy(x => x.ProductAttributeId)
                    .Skip((page - 1) * limit)
                    .Take(limit)
                    .ToListAsync();

            return (items, totalCount);
        }


        // =========================================================
        // SORTING
        // GET /api/product-attributes?sort=name_asc
        // =========================================================

        public async Task<IEnumerable<ProductAttribute>>
            GetSortedAsync(string? sort)
        {
            var query = _context.ProductAttributes
                .AsNoTracking()
                .AsQueryable();

            switch (sort?.ToLower())
            {
                case "name_asc":

                    query = query.OrderBy(x =>
                        x.AttributeName);

                    break;

                case "name_desc":

                    query = query.OrderByDescending(x =>
                        x.AttributeName);

                    break;

                case "id_asc":

                    query = query.OrderBy(x =>
                        x.ProductAttributeId);

                    break;

                case "id_desc":

                    query = query.OrderByDescending(x =>
                        x.ProductAttributeId);

                    break;

                default:

                    query = query.OrderByDescending(x =>
                        x.ProductAttributeId);

                    break;
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<ProductAttribute>> GetAllAsync()
        {
            return await _context.ProductAttributes.ToListAsync();
        }

        public async Task<ProductAttribute?> GetByIdAsync(int productAttributeId)
        {
            return await _context.ProductAttributes
                .FirstOrDefaultAsync(x => x.ProductAttributeId == productAttributeId);
        }
       

        public async Task<IEnumerable<ProductAttribute>> GetByProductIdAsync(int productId)
        {
            return await _context.ProductAttributes
                .Where(x => x.ProductId == productId)
                .ToListAsync();
        }

      

        public async Task AddAsync(ProductAttribute productAttribute)
        {
            await _context.ProductAttributes.AddAsync(productAttribute);
        }

        public Task UpdateAsync(ProductAttribute productAttribute)
        {
            _context.ProductAttributes.Update(productAttribute);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int productAttributeId)
        {
            var entity = await GetByIdAsync(productAttributeId);

            if (entity != null)
                _context.ProductAttributes.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
      
    }
}

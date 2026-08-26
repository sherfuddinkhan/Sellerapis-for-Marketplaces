
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Products.DTOs;
using Marketplacesellerportal.Products.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.Products.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<IEnumerable<Product>>
            GetAllAsync()
        {
            return await _context.Products
                .AsNoTracking()
                .OrderBy(x => x.ProductId)
                .ToListAsync();
        }

        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<Product?>
            GetByIdAsync(int productId)
        {
            return await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.ProductId == productId);
        }

        // =========================================================
        // GET BY SKU
        // =========================================================

        public async Task<Product?>
            GetBySKUAsync(string sku)
        {
            if (string.IsNullOrWhiteSpace(sku))
                return null;

            sku = sku.Trim();

            return await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.SKU == sku);
        }

        // =========================================================
        // GET BY SELLER
        // =========================================================

        public async Task<IEnumerable<Product>>
            GetBySellerIdAsync(int sellerId)
        {
            return await _context.Products
                .AsNoTracking()
                .Where(x =>
                    x.SellerId == sellerId)
                .OrderBy(x => x.ProductId)
                .ToListAsync();
        }

        // =========================================================
        // GET BY CUSTOMER
        // =========================================================

        public async Task<IEnumerable<Product>>
            GetByCustomerIdAsync(int customerId)
        {
            return await _context.Products
                .AsNoTracking()
                .Where(x =>
                    x.CustomerId == customerId)
                .OrderBy(x => x.ProductId)
                .ToListAsync();
        }

        // =========================================================
        // GET BY SELLER + CUSTOMER
        // =========================================================

        public async Task<IEnumerable<Product>>
            GetProductsBySellerCustomerAsync(
                int sellerId,
                int customerId)
        {
            return await _context.Products
                .AsNoTracking()
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .OrderBy(x => x.ProductId)
                .ToListAsync();
        }

        // =========================================================
        // GET BY PRODUCT IDS
        // =========================================================

        public async Task<IEnumerable<Product>>
            GetByProductIdsAsync(
                IEnumerable<int> productIds)
        {
            var ids = productIds?
                .Distinct()
                .ToList()
                ?? new List<int>();

            if (!ids.Any())
                return Enumerable.Empty<Product>();

            return await _context.Products
                .AsNoTracking()
                .Where(x =>
                    ids.Contains(x.ProductId))
                .OrderBy(x => x.ProductId)
                .ToListAsync();
        }

        // =========================================================
        // GET BY BRAND
        // =========================================================

        public async Task<IEnumerable<Product>>
            GetByBrandIdAsync(int brandId)
        {
            return await _context.Products
                .AsNoTracking()
                .Where(x =>
                    x.BrandId == brandId)
                .OrderBy(x => x.ProductId)
                .ToListAsync();
        }

        // =========================================================
        // GET BY CATEGORY
        // =========================================================

        public async Task<IEnumerable<Product>>
            GetByCategoryIdAsync(int categoryId)
        {
            return await _context.Products
                .AsNoTracking()
                .Where(x =>
                    x.CategoryId == categoryId)
                .OrderBy(x => x.ProductId)
                .ToListAsync();
        }

        // =========================================================
        // GET BY PRODUCT TYPE
        // =========================================================

        public async Task<IEnumerable<Product>>
            GetByProductTypeIdAsync(int productTypeId)
        {
            return await _context.Products
                .AsNoTracking()
                .Where(x =>
                    x.ProductTypeId == productTypeId)
                .OrderBy(x => x.ProductId)
                .ToListAsync();
        }

        // =========================================================
        // CREATE
        // =========================================================

        public async Task AddAsync(
            Product product)
        {
            await _context.Products
                .AddAsync(product);
        }

        // =========================================================
        // UPDATE
        // =========================================================

        public Task UpdateAsync(
            Product product)
        {
            _context.Products.Update(product);

            return Task.CompletedTask;
        }

        // =========================================================
        // DELETE
        // =========================================================

        public Task DeleteAsync(
            Product product)
        {
            _context.Products.Remove(product);

            return Task.CompletedTask;
        }

        // =========================================================
        // SEARCH + FILTER
        // =========================================================

        public async Task<IEnumerable<Product>>
            SearchAsync(
                string? search,
                string? status,
                bool? isActive,
                int? sellerId,
                int? customerId,
                int? brandId,
                int? categoryId,
                int? productTypeId)
        {
            var query =
                _context.Products
                    .AsNoTracking()
                    .AsQueryable();

            // -----------------------------------------------------
            // SELLER
            // -----------------------------------------------------

            if (sellerId.HasValue)
            {
                query = query.Where(x =>
                    x.SellerId == sellerId.Value);
            }

            // -----------------------------------------------------
            // CUSTOMER
            // -----------------------------------------------------

            if (customerId.HasValue)
            {
                query = query.Where(x =>
                    x.CustomerId == customerId.Value);
            }

            // -----------------------------------------------------
            // BRAND
            // -----------------------------------------------------

            if (brandId.HasValue)
            {
                query = query.Where(x =>
                    x.BrandId == brandId.Value);
            }

            // -----------------------------------------------------
            // CATEGORY
            // -----------------------------------------------------

            if (categoryId.HasValue)
            {
                query = query.Where(x =>
                    x.CategoryId == categoryId.Value);
            }

            // -----------------------------------------------------
            // PRODUCT TYPE
            // -----------------------------------------------------

            if (productTypeId.HasValue)
            {
                query = query.Where(x =>
                    x.ProductTypeId == productTypeId.Value);
            }

            // -----------------------------------------------------
            // ACTIVE / INACTIVE
            // -----------------------------------------------------

            if (isActive.HasValue)
            {
                query = query.Where(x =>
                    x.IsActive == isActive.Value);
            }

            // -----------------------------------------------------
            // STATUS
            // -----------------------------------------------------

            if (!string.IsNullOrWhiteSpace(status))
            {
                status = status.Trim();

                query = query.Where(x =>
                    x.Status != null &&
                    x.Status.ToLower() ==
                    status.ToLower());
            }

            // -----------------------------------------------------
            // SEARCH
            // -----------------------------------------------------

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                query = query.Where(x =>
                    (x.ProductName != null &&
                     x.ProductName.Contains(search)) ||

                    (x.SKU != null &&
                     x.SKU.Contains(search)) ||

                    (x.Barcode != null &&
                     x.Barcode.Contains(search)) ||

                    (x.HSNCode != null &&
                     x.HSNCode.Contains(search)) ||

                    (x.Description != null &&
                     x.Description.Contains(search)));
            }

            return await query
                .OrderBy(x => x.ProductId)
                .ToListAsync();
        }

        // =========================================================
        // STATISTICS
        // =========================================================

        public async Task<ProductStatistics>
            GetStatisticsAsync()
        {
            var query =
                _context.Products
                    .AsNoTracking();

            var total =
                await query.CountAsync();

            var active =
     await query.CountAsync(x =>
         x.IsActive == true);

            var inactive =
                await query.CountAsync(x =>
                    x.IsActive == false);

            var statusCounts =
                await query
                    .GroupBy(x => x.Status)
                    .Select(g => new
                    {
                        Status = g.Key,
                        Count = g.Count()
                    })
                    .ToListAsync();

            return new ProductStatistics
            {
                TotalProducts = total,
                ActiveProducts = active,
                InactiveProducts = inactive,
                StatusCounts = statusCounts
                    .ToDictionary(
                        x => x.Status ?? "Unknown",
                        x => x.Count)
            };
        }

        // =========================================================
        // PAGINATION
        // =========================================================

        public async Task<(
            IEnumerable<Product> Items,
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

            var query =
                _context.Products
                    .AsNoTracking();

            var totalCount =
                await query.CountAsync();

            var items =
                await query
                    .OrderBy(x => x.ProductId)
                    .Skip((page - 1) * limit)
                    .Take(limit)
                    .ToListAsync();

            return (
                items,
                totalCount
            );
        }

        // =========================================================
        // SORTING
        // =========================================================

        public async Task<IEnumerable<Product>>
            GetSortedAsync(string? sort)
        {
            var query =
                _context.Products
                    .AsNoTracking();

            sort = sort?
                .Trim()
                .ToLower();

            switch (sort)
            {
                case "name_asc":

                    return await query
                        .OrderBy(x =>
                            x.ProductName)
                        .ToListAsync();

                case "name_desc":

                    return await query
                        .OrderByDescending(x =>
                            x.ProductName)
                        .ToListAsync();

                case "sku_asc":

                    return await query
                        .OrderBy(x =>
                            x.SKU)
                        .ToListAsync();

                case "sku_desc":

                    return await query
                        .OrderByDescending(x =>
                            x.SKU)
                        .ToListAsync();

                case "created_asc":

                    return await query
                        .OrderBy(x =>
                            x.CreatedDate ??
                            DateTime.MinValue)
                        .ToListAsync();

                case "created_desc":

                    return await query
                        .OrderByDescending(x =>
                            x.CreatedDate ??
                            DateTime.MinValue)
                        .ToListAsync();

                case "updated_asc":

                    return await query
                        .OrderBy(x =>
                            x.UpdatedDate ??
                            DateTime.MinValue)
                        .ToListAsync();

                case "updated_desc":

                    return await query
                        .OrderByDescending(x =>
                            x.UpdatedDate ??
                            DateTime.MinValue)
                        .ToListAsync();

                case "id_asc":

                    return await query
                        .OrderBy(x =>
                            x.ProductId)
                        .ToListAsync();

                case "id_desc":

                    return await query
                        .OrderByDescending(x =>
                            x.ProductId)
                        .ToListAsync();

                default:

                    return await query
                        .OrderBy(x =>
                            x.ProductId)
                        .ToListAsync();
            }
        }

        // =========================================================
        // SAVE CHANGES
        // =========================================================

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}


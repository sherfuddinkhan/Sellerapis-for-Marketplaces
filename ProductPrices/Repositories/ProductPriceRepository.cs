using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductPrices.DTOs;
using Marketplacesellerportal.ProductPrices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.ProductPrices.Repositories
{
    public class ProductPriceRepository : IProductPriceRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductPriceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<IEnumerable<ProductPrice>> GetAllAsync()
        {
            return await _context.ProductPrices
                .AsNoTracking()
                .OrderBy(x => x.ProductPriceId)
                .ToListAsync();
        }

        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<ProductPrice?> GetByIdAsync(
            int productPriceId)
        {
            return await _context.ProductPrices
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.ProductPriceId == productPriceId);
        }

        // =========================================================
        // GET BY PRODUCT
        // =========================================================

        public async Task<IEnumerable<ProductPrice>>
            GetByProductIdAsync(int productId)
        {
            return await _context.ProductPrices
                .AsNoTracking()
                .Where(x => x.ProductId == productId)
                .OrderBy(x => x.ProductPriceId)
                .ToListAsync();
        }

        // =========================================================
        // GET BY SELLER
        // =========================================================

        public async Task<IEnumerable<ProductPrice>>
            GetBySellerIdAsync(int sellerId)
        {
            return await _context.ProductPrices
                .AsNoTracking()
                .Where(x => x.SellerId == sellerId)
                .OrderBy(x => x.ProductPriceId)
                .ToListAsync();
        }

        // =========================================================
        // GET BY SELLER + CUSTOMER
        // =========================================================

        public async Task<IEnumerable<ProductPrice>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId)
        {
            return await _context.ProductPrices
                .AsNoTracking()
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .OrderBy(x => x.ProductPriceId)
                .ToListAsync();
        }

        // =========================================================
        // CREATE
        // =========================================================

        public async Task AddAsync(ProductPrice price)
        {
            await _context.ProductPrices.AddAsync(price);
        }

        // =========================================================
        // UPDATE
        // =========================================================

        public async Task UpdateAsync(ProductPrice price)
        {
            _context.ProductPrices.Update(price);

            await Task.CompletedTask;
        }

        // =========================================================
        // DELETE
        // =========================================================

        public async Task DeleteAsync(int productPriceId)
        {
            var price = await _context.ProductPrices
                .FirstOrDefaultAsync(x =>
                    x.ProductPriceId == productPriceId);

            if (price != null)
            {
                _context.ProductPrices.Remove(price);
            }
        }

        // =========================================================
        // SAVE
        // =========================================================

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        // =========================================================
        // SEARCH + FILTER
        // =========================================================

        public async Task<IEnumerable<ProductPrice>>
            SearchAsync(
                string? search,
                decimal? min,
                decimal? max)
        {
            var query = _context.ProductPrices
                .AsNoTracking()
                .AsQueryable();

            // SEARCH BY PRICE TYPE
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                query = query.Where(x =>
                    x.PriceType.Contains(search));
            }

            // MIN PRICE
            if (min.HasValue)
            {
                query = query.Where(x =>
                    x.Price >= min.Value);
            }

            // MAX PRICE
            if (max.HasValue)
            {
                query = query.Where(x =>
                    x.Price <= max.Value);
            }

            return await query
                .OrderBy(x => x.ProductPriceId)
                .ToListAsync();
        }

        // =========================================================
        // STATISTICS
        // =========================================================

        public async Task<ProductPriceStatistics>
            GetStatisticsAsync()
        {
            var prices = await _context.ProductPrices
                .AsNoTracking()
                .ToListAsync();

            if (!prices.Any())
            {
                return new ProductPriceStatistics
                {
                    TotalPriceRecords = 0,
                    TotalPrice = 0,
                    AveragePrice = 0,
                    MinimumPrice = 0,
                    MaximumPrice = 0,
                    ActivePrices = 0,
                    InactivePrices = 0,
                    OfferPrices = 0,
                    WholesalePrices = 0,
                    RetailPrices = 0
                };
            }

            return new ProductPriceStatistics
            {
                TotalPriceRecords =
                    prices.Count,

                TotalPrice =
                    prices.Sum(x => x.Price),

                AveragePrice =
                    prices.Average(x => x.Price),

                MinimumPrice =
                    prices.Min(x => x.Price),

                MaximumPrice =
                    prices.Max(x => x.Price),

                ActivePrices =
                    prices.Count(x =>
                        x.IsActive == true),

                InactivePrices =
                    prices.Count(x =>
                        x.IsActive != true),

                OfferPrices =
                    prices.Count(x =>
                        string.Equals(
                            x.PriceType,
                            "Offer",
                            StringComparison.OrdinalIgnoreCase)),

                WholesalePrices =
                    prices.Count(x =>
                        string.Equals(
                            x.PriceType,
                            "Wholesale",
                            StringComparison.OrdinalIgnoreCase)),

                RetailPrices =
                    prices.Count(x =>
                        string.Equals(
                            x.PriceType,
                            "Retail",
                            StringComparison.OrdinalIgnoreCase))
            };
        }

        // =========================================================
        // PAGINATION
        // =========================================================

        public async Task<(
            IEnumerable<ProductPrice> Items,
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

            var query = _context.ProductPrices
                .AsNoTracking();

            var totalCount =
                await query.CountAsync();

            var items = await query
                .OrderBy(x => x.ProductPriceId)
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

        public async Task<IEnumerable<ProductPrice>>
            GetSortedAsync(string? sort)
        {
            var query = _context.ProductPrices
                .AsNoTracking();

            sort = sort?.Trim().ToLower();

            switch (sort)
            {
                // PRICE ASC
                case "amount_asc":
                case "price_asc":

                    return await query
                        .OrderBy(x => x.Price)
                        .ToListAsync();

                // PRICE DESC
                case "amount_desc":
                case "price_desc":

                    return await query
                        .OrderByDescending(x => x.Price)
                        .ToListAsync();

                // PRODUCT ASC
                case "product_asc":

                    return await query
                        .OrderBy(x => x.ProductId)
                        .ToListAsync();

                // PRODUCT DESC
                case "product_desc":

                    return await query
                        .OrderByDescending(x => x.ProductId)
                        .ToListAsync();

                // CREATED ASC
                case "created_asc":

                    return await query
                        .OrderBy(x =>
                            x.CreatedDate ??
                            DateTime.MinValue)
                        .ToListAsync();

                // CREATED DESC
                case "created_desc":

                    return await query
                        .OrderByDescending(x =>
                            x.CreatedDate ??
                            DateTime.MinValue)
                        .ToListAsync();

                // UPDATED ASC
                case "updated_asc":

                    return await query
                        .OrderBy(x =>
                            x.UpdatedDate ??
                            DateTime.MinValue)
                        .ToListAsync();

                // UPDATED DESC
                case "updated_desc":

                    return await query
                        .OrderByDescending(x =>
                            x.UpdatedDate ??
                            DateTime.MinValue)
                        .ToListAsync();

                // DEFAULT
                default:

                    return await query
                        .OrderBy(x =>
                            x.ProductPriceId)
                        .ToListAsync();
            }
        }
    }
}
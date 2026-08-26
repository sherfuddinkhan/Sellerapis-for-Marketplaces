using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Sellers.DTOs;
using Marketplacesellerportal.Sellers.Interfaces;
using Marketplacesellerportal.SharedKernel.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.Sellers.Repositories
{
    public class SellerRepository : BaseRepository<Seller>, ISellerRepository
    {
        public SellerRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<Seller?> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<bool> ExistsAsync(int sellerId)
        {
            return await _dbSet.AnyAsync(x => x.SellerId == sellerId);
        }
       
// =====================================================
// SEARCH
// GET:
// /api/sellers?search=amazon
// =====================================================

public async Task<IEnumerable<Seller>>
    SearchAsync(string? search)
        {
            var query = _context.Sellers
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                query = query.Where(x =>
                    x.SellerCode.Contains(search) ||
                    x.SellerName.Contains(search) ||
                    x.TradeName.Contains(search) ||
                    x.LegalName.Contains(search) ||
                    x.ContactPerson.Contains(search) ||
                    x.Email.Contains(search) ||
                    x.Phone.Contains(search) ||
                    x.GSTIN.Contains(search) ||
                    x.City.Contains(search) ||
                    x.State.Contains(search) ||
                    x.Country.Contains(search));
            }

            return await query.ToListAsync();
        }


        // =====================================================
        // STATISTICS
        // GET:
        // /api/sellers/stats
        // =====================================================

        public async Task<SellerStatistics>
            GetStatisticsAsync()
        {
            var query = _context.Sellers
                .AsNoTracking();

            var statistics = new SellerStatistics
            {
                // Total sellers
                TotalSellers =
                    await query.CountAsync(),

                // Active sellers
                ActiveSellers =
                    await query.CountAsync(x =>
                        x.IsActive),

                // Inactive sellers
                InactiveSellers =
                    await query.CountAsync(x =>
                        !x.IsActive),

                // Sellers having GSTIN
                SellersWithGSTIN =
                    await query.CountAsync(x =>
                        !string.IsNullOrWhiteSpace(x.GSTIN)),

                // Sellers having email
                SellersWithEmail =
                    await query.CountAsync(x =>
                        !string.IsNullOrWhiteSpace(x.Email)),

                // Sellers having phone
                SellersWithPhone =
                    await query.CountAsync(x =>
                        !string.IsNullOrWhiteSpace(x.Phone)),

                // Different cities
                DistinctCities =
                    await query
                        .Where(x =>
                            !string.IsNullOrWhiteSpace(x.City))
                        .Select(x => x.City)
                        .Distinct()
                        .CountAsync(),

                // Different states
                DistinctStates =
                    await query
                        .Where(x =>
                            !string.IsNullOrWhiteSpace(x.State))
                        .Select(x => x.State)
                        .Distinct()
                        .CountAsync(),

                // Different countries
                DistinctCountries =
                    await query
                        .Where(x =>
                            !string.IsNullOrWhiteSpace(x.Country))
                        .Select(x => x.Country)
                        .Distinct()
                        .CountAsync()
            };

            return statistics;
        }


        // =====================================================
        // PAGINATION
        // GET:
        // /api/sellers?page=1&limit=15
        // =====================================================

        public async Task<(
            IEnumerable<Seller> Items,
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

            var query = _context.Sellers
                .AsNoTracking();

            var totalCount =
                await query.CountAsync();

            var items =
                await query
                    .OrderByDescending(x =>
                        x.SellerId)
                    .Skip((page - 1) * limit)
                    .Take(limit)
                    .ToListAsync();

            return (
                items,
                totalCount
            );
        }


        // =====================================================
        // SORTING
        // GET:
        // /api/sellers?sort=name_asc
        // =====================================================

        public async Task<IEnumerable<Seller>>
            GetSortedAsync(string? sort)
        {
            var query = _context.Sellers
                .AsNoTracking()
                .AsQueryable();

            switch (sort?.ToLower())
            {
                // ---------------------------------------------
                // SELLER NAME
                // ---------------------------------------------

                case "name_asc":
                    query = query.OrderBy(x =>
                        x.SellerName);
                    break;

                case "name_desc":
                    query = query.OrderByDescending(x =>
                        x.SellerName);
                    break;


                // ---------------------------------------------
                // SELLER CODE
                // ---------------------------------------------

                case "code_asc":
                    query = query.OrderBy(x =>
                        x.SellerCode);
                    break;

                case "code_desc":
                    query = query.OrderByDescending(x =>
                        x.SellerCode);
                    break;


                // ---------------------------------------------
                // CREATED DATE
                // ---------------------------------------------

                case "created_asc":
                    query = query.OrderBy(x =>
                        x.CreatedAt);
                    break;

                case "created_desc":
                    query = query.OrderByDescending(x =>
                        x.CreatedAt);
                    break;


                // ---------------------------------------------
                // CITY
                // ---------------------------------------------

                case "city_asc":
                    query = query.OrderBy(x =>
                        x.City);
                    break;

                case "city_desc":
                    query = query.OrderByDescending(x =>
                        x.City);
                    break;


                // ---------------------------------------------
                // DEFAULT
                // ---------------------------------------------

                default:
                    query = query.OrderByDescending(x =>
                        x.SellerId);
                    break;
            }

            return await query.ToListAsync();
        }


        // =====================================================
        // STATUS FILTER
        // GET:
        // /api/sellers?status=active
        // =====================================================

        public async Task<IEnumerable<Seller>>
            GetByStatusAsync(bool isActive)
        {
            return await _context.Sellers
                .AsNoTracking()
                .Where(x =>
                    x.IsActive == isActive)
                .ToListAsync();
        }


    }
}


using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductTypes.DTOs;
using Marketplacesellerportal.ProductTypes.Interfaces;

namespace Marketplacesellerportal.ProductTypes.Repositories
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductTypeRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }


        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<IEnumerable<ProductType>>
            GetAllAsync()
        {
            return await _context.ProductTypes
                .AsNoTracking()
                .OrderBy(x => x.ProductTypeId)
                .ToListAsync();
        }


        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<ProductType?>
            GetByIdAsync(
                int productTypeId)
        {
            return await _context.ProductTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.ProductTypeId == productTypeId);
        }


        // =========================================================
        // GET BY NAME
        // =========================================================

        public async Task<ProductType?>
            GetByNameAsync(
                string productTypeName)
        {
            if (string.IsNullOrWhiteSpace(productTypeName))
                return null;

            productTypeName =
                productTypeName.Trim();

            return await _context.ProductTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.ProductTypeName == productTypeName);
        }


        // =========================================================
        // GET ACTIVE
        // =========================================================

        public async Task<IEnumerable<ProductType>>
            GetActiveAsync()
        {
            return await _context.ProductTypes
                .AsNoTracking()
                .Where(x => x.IsActive)
                .OrderBy(x => x.ProductTypeName)
                .ToListAsync();
        }


        // =========================================================
        // GET BY SELLER + CUSTOMER
        // =========================================================

        public async Task<IEnumerable<ProductType>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId)
        {
            return await _context.ProductTypes
                .AsNoTracking()
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .OrderBy(x => x.ProductTypeId)
                .ToListAsync();
        }


        // =========================================================
        // SEARCH + FILTER
        //
        // search:
        // electronic
        //
        // status:
        // active
        // inactive
        //
        // search + status:
        // electronic + active
        // =========================================================

        public async Task<IEnumerable<ProductType>>
            SearchAsync(
                string? search,
                string? status)
        {
            var query =
                _context.ProductTypes
                    .AsNoTracking()
                    .AsQueryable();


            // -----------------------------------------------------
            // SEARCH
            // -----------------------------------------------------

            if (!string.IsNullOrWhiteSpace(search))
            {
                search =
                    search.Trim();

                query = query.Where(x =>
                    x.ProductTypeName != null &&
                    x.ProductTypeName.Contains(search));
            }


            // -----------------------------------------------------
            // STATUS
            // -----------------------------------------------------

            if (!string.IsNullOrWhiteSpace(status))
            {
                status =
                    status.Trim().ToLower();

                switch (status)
                {
                    case "active":

                        query = query.Where(x =>
                            x.IsActive);

                        break;


                    case "inactive":

                        query = query.Where(x =>
                            !x.IsActive);

                        break;
                }
            }


            return await query
                .OrderBy(x => x.ProductTypeName)
                .ToListAsync();
        }


        // =========================================================
        // STATISTICS
        // =========================================================

        public async Task<ProductTypeStatistics>
            GetStatisticsAsync()
        {
            var query =
                _context.ProductTypes
                    .AsNoTracking();

            var total =
                await query.CountAsync();

            var active =
                await query.CountAsync(x =>
                    x.IsActive);

            var inactive =
                await query.CountAsync(x =>
                    !x.IsActive);

            return new ProductTypeStatistics
            {
                TotalProductTypes =
                    total,

                ActiveProductTypes =
                    active,

                InactiveProductTypes =
                    inactive
            };
        }


        // =========================================================
        // PAGINATION
        //
        // page = 1
        // limit = 10
        // =========================================================

        public async Task<(
            IEnumerable<ProductType> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 10;

            if (limit > 100)
                limit = 100;


            var query =
                _context.ProductTypes
                    .AsNoTracking();


            var totalCount =
                await query.CountAsync();


            var items =
                await query
                    .OrderBy(x =>
                        x.ProductTypeId)
                    .Skip(
                        (page - 1) * limit)
                    .Take(limit)
                    .ToListAsync();


            return (
                items,
                totalCount
            );
        }


        // =========================================================
        // SORTING
        //
        // name_asc
        // name_desc
        // created_asc
        // created_desc
        // id_asc
        // id_desc
        // =========================================================

        public async Task<IEnumerable<ProductType>>
            GetSortedAsync(
                string? sort)
        {
            var query =
                _context.ProductTypes
                    .AsNoTracking();


            sort =
                sort?
                    .Trim()
                    .ToLower();


            switch (sort)
            {
                // -------------------------------------------------
                // NAME ASCENDING
                // -------------------------------------------------

                case "name_asc":

                    return await query
                        .OrderBy(x =>
                            x.ProductTypeName)
                        .ToListAsync();


                // -------------------------------------------------
                // NAME DESCENDING
                // -------------------------------------------------

                case "name_desc":

                    return await query
                        .OrderByDescending(x =>
                            x.ProductTypeName)
                        .ToListAsync();


                // -------------------------------------------------
                // CREATED ASCENDING
                // -------------------------------------------------

                case "created_asc":

                    return await query
                        .OrderBy(x =>
                            x.CreatedDate)
                        .ToListAsync();


                // -------------------------------------------------
                // CREATED DESCENDING
                // -------------------------------------------------

                case "created_desc":

                    return await query
                        .OrderByDescending(x =>
                            x.CreatedDate)
                        .ToListAsync();


                // -------------------------------------------------
                // ID ASCENDING
                // -------------------------------------------------

                case "id_asc":

                    return await query
                        .OrderBy(x =>
                            x.ProductTypeId)
                        .ToListAsync();


                // -------------------------------------------------
                // ID DESCENDING
                // -------------------------------------------------

                case "id_desc":

                    return await query
                        .OrderByDescending(x =>
                            x.ProductTypeId)
                        .ToListAsync();


                // -------------------------------------------------
                // DEFAULT
                // -------------------------------------------------

                default:

                    return await query
                        .OrderBy(x =>
                            x.ProductTypeId)
                        .ToListAsync();
            }
        }


        // =========================================================
        // CREATE
        // =========================================================

        public async Task AddAsync(
            ProductType productType)
        {
            await _context.ProductTypes
                .AddAsync(productType);
        }


        // =========================================================
        // UPDATE
        // =========================================================

        public Task UpdateAsync(
            ProductType productType)
        {
            _context.ProductTypes
                .Update(productType);

            return Task.CompletedTask;
        }


        // =========================================================
        // DELETE
        // =========================================================

        public async Task DeleteAsync(
            int productTypeId)
        {
            var entity =
                await _context.ProductTypes
                    .FirstOrDefaultAsync(x =>
                        x.ProductTypeId ==
                        productTypeId);

            if (entity != null)
            {
                _context.ProductTypes
                    .Remove(entity);
            }
        }


        // =========================================================
        // SAVE
        // =========================================================

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}


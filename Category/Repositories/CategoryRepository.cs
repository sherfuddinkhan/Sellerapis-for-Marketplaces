using Marketplacesellerportal.Catalog.DTOs;
using Marketplacesellerportal.Categories.Interfaces;
using Marketplacesellerportal.Category.DTOs;
using Marketplacesellerportal.Database;
using Microsoft.EntityFrameworkCore;

using CategoryModel = Marketplacesellerportal.Models.Category;

namespace Marketplacesellerportal.Categories.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================================================
        // GET BY IDS
        // =========================================================

        public async Task<IEnumerable<CategoryModel>> GetByIdsAsync(
            IEnumerable<int> categoryIds)
        {
            var ids = categoryIds
                .Distinct()
                .ToList();

            return await _context.Categories
                .Where(x => ids.Contains(x.CategoryId))
                .ToListAsync();
        }


        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<IEnumerable<CategoryModel>> GetAllAsync()
        {
            return await _context.Categories
                .AsNoTracking()
                .ToListAsync();
        }


        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<CategoryModel?> GetByIdAsync(int categoryId)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(
                    x => x.CategoryId == categoryId);
        }


        // =========================================================
        // GET BY NAME
        // =========================================================

        public async Task<CategoryModel?> GetByNameAsync(
            string categoryName)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(
                    x => x.CategoryName == categoryName);
        }


        // =========================================================
        // GET ACTIVE
        // =========================================================

        public async Task<IEnumerable<CategoryModel>> GetActiveAsync()
        {
            return await _context.Categories
                .Where(x => x.IsActive)
                .AsNoTracking()
                .ToListAsync();
        }


        // =========================================================
        // ADD
        // =========================================================

        public async Task AddAsync(CategoryModel category)
        {
            await _context.Categories.AddAsync(category);
        }


        // =========================================================
        // UPDATE
        // =========================================================

        public Task UpdateAsync(CategoryModel category)
        {
            _context.Categories.Update(category);

            return Task.CompletedTask;
        }


        // =========================================================
        // DELETE
        // =========================================================

        public Task DeleteAsync(CategoryModel category)
        {
            _context.Categories.Remove(category);

            return Task.CompletedTask;
        }


        // =========================================================
        // SAVE
        // =========================================================

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


        // =========================================================
        // SEARCH + FILTER + SORT + PAGINATION
        //
        // GET:
        // /api/categories
        //
        // Examples:
        // /api/categories?search=phone
        // /api/categories?status=active
        // /api/categories?page=1&limit=10
        // /api/categories?sort=name_asc
        // =========================================================

        public async Task<CategoryListResponse> GetCategoriesAsync(
            CategoryListRequest request)
        {
            var query = _context.Categories
                .AsNoTracking()
                .AsQueryable();


            // =====================================================
            // SEARCH
            // =====================================================

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var search = request.Search.Trim();

                query = query.Where(x =>
                    x.CategoryName.Contains(search));
            }


            // =====================================================
            // STATUS FILTER
            // =====================================================

            if (!string.IsNullOrWhiteSpace(request.Status))
            {
                var status = request.Status
                    .Trim()
                    .ToLower();

                if (status == "active")
                {
                    query = query.Where(x => x.IsActive);
                }
                else if (status == "inactive")
                {
                    query = query.Where(x => !x.IsActive);
                }
            }


            // =====================================================
            // SORTING
            // =====================================================

            var sort = request.Sort?
                .Trim()
                .ToLower();

            query = sort switch
            {
                "name_desc" =>
                    query.OrderByDescending(
                        x => x.CategoryName),

                "name_asc" =>
                    query.OrderBy(
                        x => x.CategoryName),

                "newest" =>
                    query.OrderByDescending(
                        x => x.CategoryId),

                "oldest" =>
                    query.OrderBy(
                        x => x.CategoryId),

                _ =>
                    query.OrderBy(
                        x => x.CategoryName)
            };


            // =====================================================
            // TOTAL COUNT
            // =====================================================

            var totalItems = await query.CountAsync();


            // =====================================================
            // PAGINATION
            // =====================================================

            var page = request.Page < 1
                ? 1
                : request.Page;

            var limit = request.Limit <= 0
                ? 10
                : request.Limit;


            // =====================================================
            // GET DATA
            // =====================================================

            var items = await query
                .Skip((page - 1) * limit)
                .Take(limit)
                .Select(x => new CategoryResponse
                {
                    CategoryId = x.CategoryId,
                    CategoryName = x.CategoryName,
                    Description = x.Description,
                    IsActive = x.IsActive
                })
                .ToListAsync();


            // =====================================================
            // TOTAL PAGES
            // =====================================================

            var totalPages = (int)Math.Ceiling(
                totalItems / (double)limit);


            // =====================================================
            // RESPONSE
            // =====================================================

            return new CategoryListResponse
            {
                Items = items,
                Page = page,
                Limit = limit,
                TotalItems = totalItems,
                TotalPages = totalPages
            };
        }


        // =========================================================
        // STATISTICS
        //
        // GET:
        // /api/categories/stats
        // =========================================================

        public async Task<CategoryStatisticsResponse>
            GetStatisticsAsync()
        {
            var totalCategories =
                await _context.Categories.CountAsync();


            var activeCategories =
                await _context.Categories
                    .CountAsync(x => x.IsActive);


            var inactiveCategories =
                await _context.Categories
                    .CountAsync(x => !x.IsActive);


            var categoriesWithProducts =
                await _context.Categories
                    .Where(c =>
                        _context.Products.Any(
                            p => p.CategoryId == c.CategoryId))
                    .CountAsync();


            var categoriesWithoutProducts =
                totalCategories - categoriesWithProducts;


            return new CategoryStatisticsResponse
            {
                TotalCategories = totalCategories,

                ActiveCategories = activeCategories,

                InactiveCategories = inactiveCategories,

                CategoriesWithProducts =
                    categoriesWithProducts,

                CategoriesWithoutProducts =
                    categoriesWithoutProducts
            };
        }
    }
}
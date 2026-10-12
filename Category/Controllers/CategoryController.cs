using Marketplacesellerportal.Categories.Interfaces;
using Marketplacesellerportal.Category.DTOs;
using Marketplacesellerportal.Models;
using Microsoft.AspNetCore.Mvc;

using CategoryEntity = Marketplacesellerportal.Models.Category;

namespace Marketplacesellerportal.Categories.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        // =========================================================
        // GET ALL CATEGORIES - LIST
        // =========================================================

        [HttpGet("list")]
        public async Task<IActionResult> GetCategoryList()
        {
            var response = await _service.GetCategoriesAsync(
                new CategoryListRequest
                {
                    Page = 1,
                    Limit = int.MaxValue
                }
            );

            var result = response.Items
                .Select(c => new
                {
                    categoryId = c.CategoryId,
                    categoryName = c.CategoryName
                })
                .ToList();

            return Ok(result);
        }
        // =========================================================
        // GET CATEGORY WITH PRODUCTS
        // GET: /api/categories/5/products
        // =========================================================

        [HttpGet("{categoryId:int}/products")]
        public async Task<IActionResult> GetCategoryWithProducts(
            int categoryId)
        {
            var result =
     await _service.GetProductsByCategoryAsync(
         categoryId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
        // =========================================================
        // GET ALL / SEARCH / FILTER / PAGINATION / SORT
        // =========================================================
        // GET:
        // /api/categories
        //
        // Search:
        // /api/categories?search=Mobile
        //
        // Status:
        // /api/categories?status=active
        //
        // Pagination:
        // /api/categories?page=1&limit=10
        //
        // Sorting:
        // /api/categories?sort=name_asc
        //
        // Combined:
        // /api/categories?search=Mobile&status=active&page=1&limit=10&sort=name_asc
        // =========================================================
        [HttpGet]
        public async Task<IActionResult> GetCategories(
            [FromQuery] CategoryListRequest request)
        {
            var result = await _service.GetCategoriesAsync(request);

            return Ok(result);
        }

        // =========================================================
        // GET CATEGORY BY ID
        // =========================================================
        // GET: /api/categories/1
        // =========================================================
        [HttpGet("{categoryId:int}")]
        public async Task<IActionResult> GetById(int categoryId)
        {
            var result = await _service.GetByIdAsync(categoryId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
        // =========================================================
        // SEARCH CATEGORIES
        // =========================================================
        // GET:
        // /api/categories/search?search=Mobile
        //
        // Examples:
        // /api/categories/search?search=Mobile
        // /api/categories/search?search=Laptop
        // /api/categories/search?search=Phone
        //
        // Purpose:
        // Dedicated category search endpoint.
        // Useful for React autocomplete / search boxes.
        // =========================================================

        [HttpGet("search")]
        public async Task<IActionResult> SearchCategories(
            [FromQuery] string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return BadRequest(new
                {
                    message = "Search term is required."
                });
            }

            var response = await _service.GetCategoriesAsync(
                new CategoryListRequest
                {
                    Search = search,
                    Page = 1,
                    Limit = 50
                }
            );

            var result = response.Items
                .Select(c => new
                {
                    categoryId = c.CategoryId,
                    categoryName = c.CategoryName
                })
                .ToList();

            return Ok(result);
        }
        // =========================================================
        // GET CATEGORY BY NAME
        // =========================================================
        // GET: /api/categories/name/Mobile Phones
        // =========================================================
        [HttpGet("name/{categoryName}")]
        public async Task<IActionResult> GetByName(
            string categoryName)
        {
            var result = await _service.GetByNameAsync(categoryName);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // =========================================================
        // GET ACTIVE CATEGORIES
        // =========================================================
        // GET: /api/categories/active
        // =========================================================
        [HttpGet("active")]
        public async Task<IActionResult> GetActive()
        {
            var result = await _service.GetActiveAsync();

            return Ok(result);
        }

        // =========================================================
        // CATEGORY STATISTICS
        // =========================================================
        // GET: /api/categories/stats
        // =========================================================
        [HttpGet("stats")]
        public async Task<IActionResult> GetStatistics()
        {
            var result = await _service.GetStatisticsAsync();

            return Ok(result);
        }

        // =========================================================
        // CREATE CATEGORY
        // =========================================================
        // POST: /api/categories
        // =========================================================
        [HttpPost]
        public async Task<IActionResult> Create(
     [FromBody] CategoryCreateRequest request)
        {
            var category = new CategoryEntity
            {
                CategoryId = request.CategoryId,
                CategoryName = request.CategoryName,
                ParentCategoryId = request.ParentCategoryId,
                Description = request.Description,
                IsActive = request.IsActive,
                CreatedDate = request.CreatedDate,
                UpdatedDate = request.UpdatedDate,
                CategoryCode = request.CategoryCode,
                CategoryPath = request.CategoryPath,
                CategoryLevel = request.CategoryLevel,
                DisplayOrder = request.DisplayOrder,
                ImageUrl = request.ImageUrl,
                BatchId = request.BatchId,
                IsBulkUpload = request.IsBulkUpload,
                ChannelCode = request.ChannelCode,
                SellerId = request.SellerId,
                CustomerId = request.CustomerId,
                CreatedBy = request.CreatedBy,
                UpdatedBy = request.UpdatedBy,
                BannerUrl = request.BannerUrl,
                IconUrl = request.IconUrl,
                MetaTitle = request.MetaTitle,
                MetaDescription = request.MetaDescription,
                IsSystemDefined = request.IsSystemDefined,
                HSNCode = request.HSNCode,
                GSTPercentage = request.GSTPercentage
            };

            var result = await _service.CreateAsync(category);

            return Ok(new
            {
                result.CategoryId,
                result.CategoryName,
                result.ParentCategoryId,
                result.Description,
                result.IsActive,
                result.CreatedDate,
                result.UpdatedDate,
                result.CategoryCode,
                result.CategoryPath,
                result.CategoryLevel,
                result.DisplayOrder,
                result.ImageUrl,
                result.BatchId,
                result.IsBulkUpload,
                result.ChannelCode,
                result.SellerId,
                result.CustomerId,
                result.CreatedBy,
                result.UpdatedBy,
                result.BannerUrl,
                result.IconUrl,
                result.MetaTitle,
                result.MetaDescription,
                result.IsSystemDefined,
                result.HSNCode,
                result.GSTPercentage
            });
        }
        // =========================================================
        // UPDATE CATEGORY
        // =========================================================
        // PUT: /api/categories/1
        // =========================================================
        [HttpPut("{categoryId:int}")]
        public async Task<IActionResult> Update(
            int categoryId,
            [FromBody] CategoryEntity category)
        {
            var result = await _service.UpdateAsync(
                categoryId,
                category);

            if (!result)
                return NotFound();

            return Ok();
        }

        // =========================================================
        // DELETE CATEGORY
        // =========================================================
        // DELETE: /api/categories/1
        // =========================================================
        [HttpDelete("{categoryId:int}")]
        public async Task<IActionResult> Delete(int categoryId)
        {
            var result = await _service.DeleteAsync(categoryId);

            if (!result)
                return NotFound();

            return Ok();
        }
    }
}
using Marketplacesellerportal.Categories.Interfaces;
using Marketplacesellerportal.Category.DTOs;
using Marketplacesellerportal.Models;
using Microsoft.AspNetCore.Mvc;

using CategoryModel = Marketplacesellerportal.Models.Category;

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
            [FromBody] CategoryModel category)
        {
            var result = await _service.CreateAsync(category);

            return Ok(result);
        }

        // =========================================================
        // UPDATE CATEGORY
        // =========================================================
        // PUT: /api/categories/1
        // =========================================================
        [HttpPut("{categoryId:int}")]
        public async Task<IActionResult> Update(
            int categoryId,
            [FromBody] CategoryModel category)
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
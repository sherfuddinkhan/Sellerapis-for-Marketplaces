using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Categories.Interfaces;

namespace Marketplacesellerportal.Categories.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        // GET: api/Category/1
        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetById(int categoryId)
        {
            var result = await _service.GetByIdAsync(categoryId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // GET: api/Category/name/Mobile Phones
        [HttpGet("name/{categoryName}")]
        public async Task<IActionResult> GetByName(string categoryName)
        {
            var result = await _service.GetByNameAsync(categoryName);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // GET: api/Category/active
        [HttpGet("active")]
        public async Task<IActionResult> GetActive()
        {
            return Ok(await _service.GetActiveAsync());
        }

        // POST: api/Category
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            var result = await _service.CreateAsync(category);

            return Ok(result);
        }

        // PUT: api/Category/1
        [HttpPut("{categoryId}")]
        public async Task<IActionResult> Update(
            int categoryId,
            Category category)
        {
            var result = await _service.UpdateAsync(
                categoryId,
                category);

            if (!result)
                return NotFound();

            return Ok();
        }

        // DELETE: api/Category/1
        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> Delete(int categoryId)
        {
            var result = await _service.DeleteAsync(categoryId);

            if (!result)
                return NotFound();

            return Ok();
        }
    }
}


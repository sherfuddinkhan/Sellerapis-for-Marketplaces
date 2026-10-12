using Marketplacesellerportal.Brands.DTOs;
using Marketplacesellerportal.Brands.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Marketplacesellerportal.Brands.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _service;
        public BrandController(IBrandService service) => _service = service;

        // ===================== BRAND =====================

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var brands = await _service.GetAllAsync();
            if (!brands.Any()) return NotFound("No brands found.");
            return Ok(brands);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var brand = await _service.GetByIdAsync(id);
            if (brand == null) return NotFound($"Brand {id} not found.");
            return Ok(brand);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActive()
        {
            var brands = await _service.GetActiveBrandsAsync();
            if (!brands.Any()) return NotFound("No active brands.");
            return Ok(brands);
        }

        [HttpGet("statistics")]
        public async Task<IActionResult> GetStatistics()
            => Ok(await _service.GetStatisticsAsync());

        [HttpGet("filters")]
        public async Task<IActionResult> GetFilters()
            => Ok(await _service.GetFiltersAsync());

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBrandRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _service.CreateAsync(request);
            if (!result) return BadRequest("Brand already exists.");
            return CreatedAtAction(nameof(GetAll), new { Success = true, Message = "Brand created" });
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateBrandRequest request)
        {
            if (id != request.BrandId) return BadRequest("Id mismatch");
            var result = await _service.UpdateAsync(request);
            if (!result) return NotFound($"Brand {id} not found.");
            return Ok(new { Success = true, Message = "Brand updated" });
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result) return NotFound($"Brand {id} not found.");
            return Ok(new { Success = true, Message = "Brand deleted" });
        }

        // ===================== BRAND MODEL - INSIDE BRANDS ONLY =====================
        // Fixes your errors: GET /api/Brand/1005/models and POST /api/Brand/1005/models

        [HttpGet("{brandId:int}/models")]
        public async Task<IActionResult> GetModelsByBrand(int brandId)
        {
            var brand = await _service.GetByIdAsync(brandId);
            if (brand == null) return NotFound($"Brand {brandId} not found.");
            var models = await _service.GetModelsByBrandIdAsync(brandId);
            return Ok(models);
        }

        [HttpGet("{brandId:int}/models/{modelId:int}")]
        public async Task<IActionResult> GetModelById(int brandId, int modelId)
        {
            var model = await _service.GetModelByIdAsync(modelId);
            if (model == null || model.BrandId != brandId)
                return NotFound($"Model {modelId} not found for brand {brandId}.");
            return Ok(model);
        }

        [HttpPost("{brandId:int}/models")]
        public async Task<IActionResult> CreateModel(int brandId, [FromBody] CreateBrandModelRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var brand = await _service.GetByIdAsync(brandId);
            if (brand == null) return NotFound($"Brand {brandId} not found.");

            var result = await _service.CreateModelAsync(brandId, request);
            return CreatedAtAction(nameof(GetModelsByBrand), new { brandId }, result);
        }

        [HttpPut("{brandId:int}/models/{modelId:int}")]
        public async Task<IActionResult> UpdateModel(int brandId, int modelId, [FromBody] UpdateBrandModelRequest request)
        {
            if (modelId != request.BrandModelId) return BadRequest("Id mismatch");
            request.BrandId = brandId;
            var result = await _service.UpdateModelAsync(request);
            if (!result) return NotFound($"Model {modelId} not found.");
            return Ok(new { Success = true, Message = "Model updated" });
        }

        [HttpDelete("{brandId:int}/models/{modelId:int}")]
        public async Task<IActionResult> DeleteModel(int brandId, int modelId)
        {
            var model = await _service.GetModelByIdAsync(modelId);
            if (model == null || model.BrandId != brandId)
                return NotFound($"Model {modelId} not found for brand {brandId}.");

            var result = await _service.DeleteModelAsync(modelId);
            if (!result) return NotFound();
            return Ok(new { Success = true, Message = "Model deleted" });
        }
    }
}
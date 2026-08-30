using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.BrandModel.DTOs;
using Marketplacesellerportal.BrandModel.Interfaces;

namespace Marketplacesellerportal.BrandModel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandModelController
        : ControllerBase
    {
        private readonly IBrandModelService
            _service;

        public BrandModelController(
            IBrandModelService service)
        {
            _service = service;
        }

        // GET: api/BrandModel
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result =
                await _service.GetAllAsync();

            return Ok(result);
        }

        // GET: api/BrandModel/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(
            int id)
        {
            var result =
                await _service.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound(new
                {
                    message =
                        "Brand model not found."
                });
            }

            return Ok(result);
        }

        // GET: api/BrandModel/brand/1
        [HttpGet("brand/{brandId}")]
        public async Task<IActionResult>
            GetByBrandId(int brandId)
        {
            var result =
                await _service
                    .GetByBrandIdAsync(brandId);

            return Ok(result);
        }

        // POST: api/BrandModel
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] BrandModelDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result =
                await _service.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new
                {
                    id = result.BrandModelId
                },
                result);
        }

        // PUT: api/BrandModel/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] BrandModelDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result =
                await _service
                    .UpdateAsync(id, dto);

            if (result == null)
            {
                return NotFound(new
                {
                    message =
                        "Brand model not found."
                });
            }

            return Ok(result);
        }

        // DELETE: api/BrandModel/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(
            int id)
        {
            var deleted =
                await _service.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound(new
                {
                    message =
                        "Brand model not found."
                });
            }

            return Ok(new
            {
                message =
                    "Brand model deleted successfully."
            });
        }
    }
}


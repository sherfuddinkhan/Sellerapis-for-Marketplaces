using Marketplacesellerportal.Brand.DTOs;
using Marketplacesellerportal.Brand.Interfaces;
using Marketplacesellerportal.Brand.Services;
using Microsoft.AspNetCore.Mvc;

namespace Marketplacesellerportal.Brand.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _service;

        public BrandController(IBrandService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retrieves all brands.
        /// </summary>
        /// <remarks>
        /// Returns a list of all brands available in the marketplace.
        ///
        /// Example:
        ///
        /// GET /api/Brand
        /// </remarks>
        /// <returns>List of brands.</returns>
        /// <response code="200">Brands retrieved successfully.</response>
        /// <response code="404">No brands found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BrandResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var brands = await _service.GetAllAsync();

            if (!brands.Any())
                return NotFound("No brands found.");

            return Ok(brands);
        }

        /// <summary>
        /// Retrieves a brand by its unique identifier.
        /// </summary>
        /// <remarks>
        /// Returns detailed information for the specified brand.
        ///
        /// Example:
        ///
        /// GET /api/Brand/1
        /// </remarks>
        /// <param name="id">Brand identifier.</param>
        /// <returns>Brand details.</returns>
        /// <response code="200">Brand retrieved successfully.</response>
        /// <response code="404">Brand not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BrandResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var brand = await _service.GetByIdAsync(id);

            if (brand == null)
                return NotFound($"Brand with Id {id} not found.");

            return Ok(brand);
        }

        /// <summary>
        /// Retrieves all active brands.
        /// </summary>
        /// <remarks>
        /// Returns all brands currently marked as active.
        ///
        /// Example:
        ///
        /// GET /api/Brand/active
        /// </remarks>
        /// <returns>List of active brands.</returns>
        /// <response code="200">Active brands retrieved successfully.</response>
        /// <response code="404">No active brands found.</response>
        [HttpGet("active")]
        [ProducesResponseType(typeof(IEnumerable<BrandResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetActiveBrands()
        {
            var brands = await _service.GetActiveBrandsAsync();

            if (!brands.Any())
                return NotFound("No active brands found.");

            return Ok(brands);
        }

        /// <summary>
        /// Creates a new brand.
        /// </summary>
        /// <remarks>
        /// Creates a new brand in the marketplace.
        ///
        /// Example:
        ///
        /// POST /api/Brand
        /// </remarks>
        /// <param name="request">Brand information.</param>
        /// <returns>Success message.</returns>
        /// <response code="201">Brand created successfully.</response>
        /// <response code="400">Invalid request or duplicate brand.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateBrandRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.CreateAsync(request);

            if (!result)
                return BadRequest("Brand already exists.");

            return Created("", new
            {
                Success = true,
                Message = "Brand created successfully."
            });
        }

        /// <summary>
        /// Updates an existing brand.
        /// </summary>
        /// <remarks>
        /// Updates the details of an existing brand.
        ///
        /// Example:
        ///
        /// PUT /api/Brand/1
        /// </remarks>
        /// <param name="id">Brand identifier.</param>
        /// <param name="request">Updated brand information.</param>
        /// <returns>Success message.</returns>
        /// <response code="200">Brand updated successfully.</response>
        /// <response code="404">Brand not found.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, UpdateBrandRequest request)
        {
            if (id != request.BrandId)
                return BadRequest("Brand Id mismatch.");

            var result = await _service.UpdateAsync(request);

            if (!result)
                return NotFound("Brand not found.");

            return Ok(new
            {
                Success = true,
                Message = "Brand updated successfully."
            });
        }

        /// <summary>
        /// Deletes a brand.
        /// </summary>
        /// <remarks>
        /// Permanently deletes a brand from the marketplace.
        ///
        /// Example:
        ///
        /// DELETE /api/Brand/1
        /// </remarks>
        /// <param name="id">Brand identifier.</param>
        /// <returns>Success message.</returns>
        /// <response code="200">Brand deleted successfully.</response>
        /// <response code="404">Brand not found.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result)
                return NotFound("Brand not found.");

            return Ok(new
            {
                Success = true,
                Message = "Brand deleted successfully."
            });
        }
        [HttpGet("statistics")]
        public async Task<IActionResult> GetStatistics()
        {
            var result = await _service.GetStatisticsAsync();

            return Ok(result);
        }

        [HttpGet("filters")]
        public async Task<IActionResult> GetFilters()
        {
            var result = await _service.GetFiltersAsync();

            return Ok(result);
        }
    }
}

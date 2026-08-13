using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductTypes.Interfaces;
using Marketplacesellerportal.ProductTypes.DTOs;
namespace Marketplacesellerportal.ProductTypes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService _service;

        public ProductTypeController(IProductTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{productTypeId}")]
        public async Task<IActionResult> GetById(int productTypeId)
        {
            var result = await _service.GetByIdAsync(productTypeId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("name/{productTypeName}")]
        public async Task<IActionResult> GetByName(string productTypeName)
        {
            var result = await _service.GetByNameAsync(productTypeName);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActive()
        {
            return Ok(await _service.GetActiveAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductTypeRequest request)
        {
            var productType = new ProductType
            {
                ProductTypeName = request.ProductTypeName,
                Description = request.Description,
                IsActive = request.IsActive,
                CreatedDate = DateTime.Now
            };

            return Ok(await _service.CreateAsync(productType));
        }

        [HttpPut("{productTypeId}")]
        public async Task<IActionResult> Update(int productTypeId, ProductType productType)
        {
            if (!await _service.UpdateAsync(productTypeId, productType))
                return NotFound();

            return Ok();
        }

        [HttpDelete("{productTypeId}")]
        public async Task<IActionResult> Delete(int productTypeId)
        {
            if (!await _service.DeleteAsync(productTypeId))
                return NotFound();

            return Ok();
        }
    }
}


using Marketplacesellerportal.Products.DTOs;
using Marketplacesellerportal.Products.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Marketplacesellerportal.Products.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        // =========================================================
        // GET ALL PRODUCTS
        // =========================================================
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllAsync();

            return Ok(products);
        }

        // =========================================================
        // GET PRODUCT BY ID
        // =========================================================
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);

            if (product == null)
                return NotFound(new
                {
                    message = "Product not found."
                });

            return Ok(product);
        }

        // =========================================================
        // CREATE PRODUCT
        // =========================================================
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateProductDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var product = await _service.CreateAsync(dto);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = product.ProductId },
                    product);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new
                {
                    message = ex.Message
                });
            }
        }

        // =========================================================
        // UPDATE PRODUCT
        // =========================================================
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] UpdateProductDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await _service.UpdateAsync(id, dto);

            if (product == null)
                return NotFound(new
                {
                    message = "Product not found."
                });

            return Ok(product);
        }

        // =========================================================
        // DELETE PRODUCT
        // =========================================================
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound(new
                {
                    message = "Product not found."
                });

            return Ok(new
            {
                message = "Product deleted successfully."
            });
        }
    }
}



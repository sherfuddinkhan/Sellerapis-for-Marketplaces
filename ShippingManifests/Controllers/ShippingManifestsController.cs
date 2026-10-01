using Marketplacesellerportal.ShippingManifests.Interfaces;
using Microsoft.AspNetCore.Mvc;

using ShippingManifestEntity =
    Marketplacesellerportal.Models.ShippingManifest;

namespace Marketplacesellerportal.ShippingManifests.Controllers
{
    [ApiController]
    [Route("api/shipping-manifests")]
    public class ShippingManifestsController :
        ControllerBase
    {
        private readonly IShippingManifestService _service;

        public ShippingManifestsController(
            IShippingManifestService service)
        {
            _service = service;
        }

        // GET: api/shipping-manifests/all
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result =
                await _service.GetAllAsync();

            return Ok(result);
        }

        // GET: api/shipping-manifests/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(
            string id)
        {
            var result =
                await _service.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST: api/shipping-manifests
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] ShippingManifestEntity entity)
        {
            var result =
                await _service.CreateAsync(entity);

            return CreatedAtAction(
                nameof(GetById),
                new
                {
                    id = result.ShippingManifestCode
                },
                result);
        }

        // PUT: api/shipping-manifests/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            string id,
            [FromBody] ShippingManifestEntity entity)
        {
            var updated =
                await _service.UpdateAsync(
                    id,
                    entity);

            if (!updated)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Shipping manifest updated successfully"
            });
        }

        // DELETE: api/shipping-manifests/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(
            string id)
        {
            var deleted =
                await _service.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Shipping manifest deleted successfully"
            });
        }
    }
}
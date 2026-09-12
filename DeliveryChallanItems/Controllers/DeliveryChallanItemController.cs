using Azure.Core;
using Marketplacesellerportal.DeliveryChallanItems.Interfaces;
using Marketplacesellerportal.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Win32;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Marketplacesellerportal.DeliveryChallanItems.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryChallanItemController : ControllerBase
    {
        private readonly IDeliveryChallanItemService _service;

        public DeliveryChallanItemController(
            IDeliveryChallanItemService service)
        {
            _service = service;
        }

        // =========================================================
        // GET ALL
        // GET: /api/DeliveryChallanItem
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();

            return Ok(result);
        }

        // =========================================================
        // GET ALL EXPLICIT
        // GET: /api/DeliveryChallanItem/all
        // =========================================================

        [HttpGet("all")]
        public async Task<IActionResult> GetAllDeliveryChallanItems()
        {
            var result = await _service.GetAllAsync();

            return Ok(result);
        }

        // =========================================================
        // GET BY ID
        // GET: /api/DeliveryChallanItem/1
        // =========================================================

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new
                {
                    message = "DeliveryChallanItemId must be greater than zero."
                });
            }

            var result = await _service.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound(new
                {
                    message = $"Delivery Challan Item with ID {id} was not found."
                });
            }

            return Ok(result);
        }

        // =========================================================
        // GET BY DELIVERY CHALLAN
        // GET: /api/DeliveryChallanItem/challan/2
        // =========================================================

        [HttpGet("challan/{deliveryChallanId:int}")]
        public async Task<IActionResult> GetByDeliveryChallan(
            int deliveryChallanId)
        {
            if (deliveryChallanId <= 0)
            {
                return BadRequest(new
                {
                    message = "DeliveryChallanId must be greater than zero."
                });
            }

            var result =
                await _service.GetByDeliveryChallanAsync(
                    deliveryChallanId);

            return Ok(result);
        }

        // =========================================================
        // GET BY PRODUCT
        // GET: /api/DeliveryChallanItem/product/6
        // =========================================================

        [HttpGet("product/{productId:int}")]
        public async Task<IActionResult> GetByProduct(
            int productId)
        {
            if (productId <= 0)
            {
                return BadRequest(new
                {
                    message = "ProductId must be greater than zero."
                });
            }

            var result =
                await _service.GetByProductAsync(productId);

            return Ok(result);
        }

        // =========================================================
        // SEARCH
        // GET: /api/DeliveryChallanItem/search?search=6
        // =========================================================

        [HttpGet("search")]
        public async Task<IActionResult> Search(
            [FromQuery] string? search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                var all = await _service.GetAllAsync();

                return Ok(all);
            }

            var result =
                await _service.SearchAsync(search.Trim());

            return Ok(result);
        }

        // =========================================================
        // STATISTICS
        // GET: /api/DeliveryChallanItem/stats
        // =========================================================

        [HttpGet("stats")]
        public async Task<IActionResult> GetStatistics()
        {
            var result =
                await _service.GetStatisticsAsync();

            return Ok(result);
        }

        // =========================================================
        // CREATE
        // POST: /api/DeliveryChallanItem
        // =========================================================

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] DeliveryChallanItem deliveryChallanItem)
        {
            if (deliveryChallanItem == null)
            {
                return BadRequest(new
                {
                    message = "Delivery Challan Item data is required."
                });
            }

            try
            {
                var result =
                    await _service.CreateAsync(
                        deliveryChallanItem);

                return CreatedAtAction(
                    nameof(GetById),
                    new
                    {
                        id = result.DeliveryChallanItemId
                    },
                    result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        message = "Failed to create Delivery Challan Item.",
                        error = ex.Message
                    });
            }
        }

        // =========================================================
        // UPDATE
        // PUT: /api/DeliveryChallanItem/1
        // =========================================================

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] DeliveryChallanItem deliveryChallanItem)
        {
            if (id <= 0)
            {
                return BadRequest(new
                {
                    message = "DeliveryChallanItemId must be greater than zero."
                });
            }

            if (deliveryChallanItem == null)
            {
                return BadRequest(new
                {
                    message = "Delivery Challan Item data is required."
                });
            }

            try
            {
                var updated =
                    await _service.UpdateAsync(
                        id,
                        deliveryChallanItem);

                if (!updated)
                {
                    return NotFound(new
                    {
                        message =
                            $"Delivery Challan Item with ID {id} was not found."
                    });
                }

                var result =
                    await _service.GetByIdAsync(id);

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        message = "Failed to update Delivery Challan Item.",
                        error = ex.Message
                    });
            }
        }

        // =========================================================
        // DELETE
        // DELETE: /api/DeliveryChallanItem/1
        // =========================================================

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new
                {
                    message = "DeliveryChallanItemId must be greater than zero."
                });
            }

            try
            {
                var deleted =
                    await _service.DeleteAsync(id);

                if (!deleted)
                {
                    return NotFound(new
                    {
                        message =
                            $"Delivery Challan Item with ID {id} was not found."
                    });
                }

                return Ok(new
                {
                    message =
                        $"Delivery Challan Item with ID {id} deleted successfully."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        message = "Failed to delete Delivery Challan Item.",
                        error = ex.Message
                    });
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.PurchaseOrders.Interfaces;

namespace Marketplacesellerportal.PurchaseOrders.Controllers
{
    [ApiController]
    [Route("api/purchase-orders")]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IPurchaseOrderService _service;


        // =========================================================
        // CONSTRUCTOR
        // =========================================================

        public PurchaseOrderController(
            IPurchaseOrderService service)
        {
            _service = service;
        }


        // =========================================================
        // GET ALL PURCHASE ORDERS
        //
        // GET:
        // /api/purchase-orders
        //
        // Fetches ALL purchase orders at once.
        //
        // No:
        // - seller filter
        // - customer filter
        // - supplier filter
        // - search
        // - pagination
        // - sorting
        // - status filter
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result =
                    await _service.GetAllAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        message =
                            "Failed to fetch purchase orders.",
                        error =
                            ex.Message
                    });
            }
        }


        // =========================================================
        // GET BY ID
        //
        // GET:
        // /api/purchase-orders/{purchaseOrderId}
        //
        // Example:
        // /api/purchase-orders/10
        // =========================================================

        [HttpGet("{purchaseOrderId:int}")]
        public async Task<IActionResult> Get(
            int purchaseOrderId)
        {
            try
            {
                var po =
                    await _service.GetByIdAsync(
                        purchaseOrderId);

                if (po == null)
                {
                    return NotFound(new
                    {
                        message =
                            "Purchase order not found."
                    });
                }

                return Ok(po);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        message =
                            "Failed to fetch purchase order.",
                        error =
                            ex.Message
                    });
            }
        }


        // =========================================================
        // GET BY SELLER + CUSTOMER
        //
        // GET:
        // /api/purchase-orders/seller/6?customerId=3
        // =========================================================

        [HttpGet("seller/{sellerId:int}")]
        public async Task<IActionResult> GetBySeller(
            int sellerId,
            [FromQuery] int customerId)
        {
            try
            {
                var result =
                    await _service.GetBySellerCustomerAsync(
                        sellerId,
                        customerId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        message =
                            "Failed to fetch seller purchase orders.",
                        error =
                            ex.Message
                    });
            }
        }


        // =========================================================
        // GET BY SUPPLIER
        //
        // GET:
        // /api/purchase-orders/supplier/5
        // =========================================================

        [HttpGet("supplier/{supplierId:int}")]
        public async Task<IActionResult> GetBySupplier(
            int supplierId)
        {
            try
            {
                var result =
                    await _service.GetBySupplierIdAsync(
                        supplierId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        message =
                            "Failed to fetch supplier purchase orders.",
                        error =
                            ex.Message
                    });
            }
        }


        // =========================================================
        // GET BY SELLER + PURCHASE ORDER
        //
        // GET:
        // /api/purchase-orders/seller/6/order/10
        // =========================================================

        [HttpGet(
            "seller/{sellerId:int}/order/{purchaseOrderId:int}")]
        public async Task<IActionResult>
            GetBySellerAndPurchaseOrder(
                int sellerId,
                int purchaseOrderId)
        {
            try
            {
                var po =
                    await _service
                        .GetBySellerAndPurchaseOrderIdAsync(
                            sellerId,
                            purchaseOrderId);

                if (po == null)
                {
                    return NotFound(new
                    {
                        message =
                            "Purchase order not found."
                    });
                }

                return Ok(po);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        message =
                            "Failed to fetch purchase order.",
                        error =
                            ex.Message
                    });
            }
        }


        // =========================================================
        // GET BY SELLER + SUPPLIER + PURCHASE ORDER
        //
        // GET:
        // /api/purchase-orders/seller/6/supplier/5/order/10
        // =========================================================

        [HttpGet(
            "seller/{sellerId:int}/supplier/{supplierId:int}/order/{purchaseOrderId:int}")]
        public async Task<IActionResult>
            GetBySellerSupplierAndPurchaseOrder(
                int sellerId,
                int supplierId,
                int purchaseOrderId)
        {
            try
            {
                var po =
                    await _service
                        .GetBySellerSupplierAndPurchaseOrderIdAsync(
                            sellerId,
                            supplierId,
                            purchaseOrderId);

                if (po == null)
                {
                    return NotFound(new
                    {
                        message =
                            "Purchase order not found."
                    });
                }

                return Ok(po);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        message =
                            "Failed to fetch purchase order.",
                        error =
                            ex.Message
                    });
            }
        }


        // =========================================================
        // STATISTICS
        //
        // GET:
        // /api/purchase-orders/stats
        // =========================================================

        [HttpGet("stats")]
        public async Task<IActionResult> GetStatistics()
        {
            try
            {
                var result =
                    await _service.GetStatisticsAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        message =
                            "Failed to fetch purchase order statistics.",
                        error =
                            ex.Message
                    });
            }
        }


        // =========================================================
        // CREATE PURCHASE ORDER
        //
        // POST:
        // /api/purchase-orders
        // =========================================================

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] PurchaseOrder purchaseOrder)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result =
                    await _service.CreateAsync(
                        purchaseOrder);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        message =
                            "Failed to create purchase order.",
                        error =
                            ex.Message
                    });
            }
        }


        // =========================================================
        // UPDATE PURCHASE ORDER
        //
        // PUT:
        // /api/purchase-orders/{purchaseOrderId}
        // =========================================================

        [HttpPut("{purchaseOrderId:int}")]
        public async Task<IActionResult> Update(
            int purchaseOrderId,
            [FromBody] PurchaseOrder purchaseOrder)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var updated =
                    await _service.UpdateAsync(
                        purchaseOrderId,
                        purchaseOrder);

                if (!updated)
                {
                    return NotFound(new
                    {
                        message =
                            "Purchase order not found."
                    });
                }

                return Ok(new
                {
                    message =
                        "Purchase order updated successfully."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        message =
                            "Failed to update purchase order.",
                        error =
                            ex.Message
                    });
            }
        }


        // =========================================================
        // DELETE PURCHASE ORDER
        //
        // DELETE:
        // /api/purchase-orders/{purchaseOrderId}
        // =========================================================

        [HttpDelete("{purchaseOrderId:int}")]
        public async Task<IActionResult> Delete(
            int purchaseOrderId)
        {
            try
            {
                var deleted =
                    await _service.DeleteAsync(
                        purchaseOrderId);

                if (!deleted)
                {
                    return NotFound(new
                    {
                        message =
                            "Purchase order not found."
                    });
                }

                return Ok(new
                {
                    message =
                        "Purchase order deleted successfully."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        message =
                            "Failed to delete purchase order.",
                        error =
                            ex.Message
                    });
            }
        }
    }
}

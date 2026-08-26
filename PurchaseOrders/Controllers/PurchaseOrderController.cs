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

        public PurchaseOrderController(
            IPurchaseOrderService service)
        {
            _service = service;
        }


        // =========================================================
        // GET ALL
        // GET: /api/purchase-orders
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? search,
            [FromQuery] string? status,
            [FromQuery] string? sort,
            [FromQuery] int? page,
            [FromQuery] int? limit)
        {
            // -----------------------------------------------------
            // SEARCH
            // /api/purchase-orders?search=PO-5520
            // -----------------------------------------------------

            if (!string.IsNullOrWhiteSpace(search))
            {
                var result =
                    await _service.SearchAsync(search);

                return Ok(result);
            }


            // -----------------------------------------------------
            // STATUS
            // /api/purchase-orders?status=pending_approval
            // -----------------------------------------------------

            if (!string.IsNullOrWhiteSpace(status))
            {
                var result =
                    await _service.GetByStatusAsync(status);

                return Ok(result);
            }


            // -----------------------------------------------------
            // PAGINATION
            // /api/purchase-orders?page=1&limit=10
            // -----------------------------------------------------

            if (page.HasValue || limit.HasValue)
            {
                var currentPage =
                    page ?? 1;

                var currentLimit =
                    limit ?? 10;

                var result =
                    await _service.GetPagedAsync(
                        currentPage,
                        currentLimit);

                return Ok(new
                {
                    page = currentPage,
                    limit = currentLimit,
                    totalCount = result.TotalCount,
                    items = result.Items
                });
            }


            // -----------------------------------------------------
            // SORT
            // -----------------------------------------------------

            if (!string.IsNullOrWhiteSpace(sort))
            {
                // If GetSortedAsync exists in your service,
                // use it here.
                var result =
                    await _service.GetSortedAsync(sort);

                return Ok(result);
            }


            // -----------------------------------------------------
            // DEFAULT GET ALL
            // -----------------------------------------------------

            return Ok(
                await _service.GetAllAsync());
        }


        // =========================================================
        // GET BY ID
        // GET: /api/purchase-orders/{purchaseOrderId}
        // =========================================================

        [HttpGet("{purchaseOrderId:int}")]
        public async Task<IActionResult> Get(
            int purchaseOrderId)
        {
            var po =
                await _service.GetByIdAsync(
                    purchaseOrderId);

            if (po == null)
                return NotFound();

            return Ok(po);
        }


        // =========================================================
        // GET BY SELLER + CUSTOMER
        // GET:
        // /api/purchase-orders/seller/6?customerId=3
        // =========================================================

        [HttpGet("seller/{sellerId:int}")]
        public async Task<IActionResult> GetBySeller(
            int sellerId,
            [FromQuery] int customerId)
        {
            var result =
                await _service.GetBySellerCustomerAsync(
                    sellerId,
                    customerId);

            return Ok(result);
        }


        // =========================================================
        // GET BY SUPPLIER
        // GET:
        // /api/purchase-orders/supplier/5
        // =========================================================

        [HttpGet("supplier/{supplierId:int}")]
        public async Task<IActionResult> GetBySupplier(
            int supplierId)
        {
            var result =
                await _service.GetBySupplierIdAsync(
                    supplierId);

            return Ok(result);
        }


        // =========================================================
        // GET BY SELLER + PURCHASE ORDER
        // GET:
        // /api/purchase-orders/seller/6/order/10
        // =========================================================

        [HttpGet("seller/{sellerId:int}/order/{purchaseOrderId:int}")]
        public async Task<IActionResult>
            GetBySellerAndPurchaseOrder(
                int sellerId,
                int purchaseOrderId)
        {
            var po =
                await _service
                    .GetBySellerAndPurchaseOrderIdAsync(
                        sellerId,
                        purchaseOrderId);

            if (po == null)
                return NotFound();

            return Ok(po);
        }


        // =========================================================
        // GET BY SELLER + SUPPLIER + PURCHASE ORDER
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
            var po =
                await _service
                    .GetBySellerSupplierAndPurchaseOrderIdAsync(
                        sellerId,
                        supplierId,
                        purchaseOrderId);

            if (po == null)
                return NotFound();

            return Ok(po);
        }


        // =========================================================
        // STATISTICS
        // GET:
        // /api/purchase-orders/stats
        // =========================================================

        [HttpGet("stats")]
        public async Task<IActionResult>
            GetStatistics()
        {
            var result =
                await _service.GetStatisticsAsync();

            return Ok(result);
        }


        // =========================================================
        // CREATE
        // POST:
        // /api/purchase-orders
        // =========================================================

        [HttpPost]
        public async Task<IActionResult>
            Create(
                [FromBody] PurchaseOrder purchaseOrder)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result =
                await _service.CreateAsync(
                    purchaseOrder);

            return Ok(result);
        }


        // =========================================================
        // UPDATE
        // PUT:
        // /api/purchase-orders/{purchaseOrderId}
        // =========================================================

        [HttpPut("{purchaseOrderId:int}")]
        public async Task<IActionResult>
            Update(
                int purchaseOrderId,
                [FromBody] PurchaseOrder purchaseOrder)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated =
                await _service.UpdateAsync(
                    purchaseOrderId,
                    purchaseOrder);

            if (!updated)
                return NotFound();

            return Ok(new
            {
                message =
                    "Purchase order updated successfully."
            });
        }


        // =========================================================
        // DELETE
        // DELETE:
        // /api/purchase-orders/{purchaseOrderId}
        // =========================================================

        [HttpDelete("{purchaseOrderId:int}")]
        public async Task<IActionResult>
            Delete(
                int purchaseOrderId)
        {
            var deleted =
                await _service.DeleteAsync(
                    purchaseOrderId);

            if (!deleted)
                return NotFound();

            return Ok(new
            {
                message =
                    "Purchase order deleted successfully."
            });
        }
    }
}
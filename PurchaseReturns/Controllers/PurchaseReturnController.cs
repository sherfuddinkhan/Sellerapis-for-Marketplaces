using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.PurchaseReturns.Interfaces;

namespace Marketplacesellerportal.PurchaseReturns.Controllers
{
    [ApiController]
    [Route("api/purchase-returns")]
    public class PurchaseReturnController : ControllerBase
    {
        private readonly IPurchaseReturnService _service;

        public PurchaseReturnController(
            IPurchaseReturnService service)
        {
            _service = service;
        }

        // =========================================================
        // GET ALL / SEARCH / STATUS / PAGINATION / SORTING
        // =========================================================
        //
        // GET /api/purchase-returns
        //
        // GET /api/purchase-returns?search=PR-3120
        //
        // GET /api/purchase-returns?status=pending_pickup
        //
        // GET /api/purchase-returns?search=PR-3120&status=pending_pickup
        //
        // GET /api/purchase-returns?page=1&limit=10
        //
        // GET /api/purchase-returns?sort=id_asc
        //
        // GET /api/purchase-returns?sort=id_desc
        //
        // GET /api/purchase-returns?sort=status_asc
        //
        // GET /api/purchase-returns?sort=status_desc
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? search,
            [FromQuery] string? status,
            [FromQuery] string? sort,
            [FromQuery] int? page,
            [FromQuery] int? limit)
        {
            // =====================================================
            // PAGINATION
            // =====================================================

            if (page.HasValue || limit.HasValue)
            {
                var currentPage = page ?? 1;
                var currentLimit = limit ?? 10;

                if (currentPage < 1)
                    currentPage = 1;

                if (currentLimit < 1)
                    currentLimit = 10;

                if (currentLimit > 100)
                    currentLimit = 100;

                var result =
                    await _service.GetPagedAsync(
                        currentPage,
                        currentLimit);

                var totalPages =
                    result.TotalCount == 0
                        ? 0
                        : (int)Math.Ceiling(
                            result.TotalCount /
                            (double)currentLimit);

                return Ok(new
                {
                    page = currentPage,
                    limit = currentLimit,
                    totalCount = result.TotalCount,
                    totalPages = totalPages,
                    items = result.Items
                });
            }

            // =====================================================
            // SEARCH + STATUS
            // =====================================================

            if (!string.IsNullOrWhiteSpace(search) ||
                !string.IsNullOrWhiteSpace(status))
            {
                var result =
                    await _service.SearchAsync(
                        search,
                        status);

                return Ok(result);
            }

            // =====================================================
            // SORTING
            // =====================================================

            if (!string.IsNullOrWhiteSpace(sort))
            {
                var result =
                    await _service.GetSortedAsync(sort);

                return Ok(result);
            }

            // =====================================================
            // GET ALL
            // =====================================================

            var all =
                await _service.GetAllAsync();

            return Ok(all);
        }


        // =========================================================
        // STATISTICS
        //
        // GET /api/purchase-returns/stats
        // =========================================================

        [HttpGet("stats")]
        public async Task<IActionResult> GetStatistics()
        {
            var result =
                await _service.GetStatisticsAsync();

            return Ok(result);
        }


        // =========================================================
        // GET BY ID
        //
        // GET /api/purchase-returns/1
        // =========================================================

        [HttpGet("{purchaseReturnId:int}")]
        public async Task<IActionResult> GetById(
            int purchaseReturnId)
        {
            var result =
                await _service.GetByIdAsync(
                    purchaseReturnId);

            if (result == null)
            {
                return NotFound(new
                {
                    message =
                        "Purchase return not found."
                });
            }

            return Ok(result);
        }


        // =========================================================
        // GET BY PURCHASE ORDER
        //
        // GET /api/purchase-returns/purchaseorder/1
        // =========================================================

        [HttpGet("purchaseorder/{purchaseOrderId:int}")]
        public async Task<IActionResult> GetByPurchaseOrder(
            int purchaseOrderId)
        {
            var result =
                await _service.GetByPurchaseOrderIdAsync(
                    purchaseOrderId);

            return Ok(result);
        }


        // =========================================================
        // GET BY SUPPLIER
        //
        // GET /api/purchase-returns/supplier/1
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
        // GET BY GRN
        //
        // GET /api/purchase-returns/grn/1
        // =========================================================

        [HttpGet("grn/{goodsReceiptNoteId:int}")]
        public async Task<IActionResult> GetByGRN(
            int goodsReceiptNoteId)
        {
            var result =
                await _service.GetByGoodsReceiptNoteIdAsync(
                    goodsReceiptNoteId);

            return Ok(result);
        }


        // =========================================================
        // GET BY SELLER
        //
        // GET /api/purchase-returns/seller/1
        // =========================================================

        [HttpGet("seller/{sellerId:int}")]
        public async Task<IActionResult> GetBySeller(
            int sellerId)
        {
            var result =
                await _service.GetBySellerIdAsync(
                    sellerId);

            return Ok(result);
        }


        // =========================================================
        // GET BY CUSTOMER
        //
        // GET /api/purchase-returns/customer/1
        // =========================================================

        [HttpGet("customer/{customerId:int}")]
        public async Task<IActionResult> GetByCustomer(
            int customerId)
        {
            var result =
                await _service.GetByCustomerIdAsync(
                    customerId);

            return Ok(result);
        }


        // =========================================================
        // GET BY SELLER + CUSTOMER
        //
        // GET /api/purchase-returns/seller/1/customer/2
        // =========================================================

        [HttpGet("seller/{sellerId:int}/customer/{customerId:int}")]
        public async Task<IActionResult> GetBySellerCustomer(
            int sellerId,
            int customerId)
        {
            var result =
                await _service.GetBySellerCustomerAsync(
                    sellerId,
                    customerId);

            return Ok(result);
        }


        // =========================================================
        // GET BY STATUS
        //
        // GET /api/purchase-returns/status/pending_pickup
        // =========================================================

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(
            string status)
        {
            var result =
                await _service.GetByStatusAsync(
                    status);

            return Ok(result);
        }


        // =========================================================
        // GET SPECIFIC PURCHASE RETURN
        //
        // GET
        // /api/purchase-returns/purchaseorder/1/supplier/2/return/3
        // =========================================================

        [HttpGet(
            "purchaseorder/{purchaseOrderId:int}/supplier/{supplierId:int}/return/{purchaseReturnId:int}")]
        public async Task<IActionResult> GetPurchaseReturn(
            int purchaseOrderId,
            int supplierId,
            int purchaseReturnId)
        {
            var result =
                await _service.GetPurchaseReturnAsync(
                    purchaseOrderId,
                    supplierId,
                    purchaseReturnId);

            if (result == null)
            {
                return NotFound(new
                {
                    message =
                        "Purchase return not found."
                });
            }

            return Ok(result);
        }


        // =========================================================
        // CREATE
        //
        // POST /api/purchase-returns
        // =========================================================

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] PurchaseReturn purchaseReturn)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result =
                    await _service.CreateAsync(
                        purchaseReturn);

                return CreatedAtAction(
                    nameof(GetById),
                    new
                    {
                        purchaseReturnId =
                            result.PurchaseReturnId
                    },
                    result);
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
        // UPDATE
        //
        // PUT /api/purchase-returns/1
        // =========================================================

        [HttpPut("{purchaseReturnId:int}")]
        public async Task<IActionResult> Update(
            int purchaseReturnId,
            [FromBody] PurchaseReturn purchaseReturn)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var updated =
                    await _service.UpdateAsync(
                        purchaseReturnId,
                        purchaseReturn);

                if (!updated)
                {
                    return NotFound(new
                    {
                        message =
                            "Purchase return not found."
                    });
                }

                var result =
                    await _service.GetByIdAsync(
                        purchaseReturnId);

                return Ok(result);
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
        // DELETE
        //
        // DELETE /api/purchase-returns/1
        // =========================================================

        [HttpDelete("{purchaseReturnId:int}")]
        public async Task<IActionResult> Delete(
            int purchaseReturnId)
        {
            var deleted =
                await _service.DeleteAsync(
                    purchaseReturnId);

            if (!deleted)
            {
                return NotFound(new
                {
                    message =
                        "Purchase return not found."
                });
            }

            return Ok(new
            {
                message =
                    "Purchase return deleted successfully."
            });
        }
    }
}
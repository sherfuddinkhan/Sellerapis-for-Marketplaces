using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.StockLedgers.Interfaces;

namespace Marketplacesellerportal.StockLedgers.Controllers
{
    [ApiController]
    [Route("api/stock-ledgers")]
    public class StockLedgerController : ControllerBase
    {
        private readonly IStockLedgerService _service;

        public StockLedgerController(
            IStockLedgerService service)
        {
            _service = service;
        }

        // =========================================================
        // GET ALL / SEARCH / FILTER / SORT / PAGINATION
        //
        // GET /api/stock-ledgers
        //
        // GET /api/stock-ledgers?search=PO-001
        //
        // GET /api/stock-ledgers?search=PO-001&transactionType=Purchase
        //
        // GET /api/stock-ledgers?sort=quantity_desc
        //
        // GET /api/stock-ledgers?page=1&limit=25
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? search,
            [FromQuery] string? transactionType,
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
                var currentLimit = limit ?? 25;

                if (currentPage < 1)
                    currentPage = 1;

                if (currentLimit < 1)
                    currentLimit = 25;

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
            // SEARCH + TRANSACTION TYPE FILTER
            // =====================================================

            if (!string.IsNullOrWhiteSpace(search) ||
                !string.IsNullOrWhiteSpace(transactionType))
            {
                var result =
                    await _service.SearchAsync(
                        search,
                        transactionType);

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
        // GET /api/stock-ledgers/statistics
        // =========================================================

        [HttpGet("statistics")]
        public async Task<IActionResult> GetStatistics()
        {
            var result =
                await _service.GetStatisticsAsync();

            return Ok(result);
        }


        // =========================================================
        // FILTERS
        //
        // GET /api/stock-ledgers/filters
        // =========================================================

        [HttpGet("filters")]
        public async Task<IActionResult> GetFilters()
        {
            var result =
                await _service.GetFiltersAsync();

            return Ok(result);
        }


        // =========================================================
        // GET BY ID
        //
        // GET /api/stock-ledgers/1
        // =========================================================

        [HttpGet("{stockLedgerId:int}")]
        public async Task<IActionResult> GetById(
            int stockLedgerId)
        {
            var result =
                await _service.GetByIdAsync(
                    stockLedgerId);

            if (result == null)
            {
                return NotFound(new
                {
                    message = "Stock ledger not found."
                });
            }

            return Ok(result);
        }


        // =========================================================
        // GET BY SELLER
        //
        // GET /api/stock-ledgers/seller/6
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
        // GET /api/stock-ledgers/customer/3
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
        // GET /api/stock-ledgers/seller/6/customer/3
        // =========================================================

        [HttpGet(
            "seller/{sellerId:int}/customer/{customerId:int}")]
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
        // GET BY PRODUCT
        //
        // GET /api/stock-ledgers/product/6
        // =========================================================

        [HttpGet("product/{productId:int}")]
        public async Task<IActionResult> GetByProduct(
            int productId)
        {
            var result =
                await _service.GetByProductIdAsync(
                    productId);

            return Ok(result);
        }


        // =========================================================
        // GET BY WAREHOUSE
        //
        // GET /api/stock-ledgers/warehouse/3
        // =========================================================

        [HttpGet("warehouse/{warehouseId:int}")]
        public async Task<IActionResult> GetByWarehouse(
            int warehouseId)
        {
            var result =
                await _service.GetByWarehouseIdAsync(
                    warehouseId);

            return Ok(result);
        }


        // =========================================================
        // GET BY TRANSACTION TYPE
        //
        // GET /api/stock-ledgers/transaction/Purchase
        // =========================================================

        [HttpGet("transaction/{transactionType}")]
        public async Task<IActionResult> GetByTransactionType(
            string transactionType)
        {
            var result =
                await _service.GetByTransactionTypeAsync(
                    transactionType);

            return Ok(result);
        }


        // =========================================================
        // GET SPECIFIC STOCK LEDGER
        //
        // GET
        // /api/stock-ledgers/
        // 6/6/3/1
        // =========================================================

        [HttpGet(
            "seller/{sellerId:int}/product/{productId:int}/warehouse/{warehouseId:int}/ledger/{stockLedgerId:int}")]
        public async Task<IActionResult> GetStockLedger(
            int sellerId,
            int productId,
            int warehouseId,
            int stockLedgerId)
        {
            var result =
                await _service.GetStockLedgerAsync(
                    sellerId,
                    productId,
                    warehouseId,
                    stockLedgerId);

            if (result == null)
            {
                return NotFound(new
                {
                    message = "Stock ledger not found."
                });
            }

            return Ok(result);
        }


        // =========================================================
        // CREATE
        //
        // POST /api/stock-ledgers
        // =========================================================

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] StockLedger stockLedger)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result =
                await _service.CreateAsync(
                    stockLedger);

            return CreatedAtAction(
                nameof(GetById),
                new
                {
                    stockLedgerId =
                        result.StockLedgerId
                },
                result);
        }


        // =========================================================
        // UPDATE
        //
        // PUT /api/stock-ledgers/1
        // =========================================================

        [HttpPut("{stockLedgerId:int}")]
        public async Task<IActionResult> Update(
            int stockLedgerId,
            [FromBody] StockLedger stockLedger)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result =
                await _service.UpdateAsync(
                    stockLedgerId,
                    stockLedger);

            if (!result)
            {
                return NotFound(new
                {
                    message = "Stock ledger not found."
                });
            }

            return Ok(new
            {
                message =
                    "Stock ledger updated successfully."
            });
        }


        // =========================================================
        // DELETE
        //
        // DELETE /api/stock-ledgers/1
        // =========================================================

        [HttpDelete("{stockLedgerId:int}")]
        public async Task<IActionResult> Delete(
            int stockLedgerId)
        {
            var result =
                await _service.DeleteAsync(
                    stockLedgerId);

            if (!result)
            {
                return NotFound(new
                {
                    message = "Stock ledger not found."
                });
            }

            return Ok(new
            {
                message =
                    "Stock ledger deleted successfully."
            });
        }
    }
}


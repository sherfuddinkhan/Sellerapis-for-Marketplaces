using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.StockLedgers.Interfaces;

namespace Marketplacesellerportal.StockLedgers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockLedgerController : ControllerBase
    {
        private readonly IStockLedgerService _service;

        public StockLedgerController(IStockLedgerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{stockLedgerId}")]
        public async Task<IActionResult> GetById(int stockLedgerId)
        {
            var result = await _service.GetByIdAsync(stockLedgerId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("seller/{sellerId}")]
        public async Task<IActionResult> GetBySeller(int sellerId)
        {
            return Ok(await _service.GetBySellerIdAsync(sellerId));
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            return Ok(await _service.GetByProductIdAsync(productId));
        }

        [HttpGet("warehouse/{warehouseId}")]
        public async Task<IActionResult> GetByWarehouse(int warehouseId)
        {
            return Ok(await _service.GetByWarehouseIdAsync(warehouseId));
        }

        [HttpGet("transaction/{transactionType}")]
        public async Task<IActionResult> GetByTransactionType(string transactionType)
        {
            return Ok(await _service.GetByTransactionTypeAsync(transactionType));
        }

        [HttpGet("{sellerId}/{productId}/{warehouseId}/{stockLedgerId}")]
        public async Task<IActionResult> GetStockLedger(
            int sellerId,
            int productId,
            int warehouseId,
            int stockLedgerId)
        {
            var result = await _service.GetStockLedgerAsync(
                sellerId,
                productId,
                warehouseId,
                stockLedgerId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StockLedger stockLedger)
        {
            return Ok(await _service.CreateAsync(stockLedger));
        }

        [HttpPut("{stockLedgerId}")]
        public async Task<IActionResult> Update(
            int stockLedgerId,
            StockLedger stockLedger)
        {
            if (!await _service.UpdateAsync(stockLedgerId, stockLedger))
                return NotFound();

            return Ok();
        }

        [HttpDelete("{stockLedgerId}")]
        public async Task<IActionResult> Delete(int stockLedgerId)
        {
            if (!await _service.DeleteAsync(stockLedgerId))
                return NotFound();

            return Ok();
        }
    }
}

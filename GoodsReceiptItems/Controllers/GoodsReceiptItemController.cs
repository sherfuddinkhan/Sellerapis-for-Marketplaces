using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.GoodsReceiptItems.Interfaces;
using Marketplacesellerportal.GoodsReceiptItems.DTOs;
using System.Text.Json;

namespace Marketplacesellerportal.GoodsReceiptItems.Controllers
{
    [ApiController]
    [Route("api/goods-receipt-note-items")]
    public class GoodsReceiptItemController : ControllerBase
    {
        private readonly IGoodsReceiptItemService _service;

        public GoodsReceiptItemController(IGoodsReceiptItemService service)
        {
            _service = service;
        }

        private static GoodsReceiptItemDto ToDto(GoodsReceiptItem x)
        {
            return new GoodsReceiptItemDto
            {
                GoodsReceiptItemId = x.GoodsReceiptItemId,
                GoodsReceiptNoteId = x.GoodsReceiptNoteId,
                PurchaseOrderItemId = x.PurchaseOrderItemId,
                SellerId = x.SellerId,
                CustomerId = x.CustomerId,
                SupplierId = x.SupplierId,
                ProductId = x.ProductId,
                LineNumber = x.LineNumber,

                // Uniware Core Fields
                SkuCode = x.SkuCode ?? "TN-WBH-001",
                ItemCode = x.ItemCode ?? "TN-WBH-001",
                UniwareItemCode = x.UniwareItemCode ?? x.SkuCode ?? "TN-WBH-001",
                BatchCode = x.BatchCode ?? "BATCH-0928-A",
                VendorBatchNumber = x.VendorBatchNumber,
                VendorCode = x.VendorCode ?? "SUP-TN-001",
                UniwareVendorCode = x.UniwareVendorCode ?? x.VendorCode ?? "SUP-TN-001",

                // 8 Missing Columns - Added with DB Values
                FacilityCode = x.FacilityCode ?? "TN-WH-01",
                UniwareFacilityCode = x.UniwareFacilityCode ?? "TN-WH-01",
                ChannelCode = x.ChannelCode ?? "CUSTOM",
                BinCode = x.BinCode ?? "BIN-A1",
                ShelfCode = x.ShelfCode ?? "SHELF-01",
                UniwareSyncStatus = x.UniwareSyncStatus ?? "Pending",

                ReceivedQuantity = x.ReceivedQuantity,
                AcceptedQuantity = x.AcceptedQuantity,
                RejectedQuantity = x.RejectedQuantity,
                UnitPrice = x.UnitPrice,
                TotalAmount = x.TotalAmount,
                Mrp = x.Mrp,
                Cost = x.Cost,
                AdditionalCost = x.AdditionalCost,
                ManufacturingDate = x.ManufacturingDate,
                ExpiryDate = x.ExpiryDate,
                ItemDetailCode = x.ItemDetailCode,
                Status = x.Status,
                Remarks = x.Remarks,
                SerialCodes = string.IsNullOrEmpty(x.SerialCodesJson)
                  ? new List<string>()
                    : System.Text.Json.JsonSerializer.Deserialize<List<string>>(x.SerialCodesJson) ?? new List<string>(),
                SerialCodesJson = x.SerialCodesJson
            };
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllItems()
        {
            var result = await _service.GetAllAsync();
            return Ok(result.Select(ToDto));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? search, [FromQuery] int? page, [FromQuery] int? limit, [FromQuery] string? sort)
        {
            if (!string.IsNullOrWhiteSpace(search))
            {
                var searchResult = await _service.SearchAsync(search);
                return Ok(searchResult.Select(ToDto));
            }
            if (page.HasValue || limit.HasValue)
            {
                var result = await _service.GetPagedAsync(page ?? 1, limit ?? 25);
                return Ok(new { page = page ?? 1, limit = limit ?? 25, totalCount = result.TotalCount, items = result.Items.Select(ToDto) });
            }
            if (!string.IsNullOrWhiteSpace(sort))
            {
                var sorted = await _service.GetSortedAsync(sort);
                return Ok(sorted.Select(ToDto));
            }
            var all = await _service.GetAllAsync();
            return Ok(all.Select(ToDto));
        }

        [HttpGet("stats")]
        public async Task<IActionResult> GetStatistics()
        {
            var result = await _service.GetStatisticsAsync();
            return Ok(result);
        }

        [HttpGet("{goodsReceiptItemId:int}")]
        public async Task<IActionResult> GetById(int goodsReceiptItemId)
        {
            var result = await _service.GetByIdAsync(goodsReceiptItemId);
            if (result == null) return NotFound();
            return Ok(ToDto(result));
        }

        [HttpGet("grn/{goodsReceiptNoteId:int}")]
        public async Task<IActionResult> GetByGoodsReceiptNote(int goodsReceiptNoteId)
        {
            var result = await _service.GetByGoodsReceiptNoteIdAsync(goodsReceiptNoteId);
            return Ok(result.Select(ToDto));
        }

        [HttpGet("grn/{goodsReceiptNoteId:int}/item/{goodsReceiptItemId:int}")]
        public async Task<IActionResult> GetByGoodsReceiptNoteAndItem(int goodsReceiptNoteId, int goodsReceiptItemId)
        {
            var result = await _service.GetByGoodsReceiptNoteAndItemAsync(goodsReceiptNoteId, goodsReceiptItemId);
            if (result == null) return NotFound();
            return Ok(ToDto(result));
        }

        [HttpGet("product/{productId:int}")]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            var result = await _service.GetByProductIdAsync(productId);
            return Ok(result.Select(ToDto));
        }

        [HttpGet("seller/{sellerId:int}")]
        public async Task<IActionResult> GetBySeller(int sellerId)
        {
            var result = await _service.GetBySellerIdAsync(sellerId);
            return Ok(result.Select(ToDto));
        }

        [HttpGet("customer/{customerId:int}")]
        public async Task<IActionResult> GetByCustomer(int customerId)
        {
            var result = await _service.GetByCustomerIdAsync(customerId);
            return Ok(result.Select(ToDto));
        }

        [HttpGet("seller/{sellerId:int}/customer/{customerId:int}")]
        public async Task<IActionResult> GetBySellerCustomer(int sellerId, int customerId)
        {
            var result = await _service.GetBySellerCustomerAsync(sellerId, customerId);
            return Ok(result.Select(ToDto));
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGoodsReceiptItemDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = new GoodsReceiptItem
            {
                GoodsReceiptNoteId = dto.GoodsReceiptNoteId,
                PurchaseOrderItemId = dto.PurchaseOrderItemId,
                ProductId = dto.ProductId,
                SellerId = dto.SellerId,
                CustomerId = dto.CustomerId,
                SupplierId = dto.SupplierId,
                LineNumber = dto.LineNumber,
                ReceivedQuantity = dto.ReceivedQuantity,
                AcceptedQuantity = dto.AcceptedQuantity,
                RejectedQuantity = dto.ReceivedQuantity - dto.AcceptedQuantity,
                UnitPrice = dto.UnitPrice,
                TotalAmount = dto.AcceptedQuantity * dto.UnitPrice,

                // Uniware Mandatory - With DB Defaults
                SkuCode = dto.SkuCode ?? "TN-WBH-001",
                ItemCode = dto.ItemCode ?? dto.SkuCode ?? "TN-WBH-001",
                BatchCode = dto.BatchCode ?? "BATCH-0928-A",
                VendorBatchNumber = dto.VendorBatchNumber ?? "VB-001",
                VendorCode = dto.VendorCode ?? "SUP-TN-001",

                // 8 Missing Columns - Now Added
                UniwareItemCode = dto.UniwareItemCode ?? dto.SkuCode ?? "TN-WBH-001",
                UniwareVendorCode = dto.UniwareVendorCode ?? dto.VendorCode ?? "SUP-TN-001",
                FacilityCode = dto.FacilityCode ?? "TN-WH-01",
                UniwareFacilityCode = dto.UniwareFacilityCode ?? "TN-WH-01",
                ChannelCode = dto.ChannelCode ?? "CUSTOM",
                BinCode = dto.BinCode ?? "BIN-A1",
                ShelfCode = dto.ShelfCode ?? "SHELF-01",
                UniwareSyncStatus = dto.UniwareSyncStatus ?? "Pending",

                Mrp = dto.Mrp ?? 120,
                Cost = dto.Cost ?? 90,
                AdditionalCost = dto.AdditionalCost,
                ManufacturingDate = dto.ManufacturingDate,
                ExpiryDate = dto.ExpiryDate,
                ItemDetailCode = dto.ItemDetailCode ?? "DETAIL-001",
                Status = dto.Status ?? "Accepted",
                Remarks = dto.Remarks ?? "QC Passed",
                SerialCodesJson = dto.SerialCodes == null ? null : System.Text.Json.JsonSerializer.Serialize(dto.SerialCodes)
            };
            var result = await _service.CreateAsync(entity);
            return CreatedAtAction(nameof(GetById), new { goodsReceiptItemId = result.GoodsReceiptItemId }, ToDto(result));
        }

        [HttpPut("{goodsReceiptItemId:int}")]
        public async Task<IActionResult> Update(int goodsReceiptItemId, [FromBody] UpdateGoodsReceiptItemDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var existing = await _service.GetByIdAsync(goodsReceiptItemId);
            if (existing == null) return NotFound();
            existing.GoodsReceiptNoteId = dto.GoodsReceiptNoteId;
            existing.ReceivedQuantity = dto.ReceivedQuantity;
            existing.AcceptedQuantity = dto.AcceptedQuantity;
            existing.UnitPrice = dto.UnitPrice;
            existing.SkuCode = dto.SkuCode;
            existing.BatchCode = dto.BatchCode;
            existing.VendorCode = dto.VendorCode;
            existing.Status = dto.Status;
            existing.Remarks = dto.Remarks;
            var updated = await _service.UpdateAsync(goodsReceiptItemId, existing);
            if (!updated) return NotFound();
            return Ok(new { message = "Goods Receipt Item updated successfully." });
        }

        [HttpDelete("{goodsReceiptItemId:int}")]
        public async Task<IActionResult> Delete(int goodsReceiptItemId)
        {
            var deleted = await _service.DeleteAsync(goodsReceiptItemId);
            if (!deleted) return NotFound();
            return Ok(new { message = "Goods Receipt Item deleted successfully." });
        }
    }
}
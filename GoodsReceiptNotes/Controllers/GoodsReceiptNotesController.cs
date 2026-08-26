using Marketplacesellerportal.GoodsReceiptNotes.DTOs;
using Marketplacesellerportal.GoodsReceiptNotes.Interfaces;
using Marketplacesellerportal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;

namespace Marketplacesellerportal.GoodsReceiptNotes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoodsReceiptNotesController : ControllerBase
    {
        private readonly IGoodsReceiptNoteService _service;

        public GoodsReceiptNotesController(
            IGoodsReceiptNoteService service)
        {
            _service = service;
        }


        // =========================================================
        // GET ALL
        // GET /api/GoodsReceiptNotes
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(
                await _service.GetAllAsync()
            );
        }


        // =========================================================
        // GET BY ID
        // GET /api/GoodsReceiptNotes/1
        // =========================================================

        [HttpGet("{goodsReceiptNoteId:int}")]
        public async Task<IActionResult> GetById(
            int goodsReceiptNoteId)
        {
            var data =
                await _service.GetByIdAsync(
                    goodsReceiptNoteId);

            if (data == null)
                return NotFound();

            return Ok(data);
        }


        // =========================================================
        // GET BY PURCHASE ORDER
        // GET /api/GoodsReceiptNotes/purchaseorder/1
        // =========================================================

        [HttpGet("purchaseorder/{purchaseOrderId:int}")]
        public async Task<IActionResult> GetByPurchaseOrder(
            int purchaseOrderId)
        {
            return Ok(
                await _service.GetByPurchaseOrderIdAsync(
                    purchaseOrderId)
            );
        }


        // =========================================================
        // GET BY PURCHASE ORDER + GRN
        // GET /api/GoodsReceiptNotes/purchaseorder/1/grn/1
        // =========================================================

        [HttpGet("purchaseorder/{purchaseOrderId:int}/grn/{goodsReceiptNoteId:int}")]
        public async Task<IActionResult> GetByPurchaseOrderAndGRN(
            int purchaseOrderId,
            int goodsReceiptNoteId)
        {
            var result =
                await _service.GetByPurchaseOrderAndGRNAsync(
                    purchaseOrderId,
                    goodsReceiptNoteId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        // =========================================================
        // GET BY SELLER
        // GET /api/GoodsReceiptNotes/seller/6
        // =========================================================

        [HttpGet("seller/{sellerId:int}")]
        public async Task<IActionResult> GetBySeller(
            int sellerId)
        {
            return Ok(
                await _service.GetBySellerIdAsync(
                    sellerId)
            );
        }


        // =========================================================
        // GET BY CUSTOMER
        // GET /api/GoodsReceiptNotes/customer/3
        // =========================================================

        [HttpGet("customer/{customerId:int}")]
        public async Task<IActionResult> GetByCustomer(
            int customerId)
        {
            return Ok(
                await _service.GetByCustomerIdAsync(
                    customerId)
            );
        }


        // =========================================================
        // GET BY SUPPLIER
        // GET /api/GoodsReceiptNotes/supplier/1
        // =========================================================

        [HttpGet("supplier/{supplierId:int}")]
        public async Task<IActionResult> GetBySupplier(
            int supplierId)
        {
            return Ok(
                await _service.GetBySupplierIdAsync(
                    supplierId)
            );
        }


        // =========================================================
        // GET BY SELLER + CUSTOMER
        // GET /api/GoodsReceiptNotes/seller/6/customer/3
        // =========================================================

        [HttpGet("seller/{sellerId:int}/customer/{customerId:int}")]
        public async Task<IActionResult> GetBySellerCustomer(
            int sellerId,
            int customerId)
        {
            return Ok(
                await _service.GetBySellerCustomerAsync(
                    sellerId,
                    customerId)
            );
        }


        // =========================================================
        // GET BY STATUS
        // GET /api/GoodsReceiptNotes/status/inspected
        // =========================================================

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(
            string status)
        {
            return Ok(
                await _service.GetByStatusAsync(
                    status)
            );
        }


        // =========================================================
        // SEARCH
        //
        // GET /api/GoodsReceiptNotes?search=GRN-998
        //
        // SEARCH + STATUS
        // GET /api/GoodsReceiptNotes?search=GRN-998&status=inspected
        // =========================================================

        [HttpGet("search")]
        public async Task<IActionResult> Search(
            [FromQuery] string? search,
            [FromQuery] string? status)
        {
            return Ok(
                await _service.SearchAsync(
                    search,
                    status)
            );
        }


        // =========================================================
        // STATISTICS
        // GET /api/GoodsReceiptNotes/stats
        // =========================================================

        [HttpGet("stats")]
        public async Task<IActionResult> GetStatistics()
        {
            return Ok(
                await _service.GetStatisticsAsync()
            );
        }


        // =========================================================
        // PAGINATION
        //
        // GET /api/GoodsReceiptNotes/page?page=1&limit=15
        // =========================================================

        [HttpGet("page")]
        public async Task<IActionResult> GetPaged(
            [FromQuery] int page = 1,
            [FromQuery] int limit = 15)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 15;

            if (limit > 100)
                limit = 100;

            var result =
                await _service.GetPagedAsync(
                    page,
                    limit);

            return Ok(new
            {
                page,
                limit,
                totalCount = result.TotalCount,
                totalPages =
                    (int)Math.Ceiling(
                        result.TotalCount /
                        (double)limit),
                items = result.Items
            });
        }


        // =========================================================
        // SORTING
        //
        // GET /api/GoodsReceiptNotes/sort?sort=date_desc
        // =========================================================

        [HttpGet("sort")]
        public async Task<IActionResult> GetSorted(
            [FromQuery] string? sort)
        {
            return Ok(
                await _service.GetSortedAsync(
                    sort)
            );
        }


        // =========================================================
        // CREATE
        // POST /api/GoodsReceiptNotes
        // =========================================================

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] GoodsReceiptNote goodsReceiptNote)
        {
            var result =
                await _service.CreateAsync(
                    goodsReceiptNote);

            return Ok(result);
        }


        // =========================================================
        // UPDATE
        // PUT /api/GoodsReceiptNotes/1
        // =========================================================

        [HttpPut("{goodsReceiptNoteId:int}")]
        public async Task<IActionResult> Update(
            int goodsReceiptNoteId,
            [FromBody] GoodsReceiptNote goodsReceiptNote)
        {
            var updated =
                await _service.UpdateAsync(
                    goodsReceiptNoteId,
                    goodsReceiptNote);

            if (!updated)
                return NotFound();

            return Ok(
                new
                {
                    message =
                        "Goods Receipt Note updated successfully."
                }
            );
        }


        // =========================================================
        // DELETE
        // DELETE /api/GoodsReceiptNotes/1
        // =========================================================

        [HttpDelete("{goodsReceiptNoteId:int}")]
        public async Task<IActionResult> Delete(
            int goodsReceiptNoteId)
        {
            var deleted =
                await _service.DeleteAsync(
                    goodsReceiptNoteId);

            if (!deleted)
                return NotFound();

            return Ok(
                new
                {
                    message =
                        "Goods Receipt Note deleted successfully."
                }
            );
        }
    }
}

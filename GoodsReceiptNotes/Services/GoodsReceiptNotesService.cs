using Marketplacesellerportal.GoodsReceiptNotes.DTOs;
using Marketplacesellerportal.GoodsReceiptNotes.Interfaces;
using Marketplacesellerportal.Models;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using static System.Net.Mime.MediaTypeNames;

namespace Marketplacesellerportal.GoodsReceiptNotes.Services
{
    public class GoodsReceiptNotesService : IGoodsReceiptNoteService
    {
        private readonly IGoodsReceiptNoteRepository _repository;

        public GoodsReceiptNotesService(
            IGoodsReceiptNoteRepository repository)
        {
            _repository = repository;
        }

        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptNote>>
            GetAllAsync()
        {
            return await _repository
                .GetAllAsync();
        }


        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<GoodsReceiptNote?>
            GetByIdAsync(
                int goodsReceiptNoteId)
        {
            return await _repository
                .GetByIdAsync(
                    goodsReceiptNoteId);
        }


        // =========================================================
        // GET BY PURCHASE ORDER
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptNote>>
            GetByPurchaseOrderIdAsync(
                int purchaseOrderId)
        {
            return await _repository
                .GetByPurchaseOrderIdAsync(
                    purchaseOrderId);
        }


        // =========================================================
        // GET BY PURCHASE ORDER + GRN
        // =========================================================

        public async Task<GoodsReceiptNote?>
            GetByPurchaseOrderAndGRNAsync(
                int purchaseOrderId,
                int goodsReceiptNoteId)
        {
            return await _repository
                .GetByPurchaseOrderAndGRNAsync(
                    purchaseOrderId,
                    goodsReceiptNoteId);
        }


        // =========================================================
        // GET BY SELLER
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptNote>>
            GetBySellerIdAsync(
                int sellerId)
        {
            return await _repository
                .GetBySellerIdAsync(
                    sellerId);
        }


        // =========================================================
        // GET BY CUSTOMER
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptNote>>
            GetByCustomerIdAsync(
                int customerId)
        {
            return await _repository
                .GetByCustomerIdAsync(
                    customerId);
        }


        // =========================================================
        // GET BY SUPPLIER
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptNote>>
            GetBySupplierIdAsync(
                int supplierId)
        {
            return await _repository
                .GetBySupplierIdAsync(
                    supplierId);
        }


        // =========================================================
        // GET BY SELLER + CUSTOMER
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptNote>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId)
        {
            return await _repository
                .GetBySellerCustomerAsync(
                    sellerId,
                    customerId);
        }


        // =========================================================
        // GET BY STATUS
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptNote>>
            GetByStatusAsync(
                string status)
        {
            return await _repository
                .GetByStatusAsync(
                    status);
        }


        // =========================================================
        // SEARCH
        //
        // Example:
        // /api/goods-receipt-notes?search=GRN-998
        // /api/goods-receipt-notes?status=inspected
        // /api/goods-receipt-notes?search=GRN-998&status=inspected
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptNote>>
            SearchAsync(
                string? search,
                string? status)
        {
            return await _repository
                .SearchAsync(
                    search,
                    status);
        }


        // =========================================================
        // STATISTICS
        //
        // /api/goods-receipt-notes/stats
        // =========================================================

        public async Task<GoodsReceiptNoteStatistics>
            GetStatisticsAsync()
        {
            return await _repository
                .GetStatisticsAsync();
        }


        // =========================================================
        // PAGINATION
        //
        // /api/goods-receipt-notes?page=1&limit=15
        // =========================================================

        public async Task<(
            IEnumerable<GoodsReceiptNote> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit)
        {
            // Prevent invalid page numbers
            if (page < 1)
            {
                page = 1;
            }

            // Default page size
            if (limit < 1)
            {
                limit = 15;
            }

            // Prevent very large requests
            if (limit > 100)
            {
                limit = 100;
            }

            return await _repository
                .GetPagedAsync(
                    page,
                    limit);
        }


        // =========================================================
        // SORTING
        //
        // Examples:
        //
        // /api/goods-receipt-notes?sort=id_asc
        // /api/goods-receipt-notes?sort=id_desc
        // /api/goods-receipt-notes?sort=date_asc
        // /api/goods-receipt-notes?sort=date_desc
        // /api/goods-receipt-notes?sort=amount_asc
        // /api/goods-receipt-notes?sort=amount_desc
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptNote>>
            GetSortedAsync(
                string? sort)
        {
            return await _repository
                .GetSortedAsync(
                    sort);
        }


        // =========================================================
        // CREATE
        // =========================================================

        public async Task<GoodsReceiptNote>
            CreateAsync(
                GoodsReceiptNote goodsReceiptNote)
        {
            goodsReceiptNote.CreatedDate =
                DateTime.Now;

            // Set receipt date automatically
            // when it is not supplied.
            if (!goodsReceiptNote.ReceiptDate.HasValue)
            {
                goodsReceiptNote.ReceiptDate =
                    DateTime.Now;
            }

            // Set default status.
            if (string.IsNullOrWhiteSpace(
                goodsReceiptNote.Status))
            {
                goodsReceiptNote.Status =
                    "pending";
            }

            await _repository
                .AddAsync(
                    goodsReceiptNote);

            await _repository
                .SaveChangesAsync();

            return goodsReceiptNote;
        }


        // =========================================================
        // UPDATE
        // =========================================================

        public async Task<bool>
            UpdateAsync(
                int goodsReceiptNoteId,
                GoodsReceiptNote goodsReceiptNote)
        {
            var existing =
                await _repository
                    .GetByIdAsync(
                        goodsReceiptNoteId);

            if (existing == null)
            {
                return false;
            }

            // -----------------------------------------------------
            // Basic fields
            // -----------------------------------------------------

            existing.PurchaseOrderId =
                goodsReceiptNote.PurchaseOrderId;

            existing.GRNNumber =
                goodsReceiptNote.GRNNumber;

            existing.Status =
                goodsReceiptNote.Status;

            existing.Remarks =
                goodsReceiptNote.Remarks;

            existing.ReceiptDate =
                goodsReceiptNote.ReceiptDate;


            // -----------------------------------------------------
            // Seller / Customer / Supplier
            // -----------------------------------------------------

            existing.SellerId =
                goodsReceiptNote.SellerId;

            existing.CustomerId =
                goodsReceiptNote.CustomerId;

            existing.SupplierId =
                goodsReceiptNote.SupplierId;


            // -----------------------------------------------------
            // Quantity fields
            // -----------------------------------------------------

            existing.TotalQuantity =
                goodsReceiptNote.TotalQuantity;

            existing.ReceivedQuantity =
                goodsReceiptNote.ReceivedQuantity;

            existing.RejectedQuantity =
                goodsReceiptNote.RejectedQuantity;


            // -----------------------------------------------------
            // Amount
            // -----------------------------------------------------

            existing.TotalAmount =
                goodsReceiptNote.TotalAmount;


            // -----------------------------------------------------
            // Updated date
            // -----------------------------------------------------

            existing.UpdatedDate =
                DateTime.Now;


            await _repository
                .UpdateAsync(
                    existing);

            await _repository
                .SaveChangesAsync();

            return true;
        }


        // =========================================================
        // DELETE
        // =========================================================

        public async Task<bool>
            DeleteAsync(
                int goodsReceiptNoteId)
        {
            var existing =
                await _repository
                    .GetByIdAsync(
                        goodsReceiptNoteId);

            if (existing == null)
            {
                return false;
            }

            await _repository
                .DeleteAsync(
                    goodsReceiptNoteId);

            await _repository
                .SaveChangesAsync();

            return true;
        }
    }
}

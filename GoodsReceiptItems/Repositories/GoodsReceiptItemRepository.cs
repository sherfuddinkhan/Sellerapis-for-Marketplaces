using Marketplacesellerportal.Models; // if your DbContext is in Models folder
using Marketplacesellerportal.Database;
using Marketplacesellerportal.GoodsReceiptItems.DTOs;
using Marketplacesellerportal.GoodsReceiptItems.Interfaces;
using Marketplacesellerportal.Models;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.GoodsReceiptItems.Repositories
{
    public class GoodsReceiptItemsRepository : IGoodsReceiptItemRepository
    {
        private readonly ApplicationDbContext _context;

        public GoodsReceiptItemsRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================================================
        // BASIC - GET ALL
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptItem>>
            GetAllAsync()
        {
            return await _context
                .GoodsReceiptItems
                .Include(x => x.GoodsReceiptNote)
                .Include(x => x.Product)
                .OrderByDescending(x => x.GoodsReceiptItemId)
                .ToListAsync();
        }

        // =========================================================
        // BASIC - GET BY ID
        // =========================================================

        public async Task<GoodsReceiptItem?>
            GetByIdAsync(
                int goodsReceiptItemId)
        {
            return await _context
                .GoodsReceiptItems
                .Include(x => x.GoodsReceiptNote)
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x =>
                    x.GoodsReceiptItemId ==
                    goodsReceiptItemId);
        }

        // =========================================================
        // GOODS RECEIPT NOTE
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptItem>>
            GetByGoodsReceiptNoteIdAsync(
                int goodsReceiptNoteId)
        {
            return await _context
                .GoodsReceiptItems
                .Where(x =>
                    x.GoodsReceiptNoteId ==
                    goodsReceiptNoteId)
                .OrderBy(x => x.LineNumber)
                .ToListAsync();
        }

        public async Task<GoodsReceiptItem?>
            GetByGoodsReceiptNoteAndItemAsync(
                int goodsReceiptNoteId,
                int goodsReceiptItemId)
        {
            return await _context
                .GoodsReceiptItems
                .FirstOrDefaultAsync(x =>
                    x.GoodsReceiptNoteId ==
                    goodsReceiptNoteId &&
                    x.GoodsReceiptItemId ==
                    goodsReceiptItemId);
        }

        // =========================================================
        // PRODUCT
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptItem>>
            GetByProductIdAsync(
                int productId)
        {
            return await _context
                .GoodsReceiptItems
                .Where(x =>
                    x.ProductId ==
                    productId)
                .ToListAsync();
        }

        // =========================================================
        // SELLER
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptItem>>
            GetBySellerIdAsync(
                int sellerId)
        {
            return await _context
                .GoodsReceiptItems
                .Where(x =>
                    x.SellerId ==
                    sellerId)
                .ToListAsync();
        }

        // =========================================================
        // CUSTOMER
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptItem>>
            GetByCustomerIdAsync(
                int customerId)
        {
            return await _context
                .GoodsReceiptItems
                .Where(x =>
                    x.CustomerId ==
                    customerId)
                .ToListAsync();
        }

        // =========================================================
        // SELLER + CUSTOMER
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptItem>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId)
        {
            return await _context
                .GoodsReceiptItems
                .Where(x =>
                    x.SellerId ==
                    sellerId &&
                    x.CustomerId ==
                    customerId)
                .ToListAsync();
        }

        // =========================================================
        // SEARCH - NOW INCLUDES SKU CODE
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptItem>>
            SearchAsync(
                string? search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return await GetAllAsync();
            }

            search = search.ToLower();

            return await _context
                .GoodsReceiptItems
                .Where(x =>
                    x.SkuCode!.ToLower().Contains(search) ||
                    x.ItemCode!.ToLower().Contains(search) ||
                    x.BatchCode!.ToLower().Contains(search) ||
                    x.VendorCode!.ToLower().Contains(search) ||
                    x.ItemDetailCode!.ToLower().Contains(search) ||
                    x.GoodsReceiptItemId.ToString().Contains(search))
                .ToListAsync();
        }

        // =========================================================
        // STATISTICS
        // =========================================================

        public async Task<GoodsReceiptNoteItemStatistics>
            GetStatisticsAsync()
        {
            var totalItems =
                await _context
                    .GoodsReceiptItems
                    .CountAsync();

            var totalReceived =
                await _context
                    .GoodsReceiptItems
                    .SumAsync(x => x.ReceivedQuantity);

            var totalAccepted =
                await _context
                    .GoodsReceiptItems
                    .SumAsync(x => x.AcceptedQuantity);

            var totalRejected =
                await _context
                    .GoodsReceiptItems
                    .SumAsync(x => x.RejectedQuantity);

            return new GoodsReceiptNoteItemStatistics
            {
                TotalItems = totalItems,
                TotalReceivedQuantity = totalReceived,
                TotalAcceptedQuantity = totalAccepted,
                TotalRejectedQuantity = totalRejected
            };
        }

        // =========================================================
        // PAGINATION
        // =========================================================

        public async Task<(
            IEnumerable<GoodsReceiptItem> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit)
        {
            var totalCount =
                await _context
                    .GoodsReceiptItems
                    .CountAsync();

            var items =
                await _context
                    .GoodsReceiptItems
                    .OrderByDescending(x =>
                        x.GoodsReceiptItemId)
                    .Skip((page - 1) * limit)
                    .Take(limit)
                    .ToListAsync();

            return (items, totalCount);
        }

        // =========================================================
        // SORTING
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptItem>>
            GetSortedAsync(
                string? sort)
        {
            var query =
                _context.GoodsReceiptItems.AsQueryable();

            switch (sort?.ToLower())
            {
                case "line_number":
                case "line_number_asc":
                    query = query.OrderBy(x => x.LineNumber);
                    break;

                case "line_number_desc":
                    query = query.OrderByDescending(x => x.LineNumber);
                    break;

                case "quantity_asc":
                    query = query.OrderBy(x => x.AcceptedQuantity);
                    break;

                case "quantity_desc":
                    query = query.OrderByDescending(x => x.AcceptedQuantity);
                    break;

                case "sku_asc":
                    query = query.OrderBy(x => x.SkuCode);
                    break;

                case "sku_desc":
                    query = query.OrderByDescending(x => x.SkuCode);
                    break;

                case "id_asc":
                    query = query.OrderBy(x => x.GoodsReceiptItemId);
                    break;

                default:
                    query = query.OrderByDescending(x => x.GoodsReceiptItemId);
                    break;
            }

            return await query.ToListAsync();
        }

        // =========================================================
        // CRUD - ADD
        // =========================================================

        public async Task AddAsync(
            GoodsReceiptItem goodsReceiptItem)
        {
            await _context
                .GoodsReceiptItems
                .AddAsync(goodsReceiptItem);
        }

        // =========================================================
        // CRUD - UPDATE
        // =========================================================

        public Task UpdateAsync(
            GoodsReceiptItem goodsReceiptItem)
        {
            _context
                .GoodsReceiptItems
                .Update(goodsReceiptItem);

            return Task.CompletedTask;
        }

        // =========================================================
        // CRUD - DELETE
        // =========================================================

        public async Task DeleteAsync(
            int goodsReceiptItemId)
        {
            var entity =
                await _context
                    .GoodsReceiptItems
                    .FindAsync(goodsReceiptItemId);

            if (entity != null)
            {
                _context
                    .GoodsReceiptItems
                    .Remove(entity);
            }
        }

        // =========================================================
        // SAVE
        // =========================================================

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
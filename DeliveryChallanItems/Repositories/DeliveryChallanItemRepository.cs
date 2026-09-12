
using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.DeliveryChallanItems.Interfaces;

namespace Marketplacesellerportal.DeliveryChallanItems.Repositories
{
    public class DeliveryChallanItemRepository
        : IDeliveryChallanItemRepository
    {
        private readonly ApplicationDbContext _context;

        public DeliveryChallanItemRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        // =====================================================
        // GET ALL
        // =====================================================

        public async Task<List<DeliveryChallanItem>>
            GetAllAsync()
        {
            return await _context.DeliveryChallanItems
                .AsNoTracking()
                .OrderByDescending(x =>
                    x.DeliveryChallanItemId)
                .ToListAsync();
        }

        // =====================================================
        // GET BY ID
        // =====================================================

        public async Task<DeliveryChallanItem?>
            GetByIdAsync(
                int deliveryChallanItemId)
        {
            return await _context.DeliveryChallanItems
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.DeliveryChallanItemId ==
                    deliveryChallanItemId);
        }

        // =====================================================
        // GET BY DELIVERY CHALLAN
        // =====================================================

        public async Task<List<DeliveryChallanItem>>
            GetByDeliveryChallanAsync(
                int deliveryChallanId)
        {
            return await _context.DeliveryChallanItems
                .AsNoTracking()
                .Where(x =>
                    x.DeliveryChallanId ==
                    deliveryChallanId)
                .OrderBy(x =>
                    x.DeliveryChallanItemId)
                .ToListAsync();
        }

        // =====================================================
        // GET BY PRODUCT
        // =====================================================

        public async Task<List<DeliveryChallanItem>>
            GetByProductAsync(
                int productId)
        {
            return await _context.DeliveryChallanItems
                .AsNoTracking()
                .Where(x =>
                    x.ProductId ==
                    productId)
                .OrderByDescending(x =>
                    x.DeliveryChallanItemId)
                .ToListAsync();
        }

        // =====================================================
        // SEARCH
        // =====================================================

        public async Task<List<DeliveryChallanItem>>
            SearchAsync(
                string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return await GetAllAsync();
            }

            search = search.Trim();

            return await _context.DeliveryChallanItems
                .AsNoTracking()
                .Where(x =>
                    x.DeliveryChallanItemId.ToString()
                        .Contains(search)

                    || x.DeliveryChallanId.ToString()
                        .Contains(search)

                    || x.ProductId.ToString()
                        .Contains(search)

                    || x.Quantity.ToString()
                        .Contains(search)

                    || x.UnitPrice.ToString()
                        .Contains(search)

                    || (x.Remarks != null &&
                        x.Remarks.Contains(search))
                )
                .OrderByDescending(x =>
                    x.DeliveryChallanItemId)
                .ToListAsync();
        }

        // =====================================================
        // CREATE
        // =====================================================

        public async Task<DeliveryChallanItem>
            CreateAsync(
                DeliveryChallanItem deliveryChallanItem)
        {
            _context.DeliveryChallanItems.Add(
                deliveryChallanItem
            );

            await _context.SaveChangesAsync();

            return deliveryChallanItem;
        }

        // =====================================================
        // UPDATE
        // =====================================================

        public async Task<bool>
            UpdateAsync(
                int deliveryChallanItemId,
                DeliveryChallanItem deliveryChallanItem)
        {
            var existing =
                await _context.DeliveryChallanItems
                    .FirstOrDefaultAsync(x =>
                        x.DeliveryChallanItemId ==
                        deliveryChallanItemId);

            if (existing == null)
            {
                return false;
            }

            // ================================================
            // UPDATE FIELDS
            // ================================================

            existing.DeliveryChallanId =
                deliveryChallanItem.DeliveryChallanId;

            existing.ProductId =
                deliveryChallanItem.ProductId;

            existing.Quantity =
                deliveryChallanItem.Quantity;

            existing.UnitPrice =
                deliveryChallanItem.UnitPrice;

            existing.Discount =
                deliveryChallanItem.Discount;

            existing.TaxAmount =
                deliveryChallanItem.TaxAmount;

            existing.TotalAmount =
                deliveryChallanItem.TotalAmount;

            existing.Remarks =
                deliveryChallanItem.Remarks;

            await _context.SaveChangesAsync();

            return true;
        }

        // =====================================================
        // DELETE
        // =====================================================

        public async Task<bool>
            DeleteAsync(
                int deliveryChallanItemId)
        {
            var existing =
                await _context.DeliveryChallanItems
                    .FirstOrDefaultAsync(x =>
                        x.DeliveryChallanItemId ==
                        deliveryChallanItemId);

            if (existing == null)
            {
                return false;
            }

            _context.DeliveryChallanItems.Remove(
                existing
            );

            await _context.SaveChangesAsync();

            return true;
        }
    }
}



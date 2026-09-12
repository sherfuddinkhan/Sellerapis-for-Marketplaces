using Marketplacesellerportal.Database;
using Marketplacesellerportal.DeliveryChallanItems.Interfaces;
using Marketplacesellerportal.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Marketplacesellerportal.DeliveryChallanItems.Services
{
    public class DeliveryChallanItemService
        : IDeliveryChallanItemService
    {
        private readonly IDeliveryChallanItemRepository _repository;
        private readonly ApplicationDbContext _context;

        public DeliveryChallanItemService(
            IDeliveryChallanItemRepository repository,
            ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<List<DeliveryChallanItem>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<DeliveryChallanItem?> GetByIdAsync(
            int deliveryChallanItemId)
        {
            if (deliveryChallanItemId <= 0)
                return null;

            return await _repository.GetByIdAsync(
                deliveryChallanItemId);
        }

        // =========================================================
        // GET BY DELIVERY CHALLAN
        // =========================================================

        public async Task<List<DeliveryChallanItem>>
            GetByDeliveryChallanAsync(
                int deliveryChallanId)
        {
            if (deliveryChallanId <= 0)
                return new List<DeliveryChallanItem>();

            return await _repository.GetByDeliveryChallanAsync(
                deliveryChallanId);
        }

        // =========================================================
        // GET BY PRODUCT
        // =========================================================

        public async Task<List<DeliveryChallanItem>>
            GetByProductAsync(
                int productId)
        {
            if (productId <= 0)
                return new List<DeliveryChallanItem>();

            return await _repository.GetByProductAsync(
                productId);
        }

        // =========================================================
        // SEARCH
        // =========================================================

        public async Task<List<DeliveryChallanItem>>
            SearchAsync(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return await _repository.GetAllAsync();

            return await _repository.SearchAsync(
                search.Trim());
        }

        // =========================================================
        // STATISTICS
        // =========================================================

        public async Task<object> GetStatisticsAsync()
        {
            var totalItems = await _context.DeliveryChallanItems
                .AsNoTracking()
                .CountAsync();

            var totalQuantity = await _context.DeliveryChallanItems
                .AsNoTracking()
                .SumAsync(x => x.Quantity);

            var totalDiscount = await _context.DeliveryChallanItems
                .AsNoTracking()
                .SumAsync(x => x.Discount ?? 0m);

            var totalTaxAmount = await _context.DeliveryChallanItems
                .AsNoTracking()
                .SumAsync(x => x.TaxAmount ?? 0m);

            var totalAmount = await _context.DeliveryChallanItems
                .AsNoTracking()
                .SumAsync(x => x.TotalAmount);

            return new
            {
                TotalItems = totalItems,
                TotalQuantity = totalQuantity,
                TotalDiscount = totalDiscount,
                TotalTaxAmount = totalTaxAmount,
                TotalAmount = totalAmount
            };
        }

        // =========================================================
        // CREATE
        // =========================================================

        public async Task<DeliveryChallanItem> CreateAsync(
            DeliveryChallanItem deliveryChallanItem)
        {
            if (deliveryChallanItem == null)
                throw new ArgumentNullException(
                    nameof(deliveryChallanItem));

            // -----------------------------------------------------
            // Validate Delivery Challan
            // -----------------------------------------------------

            if (deliveryChallanItem.DeliveryChallanId <= 0)
            {
                throw new ArgumentException(
                    "DeliveryChallanId is required.");
            }

            var deliveryChallanExists =
                await _context.DeliveryChallans
                    .AsNoTracking()
                    .AnyAsync(x =>
                        x.DeliveryChallanId ==
                        deliveryChallanItem.DeliveryChallanId);

            if (!deliveryChallanExists)
            {
                throw new ArgumentException(
                    $"Delivery Challan with ID " +
                    $"{deliveryChallanItem.DeliveryChallanId} " +
                    $"does not exist.");
            }

            // -----------------------------------------------------
            // Validate Product
            // -----------------------------------------------------

            if (deliveryChallanItem.ProductId <= 0)
            {
                throw new ArgumentException(
                    "ProductId is required.");
            }

            var productExists =
                await _context.Products
                    .AsNoTracking()
                    .AnyAsync(x =>
                        x.ProductId ==
                        deliveryChallanItem.ProductId);

            if (!productExists)
            {
                throw new ArgumentException(
                    $"Product with ID " +
                    $"{deliveryChallanItem.ProductId} " +
                    $"does not exist.");
            }

            // -----------------------------------------------------
            // Validate Quantity
            // -----------------------------------------------------

            if (deliveryChallanItem.Quantity <= 0)
            {
                throw new ArgumentException(
                    "Quantity must be greater than zero.");
            }

            // -----------------------------------------------------
            // Validate Unit Price
            // -----------------------------------------------------

            if (deliveryChallanItem.UnitPrice < 0)
            {
                throw new ArgumentException(
                    "UnitPrice cannot be negative.");
            }

            // -----------------------------------------------------
            // Normalize Discount
            // -----------------------------------------------------

            var discount =
                deliveryChallanItem.Discount ?? 0m;

            if (discount < 0)
            {
                throw new ArgumentException(
                    "Discount cannot be negative.");
            }

            // -----------------------------------------------------
            // Normalize Tax
            // -----------------------------------------------------

            var taxAmount =
                deliveryChallanItem.TaxAmount ?? 0m;

            if (taxAmount < 0)
            {
                throw new ArgumentException(
                    "TaxAmount cannot be negative.");
            }

            // -----------------------------------------------------
            // Calculate Total Amount
            // -----------------------------------------------------

            var calculatedTotal =
                (deliveryChallanItem.Quantity *
                 deliveryChallanItem.UnitPrice)
                - discount
                + taxAmount;

            if (calculatedTotal < 0)
            {
                throw new ArgumentException(
                    "Calculated TotalAmount cannot be negative.");
            }

            deliveryChallanItem.Discount = discount;
            deliveryChallanItem.TaxAmount = taxAmount;
            deliveryChallanItem.TotalAmount = calculatedTotal;

            // -----------------------------------------------------
            // Created Date
            // -----------------------------------------------------

            if (!deliveryChallanItem.CreatedDate.HasValue)
            {
                deliveryChallanItem.CreatedDate =
                    DateTime.Now;
            }

            // -----------------------------------------------------
            // Save
            // -----------------------------------------------------

            return await _repository.CreateAsync(
                deliveryChallanItem);
        }

        // =========================================================
        // UPDATE
        // =========================================================

        public async Task<bool> UpdateAsync(
            int deliveryChallanItemId,
            DeliveryChallanItem deliveryChallanItem)
        {
            if (deliveryChallanItemId <= 0)
                return false;

            if (deliveryChallanItem == null)
                throw new ArgumentNullException(
                    nameof(deliveryChallanItem));

            // -----------------------------------------------------
            // Validate Delivery Challan
            // -----------------------------------------------------

            if (deliveryChallanItem.DeliveryChallanId <= 0)
            {
                throw new ArgumentException(
                    "DeliveryChallanId is required.");
            }

            var deliveryChallanExists =
                await _context.DeliveryChallans
                    .AsNoTracking()
                    .AnyAsync(x =>
                        x.DeliveryChallanId ==
                        deliveryChallanItem.DeliveryChallanId);

            if (!deliveryChallanExists)
            {
                throw new ArgumentException(
                    $"Delivery Challan with ID " +
                    $"{deliveryChallanItem.DeliveryChallanId} " +
                    $"does not exist.");
            }

            // -----------------------------------------------------
            // Validate Product
            // -----------------------------------------------------

            if (deliveryChallanItem.ProductId <= 0)
            {
                throw new ArgumentException(
                    "ProductId is required.");
            }

            var productExists =
                await _context.Products
                    .AsNoTracking()
                    .AnyAsync(x =>
                        x.ProductId ==
                        deliveryChallanItem.ProductId);

            if (!productExists)
            {
                throw new ArgumentException(
                    $"Product with ID " +
                    $"{deliveryChallanItem.ProductId} " +
                    $"does not exist.");
            }

            // -----------------------------------------------------
            // Validate Quantity
            // -----------------------------------------------------

            if (deliveryChallanItem.Quantity <= 0)
            {
                throw new ArgumentException(
                    "Quantity must be greater than zero.");
            }

            // -----------------------------------------------------
            // Validate Unit Price
            // -----------------------------------------------------

            if (deliveryChallanItem.UnitPrice < 0)
            {
                throw new ArgumentException(
                    "UnitPrice cannot be negative.");
            }

            // -----------------------------------------------------
            // Validate Discount
            // -----------------------------------------------------

            var discount =
                deliveryChallanItem.Discount ?? 0m;

            if (discount < 0)
            {
                throw new ArgumentException(
                    "Discount cannot be negative.");
            }

            // -----------------------------------------------------
            // Validate Tax
            // -----------------------------------------------------

            var taxAmount =
                deliveryChallanItem.TaxAmount ?? 0m;

            if (taxAmount < 0)
            {
                throw new ArgumentException(
                    "TaxAmount cannot be negative.");
            }

            // -----------------------------------------------------
            // Calculate Total Amount
            // -----------------------------------------------------

            var calculatedTotal =
                (deliveryChallanItem.Quantity *
                 deliveryChallanItem.UnitPrice)
                - discount
                + taxAmount;

            if (calculatedTotal < 0)
            {
                throw new ArgumentException(
                    "Calculated TotalAmount cannot be negative.");
            }

            deliveryChallanItem.Discount = discount;
            deliveryChallanItem.TaxAmount = taxAmount;
            deliveryChallanItem.TotalAmount = calculatedTotal;

            // -----------------------------------------------------
            // Preserve CreatedDate
            // -----------------------------------------------------

            var existing =
                await _repository.GetByIdAsync(
                    deliveryChallanItemId);

            if (existing == null)
                return false;

            deliveryChallanItem.CreatedDate =
                existing.CreatedDate;

            // -----------------------------------------------------
            // Save
            // -----------------------------------------------------

            return await _repository.UpdateAsync(
                deliveryChallanItemId,
                deliveryChallanItem);
        }

        // =========================================================
        // DELETE
        // =========================================================

        public async Task<bool> DeleteAsync(
            int deliveryChallanItemId)
        {
            if (deliveryChallanItemId <= 0)
                return false;

            var existing =
                await _repository.GetByIdAsync(
                    deliveryChallanItemId);

            if (existing == null)
                return false;

            return await _repository.DeleteAsync(
                deliveryChallanItemId);
        }
    }
}

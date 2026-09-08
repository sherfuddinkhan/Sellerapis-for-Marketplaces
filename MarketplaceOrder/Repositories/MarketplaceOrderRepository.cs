using Microsoft.EntityFrameworkCore;

using Marketplacesellerportal.Database;
using Marketplacesellerportal.Interface;

using MarketplaceOrderEntity =
    MarketplaceSellerPortal.Models.MarketplaceOrder;

namespace Marketplacesellerportal.Repositories
{
    public class MarketplaceOrderRepository
        : IMarketplaceOrderRepository
    {
        private readonly ApplicationDbContext _context;


        // =========================================================
        // CONSTRUCTOR
        // =========================================================

        public MarketplaceOrderRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }


        // =========================================================
        // GET ALL ORDERS
        // =========================================================

        public async Task<List<MarketplaceOrderEntity>> GetAllAsync()
        {
            return await _context.MarketplaceOrders
                .AsNoTracking()
                .OrderByDescending(
                    o => o.MarketplaceOrderId)
                .ToListAsync();
        }


        // =========================================================
        // GET ORDER BY ID
        // =========================================================

        public async Task<MarketplaceOrderEntity?> GetByIdAsync(
            int marketplaceOrderId)
        {
            return await _context.MarketplaceOrders
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    o => o.MarketplaceOrderId
                        == marketplaceOrderId);
        }


        // =========================================================
        // GET ORDERS BY SELLER ID
        // =========================================================

        public async Task<List<MarketplaceOrderEntity>> GetBySellerIdAsync(
            int sellerId)
        {
            return await _context.MarketplaceOrders
                .Where(o => o.SellerId == sellerId)
                .AsNoTracking()
                .OrderByDescending(
                    o => o.MarketplaceOrderId)
                .ToListAsync();
        }


        // =========================================================
        // GET ORDERS BY CUSTOMER ID
        // =========================================================

        public async Task<List<MarketplaceOrderEntity>> GetByCustomerIdAsync(
            int customerId)
        {
            return await _context.MarketplaceOrders
                .Where(o => o.CustomerId == customerId)
                .AsNoTracking()
                .OrderByDescending(
                    o => o.MarketplaceOrderId)
                .ToListAsync();
        }
        // =========================================================
        // GET ORDERS BY SELLER AND CUSTOMER
        // =========================================================

        public async Task<List<MarketplaceOrderEntity>> GetBySellerCustomerAsync(
            int sellerId,
            int customerId)
        {
            return await _context.MarketplaceOrders
                .Where(o =>
                    o.SellerId == sellerId &&
                    o.CustomerId == customerId)
                .AsNoTracking()
                .OrderByDescending(
                    o => o.MarketplaceOrderId)
                .ToListAsync();
        }

        // =========================================================
        // GET ORDER BY MARKETPLACE ORDER NUMBER
        // =========================================================

        public async Task<MarketplaceOrderEntity?> GetByOrderNumberAsync(
            string marketplaceOrderNumber)
        {
            return await _context.MarketplaceOrders
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    o => o.MarketplaceOrderNumber
                        == marketplaceOrderNumber);
        }


        // =========================================================
        // CREATE ORDER
        // =========================================================

        public async Task<MarketplaceOrderEntity> CreateAsync(
            MarketplaceOrderEntity order)
        {
            _context.MarketplaceOrders.Add(order);

            await _context.SaveChangesAsync();

            return order;
        }


        // =========================================================
        // UPDATE ORDER
        // =========================================================

        public async Task<MarketplaceOrderEntity?> UpdateAsync(
            MarketplaceOrderEntity order)
        {
            var existingOrder =
                await _context.MarketplaceOrders
                    .FirstOrDefaultAsync(
                        o => o.MarketplaceOrderId
                            == order.MarketplaceOrderId);

            if (existingOrder == null)
            {
                return null;
            }

            _context.Entry(existingOrder)
                .CurrentValues
                .SetValues(order);

            await _context.SaveChangesAsync();

            return existingOrder;
        }


        // =========================================================
        // DELETE ORDER
        // =========================================================

        public async Task<bool> DeleteAsync(
            int marketplaceOrderId)
        {
            var order =
                await _context.MarketplaceOrders
                    .FirstOrDefaultAsync(
                        o => o.MarketplaceOrderId
                            == marketplaceOrderId);

            if (order == null)
            {
                return false;
            }

            _context.MarketplaceOrders.Remove(order);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
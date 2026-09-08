using Marketplacesellerportal.Interface;

using MarketplaceOrderEntity =
    MarketplaceSellerPortal.Models.MarketplaceOrder;

namespace Marketplacesellerportal.Services
{
    public class MarketplaceOrderService : IMarketplaceOrderService
    {
        private readonly IMarketplaceOrderRepository _repository;


        // =========================================================
        // CONSTRUCTOR
        // =========================================================

        public MarketplaceOrderService(
            IMarketplaceOrderRepository repository)
        {
            _repository = repository;
        }


        // =========================================================
        // GET ALL ORDERS
        // =========================================================

        public async Task<List<MarketplaceOrderEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }


        // =========================================================
        // GET ORDER BY ID
        // =========================================================

        public async Task<MarketplaceOrderEntity?> GetByIdAsync(
            int marketplaceOrderId)
        {
            return await _repository.GetByIdAsync(
                marketplaceOrderId);
        }


        // =========================================================
        // GET ORDERS BY SELLER
        // =========================================================

        public async Task<List<MarketplaceOrderEntity>> GetBySellerIdAsync(
            int sellerId)
        {
            return await _repository.GetBySellerIdAsync(
                sellerId);
        }


        // =========================================================
        // GET ORDERS BY CUSTOMER
        // =========================================================

        public async Task<List<MarketplaceOrderEntity>> GetByCustomerIdAsync(
            int customerId)
        {
            return await _repository.GetByCustomerIdAsync(
                customerId);
        }


        // =========================================================
        // GET ORDER BY MARKETPLACE ORDER NUMBER
        // =========================================================

        public async Task<MarketplaceOrderEntity?> GetByOrderNumberAsync(
            string marketplaceOrderNumber)
        {
            return await _repository.GetByOrderNumberAsync(
                marketplaceOrderNumber);
        }


        // =========================================================
        // CREATE ORDER
        // =========================================================

        public async Task<MarketplaceOrderEntity> CreateAsync(
            MarketplaceOrderEntity order)
        {
            return await _repository.CreateAsync(order);
        }


        // =========================================================
        // UPDATE ORDER
        // =========================================================

        public async Task<MarketplaceOrderEntity?> UpdateAsync(
            MarketplaceOrderEntity order)
        {
            return await _repository.UpdateAsync(order);
        }


        // =========================================================
        // DELETE ORDER
        // =========================================================

        public async Task<bool> DeleteAsync(
            int marketplaceOrderId)
        {
            return await _repository.DeleteAsync(
                marketplaceOrderId);
        }
    }
}
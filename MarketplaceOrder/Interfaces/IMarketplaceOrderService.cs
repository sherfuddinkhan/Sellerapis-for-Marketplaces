using MarketplaceOrderEntity =
    MarketplaceSellerPortal.Models.MarketplaceOrder;

namespace Marketplacesellerportal.Interface
{
    public interface IMarketplaceOrderService
    {
        // =========================================================
        // GET ALL ORDERS
        // =========================================================

        Task<List<MarketplaceOrderEntity>> GetAllAsync();


        // =========================================================
        // GET ORDER BY ID
        // =========================================================

        Task<MarketplaceOrderEntity?> GetByIdAsync(
            int marketplaceOrderId);


        // =========================================================
        // GET ORDERS BY SELLER
        // =========================================================

        Task<List<MarketplaceOrderEntity>> GetBySellerIdAsync(
            int sellerId);


        // =========================================================
        // GET ORDERS BY CUSTOMER
        // =========================================================

        Task<List<MarketplaceOrderEntity>> GetByCustomerIdAsync(
            int customerId);


        // =========================================================
        // GET ORDER BY MARKETPLACE ORDER NUMBER
        // =========================================================

        Task<MarketplaceOrderEntity?> GetByOrderNumberAsync(
            string marketplaceOrderNumber);


        // =========================================================
        // CREATE ORDER
        // =========================================================

        Task<MarketplaceOrderEntity> CreateAsync(
            MarketplaceOrderEntity order);


        // =========================================================
        // UPDATE ORDER
        // =========================================================

        Task<MarketplaceOrderEntity?> UpdateAsync(
            MarketplaceOrderEntity order);


        // =========================================================
        // DELETE ORDER
        // =========================================================

        Task<bool> DeleteAsync(
            int marketplaceOrderId);
    }
}
using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.DeliveryChallanItems.Interfaces
{
    public interface IDeliveryChallanItemRepository
    {
        // =====================================================
        // GET ALL
        // =====================================================

        Task<List<DeliveryChallanItem>> GetAllAsync();

        // =====================================================
        // GET BY ID
        // =====================================================

        Task<DeliveryChallanItem?> GetByIdAsync(
            int deliveryChallanItemId
        );

        // =====================================================
        // GET BY DELIVERY CHALLAN
        // =====================================================

        Task<List<DeliveryChallanItem>> GetByDeliveryChallanAsync(
            int deliveryChallanId
        );

        // =====================================================
        // GET BY PRODUCT
        // =====================================================

        Task<List<DeliveryChallanItem>> GetByProductAsync(
            int productId
        );

        // =====================================================
        // SEARCH
        // =====================================================

        Task<List<DeliveryChallanItem>> SearchAsync(
            string search
        );

        // =====================================================
        // CREATE
        // =====================================================

        Task<DeliveryChallanItem> CreateAsync(
            DeliveryChallanItem deliveryChallanItem
        );

        // =====================================================
        // UPDATE
        // =====================================================

        Task<bool> UpdateAsync(
            int deliveryChallanItemId,
            DeliveryChallanItem deliveryChallanItem
        );

        // =====================================================
        // DELETE
        // =====================================================

        Task<bool> DeleteAsync(
            int deliveryChallanItemId
        );
    }
}



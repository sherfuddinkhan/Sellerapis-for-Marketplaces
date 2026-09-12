using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.DeliveryChallanItems.Interfaces
{
    public interface IDeliveryChallanItemService
    {
        // =====================================================
        // GET ALL DELIVERY CHALLAN ITEMS
        // =====================================================

        Task<List<DeliveryChallanItem>> GetAllAsync();

        // =====================================================
        // GET DELIVERY CHALLAN ITEM BY ID
        // =====================================================

        Task<DeliveryChallanItem?> GetByIdAsync(
            int deliveryChallanItemId
        );

        // =====================================================
        // GET ITEMS BY DELIVERY CHALLAN
        // =====================================================

        Task<List<DeliveryChallanItem>>
            GetByDeliveryChallanAsync(
                int deliveryChallanId
            );

        // =====================================================
        // GET ITEMS BY PRODUCT
        // =====================================================

        Task<List<DeliveryChallanItem>>
            GetByProductAsync(
                int productId
            );

        // =====================================================
        // SEARCH DELIVERY CHALLAN ITEMS
        // =====================================================

        Task<List<DeliveryChallanItem>> SearchAsync(
            string search
        );

        // =====================================================
        // GET STATISTICS
        // =====================================================

        Task<object> GetStatisticsAsync();

        // =====================================================
        // CREATE DELIVERY CHALLAN ITEM
        // =====================================================

        Task<DeliveryChallanItem> CreateAsync(
            DeliveryChallanItem deliveryChallanItem
        );

        // =====================================================
        // UPDATE DELIVERY CHALLAN ITEM
        // =====================================================

        Task<bool> UpdateAsync(
            int deliveryChallanItemId,
            DeliveryChallanItem deliveryChallanItem
        );

        // =====================================================
        // DELETE DELIVERY CHALLAN ITEM
        // =====================================================

        Task<bool> DeleteAsync(
            int deliveryChallanItemId
        );
    }
}



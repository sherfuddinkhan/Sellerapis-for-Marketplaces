using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.DeliveryChallans.Interfaces
{
    public interface IDeliveryChallanRepository
    {
        // =====================================================
        // BASIC
        // =====================================================

        Task<IEnumerable<DeliveryChallan>> GetAllAsync();

        Task<DeliveryChallan?> GetByIdAsync(int id);

        Task<IEnumerable<DeliveryChallan>>
            GetBySalesOrderAsync(int salesOrderId);

        Task<IEnumerable<DeliveryChallan>>
            GetByStatusAsync(string status);

        Task<DeliveryChallan?>
            GetByChallanNumberAsync(string challanNumber);

        // =====================================================
        // SELLER + CUSTOMER
        // =====================================================

        Task<IEnumerable<DeliveryChallan>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId);

        // =====================================================
        // SEARCH / SORT / PAGINATION
        // =====================================================

        Task<IEnumerable<DeliveryChallan>>
            SearchAsync(string search);

        Task<IEnumerable<DeliveryChallan>>
            GetSortedAsync(string? sort);

        Task<PagedResult<DeliveryChallan>>
            GetPagedAsync(int page, int limit);

        // =====================================================
        // STATISTICS
        // =====================================================

        Task<DeliveryChallanStatistics>
            GetStatisticsAsync();

        // =====================================================
        // CRUD
        // =====================================================

        Task AddAsync(
            DeliveryChallan deliveryChallan);

        Task UpdateAsync(
            DeliveryChallan deliveryChallan);

        Task DeleteAsync(int id);

        Task SaveChangesAsync();
    }
}


using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.DeliveryChallans.Interfaces
{
    public interface IDeliveryChallanService
    {
        Task<IEnumerable<DeliveryChallan>> GetAllAsync();

        Task<DeliveryChallan?> GetByIdAsync(int id);

        Task<IEnumerable<DeliveryChallan>>
            GetBySalesOrderAsync(int salesOrderId);

        Task<IEnumerable<DeliveryChallan>>
            GetByStatusAsync(string status);

        Task<DeliveryChallan?>
            GetByChallanNumberAsync(string challanNumber);

        Task<IEnumerable<DeliveryChallan>>
            SearchAsync(string search);

        Task<IEnumerable<DeliveryChallan>>
            GetSortedAsync(string? sort);

        Task<PagedResult<DeliveryChallan>>
            GetPagedAsync(int page, int limit);

        Task<DeliveryChallanStatistics>
            GetStatisticsAsync();

        Task<DeliveryChallan>
            CreateAsync(DeliveryChallan deliveryChallan);

        Task<bool>
            UpdateAsync(
                int id,
                DeliveryChallan deliveryChallan);

        Task<bool>
            DeleteAsync(int id);
    }
}
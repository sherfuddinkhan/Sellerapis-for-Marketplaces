using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.DeliveryChallans.Interfaces
{
    public interface IDeliveryChallanService
    {
        Task<IEnumerable<DeliveryChallan>> GetAllAsync();

        Task<DeliveryChallan?> GetByIdAsync(int deliveryChallanId);

        Task<IEnumerable<DeliveryChallan>> GetBySalesOrderAsync(int salesOrderId);

        Task<IEnumerable<DeliveryChallan>> GetByStatusAsync(string status);

        Task<DeliveryChallan?> GetByChallanNumberAsync(string challanNumber);

        Task<DeliveryChallan> CreateAsync(DeliveryChallan deliveryChallan);

        Task<bool> UpdateAsync(int deliveryChallanId, DeliveryChallan deliveryChallan);

        Task<bool> DeleteAsync(int deliveryChallanId);
    }
}

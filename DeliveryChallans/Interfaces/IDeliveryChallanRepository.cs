using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.DeliveryChallans.Interfaces
{
    public interface IDeliveryChallanRepository
    {
        Task<IEnumerable<DeliveryChallan>> GetAllAsync();

        Task<DeliveryChallan?> GetByIdAsync(int deliveryChallanId);

        Task<IEnumerable<DeliveryChallan>> GetBySalesOrderAsync(int salesOrderId);
        Task<IEnumerable<DeliveryChallan>> GetBySellerCustomerAsync(
    int sellerId,
    int customerId);
        Task<IEnumerable<DeliveryChallan>> GetByStatusAsync(string status);

        Task<DeliveryChallan?> GetByChallanNumberAsync(string challanNumber);

        Task AddAsync(DeliveryChallan deliveryChallan);

        Task UpdateAsync(DeliveryChallan deliveryChallan);

        Task DeleteAsync(int deliveryChallanId);

        Task SaveChangesAsync();
    }
}

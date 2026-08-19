using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Shipments.Interfaces
{
    public interface IShipmentRepository
    {
        Task<IEnumerable<Shipment>> GetAllAsync();

        Task<Shipment?> GetByIdAsync(int shipmentId);

        Task<IEnumerable<Shipment>> GetByOrderAsync(int orderId);

        Task<IEnumerable<Shipment>> GetByStatusAsync(string shipmentStatus);

        Task<Shipment?> GetByTrackingNumberAsync(string trackingNumber);
        Task<IEnumerable<Shipment>> GetBySellerCustomerAsync(
    int sellerId,
    int customerId);
        Task AddAsync(Shipment shipment);

        Task UpdateAsync(Shipment shipment);

        Task DeleteAsync(int shipmentId);

        Task SaveChangesAsync();
    }
}

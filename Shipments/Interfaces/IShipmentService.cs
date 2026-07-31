using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Shipments.Interfaces
{
    public interface IShipmentService
    {
        Task<IEnumerable<Shipment>> GetAllAsync();

        Task<Shipment?> GetByIdAsync(int shipmentId);

        Task<IEnumerable<Shipment>> GetByOrderAsync(int orderId);

        Task<IEnumerable<Shipment>> GetByStatusAsync(string shipmentStatus);

        Task<Shipment?> GetByTrackingNumberAsync(string trackingNumber);

        Task<Shipment> CreateAsync(Shipment shipment);

        Task<bool> UpdateAsync(int shipmentId, Shipment shipment);

        Task<bool> DeleteAsync(int shipmentId);
    }
}

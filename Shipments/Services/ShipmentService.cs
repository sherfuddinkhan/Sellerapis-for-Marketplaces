using Marketplacesellerportal.Models;
using Marketplacesellerportal.Shipments.Interfaces;

namespace Marketplacesellerportal.Shipments.Services
{
    public class ShipmentService : IShipmentService
    {
        private readonly IShipmentRepository _repository;

        public ShipmentService(IShipmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Shipment>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Shipment?> GetByIdAsync(int shipmentId)
        {
            return await _repository.GetByIdAsync(shipmentId);
        }

        public async Task<IEnumerable<Shipment>> GetByOrderAsync(int orderId)
        {
            return await _repository.GetByOrderAsync(orderId);
        }

        public async Task<IEnumerable<Shipment>> GetByStatusAsync(string shipmentStatus)
        {
            return await _repository.GetByStatusAsync(shipmentStatus);
        }

        public async Task<Shipment?> GetByTrackingNumberAsync(string trackingNumber)
        {
            return await _repository.GetByTrackingNumberAsync(trackingNumber);
        }

        public async Task<Shipment> CreateAsync(Shipment shipment)
        {
            if (shipment.ShipmentDate == null)
                shipment.ShipmentDate = DateTime.Now;

            await _repository.AddAsync(shipment);
            await _repository.SaveChangesAsync();

            return shipment;
        }

        public async Task<bool> UpdateAsync(int shipmentId, Shipment shipment)
        {
            var existing = await _repository.GetByIdAsync(shipmentId);

            if (existing == null)
                return false;

            existing.OrderId = shipment.OrderId;
            existing.CourierName = shipment.CourierName;
            existing.TrackingNumber = shipment.TrackingNumber;
            existing.ShipmentDate = shipment.ShipmentDate;
            existing.DeliveryDate = shipment.DeliveryDate;
            existing.ShipmentStatus = shipment.ShipmentStatus;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int shipmentId)
        {
            var existing = await _repository.GetByIdAsync(shipmentId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(shipmentId);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}

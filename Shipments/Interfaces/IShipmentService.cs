using Marketplacesellerportal.Models;
using Marketplacesellerportal.Shipments.DTOs;

namespace Marketplacesellerportal.Shipments.Interfaces
{
    public interface IShipmentService
    {
        Task<IEnumerable<Shipment>> GetAllAsync();

        Task<Shipment?> GetByIdAsync(int id);

        Task<IEnumerable<Shipment>> GetByOrderAsync(
            int orderId);

        Task<IEnumerable<Shipment>> GetByStatusAsync(
            string status);

        Task<Shipment?> GetByTrackingNumberAsync(
            string trackingNumber);

        // =====================================================
        // NEW 4 APIs
        // =====================================================

        Task<IEnumerable<Shipment>> SearchAsync(
            string search);

        Task<IEnumerable<Shipment>> GetSortedAsync(
            string? sort);

        Task<PagedResult<Shipment>> GetPagedAsync(
            int page,
            int limit);

        Task<ShipmentStatistics> GetStatisticsAsync();

        // =====================================================
        // CRUD
        // =====================================================

        Task<Shipment> CreateAsync(
            Shipment shipment);

        Task<bool> UpdateAsync(
            int id,
            Shipment shipment);

        Task<bool> DeleteAsync(
            int id);
    }
}
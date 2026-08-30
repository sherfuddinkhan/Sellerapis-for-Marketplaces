using Marketplacesellerportal.Models;
using Marketplacesellerportal.Shipments.DTOs;

namespace Marketplacesellerportal.Shipments.Interfaces
{
    public interface IShipmentRepository
    {
        Task<IEnumerable<Shipment>> GetAllAsync();

        Task<Shipment?> GetByIdAsync(
            int shipmentId);

        // =====================================================
        // SELLER + CUSTOMER
        // =====================================================

        Task<IEnumerable<Shipment>> GetBySellerCustomerAsync(
            int sellerId,
            int customerId);

        // =====================================================
        // EXISTING FILTERS
        // =====================================================

        Task<IEnumerable<Shipment>> GetByOrderAsync(
            int orderId);

        Task<IEnumerable<Shipment>> GetByStatusAsync(
            string shipmentStatus);

        Task<Shipment?> GetByTrackingNumberAsync(
            string trackingNumber);

        // =====================================================
        // SEARCH
        // =====================================================

        Task<IEnumerable<Shipment>> SearchAsync(
            string search);

        // =====================================================
        // SORT
        // =====================================================

        Task<IEnumerable<Shipment>> GetSortedAsync(
            string? sort);

        // =====================================================
        // PAGINATION
        // =====================================================

        Task<PagedResult<Shipment>> GetPagedAsync(
            int page,
            int limit);

        // =====================================================
        // STATISTICS
        // =====================================================

        Task<ShipmentStatistics> GetStatisticsAsync();

        // =====================================================
        // CRUD
        // =====================================================

        Task AddAsync(
            Shipment shipment);

        Task UpdateAsync(
            Shipment shipment);

        Task DeleteAsync(
            int shipmentId);

        Task SaveChangesAsync();
    }
}
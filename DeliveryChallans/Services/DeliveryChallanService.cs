using Marketplacesellerportal.Models;
using Marketplacesellerportal.DeliveryChallans.Interfaces;

namespace Marketplacesellerportal.DeliveryChallans.Services
{
    public class DeliveryChallanService : IDeliveryChallanService
    {
        private readonly IDeliveryChallanRepository _repository;

        public DeliveryChallanService(
            IDeliveryChallanRepository repository)
        {
            _repository = repository;
        }

        // =====================================================
        // GET ALL
        // GET /api/DeliveryChallan
        // =====================================================

        public async Task<IEnumerable<DeliveryChallan>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // =====================================================
        // GET BY ID
        // GET /api/DeliveryChallan/{id}
        // =====================================================

        public async Task<DeliveryChallan?> GetByIdAsync(
            int deliveryChallanId)
        {
            return await _repository.GetByIdAsync(
                deliveryChallanId);
        }

        // =====================================================
        // GET BY SALES ORDER
        // GET /api/DeliveryChallan/salesorder/{salesOrderId}
        // =====================================================

        public async Task<IEnumerable<DeliveryChallan>>
            GetBySalesOrderAsync(int salesOrderId)
        {
            return await _repository.GetBySalesOrderAsync(
                salesOrderId);
        }

        // =====================================================
        // GET BY STATUS
        // GET /api/DeliveryChallan/status/{status}
        // =====================================================

        public async Task<IEnumerable<DeliveryChallan>>
            GetByStatusAsync(string status)
        {
            return await _repository.GetByStatusAsync(status);
        }

        // =====================================================
        // GET BY CHALLAN NUMBER
        // GET /api/DeliveryChallan/number/{challanNumber}
        // =====================================================

        public async Task<DeliveryChallan?>
            GetByChallanNumberAsync(string challanNumber)
        {
            return await _repository.GetByChallanNumberAsync(
                challanNumber);
        }

        // =====================================================
        // SEARCH
        // GET /api/DeliveryChallan?search=DC-001
        // =====================================================

        public async Task<IEnumerable<DeliveryChallan>>
            SearchAsync(string search)
        {
            return await _repository.SearchAsync(search);
        }

        // =====================================================
        // SORT
        // GET /api/DeliveryChallan?sort=challan_number
        // =====================================================

        public async Task<IEnumerable<DeliveryChallan>>
            GetSortedAsync(string? sort)
        {
            return await _repository.GetSortedAsync(sort);
        }

        // =====================================================
        // PAGINATION
        // GET /api/DeliveryChallan?page=1&limit=15
        // =====================================================

        public async Task<PagedResult<DeliveryChallan>>
            GetPagedAsync(int page, int limit)
        {
            return await _repository.GetPagedAsync(
                page,
                limit);
        }

        // =====================================================
        // STATISTICS
        // GET /api/DeliveryChallan/stats
        // =====================================================

        public async Task<DeliveryChallanStatistics>
            GetStatisticsAsync()
        {
            return await _repository.GetStatisticsAsync();
        }

        // =====================================================
        // CREATE
        // POST /api/DeliveryChallan
        // =====================================================

        public async Task<DeliveryChallan> CreateAsync(
            DeliveryChallan deliveryChallan)
        {
            deliveryChallan.CreatedDate = DateTime.Now;

            if (deliveryChallan.ChallanDate == null)
            {
                deliveryChallan.ChallanDate = DateTime.Now;
            }

            await _repository.AddAsync(deliveryChallan);

            await _repository.SaveChangesAsync();

            return deliveryChallan;
        }

        // =====================================================
        // UPDATE
        // PUT /api/DeliveryChallan/{id}
        // =====================================================

        public async Task<bool> UpdateAsync(
            int deliveryChallanId,
            DeliveryChallan deliveryChallan)
        {
            var existing =
                await _repository.GetByIdAsync(
                    deliveryChallanId);

            if (existing == null)
                return false;

            existing.SalesOrderId =
                deliveryChallan.SalesOrderId;

            existing.ChallanNumber =
                deliveryChallan.ChallanNumber;

            existing.ChallanDate =
                deliveryChallan.ChallanDate;

            existing.VehicleNumber =
                deliveryChallan.VehicleNumber;

            existing.DriverName =
                deliveryChallan.DriverName;

            existing.DriverMobile =
                deliveryChallan.DriverMobile;

            existing.TransporterName =
                deliveryChallan.TransporterName;

            existing.Status =
                deliveryChallan.Status;

            existing.Remarks =
                deliveryChallan.Remarks;

            await _repository.UpdateAsync(existing);

            await _repository.SaveChangesAsync();

            return true;
        }

        // =====================================================
        // DELETE
        // DELETE /api/DeliveryChallan/{id}
        // =====================================================

        public async Task<bool> DeleteAsync(
            int deliveryChallanId)
        {
            var existing =
                await _repository.GetByIdAsync(
                    deliveryChallanId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(
                deliveryChallanId);

            await _repository.SaveChangesAsync();

            return true;
        }
    }
}


using Marketplacesellerportal.Models;
using Marketplacesellerportal.DeliveryChallans.Interfaces;

namespace Marketplacesellerportal.DeliveryChallans.Services
{
    public class DeliveryChallanService : IDeliveryChallanService
    {
        private readonly IDeliveryChallanRepository _repository;

        public DeliveryChallanService(IDeliveryChallanRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DeliveryChallan>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<DeliveryChallan?> GetByIdAsync(int deliveryChallanId)
        {
            return await _repository.GetByIdAsync(deliveryChallanId);
        }

        public async Task<IEnumerable<DeliveryChallan>> GetBySalesOrderAsync(int salesOrderId)
        {
            return await _repository.GetBySalesOrderAsync(salesOrderId);
        }

        public async Task<IEnumerable<DeliveryChallan>> GetByStatusAsync(string status)
        {
            return await _repository.GetByStatusAsync(status);
        }

        public async Task<DeliveryChallan?> GetByChallanNumberAsync(string challanNumber)
        {
            return await _repository.GetByChallanNumberAsync(challanNumber);
        }

        public async Task<DeliveryChallan> CreateAsync(DeliveryChallan deliveryChallan)
        {
            deliveryChallan.CreatedDate = DateTime.Now;

            if (deliveryChallan.ChallanDate == null)
                deliveryChallan.ChallanDate = DateTime.Now;

            await _repository.AddAsync(deliveryChallan);
            await _repository.SaveChangesAsync();

            return deliveryChallan;
        }

        public async Task<bool> UpdateAsync(int deliveryChallanId, DeliveryChallan deliveryChallan)
        {
            var existing = await _repository.GetByIdAsync(deliveryChallanId);

            if (existing == null)
                return false;

            existing.SalesOrderId = deliveryChallan.SalesOrderId;
            existing.ChallanNumber = deliveryChallan.ChallanNumber;
            existing.ChallanDate = deliveryChallan.ChallanDate;
            existing.VehicleNumber = deliveryChallan.VehicleNumber;
            existing.DriverName = deliveryChallan.DriverName;
            existing.DriverMobile = deliveryChallan.DriverMobile;
            existing.TransporterName = deliveryChallan.TransporterName;
            existing.Status = deliveryChallan.Status;
            existing.Remarks = deliveryChallan.Remarks;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int deliveryChallanId)
        {
            var existing = await _repository.GetByIdAsync(deliveryChallanId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(deliveryChallanId);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}

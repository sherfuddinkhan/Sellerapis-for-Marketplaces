using Marketplacesellerportal.ReversePickups.DTOs;
using Marketplacesellerportal.ReversePickups.Interfaces;
using ReversePickupEntity = Marketplacesellerportal.Models.ReversePickup;

namespace Marketplacesellerportal.ReversePickups.Services
{
    public class ReversePickupService : IReversePickupService
    {
        private readonly IReversePickupRepository _repo;
        public ReversePickupService(IReversePickupRepository repo) => _repo = repo;

        public async Task<ReversePickupListResponse> GetAllAsync()
        {
            var items = await _repo.GetAllAsync();
            var list = items.Select(Map).ToList();
            return new ReversePickupListResponse
            {
                Success = true,
                Message = "All reverse pickups fetched",
                Data = list,
                TotalCount = list.Count,
                PageNumber = 1,
                PageSize = list.Count
            };
        }

        public async Task<ReversePickupResponse> GetByIdAsync(int id, int sellerId, int customerId)
        {
            var e = await _repo.GetByIdAsync(id, sellerId, customerId);
            if (e == null) return new ReversePickupResponse { Success = false, Message = "Not found" };
            return new ReversePickupResponse { Success = true, Data = Map(e) };
        }

        public async Task<ReversePickupListResponse> GetListAsync(ReversePickupListRequest req)
        {
            var (items, total) = await _repo.GetListAsync(req);
            return new ReversePickupListResponse
            {
                Success = true,
                Data = items.Select(Map).ToList(),
                TotalCount = total,
                PageNumber = req.PageNumber,
                PageSize = req.PageSize
            };
        }

        public async Task<ReversePickupResponse> CreateAsync(ReversePickupModel m)
        {
            var cr = await _repo.CreateAsync(MapToEntity(m));
            return new ReversePickupResponse { Success = true, Message = "Created", Data = Map(cr) };
        }

        public async Task<ReversePickupResponse> UpdateAsync(int id, ReversePickupModel m)
        {
            var e = MapToEntity(m);
            e.ReversePickupId = id;
            var up = await _repo.UpdateAsync(e);
            if (up == null) return new ReversePickupResponse { Success = false, Message = "Not found" };
            return new ReversePickupResponse { Success = true, Message = "Updated", Data = Map(up) };
        }

        // FIXED - This matches your Interface exactly
        public async Task<ReversePickupResponse> DeleteAsync(int id, int sellerId, int customerId)
        {
            try
            {
                var entity = await _repo.GetByIdAsync(id, sellerId, customerId);
                if (entity == null)
                    return new ReversePickupResponse { Success = false, Message = $"Not found: {id}/{sellerId}/{customerId}" };

                var ok = await _repo.DeleteAsync(id, sellerId, customerId);
                if (!ok)
                    return new ReversePickupResponse { Success = false, Message = "Delete failed in repo" };

                return new ReversePickupResponse { Success = true, Message = "Deleted successfully" };
            }
            catch (Exception ex)
            {
                return new ReversePickupResponse { Success = false, Message = ex.InnerException?.Message ?? ex.Message };
            }
        }

        private static ReversePickupModel Map(ReversePickupEntity e) => new()
        {
            ReversePickupId = e.ReversePickupId,
            ReversePickupNo = e.ReversePickupNo,
            SaleOrderCode = e.SaleOrderCode,
            SaleOrderItemCode = e.SaleOrderItemCode,
            ItemSkuCode = e.ItemSkuCode,
            TrackingNo = e.TrackingNo,
            ReturnReason = e.ReturnReason,
            QCComment = e.QCComment,
            ReversePickupStatus = e.ReversePickupStatus,
            CourierProviderName = e.CourierProviderName,
            FacilityCode = e.FacilityCode,
            ChannelName = e.ChannelName,
            PutawayCode = e.PutawayCode,
            SellerId = e.SellerId,
            CustomerId = e.CustomerId,
            CreatedDate = e.CreatedDate,
            UpdatedDate = e.UpdatedDate
        };

        private static ReversePickupEntity MapToEntity(ReversePickupModel m) => new()
        {
            ReversePickupNo = m.ReversePickupNo,
            SaleOrderCode = m.SaleOrderCode,
            SaleOrderItemCode = m.SaleOrderItemCode,
            ItemSkuCode = m.ItemSkuCode,
            TrackingNo = m.TrackingNo,
            ReturnReason = m.ReturnReason,
            QCComment = m.QCComment,
            ReversePickupStatus = m.ReversePickupStatus,
            CourierProviderName = m.CourierProviderName,
            FacilityCode = m.FacilityCode,
            ChannelName = m.ChannelName,
            PutawayCode = m.PutawayCode,
            SellerId = m.SellerId,
            CustomerId = m.CustomerId,
            CreatedDate = m.CreatedDate,
            UpdatedDate = DateTime.UtcNow
        };
    }
}
using Marketplacesellerportal.DTOs;
using Marketplacesellerportal.Interfaces;
using Marketplacesellerportal.ReversePickup.DTOs;
using Marketplacesellerportal.ReversePickups.DTOs;
using Marketplacesellerportal.ReversePickups.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using ReversePickupEntity = Marketplacesellerportal.Models.ReversePickup;

namespace Marketplacesellerportal.ReversePickups.Services
{
    public class ReversePickupService : IReversePickupService
    {
        private readonly IReversePickupRepository _repo;
        public ReversePickupService(IReversePickupRepository repo) => _repo = repo;

        public async Task<ReversePickupResponse> GetByIdAsync(int id, int s, int c)
        {
            var e = await _repo.GetByIdAsync(id, s, c);
            if (e == null) return new ReversePickupResponse { Success = false, Message = "Not found" };
            return new ReversePickupResponse { Success = true, Data = Map(e) };
        }

        public async Task<ReversePickupListResponse> GetListAsync(ReversePickupListRequest req)
        {
            var (items, total) = await _repo.GetListAsync(req);
            return new ReversePickupListResponse { Success = true, Data = items.Select(Map).ToList(), TotalCount = total, PageNumber = req.PageNumber, PageSize = req.PageSize };
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

        public async Task<ReversePickupResponse> DeleteAsync(int id, int s, int c)
        {
            var ok = await _repo.DeleteAsync(id, s, c);
            return new ReversePickupResponse { Success = ok, Message = ok ? "Deleted" : "Not found" };
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
            ReversePickupId = m.ReversePickupId,
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
            UpdatedDate = m.UpdatedDate
        };
    }
}
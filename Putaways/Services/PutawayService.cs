using Marketplacesellerportal.DTOs;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Putaways.DTOs;
using Marketplacesellerportal.Putaways.Interfaces;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplacesellerportal.Putaways.Services
{
    public class PutawayService : IPutawayService
    {
        private readonly IPutawayRepository _repo;
        public PutawayService(IPutawayRepository repo) => _repo = repo;

        public async Task<PutawayResponse> GetByIdAsync(int id, int s, int c)
        {
            var e = await _repo.GetByIdAsync(id, s, c);
            if (e == null) return PutawayResponse.Fail("Not found");
            return PutawayResponse.Ok(Map(e));
        }

        public async Task<PutawayListResponse> GetListAsync(PutawayListRequest req)
        {
            var (items, total) = await _repo.GetListAsync(req);
            return PutawayListResponse.Ok(items.Select(Map).ToList(), total, req.PageNumber, req.PageSize);
        }

        public async Task<PutawayResponse> CreateAsync(PutawayModel m)
        {
            var e = MapToEntity(m);
            var cr = await _repo.CreateAsync(e);
            return PutawayResponse.Ok(Map(cr), "Created");
        }

        public async Task<PutawayResponse> UpdateAsync(int id, PutawayModel m)
        {
            var e = MapToEntity(m);
            e.PutawayId = id;
            var up = await _repo.UpdateAsync(e);
            if (up == null) return PutawayResponse.Fail("Not found");
            return PutawayResponse.Ok(Map(up), "Updated");
        }

        public async Task<PutawayResponse> DeleteAsync(int id, int s, int c)
        {
            var ok = await _repo.DeleteAsync(id, s, c);
            return ok ? new PutawayResponse { Success = true, Message = "Deleted" } : PutawayResponse.Fail("Not found");
        }

        public async Task<PutawayStatisticsResponse> GetStatisticsAsync(int s, int c)
        {
            var st = await _repo.GetStatisticsAsync(s, c);
            return PutawayStatisticsResponse.Ok(st);
        }

        private static PutawayModel Map(Putaway e) => new()
        {
            PutawayId = e.PutawayId,
            PutawayCode = e.PutawayCode,
            ShelfCode = e.ShelfCode,
            ItemTypeSkuCode = e.ItemTypeSkuCode,
            PutawayQuantity = e.PutawayQuantity,
            BatchCode = e.BatchCode,
            InventoryType = e.InventoryType,
            StatusCode = e.StatusCode,
            FacilityCode = e.FacilityCode,
            PutawayType = e.PutawayType,
            CreatedBy = e.CreatedBy,
            SellerId = e.SellerId,
            CustomerId = e.CustomerId,
            CreatedDate = e.CreatedDate,
            UpdatedDate = e.UpdatedDate
        };

        private static Putaway MapToEntity(PutawayModel m) => new()
        {
            PutawayId = m.PutawayId,
            PutawayCode = m.PutawayCode,
            ShelfCode = m.ShelfCode,
            ItemTypeSkuCode = m.ItemTypeSkuCode,
            PutawayQuantity = m.PutawayQuantity,
            BatchCode = m.BatchCode,
            InventoryType = m.InventoryType,
            StatusCode = m.StatusCode,
            FacilityCode = m.FacilityCode,
            PutawayType = m.PutawayType,
            CreatedBy = m.CreatedBy,
            SellerId = m.SellerId,
            CustomerId = m.CustomerId,
            CreatedDate = m.CreatedDate,
            UpdatedDate = m.UpdatedDate
        };
    }
}
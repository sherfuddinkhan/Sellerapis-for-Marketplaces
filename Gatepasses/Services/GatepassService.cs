using Marketplacesellerportal.Gatepasses.DTOs;
using Marketplacesellerportal.Gatepasses.DTOs.Marketplacesellerportal.Gatepasses.DTOs;
using Marketplacesellerportal.Gatepasses.Interfaces;
using Marketplacesellerportal.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplacesellerportal.Gatepasses.Services
{
    public class GatepassService : IGatepassService
    {
        private readonly IGatepassRepository _repo;
        public GatepassService(IGatepassRepository repo) => _repo = repo;

        public async Task<GatepassResponse> GetByIdAsync(int id, int s, int c)
        {
            var e = await _repo.GetByIdAsync(id, s, c);
            if (e == null) return GatepassResponse.Fail("Not found");
            return GatepassResponse.Ok(Map(e));
        }

        public async Task<GatepassResponse> GetByCodeAsync(string code, int s, int c)
        {
            var e = await _repo.GetByCodeAsync(code, s, c);
            if (e == null) return GatepassResponse.Fail("Not found");
            return GatepassResponse.Ok(Map(e));
        }

        public async Task<GatepassListResponse> GetListAsync(GatepassListRequest req)
        {
            var (items, total) = await _repo.GetListAsync(req);
            return new GatepassListResponse
            {
                Success = true,
                Data = items.Select(Map).ToList(),
                TotalCount = total,
                PageNumber = req.PageNumber,
                PageSize = req.PageSize
            };
        }

        public async Task<GatepassListResponse> GetAllBySellerCustomerAsync(int s, int c)
        {
            var items = await _repo.GetAllBySellerCustomerAsync(s, c);
            return new GatepassListResponse
            {
                Success = true,
                Data = items.Select(Map).ToList(),
                TotalCount = items.Count,
                PageNumber = 1,
                PageSize = items.Count
            };
        }

        public async Task<GatepassResponse> CreateAsync(GatepassModel m)
        {
            var e = MapToEntity(m);
            var cr = await _repo.CreateAsync(e);
            return GatepassResponse.Ok(Map(cr), "Created");
        }

        public async Task<GatepassResponse> UpdateAsync(int id, GatepassModel m)
        {
            var e = MapToEntity(m);
            e.GatepassId = id;
            var up = await _repo.UpdateAsync(e);
            if (up == null) return GatepassResponse.Fail("Not found");
            return GatepassResponse.Ok(Map(up), "Updated");
        }

        public async Task<GatepassResponse> DeleteAsync(int id, int s, int c)
        {
            var ok = await _repo.DeleteAsync(id, s, c);
            return ok ? new GatepassResponse { Success = true, Message = "Deleted" }
                      : GatepassResponse.Fail("Not found");
        }

        // Map Entity -> Dto (for response)
        private static GatepassDto Map(Gatepass e) => new()
        {
            GatepassId = e.GatepassId,
            GatepassCode = e.GatepassCode,
            FacilityCode = e.FacilityCode,
            ItemSkuCode = e.ItemSkuCode,
            Quantity = e.Quantity,
            Reason = e.Reason,
            Status = e.Status,
            CreatedBy = e.CreatedBy,
            SellerId = e.SellerId,
            CustomerId = e.CustomerId,
            CreatedDate = e.CreatedDate,
            UpdatedDate = e.UpdatedDate
        };

        // Map Model -> Entity (for create/update)
        private static Gatepass MapToEntity(GatepassModel m) => new()
        {
            GatepassId = m.GatepassId,
            GatepassCode = m.GatepassCode,
            FacilityCode = m.FacilityCode,
            ItemSkuCode = m.ItemSkuCode,
            Quantity = m.Quantity,
            Reason = m.Reason,
            Status = m.Status,
            CreatedBy = m.CreatedBy,
            SellerId = m.SellerId,
            CustomerId = m.CustomerId,
            CreatedDate = m.CreatedDate
        };
    }
}
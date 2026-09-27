using Marketplacesellerportal.DTOs;
using Marketplacesellerportal.Interfaces;
using Marketplacesellerportal.VendorItemMaster.DTOs;
using Marketplacesellerportal.VendorItemMasters.DTOs;
using Marketplacesellerportal.VendorItemMasters.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using VendorItemMasterEntity = Marketplacesellerportal.Models.VendorItemMaster;

namespace Marketplacesellerportal.VendorItemMasters.Services
{
    public class VendorItemMasterService : IVendorItemMasterService
    {
        private readonly IVendorItemMasterRepository _repo;
        public VendorItemMasterService(IVendorItemMasterRepository repo) => _repo = repo;

        public async Task<VendorItemMasterResponse> GetByIdAsync(int id, int s, int c)
        {
            var e = await _repo.GetByIdAsync(id, s, c);
            if (e == null) return new VendorItemMasterResponse { Success = false, Message = "Not found" };
            return new VendorItemMasterResponse { Success = true, Data = Map(e) };
        }

        public async Task<VendorItemMasterListResponse> GetListAsync(VendorItemMasterListRequest req)
        {
            var (items, total) = await _repo.GetListAsync(req);
            return new VendorItemMasterListResponse { Success = true, Data = items.Select(Map).ToList(), TotalCount = total, PageNumber = req.PageNumber, PageSize = req.PageSize };
        }

        public async Task<VendorItemMasterResponse> CreateAsync(VendorItemMasterModel m)
        {
            if (await _repo.ExistsByVendorSkuAsync(m.VendorSkuCode, m.VendorId, m.SellerId, m.CustomerId))
            {
                return new VendorItemMasterResponse { Success = false, Message = "VendorSku already exists" };
            }
            var cr = await _repo.CreateAsync(MapToEntity(m));
            return new VendorItemMasterResponse { Success = true, Message = "Created", Data = Map(cr) };
        }

        public async Task<VendorItemMasterResponse> UpdateAsync(int id, VendorItemMasterModel m)
        {
            var e = MapToEntity(m);
            e.VendorItemMasterId = id;
            var up = await _repo.UpdateAsync(e);
            if (up == null) return new VendorItemMasterResponse { Success = false, Message = "Not found" };
            return new VendorItemMasterResponse { Success = true, Message = "Updated", Data = Map(up) };
        }

        public async Task<VendorItemMasterResponse> DeleteAsync(int id, int s, int c)
        {
            var ok = await _repo.DeleteAsync(id, s, c);
            return new VendorItemMasterResponse { Success = ok, Message = ok ? "Deleted" : "Not found" };
        }

        private static VendorItemMasterModel Map(VendorItemMasterEntity e) => new()
        {
            VendorItemMasterId = e.VendorItemMasterId,
            SellerId = e.SellerId,
            CustomerId = e.CustomerId,
            VendorId = e.VendorId,
            VendorSkuCode = e.VendorSkuCode,
            ItemSkuCode = e.ItemSkuCode,
            ProductId = e.ProductId,
            CostPrice = e.CostPrice,
            IsActive = e.IsActive,
            CreatedDate = e.CreatedDate,
            UpdatedDate = e.UpdatedDate
        };

        private static VendorItemMasterEntity MapToEntity(VendorItemMasterModel m) => new()
        {
            VendorItemMasterId = m.VendorItemMasterId,
            SellerId = m.SellerId,
            CustomerId = m.CustomerId,
            VendorId = m.VendorId,
            VendorSkuCode = m.VendorSkuCode,
            ItemSkuCode = m.ItemSkuCode,
            ProductId = m.ProductId,
            CostPrice = m.CostPrice,
            IsActive = m.IsActive,
            CreatedDate = m.CreatedDate,
            UpdatedDate = m.UpdatedDate
        };
    }
}
// NO duplicate usings
using Marketplacesellerportal.DTOs;
using Marketplacesellerportal.VendorItemMasters.DTOs;
using Marketplacesellerportal.VendorItemMasters.Interfaces;
using System.Linq;
using System.Threading.Tasks;

// Use global:: to force Model, not Namespace
using VendorMasterEntity = global::Marketplacesellerportal.Models.VendorItemMaster;

namespace Marketplacesellerportal.VendorItemMasters.Services
{
    public class VendorItemMasterService(IVendorItemMasterRepository repo) : IVendorItemMasterService
    {
        private readonly IVendorItemMasterRepository _repo = repo;

        public async Task<VendorItemMasterResponse> GetByIdAsync(int id, int s, int c)
        {
            var e = await _repo.GetByIdAsync(id, s, c);
            if (e is null) return new() { Success = false, Message = "Not found" };
            return new() { Success = true, Data = Map(e) };
        }

        public async Task<VendorItemMasterListResponse> GetListAsync(VendorItemMasterListRequest req)
        {
            var (items, total) = await _repo.GetListAsync(req);
            return new()
            {
                Success = true,
                Data = [.. items.Select(Map)], // Simplified collection
                TotalCount = total,
                PageNumber = req.PageNumber,
                PageSize = req.PageSize
            };
        }

        public async Task<VendorItemMasterResponse> CreateAsync(VendorItemMasterModel m)
        {
            if (await _repo.ExistsByVendorSkuAsync(m.VendorSkuCode, m.VendorId, m.SellerId, m.CustomerId))
                return new() { Success = false, Message = "VendorSku already exists" };

            var cr = await _repo.CreateAsync(MapToEntity(m));
            return new() { Success = true, Message = "Created", Data = Map(cr) };
        }

        public async Task<VendorItemMasterResponse> UpdateAsync(int id, VendorItemMasterModel m)
        {
            var entity = MapToEntity(m);
            entity.VendorItemMasterId = id;
            var up = await _repo.UpdateAsync(entity);
            if (up is null) return new() { Success = false, Message = "Not found" };
            return new() { Success = true, Message = "Updated", Data = Map(up) };
        }

        public async Task<VendorItemMasterResponse> DeleteAsync(int id, int s, int c)
        {
            var ok = await _repo.DeleteAsync(id, s, c);
            return new() { Success = ok, Message = ok ? "Deleted" : "Not found" };
        }

        private static VendorItemMasterModel Map(VendorMasterEntity e) => new()
        {
            VendorItemMasterId = e.VendorItemMasterId,
            SellerId = e.SellerId,
            CustomerId = e.CustomerId,
            VendorId = e.VendorId,
            ProductId = e.ProductId ?? 0,
            VendorSkuCode = e.VendorSkuCode,
            ItemSkuCode = e.ItemSkuCode,
            ItemCode = e.ItemCode,
            ItemSku = e.ItemSku,
            SKU = e.SKU,
            vendorCode = e.vendorCode,
            VendorItemCode = e.VendorItemCode,
            CostPrice = e.CostPrice,
            unitPrice = e.unitPrice,
            MRP = e.MRP,
            SellingPrice = e.SellingPrice,
            inventory = e.inventory ?? 0,
            LeadTime = e.LeadTime,
            priority = e.priority ?? 0,
            enabled = e.enabled,
            IsActive = e.IsActive,
            CreatedDate = e.CreatedDate ?? DateTime.MinValue,
            UpdatedDate = e.UpdatedDate
        };

        private static VendorMasterEntity MapToEntity(VendorItemMasterModel m) => new()
        {
            VendorItemMasterId = m.VendorItemMasterId,
            SellerId = m.SellerId,
            CustomerId = m.CustomerId,
            VendorId = m.VendorId,
            ProductId = m.ProductId,
            VendorSkuCode = m.VendorSkuCode,
            ItemSkuCode = m.ItemSkuCode,
            ItemCode = m.ItemCode,
            ItemSku = m.ItemSku,
            SKU = m.SKU,
            vendorCode = m.vendorCode,
            VendorItemCode = m.VendorItemCode,
            CostPrice = m.CostPrice,
            unitPrice = m.unitPrice,
            MRP = m.MRP,
            SellingPrice = m.SellingPrice,
            inventory = m.inventory,
            LeadTime = m.LeadTime,
            priority = m.priority,
            enabled = m.enabled,
            IsActive = m.IsActive,
            CreatedDate = m.CreatedDate,
            UpdatedDate = m.UpdatedDate
        };
    }
}
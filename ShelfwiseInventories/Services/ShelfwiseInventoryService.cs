using Marketplacesellerportal.DTOs;
using Marketplacesellerportal.Interfaces;
using Marketplacesellerportal.ShelfwiseInventory.DTOs;
using Marketplacesellerportal.ShelfwiseInventory.DTOs.Marketplacesellerportal.DTOs;
using Marketplacesellerportal.ShelfwiseInventory.Interfaces;
using System.Linq;
using System.Threading.Tasks;
// ALIAS to fix "is a namespace but is used like a type"
using ShelfwiseInventoryEntity = Marketplacesellerportal.Models.ShelfwiseInventory;

namespace Marketplacesellerportal.ShelfwiseInventory.Services
{
    public class ShelfwiseInventoryService : IShelfwiseInventoryService
    {
        private readonly IShelfwiseInventoryRepository _repo;
        public ShelfwiseInventoryService(IShelfwiseInventoryRepository repo) => _repo = repo;

        public async Task<ShelfwiseInventoryResponse> GetByIdAsync(int id, int s, int c)
        {
            var e = await _repo.GetByIdAsync(id, s, c);
            if (e == null) return new ShelfwiseInventoryResponse { Success = false, Message = "Not found" };
            return new ShelfwiseInventoryResponse { Success = true, Data = Map(e) };
        }

        public async Task<ShelfwiseInventoryListResponse> GetListAsync(ShelfwiseInventoryListRequest req)
        {
            var (items, total) = await _repo.GetListAsync(req);
            return new ShelfwiseInventoryListResponse { Success = true, Data = items.Select(Map).ToList(), TotalCount = total, PageNumber = req.PageNumber, PageSize = req.PageSize };
        }

        public async Task<ShelfwiseInventoryResponse> CreateAsync(ShelfwiseInventoryModel m)
        {
            var cr = await _repo.CreateAsync(MapToEntity(m));
            return new ShelfwiseInventoryResponse { Success = true, Message = "Created", Data = Map(cr) };
        }

        public async Task<ShelfwiseInventoryResponse> UpdateAsync(int id, ShelfwiseInventoryModel m)
        {
            var e = MapToEntity(m);
            e.ShelfwiseInventoryId = id;
            var up = await _repo.UpdateAsync(e);
            if (up == null) return new ShelfwiseInventoryResponse { Success = false, Message = "Not found" };
            return new ShelfwiseInventoryResponse { Success = true, Message = "Updated", Data = Map(up) };
        }

        public async Task<ShelfwiseInventoryResponse> DeleteAsync(int id, int s, int c)
        {
            var ok = await _repo.DeleteAsync(id, s, c);
            return new ShelfwiseInventoryResponse { Success = ok, Message = ok ? "Deleted" : "Not found" };
        }

        private static ShelfwiseInventoryModel Map(
      ShelfwiseInventoryEntity e)
        {
            return new ShelfwiseInventoryModel
            {
                ShelfwiseInventoryId =
                    e.ShelfwiseInventoryId,

                SellerId =
                    e.SellerId ?? 0,

                CustomerId =
                    e.CustomerId ?? 0,

                FacilityCode =
                    e.FacilityCode,

                ShelfCode =
                    e.ShelfCode,

                ItemSkuCode =
                    e.ItemSkuCode,

                Quantity =
                    e.Quantity ?? 0,

                BatchCode =
                    e.BatchCode,

                ExpiryDate =
                    e.ExpiryDate,

                InventoryType =
                    e.InventoryType,

                LocationCode =
                    e.LocationCode,

                CreatedDate =
                    e.CreatedDate ?? DateTime.MinValue,

                UpdatedDate =
                    e.UpdatedDate ?? DateTime.MinValue,

                // =====================================================
                // ADDED
                // =====================================================

                Mrp =
                    e.Mrp,

                Mfd =
                    e.Mfd,

                VendorCode =
                    e.VendorCode,

                VendorBatchNumber =
                    e.VendorBatchNumber,

                LotNumber =
                    e.LotNumber,

                TransferToShelfCode =
                    e.TransferToShelfCode,

                Sla =
                    e.Sla,

                Remarks =
                    e.Remarks,

                WarehouseId =
                    e.WarehouseId
            };
        }
        private static ShelfwiseInventoryEntity MapToEntity(ShelfwiseInventoryModel m) => new()
        {
            ShelfwiseInventoryId = m.ShelfwiseInventoryId,
            SellerId = m.SellerId,
            CustomerId = m.CustomerId,
            FacilityCode = m.FacilityCode,
            ShelfCode = m.ShelfCode,
            ItemSkuCode = m.ItemSkuCode,
            Quantity = m.Quantity,
            BatchCode = m.BatchCode,
            ExpiryDate = m.ExpiryDate,
            InventoryType = m.InventoryType,
            LocationCode = m.LocationCode,
            CreatedDate = m.CreatedDate,
            UpdatedDate = m.UpdatedDate,
            // ===== ADDED =====
            Mrp = m.Mrp,
            Mfd = m.Mfd,
            VendorCode = m.VendorCode,
            VendorBatchNumber = m.VendorBatchNumber,
            LotNumber = m.LotNumber,
            TransferToShelfCode = m.TransferToShelfCode,
            Sla = m.Sla,
            Remarks = m.Remarks,
            WarehouseId = m.WarehouseId
        };
    }
}
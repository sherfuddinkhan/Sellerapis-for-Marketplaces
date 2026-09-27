using System;
using System.Collections.Generic;

namespace Marketplacesellerportal.ShelfwiseInventory.DTOs
{
    public class ShelfwiseInventoryListResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<ShelfwiseInventoryModel> Data { get; set; } = new();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => PageSize > 0 ? (int)Math.Ceiling((double)TotalCount / PageSize) : 0;

        public static ShelfwiseInventoryListResponse Ok(List<ShelfwiseInventoryModel> data, int totalCount, int pageNumber, int pageSize, string msg = "")
        {
            return new ShelfwiseInventoryListResponse
            {
                Success = true,
                Message = msg,
                Data = data,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public static ShelfwiseInventoryListResponse Fail(string msg)
        {
            return new ShelfwiseInventoryListResponse
            {
                Success = false,
                Message = msg
            };
        }
    }
}
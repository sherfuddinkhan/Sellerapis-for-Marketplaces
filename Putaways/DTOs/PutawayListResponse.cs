using System.Collections.Generic;

namespace Marketplacesellerportal.Putaways.DTOs
{
    public class PutawayListResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = "";
        public List<PutawayModel> Data { get; set; } = new();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public static PutawayListResponse Ok(List<PutawayModel> data, int total, int pageNumber, int pageSize)
        {
            return new PutawayListResponse
            {
                Success = true,
                Data = data,
                TotalCount = total,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
}

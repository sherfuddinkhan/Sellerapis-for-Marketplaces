using Marketplacesellerportal.Gatepasses.DTOs.Marketplacesellerportal.Gatepasses.DTOs;

namespace Marketplacesellerportal.Gatepasses.DTOs
{
    public class GatepassListResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = "";
        public List<GatepassDto> Data { get; set; } = new();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}

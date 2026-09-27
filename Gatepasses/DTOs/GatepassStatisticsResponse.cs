using System.Collections.Generic;
namespace Marketplacesellerportal.DTOs
{
  
    public class GatepassStatisticsResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public GatepassStatistics Data { get; set; } = new();
    }
}


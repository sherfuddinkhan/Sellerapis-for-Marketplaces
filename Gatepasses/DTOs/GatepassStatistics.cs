using System.Collections.Generic;
namespace Marketplacesellerportal.DTOs
{
    public class GatepassStatistics
    {
        public int TotalCount { get; set; }
        public int TotalQuantity { get; set; }
        public Dictionary<string, int> ByStatus { get; set; } = new();
        public Dictionary<string, int> ByFacility { get; set; } = new();
    }
   
}

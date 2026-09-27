namespace Marketplacesellerportal.Putaways.DTOs
{
    public class PutawayStatisticsResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = "";
        public PutawayStatistics? Data { get; set; }

        public static PutawayStatisticsResponse Ok(PutawayStatistics data, string msg = "")
        {
            return new PutawayStatisticsResponse
            {
                Success = true,
                Message = msg,
                Data = data
            };
        }

        public static PutawayStatisticsResponse Fail(string msg)
        {
            return new PutawayStatisticsResponse
            {
                Success = false,
                Message = msg
            };
        }
    }
}

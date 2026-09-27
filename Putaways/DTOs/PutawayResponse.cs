namespace Marketplacesellerportal.Putaways.DTOs
{
    public class PutawayResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = "";
        public PutawayModel? Data { get; set; }

        public static PutawayResponse Ok(PutawayModel data, string msg = "")
            => new() { Success = true, Message = msg, Data = data };

        public static PutawayResponse Fail(string msg)
            => new() { Success = false, Message = msg };
    }
}
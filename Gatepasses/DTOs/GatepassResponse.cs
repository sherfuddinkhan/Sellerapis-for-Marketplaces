using Marketplacesellerportal.Gatepasses.DTOs.Marketplacesellerportal.Gatepasses.DTOs;

namespace Marketplacesellerportal.Gatepasses.DTOs
{
    public class GatepassResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = "";
        public GatepassDto? Data { get; set; }

        public static GatepassResponse Ok(GatepassDto data, string msg = "")
            => new() { Success = true, Message = msg, Data = data };

        public static GatepassResponse Fail(string msg)
            => new() { Success = false, Message = msg };
    }
}
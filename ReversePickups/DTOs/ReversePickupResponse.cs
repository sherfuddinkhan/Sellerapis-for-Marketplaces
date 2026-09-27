using Marketplacesellerportal.ReversePickups.DTOs;

public class ReversePickupResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = "";
    public ReversePickupModel? Data { get; set; }
}
namespace Marketplacesellerportal.FacilityChannel.DTOs;

public record FacilityChannelInventoryResponse(
    int Id,
    int SellerId,
    int CustomerId,
    int ProductId,
    string SkuCode,
    string FacilityCode,
    string ChannelCode,
    int SellableQuantity
);

public record CreateFacilityChannelInventoryRequest(
    int SellerId,
    int CustomerId,
    int ProductId,
    string SkuCode,
    string FacilityCode,
    string ChannelCode,
    int SellableQuantity
);

public record UpdateFacilityChannelInventoryRequest(
    int SellerId,
    int CustomerId,
    int ProductId,
    string SkuCode,
    string FacilityCode,
    string ChannelCode,
    int SellableQuantity
);

public record FacilityChannelInventoryFilterRequest(
    int SellerId,
    int CustomerId,
    string? FacilityCode = null,
    string? ChannelCode = null
);
public class SellerCustomerWarehouseResponse
{
    public int WarehouseId { get; set; }
    public int SellerId { get; set; }
    public int? CustomerId { get; set; }

    public string WarehouseCode { get; set; } = string.Empty;
    public string? FacilityCode { get; set; }
    public string? UniwareFacilityCode { get; set; }
    public string WarehouseName { get; set; } = string.Empty;
    public string? FacilityName { get; set; }
    public string? FacilityType { get; set; }
    public string? LocationCode { get; set; }

    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? StateCode { get; set; }
    public string? Country { get; set; }
    public string? CountryCode { get; set; }
    public string? PostalCode { get; set; }

    public string? ContactPerson { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }

    // GST / Tax - YOU MISSED
    public string? GSTNumber { get; set; }
    public string? Pan { get; set; }
    public string? Arn { get; set; }
    public string? TinNo { get; set; }

    public bool? IsActive { get; set; }
    public bool? IsDefault { get; set; }
    public bool? IsQCEnabled { get; set; }
    public bool? IsPutawayEnabled { get; set; }
    public string? ChannelCode { get; set; }

    // Calculated
    public bool IsFacilityCodeMatch { get; set; }
    public int? TotalInventory { get; set; }
    public int? SellableInventory { get; set; }

    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string? CreatedBy { get; set; }
}
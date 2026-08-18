public class SellerCustomerWarehouseResponse
{
    public int WarehouseId { get; set; }

    public int SellerId { get; set; }
    public int CustomerId { get; set; }

    public string WarehouseCode { get; set; } = string.Empty;
    public string WarehouseName { get; set; } = string.Empty;

    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }

    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? PostalCode { get; set; }

    public string? ContactPerson { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}

public class SellerCustomerProductAddressLabelResponse
{
    public int ProductAddressLabelId { get; set; }
    public int ProductId { get; set; }
    public string ManufacturerDetails { get; set; } = string.Empty;
    public string? ImporterDetails { get; set; }
    public string? PackerDetails { get; set; }
    public string CountryOfOrigin { get; set; } = "IN";
    public long? MfgDateEpoch { get; set; }
    public long? ShelfLifeSeconds { get; set; }
    public long? ExpiryDateEpoch { get; set; }
    public string? Quantity { get; set; }
    public decimal? Mrp { get; set; }
}
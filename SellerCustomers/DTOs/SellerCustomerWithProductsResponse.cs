namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerWithProductsResponse
    {
        // =========================================================
        // CUSTOMER
        // =========================================================

        public int CustomerId { get; set; }
        public int SellerId { get; set; }

        public string CustomerCode { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;

        // =========================================================
        // BUSINESS / LEGAL DETAILS
        // =========================================================

        public string? TradeName { get; set; }
        public string? LegalName { get; set; }

        // =========================================================
        // CONTACT DETAILS
        // =========================================================

        public string? ContactPerson { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        // =========================================================
        // TAX DETAILS
        // =========================================================

        public string? GSTIN { get; set; }

        // =========================================================
        // ADDRESS DETAILS
        // =========================================================

        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }

        public string? BuildingName { get; set; }
        public string? Location { get; set; }

        public string? City { get; set; }
        public string? State { get; set; }
        public string? StateCode { get; set; }
        public string? FloorNo { get; set; }

        public string? Country { get; set; }
        public string? PostalCode { get; set; }

        // =========================================================
        // FINANCIAL DETAILS
        // =========================================================

        public decimal CreditLimit { get; set; }

        // =========================================================
        // STATUS / AUDIT
        // =========================================================

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }


        // =========================================================
        // REPORT DATA
        // =========================================================

        public List<SellerCustomerProductResponse> Products { get; set; }
            = new();

        public List<SellerCustomerInventoryResponse> Inventories { get; set; }
            = new();

        public List<SellerCustomerPriceResponse> Prices { get; set; }
            = new();

        public List<SellerCustomerProductTypeResponse> ProductTypes { get; set; }
            = new();

        public List<SellerCustomerCategoryResponse> Categories { get; set; }
            = new();

        public List<SellerCustomerImageResponse> Images { get; set; }
            = new();

        public List<SellerCustomerAttributeResponse> Attributes { get; set; }
            = new();


        // =========================================================
        // STOCK MOVEMENTS
        // =========================================================

        public List<SellerCustomerStockMovementResponse> StockMovements { get; set; }
            = new();


        // =========================================================
        // STOCK LEDGERS
        // =========================================================

        public List<SellerCustomerStockLedgerResponse> StockLedgers { get; set; }
            = new();


        // =========================================================
        // WAREHOUSES
        // =========================================================

        public List<SellerCustomerWarehouseResponse> Warehouses { get; set; }
            = new();


        // =========================================================
        // INVENTORY / STOCK
        // =========================================================

        public List<SellerCustomerStockAdjustmentResponse> StockAdjustments { get; set; }
            = new();

        public List<SellerCustomerStockTransferResponse> StockTransfers { get; set; }
            = new();

        public List<SellerCustomerWarehouseLocationResponse> WarehouseLocations { get; set; }
            = new();


        // =========================================================
        // PROCUREMENT
        // =========================================================

        public List<SellerCustomerSupplierResponse> Suppliers { get; set; }
            = new();


        // =========================================================
        // BRAND MODELS
        // =========================================================
        // =========================================================
        // BRANDS
        // =========================================================

        public List<SellerCustomerBrandResponse> Brands { get; set; }
            = new();
        public List<SellerCustomerBrandModelResponse> BrandModels { get; set; }
            = new();


        // =========================================================
        // TRANSACTIONS
        // =========================================================

        public SellerCustomerTransactionResponse Transactions { get; set; }
            = new();


    }
}
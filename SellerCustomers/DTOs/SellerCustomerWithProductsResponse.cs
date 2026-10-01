using Marketplacesellerportal.EInvoice.DTOs;
using Marketplacesellerportal.EWayBill.DTOs;

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



        public List<SellerCustomerMarketplaceResponse> Marketplaces { get; set; } = new();
        public List<SellerCustomerDeliveryChallanItemResponse> DeliveryChallanItems { get; set; } = new();
        public SellerCustomerSellerResponse? Seller { get; set; }
        public List<SellerCustomerEInvoiceResponse> EInvoices { get; set; } = new();
        public List<SellerCustomerEWayBillResponse> EWayBills { get; set; } = new();

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
        public List<SellerCustomerExportJobResponse> ExportJobs { get; set; }
    = new List<SellerCustomerExportJobResponse>();
        public List<SellerCustomerAddressResponse> CustomerAddresses { get; set; }
    = new();

        public List<SellerCustomerSaleOrderAddressResponse> SalesOrderAddresses { get; set; }
      = new List<SellerCustomerSaleOrderAddressResponse>();
        public List<SellerCustomerReversePickupItemResponse> ReversePickupItems { get; set; }
    = new List<SellerCustomerReversePickupItemResponse>();

        public List<SellerCustomerPicklistResponse> Picklists { get; set; }
    = new List<SellerCustomerPicklistResponse>();
        public List<SellerCustomerReversePickupAddressResponse> ReversePickupAddresses { get; set; }
    = new List<SellerCustomerReversePickupAddressResponse>();
        public List<SellerCustomerManifestPackageResponse> ManifestPackages { get; set; }
    = new List<SellerCustomerManifestPackageResponse>();
        public List<SellerCustomerInvoiceTaxDetailResponse> InvoiceTaxDetails { get; set; }
    = new List<SellerCustomerInvoiceTaxDetailResponse>();



        public List<SellerCustomerShippingManifestResponse> ShippingManifests { get; set; } = new();
        public List<SellerCustomerSupplierAddressResponse> SupplierAddresses { get; set; } = new();
        public List<SellerCustomerSupplierContactResponse> SupplierContacts { get; set; } = new();
        public List<SellerCustomerVendorItemCustomFieldResponse> VendorItemCustomFields { get; set; } = new();
        // =========================================================
        // NEW - INVENTORY & WMS TABLES YOU FIXED
        // =========================================================
        public List<SellerCustomerShelfwiseInventoryResponse> ShelfwiseInventories { get; set; } = new();
        public List<SellerCustomerVendorItemMasterResponse> VendorItemMasters { get; set; } = new();
        public List<SellerCustomerGatepassResponse> Gatepasses { get; set; } = new();
        public List<SellerCustomerPutawayResponse> Putaways { get; set; } = new();
        public List<SellerCustomerReversePickupResponse> ReversePickups { get; set; } = new();
        public List<SellerCustomerMarketplaceListingInventoryResponse> MarketplaceListingInventories { get; set; } = new();
        public List<SellerCustomerAmazonInventorySyncResponse> AmazonInventorySyncs { get; set; } = new();

    }
}
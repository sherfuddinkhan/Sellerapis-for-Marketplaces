using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marketplacesellerportal.Migrations
{
    public partial class AddSalesInvoiceDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // ============================================================
            // 1. UPDATE EXISTING SalesInvoices TABLE
            // ============================================================

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "SalesInvoices",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobileNo",
                table: "SalesInvoices",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "SalesInvoices",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyAddress",
                table: "SalesInvoices",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyCity",
                table: "SalesInvoices",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyState",
                table: "SalesInvoices",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyPINCode",
                table: "SalesInvoices",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerGSTIN",
                table: "SalesInvoices",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurchaseOrderNo",
                table: "SalesInvoices",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchaseOrderDate",
                table: "SalesInvoices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherReferences",
                table: "SalesInvoices",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DespatchedDocumentNumber",
                table: "SalesInvoices",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StateCode",
                table: "SalesInvoices",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryNote",
                table: "SalesInvoices",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryNoteDate",
                table: "SalesInvoices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EWayBillNumber",
                table: "SalesInvoices",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleNo",
                table: "SalesInvoices",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Distance",
                table: "SalesInvoices",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Transport",
                table: "SalesInvoices",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransporterName",
                table: "SalesInvoices",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransporterID",
                table: "SalesInvoices",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransporterDocNo",
                table: "SalesInvoices",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransportMode",
                table: "SalesInvoices",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "SalesInvoices",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillOfLandingOrLRRRNo",
                table: "SalesInvoices",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DespatchedThrough",
                table: "SalesInvoices",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModeOrTermsOfPayment",
                table: "SalesInvoices",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentMode",
                table: "SalesInvoices",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);


            // ============================================================
            // 2. CREATE SalesInvoiceItems
            // ============================================================

            migrationBuilder.CreateTable(
                name: "SalesInvoiceItems",
                columns: table => new
                {
                    SalesInvoiceItemId = table.Column<int>(
                        type: "int",
                        nullable: false)
                        .Annotation(
                            "SqlServer:Identity",
                            "1, 1"),

                    SalesInvoiceId = table.Column<int>(
                        type: "int",
                        nullable: false),

                    ProductId = table.Column<int>(
                        type: "int",
                        nullable: false),

                    Quantity = table.Column<decimal>(
                        type: "decimal(18,2)",
                        nullable: false),

                    UnitPrice = table.Column<decimal>(
                        type: "decimal(18,2)",
                        nullable: false),

                    Discount = table.Column<decimal>(
                        type: "decimal(18,2)",
                        nullable: false),

                    TaxAmount = table.Column<decimal>(
                        type: "decimal(18,2)",
                        nullable: false),

                    TotalAmount = table.Column<decimal>(
                        type: "decimal(18,2)",
                        nullable: false),

                    Pid = table.Column<int>(
                        type: "int",
                        nullable: true),

                    InvoiceXID = table.Column<int>(
                        type: "int",
                        nullable: true),

                    Description = table.Column<string>(
                        type: "nvarchar(1000)",
                        maxLength: 1000,
                        nullable: true),

                    Uom = table.Column<string>(
                        type: "nvarchar(50)",
                        maxLength: 50,
                        nullable: true),

                    QuantityAmount = table.Column<decimal>(
                        type: "decimal(18,2)",
                        nullable: true),

                    InvoiceDiscountType = table.Column<int>(
                        type: "int",
                        nullable: true),

                    InvoiceDiscountValue = table.Column<decimal>(
                        type: "decimal(18,2)",
                        nullable: true),

                    InvoiceDiscountAmount = table.Column<decimal>(
                        type: "decimal(18,2)",
                        nullable: true),

                    TotalRateBeforeDiscount = table.Column<decimal>(
                        type: "decimal(18,2)",
                        nullable: true),

                    Hsncode = table.Column<string>(
                        type: "nvarchar(50)",
                        maxLength: 50,
                        nullable: true),

                    GstPer = table.Column<decimal>(
                        type: "decimal(18,2)",
                        nullable: true),

                    SgstPer = table.Column<decimal>(
                        type: "decimal(18,2)",
                        nullable: true),

                    SgstAmount = table.Column<decimal>(
                        type: "decimal(18,2)",
                        nullable: true),

                    CgstPer = table.Column<decimal>(
                        type: "decimal(18,2)",
                        nullable: true),

                    CgstAmount = table.Column<decimal>(
                        type: "decimal(18,2)",
                        nullable: true),

                    IgstPer = table.Column<decimal>(
                        type: "decimal(18,2)",
                        nullable: true),

                    IgstAmount = table.Column<decimal>(
                        type: "decimal(18,2)",
                        nullable: true),

                    AfterGSTAmount = table.Column<decimal>(
                        type: "decimal(18,2)",
                        nullable: true),

                    TaxType = table.Column<string>(
                        type: "nvarchar(100)",
                        maxLength: 100,
                        nullable: true),

                    MfgDate = table.Column<DateTime>(
                        type: "datetime2",
                        nullable: true),

                    ExpDate = table.Column<DateTime>(
                        type: "datetime2",
                        nullable: true),

                    Cases = table.Column<string>(
                        type: "nvarchar(100)",
                        maxLength: 100,
                        nullable: true),

                    ColorCode = table.Column<string>(
                        type: "nvarchar(100)",
                        maxLength: 100,
                        nullable: true),

                    ColorAmount = table.Column<decimal>(
                        type: "decimal(18,2)",
                        nullable: true),

                    Remarks = table.Column<string>(
                        type: "nvarchar(1000)",
                        maxLength: 1000,
                        nullable: true),

                    ItemXID = table.Column<int>(
                        type: "int",
                        nullable: true),

                    BrandXID = table.Column<int>(
                        type: "int",
                        nullable: true),

                    IsReward = table.Column<bool>(
                        type: "bit",
                        nullable: true),

                    IsAdditionalCharges = table.Column<bool>(
                        type: "bit",
                        nullable: true),

                    MaterialTypeXid = table.Column<int>(
                        type: "int",
                        nullable: true),

                    SpecificationTypeXid = table.Column<int>(
                        type: "int",
                        nullable: true),

                    ProjectAssetDetailXID = table.Column<int>(
                        type: "int",
                        nullable: true),

                    SpecificationTypeDetailName = table.Column<string>(
                        type: "nvarchar(500)",
                        maxLength: 500,
                        nullable: true),

                    IsPurchasing = table.Column<bool>(
                        type: "bit",
                        nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_SalesInvoiceItems",
                        x => x.SalesInvoiceItemId);

                    table.ForeignKey(
                        name: "FK_SalesInvoiceItems_SalesInvoices_SalesInvoiceId",
                        column: x => x.SalesInvoiceId,
                        principalTable: "SalesInvoices",
                        principalColumn: "SalesInvoiceId",
                        onDelete: ReferentialAction.Cascade);

                    table.ForeignKey(
                        name: "FK_SalesInvoiceItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });


            // ============================================================
            // 3. CREATE SalesInvoicePayments
            // ============================================================

            migrationBuilder.CreateTable(
                name: "SalesInvoicePayments",
                columns: table => new
                {
                    SalesInvoicePaymentId = table.Column<int>(
                        type: "int",
                        nullable: false)
                        .Annotation(
                            "SqlServer:Identity",
                            "1, 1"),

                    SalesInvoiceId = table.Column<int>(
                        type: "int",
                        nullable: false),

                    PaymentDate = table.Column<DateTime>(
                        type: "datetime2",
                        nullable: false),

                    PaymentMode = table.Column<string>(
                        type: "nvarchar(100)",
                        maxLength: 100,
                        nullable: true),

                    Amount = table.Column<decimal>(
                        type: "decimal(18,2)",
                        nullable: false),

                    ReferenceNumber = table.Column<string>(
                        type: "nvarchar(200)",
                        maxLength: 200,
                        nullable: true),

                    Remarks = table.Column<string>(
                        type: "nvarchar(1000)",
                        maxLength: 1000,
                        nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_SalesInvoicePayments",
                        x => x.SalesInvoicePaymentId);

                    table.ForeignKey(
                        name: "FK_SalesInvoicePayments_SalesInvoices_SalesInvoiceId",
                        column: x => x.SalesInvoiceId,
                        principalTable: "SalesInvoices",
                        principalColumn: "SalesInvoiceId",
                        onDelete: ReferentialAction.Cascade);
                });


            // ============================================================
            // 4. CREATE SalesInvoiceAdditionalCharges
            // ============================================================

            migrationBuilder.CreateTable(
                name: "SalesInvoiceAdditionalCharges",
                columns: table => new
                {
                    SalesInvoiceAdditionalChargeId =
                        table.Column<int>(
                            type: "int",
                            nullable: false)
                            .Annotation(
                                "SqlServer:Identity",
                                "1, 1"),

                    SalesInvoiceId = table.Column<int>(
                        type: "int",
                        nullable: false),

                    ChargeName = table.Column<string>(
                        type: "nvarchar(200)",
                        maxLength: 200,
                        nullable: false),

                    ChargeType = table.Column<string>(
                        type: "nvarchar(100)",
                        maxLength: 100,
                        nullable: true),

                    Amount = table.Column<decimal>(
                        type: "decimal(18,2)",
                        nullable: false),

                    TaxPercentage = table.Column<decimal>(
                        type: "decimal(18,2)",
                        nullable: false),

                    TaxAmount = table.Column<decimal>(
                        type: "decimal(18,2)",
                        nullable: false),

                    TotalAmount = table.Column<decimal>(
                        type: "decimal(18,2)",
                        nullable: false),

                    Remarks = table.Column<string>(
                        type: "nvarchar(1000)",
                        maxLength: 1000,
                        nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_SalesInvoiceAdditionalCharges",
                        x => x.SalesInvoiceAdditionalChargeId);

                    table.ForeignKey(
                        name: "FK_SalesInvoiceAdditionalCharges_SalesInvoices_SalesInvoiceId",
                        column: x => x.SalesInvoiceId,
                        principalTable: "SalesInvoices",
                        principalColumn: "SalesInvoiceId",
                        onDelete: ReferentialAction.Cascade);
                });


            // ============================================================
            // 5. INDEXES
            // ============================================================

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceItems_SalesInvoiceId",
                table: "SalesInvoiceItems",
                column: "SalesInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceItems_ProductId",
                table: "SalesInvoiceItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoicePayments_SalesInvoiceId",
                table: "SalesInvoicePayments",
                column: "SalesInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoicePayments_PaymentDate",
                table: "SalesInvoicePayments",
                column: "PaymentDate");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceAdditionalCharges_SalesInvoiceId",
                table: "SalesInvoiceAdditionalCharges",
                column: "SalesInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_InvoiceNumber",
                table: "SalesInvoices",
                column: "InvoiceNumber");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_SalesOrderId",
                table: "SalesInvoices",
                column: "SalesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_SellerId",
                table: "SalesInvoices",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_CustomerId",
                table: "SalesInvoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_PaymentStatus",
                table: "SalesInvoices",
                column: "PaymentStatus");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_Status",
                table: "SalesInvoices",
                column: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // ============================================================
            // Remove child tables created by this migration
            // ============================================================

            migrationBuilder.DropTable(
                name: "SalesInvoiceAdditionalCharges");

            migrationBuilder.DropTable(
                name: "SalesInvoiceItems");

            migrationBuilder.DropTable(
                name: "SalesInvoicePayments");


            // ============================================================
            // Remove only columns added by this migration
            // ============================================================

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "MobileNo",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "CompanyAddress",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "CompanyCity",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "CompanyState",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "CompanyPINCode",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "CustomerGSTIN",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "PurchaseOrderNo",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "PurchaseOrderDate",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "OtherReferences",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "DespatchedDocumentNumber",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "StateCode",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "DeliveryNote",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "DeliveryNoteDate",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "EWayBillNumber",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "VehicleNo",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "Distance",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "Transport",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "TransporterName",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "TransporterID",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "TransporterDocNo",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "TransportMode",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "BillOfLandingOrLRRRNo",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "DespatchedThrough",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "ModeOrTermsOfPayment",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "PaymentMode",
                table: "SalesInvoices");
        }
    }
}
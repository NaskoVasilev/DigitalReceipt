using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalReceipt.Data.Migrations
{
    public partial class DatabaseRefactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_AspNetUsers_UserId",
                table: "Receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptProduct_Product_ProductId",
                table: "ReceiptProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptProduct_Receipt_ReceiptId",
                table: "ReceiptProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceiptProduct",
                table: "ReceiptProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receipt",
                table: "Receipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "ReceiptProduct",
                newName: "ReceiptProducts");

            migrationBuilder.RenameTable(
                name: "Receipt",
                newName: "Receipts");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptProduct_ProductId",
                table: "ReceiptProducts",
                newName: "IX_ReceiptProducts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipt_UserId",
                table: "Receipts",
                newName: "IX_Receipts_UserId");

            migrationBuilder.AddColumn<string>(
                name: "CashierName",
                table: "Receipts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClientNumber",
                table: "Receipts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyAddress",
                table: "Receipts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Receipts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FiscalNumber",
                table: "Receipts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdFiscalNumber",
                table: "Receipts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Receipts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StoreAddress",
                table: "Receipts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StoreName",
                table: "Receipts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaxNumber",
                table: "Receipts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UIC",
                table: "Receipts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "Products",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceiptProducts",
                table: "ReceiptProducts",
                columns: new[] { "ReceiptId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receipts",
                table: "Receipts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_CompanyId",
                table: "Receipts",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptProducts_Products_ProductId",
                table: "ReceiptProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptProducts_Receipts_ReceiptId",
                table: "ReceiptProducts",
                column: "ReceiptId",
                principalTable: "Receipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Companies_CompanyId",
                table: "Receipts",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_AspNetUsers_UserId",
                table: "Receipts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptProducts_Products_ProductId",
                table: "ReceiptProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptProducts_Receipts_ReceiptId",
                table: "ReceiptProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Companies_CompanyId",
                table: "Receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_AspNetUsers_UserId",
                table: "Receipts");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receipts",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_CompanyId",
                table: "Receipts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceiptProducts",
                table: "ReceiptProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CashierName",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "ClientNumber",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "CompanyAddress",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "FiscalNumber",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "IdFiscalNumber",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "StoreAddress",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "StoreName",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "TaxNumber",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "UIC",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Receipts",
                newName: "Receipt");

            migrationBuilder.RenameTable(
                name: "ReceiptProducts",
                newName: "ReceiptProduct");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_UserId",
                table: "Receipt",
                newName: "IX_Receipt_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptProducts_ProductId",
                table: "ReceiptProduct",
                newName: "IX_ReceiptProduct_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receipt",
                table: "Receipt",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceiptProduct",
                table: "ReceiptProduct",
                columns: new[] { "ReceiptId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_AspNetUsers_UserId",
                table: "Receipt",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptProduct_Product_ProductId",
                table: "ReceiptProduct",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptProduct_Receipt_ReceiptId",
                table: "ReceiptProduct",
                column: "ReceiptId",
                principalTable: "Receipt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

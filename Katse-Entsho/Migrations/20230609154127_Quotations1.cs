using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Katse_Entsho.Migrations
{
    public partial class Quotations1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryCatID",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierSuppID",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(maxLength: 30, nullable: false),
                    CompanyEmail = table.Column<string>(maxLength: 30, nullable: false),
                    CompanyContactNumber = table.Column<int>(maxLength: 10, nullable: false),
                    AddressLine1 = table.Column<string>(maxLength: 30, nullable: false),
                    AddressLine2 = table.Column<string>(maxLength: 30, nullable: false),
                    ProvinceID = table.Column<int>(nullable: false),
                    CityID = table.Column<int>(nullable: false),
                    SuburbID = table.Column<int>(nullable: false),
                    SuburbID1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyID);
                    table.ForeignKey(
                        name: "FK_Companies_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Companies_Provinces_ProvinceID",
                        column: x => x.ProvinceID,
                        principalTable: "Provinces",
                        principalColumn: "ProvinceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Companies_Suburbs_SuburbID1",
                        column: x => x.SuburbID1,
                        principalTable: "Suburbs",
                        principalColumn: "SuburbID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Quote_Links",
                columns: table => new
                {
                    Quote_LinkID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quote_Links", x => x.Quote_LinkID);
                    table.ForeignKey(
                        name: "FK_Quote_Links_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Request_Links",
                columns: table => new
                {
                    Request_LinkID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request_Links", x => x.Request_LinkID);
                    table.ForeignKey(
                        name: "FK_Request_Links_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Request_Quotes",
                columns: table => new
                {
                    RequestID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Request_LinkID = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    CustomerUserID = table.Column<int>(nullable: true),
                    ProductID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request_Quotes", x => x.RequestID);
                    table.ForeignKey(
                        name: "FK_Request_Quotes_Customers_CustomerUserID",
                        column: x => x.CustomerUserID,
                        principalTable: "Customers",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Request_Quotes_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    QuoteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestID = table.Column<int>(nullable: false),
                    CompanyID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    CustomerUserID = table.Column<int>(nullable: true),
                    QuoteDate = table.Column<DateTime>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    Quote_LinkID = table.Column<int>(nullable: false),
                    SubTotal = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.QuoteID);
                    table.ForeignKey(
                        name: "FK_Quotes_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Quotes_Customers_CustomerUserID",
                        column: x => x.CustomerUserID,
                        principalTable: "Customers",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quotes_Quote_Links_Quote_LinkID",
                        column: x => x.Quote_LinkID,
                        principalTable: "Quote_Links",
                        principalColumn: "Quote_LinkID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryCatID",
                table: "Products",
                column: "CategoryCatID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierSuppID",
                table: "Products",
                column: "SupplierSuppID");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CityID",
                table: "Companies",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ProvinceID",
                table: "Companies",
                column: "ProvinceID");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_SuburbID1",
                table: "Companies",
                column: "SuburbID1");

            migrationBuilder.CreateIndex(
                name: "IX_Quote_Links_ProductID",
                table: "Quote_Links",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_CompanyID",
                table: "Quotes",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_CustomerUserID",
                table: "Quotes",
                column: "CustomerUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_Quote_LinkID",
                table: "Quotes",
                column: "Quote_LinkID");

            migrationBuilder.CreateIndex(
                name: "IX_Request_Links_ProductID",
                table: "Request_Links",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Request_Quotes_CustomerUserID",
                table: "Request_Quotes",
                column: "CustomerUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Request_Quotes_ProductID",
                table: "Request_Quotes",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryCatID",
                table: "Products",
                column: "CategoryCatID",
                principalTable: "Categories",
                principalColumn: "CatID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Suppliers_SupplierSuppID",
                table: "Products",
                column: "SupplierSuppID",
                principalTable: "Suppliers",
                principalColumn: "SuppID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryCatID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_SupplierSuppID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "Request_Links");

            migrationBuilder.DropTable(
                name: "Request_Quotes");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Quote_Links");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryCatID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SupplierSuppID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryCatID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SupplierSuppID",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}

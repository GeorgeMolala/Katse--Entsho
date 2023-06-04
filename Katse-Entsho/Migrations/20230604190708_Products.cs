using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Katse_Entsho.Migrations
{
    public partial class Products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SuppID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(maxLength: 30, nullable: false),
                    ContactNumber = table.Column<int>(maxLength: 10, nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: false),
                    AddressLine1 = table.Column<string>(maxLength: 30, nullable: false),
                    AddressLine2 = table.Column<string>(maxLength: 30, nullable: false),
                    ProvinceID = table.Column<int>(nullable: false),
                    CityID = table.Column<int>(nullable: false),
                    SuburbID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SuppID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarCode = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ImageData = table.Column<byte[]>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    SuppID = table.Column<int>(nullable: false),
                    SupplierSuppID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierSuppID",
                        column: x => x.SupplierSuppID,
                        principalTable: "Suppliers",
                        principalColumn: "SuppID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suburbs_CityID",
                table: "Suburbs",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceID",
                table: "Cities",
                column: "ProvinceID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierSuppID",
                table: "Products",
                column: "SupplierSuppID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Provinces_ProvinceID",
                table: "Cities",
                column: "ProvinceID",
                principalTable: "Provinces",
                principalColumn: "ProvinceID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Suburbs_Cities_CityID",
                table: "Suburbs",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Provinces_ProvinceID",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Suburbs_Cities_CityID",
                table: "Suburbs");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suburbs_CityID",
                table: "Suburbs");

            migrationBuilder.DropIndex(
                name: "IX_Cities_ProvinceID",
                table: "Cities");
        }
    }
}

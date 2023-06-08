using Microsoft.EntityFrameworkCore.Migrations;

namespace Katse_Entsho.Migrations
{
    public partial class ImageUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryCatID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_SupplierSuppID",
                table: "Products");

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
                name: "Name",
                table: "Products",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "CategoryCatID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierSuppID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryCatID",
                table: "Products",
                column: "CategoryCatID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierSuppID",
                table: "Products",
                column: "SupplierSuppID");

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
    }
}

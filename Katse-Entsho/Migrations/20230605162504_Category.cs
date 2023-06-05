using Microsoft.EntityFrameworkCore.Migrations;

namespace Katse_Entsho.Migrations
{
    public partial class Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatID",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryCatID",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CatID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CatID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryCatID",
                table: "Products",
                column: "CategoryCatID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryCatID",
                table: "Products",
                column: "CategoryCatID",
                principalTable: "Categories",
                principalColumn: "CatID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryCatID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryCatID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CatID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryCatID",
                table: "Products");
        }
    }
}

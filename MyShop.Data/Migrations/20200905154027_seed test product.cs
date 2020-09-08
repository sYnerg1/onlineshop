using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.Data.Migrations
{
    public partial class seedtestproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItems_Products_ProductId",
                table: "ShopCartItems");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ShopCartItems",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Name", "Price" },
                values: new object[] { 1, null, null, "Test", 0m });

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItems_Products_ProductId",
                table: "ShopCartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItems_Products_ProductId",
                table: "ShopCartItems");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ShopCartItems",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItems_Products_ProductId",
                table: "ShopCartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

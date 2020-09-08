using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.Data.Migrations
{
    public partial class OrderUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItems_Products_ProductId",
                table: "ShopCartItems");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ShopCartItems",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItems_Products_ProductId",
                table: "ShopCartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItems_Products_ProductId",
                table: "ShopCartItems");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ShopCartItems",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItems_Products_ProductId",
                table: "ShopCartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

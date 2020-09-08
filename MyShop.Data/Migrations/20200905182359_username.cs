using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.Data.Migrations
{
    public partial class username : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_ShopUserName",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShopUserName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShopUserName",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "ShopUserId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShopUserId",
                table: "Orders",
                column: "ShopUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_ShopUserId",
                table: "Orders",
                column: "ShopUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_ShopUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShopUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShopUserId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "ShopUserName",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShopUserName",
                table: "Orders",
                column: "ShopUserName");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_ShopUserName",
                table: "Orders",
                column: "ShopUserName",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

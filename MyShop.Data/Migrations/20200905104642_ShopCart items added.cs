using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MyShop.Data.Migrations
{
    public partial class ShopCartitemsadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ShopCarts_ShopCartId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ShopCartId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "ShopCartId",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ShopCartItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quantity = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ShopCartId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopCartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopCartItems_ShopCarts_ShopCartId",
                        column: x => x.ShopCartId,
                        principalTable: "ShopCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ShopCartId",
                table: "AspNetUsers",
                column: "ShopCartId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShopCartItems_ProductId",
                table: "ShopCartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopCartItems_ShopCartId",
                table: "ShopCartItems",
                column: "ShopCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ShopCarts_ShopCartId",
                table: "AspNetUsers",
                column: "ShopCartId",
                principalTable: "ShopCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ShopCarts_ShopCartId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ShopCartItems");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ShopCartId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "ShopCartId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Name", "Price" },
                values: new object[] { 1, null, null, "Test", 0m });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ShopCartId",
                table: "AspNetUsers",
                column: "ShopCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ShopCarts_ShopCartId",
                table: "AspNetUsers",
                column: "ShopCartId",
                principalTable: "ShopCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

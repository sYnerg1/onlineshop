using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.Data.Migrations
{
    public partial class Usersseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "admin-role-id", "8fe9e775-d5ff-4a07-a4fb-ae32013cb606", "Admin", "ADMIN" },
                    { "golduser-role-id", "871d0127-f973-473f-8017-851ac5cea6d1", "GoldUser", "GOLDSER" }
                });

            migrationBuilder.InsertData(
                table: "ShopCarts",
                columns: new[] { "Id", "TotalCost" },
                values: new object[,]
                {
                    { 33, 0m },
                    { 34, 0m }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ShopCartId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "admin-id", 10, "35a4af18-fef4-4214-9bc1-815ed2ddc792", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEM9a6sVPh4xbmqpm+nRJkU73acddJ/7DgO8nDx7Jw2oB3Aj77Qkyh5NbGGCS9U8m4Q==", null, false, "9d6ee28e-0130-4c32-9bd3-9fcd9e5aa2f3", 33, false, "admin" },
                    { "golduser-id", 10, "316e937f-42ea-45ef-9131-085a2804c8f4", null, false, false, null, null, "GOLDUSER", "AQAAAAEAACcQAAAAENgxtYzFg8Lz1pkCkpEVHabTrnlDvp5e04RBSn4rIbYFUpciU9kqHXL5yKZJZhtJcw==", null, false, "43297686-0e08-465b-a445-7062d4e78d20", 34, false, "golduser" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "admin-id", "admin-role-id" },
                    { "golduser-id", "golduser-role-id" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "admin-id", "admin-role-id" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "golduser-id", "golduser-role-id" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin-role-id");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "golduser-role-id");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "golduser-id");

            migrationBuilder.DeleteData(
                table: "ShopCarts",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ShopCarts",
                keyColumn: "Id",
                keyValue: 34);
        }
    }
}

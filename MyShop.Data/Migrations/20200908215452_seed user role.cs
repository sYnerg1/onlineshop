using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.Data.Migrations
{
    public partial class seeduserrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin-role-id",
                column: "ConcurrencyStamp",
                value: "55cbe012-cc18-4f0f-9318-b3ec627050bd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "golduser-role-id",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "d0eda029-af34-4bc0-bbda-1673bf39aa82", "GOLDUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "user-role-id", "a5935da6-1f00-4a9d-b88a-ee6d58279d9b", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0dcb9d45-9238-4a88-85b4-10535d160850", "AQAAAAEAACcQAAAAELCEBSTplGXtg4t1RrAt413Udx7yhZwhhfqsrQrn3CFftKfH7DXP1nZTlURm1I3+Xw==", "482fbcd4-f034-4b28-9a7b-d5acd9f3f082" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "golduser-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d812eda2-9311-4d69-a579-747f3b0a231d", "AQAAAAEAACcQAAAAEPZuLhXDUzS82zwfT5/Aj2UKe1vf/jZcWtzjgX4+jIKrTf5/18BFOeCOCIml3sqkiw==", "6776adcd-3869-4f31-a126-0c316c7173d0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user-role-id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin-role-id",
                column: "ConcurrencyStamp",
                value: "8fe9e775-d5ff-4a07-a4fb-ae32013cb606");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "golduser-role-id",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "871d0127-f973-473f-8017-851ac5cea6d1", "GOLDSER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35a4af18-fef4-4214-9bc1-815ed2ddc792", "AQAAAAEAACcQAAAAEM9a6sVPh4xbmqpm+nRJkU73acddJ/7DgO8nDx7Jw2oB3Aj77Qkyh5NbGGCS9U8m4Q==", "9d6ee28e-0130-4c32-9bd3-9fcd9e5aa2f3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "golduser-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "316e937f-42ea-45ef-9131-085a2804c8f4", "AQAAAAEAACcQAAAAENgxtYzFg8Lz1pkCkpEVHabTrnlDvp5e04RBSn4rIbYFUpciU9kqHXL5yKZJZhtJcw==", "43297686-0e08-465b-a445-7062d4e78d20" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.Data.Migrations
{
    public partial class seedproducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin-role-id",
                column: "ConcurrencyStamp",
                value: "87c8c605-5f8f-49b3-9819-155dc14312ae");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "golduser-role-id",
                column: "ConcurrencyStamp",
                value: "fe35c736-f66f-4a43-b8a0-4d72d8a24fd6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user-role-id",
                column: "ConcurrencyStamp",
                value: "6492738a-fbdd-445b-a436-0bdfcc8b0c0f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf2f59a0-58aa-492d-a243-0ba0726bf791", "AQAAAAEAACcQAAAAEOihzc/DbMbuSqcnJexJ4g/+ltnCJ7/BlwtE7BtqnXqhPReLSzjEKkStC46Xi1JOYQ==", "819cb1aa-46b8-43ec-8d10-3b659c018f88" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "golduser-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6586837-49d1-4de6-bb63-47bc5238c2dc", "AQAAAAEAACcQAAAAEL9zvceNHiYv/HXgRNSR6SI+Tn9Q7U6Yp9C6nSsEZRW1XxdVEazxorflMcYyLrlYng==", "d1b9656e-317e-445b-a617-5e760ad7e606" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Amount", "Name", "Price" },
                values: new object[] { 24, "Meat", 12.3m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Amount", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 2, 24, null, null, "Water", 4.5m },
                    { 3, 24, null, null, "Bread", 9m },
                    { 4, 24, null, null, "Cake", 2.41m },
                    { 5, 2, null, null, "Bottle", 31.3m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

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
                column: "ConcurrencyStamp",
                value: "d0eda029-af34-4bc0-bbda-1673bf39aa82");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user-role-id",
                column: "ConcurrencyStamp",
                value: "a5935da6-1f00-4a9d-b88a-ee6d58279d9b");

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

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Amount", "Name", "Price" },
                values: new object[] { 0, "Test", 0m });
        }
    }
}

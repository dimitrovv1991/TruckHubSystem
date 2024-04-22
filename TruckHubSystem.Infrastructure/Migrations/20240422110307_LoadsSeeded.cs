using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckHubSystem.Infrastructure.Migrations
{
    public partial class LoadsSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b893d8395280-jf28-6532-c198-kiu12856",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1cace751-1df3-4fcf-985c-c4593b1f0021", "AQAAAAEAACcQAAAAEAQ/rdQ/cUKUqPYEKREAQJE9GLY+t9xslHuK8y1FWzMXs6kUPZzamxlZHZEbjL6hTQ==", "c6b5e3bd-728d-450c-9f26-5d8400297726" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "kiu12856-c198-6532-jf28-b893d8395280",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c2c49e1-5811-4fe2-a94c-4e0dc56252f6", "AQAAAAEAACcQAAAAENLn0D2xEP4NSSQKLKvPAsbxARxkc9FrDp1Bfx3RmOrKZeXXKjM9J/rGM7fszsOg6A==", "5d284875-6225-43b7-8b6c-2e489957dc1e" });

            migrationBuilder.InsertData(
                table: "Loads",
                columns: new[] { "Id", "FactoryId", "IsLoadAvailable", "LoadCategoryId", "Name", "Weigth" },
                values: new object[,]
                {
                    { 1, 1, true, 5, "Detergents", 12000 },
                    { 2, 1, true, 5, "Detergents", 19000 },
                    { 3, 2, true, 8, "Machines", 7000 },
                    { 4, 3, true, 1, "Plastics", 22000 },
                    { 5, 3, true, 5, "Plastics", 21000 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Loads",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Loads",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Loads",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Loads",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Loads",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b893d8395280-jf28-6532-c198-kiu12856",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e78d714d-939c-45ad-baac-d9267b633c25", "AQAAAAEAACcQAAAAED5YDlGOZkJC3te9OYVWUkw2bDOsSXXlXbgGLlrfv6RPXrTVqy8mVNUTnNrA+awjgA==", "9c61678c-b23a-4f97-be7a-feb59d0617cb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "kiu12856-c198-6532-jf28-b893d8395280",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e7fcdaf-6ba2-4fd4-8543-e17490743914", "AQAAAAEAACcQAAAAEBLofUUFhg0L5Jie7JXyDWxOKRPqHQlPLyy2/ZP8hVi3mo1yMjPoLpV16pZ/BGpQ4Q==", "0c4a5d9f-523e-4900-a9d6-e1f073165533" });
        }
    }
}

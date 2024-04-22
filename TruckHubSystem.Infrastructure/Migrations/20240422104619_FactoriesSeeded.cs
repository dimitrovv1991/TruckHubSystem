using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckHubSystem.Infrastructure.Migrations
{
    public partial class FactoriesSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Factories",
                columns: new[] { "Id", "CreatorId", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "kiu12856-c198-6532-jf28-b893d8395280", "Shumen", "Ficosotta" },
                    { 2, "kiu12856-c198-6532-jf28-b893d8395280", "Ruse", "Husqvarna" },
                    { 3, "b893d8395280-jf28-6532-c198-kiu12856", "Varna", "Plastchim" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Factories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Factories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Factories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b893d8395280-jf28-6532-c198-kiu12856",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fcf42c03-7cb2-4666-8455-cbe09c20dc57", "AQAAAAEAACcQAAAAEHj7XYH93jicRo8i5qEPBVcoAMiuXBvh3mRAt01u0HXGSDcsDhXVHL6oISqIv32lew==", "d85be189-053a-4a5a-93d1-0c6dd703908d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "kiu12856-c198-6532-jf28-b893d8395280",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de0d5234-bb26-4e0a-88a8-5bc7ebe45fba", "AQAAAAEAACcQAAAAEFXKUOS+kydBZv3u8MgiHxh8Z2qfUoEIW+UzYx/foEHMttRyKE0ZJjezyy9bb4il0w==", "f7515f99-aedd-4f0e-af4b-637fd060a462" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckHubSystem.Infrastructure.Migrations
{
    public partial class CurrentLoadsSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b893d8395280-jf28-6532-c198-kiu12856",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b7d3339-1c97-4c0b-90b9-effe28ce54be", "AQAAAAEAACcQAAAAEPPktPd6zlmv4SsscAs7pRX5HE1Pe92xcDkM3yFO8vW81jrtQ4epld/ag6K3sZFG+w==", "dd54405c-b802-4187-a1ad-e68451781288" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "kiu12856-c198-6532-jf28-b893d8395280",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b87dc457-5f32-4ceb-99ec-64f29da30a11", "AQAAAAEAACcQAAAAELRsWZ8pzLiUCtkOd/SiMD20i3/02G/PP+AxZAuubLFI1TuXKP9NDG6rPuQ5nOuZuw==", "79649552-ecee-41c2-b1e1-5ad62c7ba850" });

            migrationBuilder.InsertData(
                table: "CurrentLoads",
                columns: new[] { "Id", "FactoryId", "LoadId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 3 },
                    { 4, 3, 4 },
                    { 5, 3, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CurrentLoads",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CurrentLoads",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CurrentLoads",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CurrentLoads",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CurrentLoads",
                keyColumn: "Id",
                keyValue: 5);

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
        }
    }
}

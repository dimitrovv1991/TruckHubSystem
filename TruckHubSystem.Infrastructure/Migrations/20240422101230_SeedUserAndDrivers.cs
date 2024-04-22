using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckHubSystem.Infrastructure.Migrations
{
    public partial class SeedUserAndDrivers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "kiu12856-c198-6532-jf28-b893d8395280",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83a48823-86f4-4c17-9735-e0a5778b8f66", "AQAAAAEAACcQAAAAEEdVEW9AR6N38GVfSHI50cRfZOjh2kZkOYoORIr+GFvBjoHlD8JC/jvWMI6hNZP1Yw==", "790a204a-e8eb-40c5-ba89-07959054fc51" });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "FamilyName", "FirstName", "IsDriverAvailable", "PhoneNumber", "YearDrivingLicenseAcquired" },
                values: new object[,]
                {
                    { 1, "Georgiev", "Georgi", true, "0883442233", 2002 },
                    { 2, "Ivanov", "Ivan", true, "0883445566", 2005 },
                    { 3, "Petrov", "Petar", true, "0883447788", 2010 },
                    { 4, "Stefanov", "Stefan", true, "0883449900", 2015 },
                    { 5, "Vasilev", "Vasil", true, "0883441122", 2020 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "kiu12856-c198-6532-jf28-b893d8395280",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d146a3ec-ede3-4c26-b286-9114472138c6", "AQAAAAEAACcQAAAAEDaFHbvxMBaWJ3OLZlCvfxkEaoOgxQ/cZE+M8TcHaTZmhPdc0tyqaIrGi88q+VMsaQ==", "7c25cb6b-ab1a-4eee-836f-be9c803dc968" });
        }
    }
}

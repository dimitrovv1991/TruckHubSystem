using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckHubSystem.Infrastructure.Migrations
{
    public partial class SeedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "kiu12856-c198-6532-jf28-b893d8395280", 0, "d146a3ec-ede3-4c26-b286-9114472138c6", "guest@gmail.com", false, false, null, "guest@gmail.com", "guest@gmail.com", "AQAAAAEAACcQAAAAEDaFHbvxMBaWJ3OLZlCvfxkEaoOgxQ/cZE+M8TcHaTZmhPdc0tyqaIrGi88q+VMsaQ==", null, false, "7c25cb6b-ab1a-4eee-836f-be9c803dc968", false, "guest@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "kiu12856-c198-6532-jf28-b893d8395280");
        }
    }
}

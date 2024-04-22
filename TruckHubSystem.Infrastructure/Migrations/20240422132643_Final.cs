using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckHubSystem.Infrastructure.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b893d8395280-jf28-6532-c198-kiu12856",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0758420-1a85-494c-b9fc-0a7e7551e490", "AQAAAAEAACcQAAAAEJ5g3+PTmbKGMvSZ1sAjVdHONi869FKQdR7hwW5aKefjff0ptoCBEqKQAEq/S8KVqg==", "9e36ba1e-1729-4865-9603-639c926f6ac2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "kiu12856-c198-6532-jf28-b893d8395280",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14ea73a4-025f-49a1-a518-b5ac8801843d", "AQAAAAEAACcQAAAAEDounOQFWNMWfr/yCfvE8IeD329WIepmm3vhWnbOBhB+Nj0oWKjoh/6pq73afogjrQ==", "63ea9736-4de1-4e44-adcc-353f11576faa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b893d8395280-jf28-6532-c198-kiu12856",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "305198b8-49cf-4e6c-809c-ec0022d62998", "AQAAAAEAACcQAAAAENH9OQEn7jNKWZ1ViGmhmNfVSjl0mdDeNUCuFb0rOcuTHasQF4+rPifdzJCQrPyG9g==", "58be6672-d86c-43f9-987c-e0ce88351083" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "kiu12856-c198-6532-jf28-b893d8395280",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "acaf92cf-9a14-4b6f-b429-e1e8bc7bb666", "AQAAAAEAACcQAAAAEJumIQTgtZSFhu0Cm6KLtdb5wFlOCbarzQ83bjFteYtz4cLe4FGU+LcT7QyLDf6Oag==", "8b883230-f648-4857-97a6-3c7bb75a2ee7" });
        }
    }
}

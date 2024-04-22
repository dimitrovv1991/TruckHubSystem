using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckHubSystem.Infrastructure.Migrations
{
    public partial class SecondUserAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "kiu12856-c198-6532-jf28-b893d8395280",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de0d5234-bb26-4e0a-88a8-5bc7ebe45fba", "AQAAAAEAACcQAAAAEFXKUOS+kydBZv3u8MgiHxh8Z2qfUoEIW+UzYx/foEHMttRyKE0ZJjezyy9bb4il0w==", "f7515f99-aedd-4f0e-af4b-637fd060a462" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b893d8395280-jf28-6532-c198-kiu12856", 0, "fcf42c03-7cb2-4666-8455-cbe09c20dc57", "guest2@gmail.com", false, false, null, "guest2@gmail.com", "guest2@gmail.com", "AQAAAAEAACcQAAAAEHj7XYH93jicRo8i5qEPBVcoAMiuXBvh3mRAt01u0HXGSDcsDhXVHL6oISqIv32lew==", null, false, "d85be189-053a-4a5a-93d1-0c6dd703908d", false, "guest2@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b893d8395280-jf28-6532-c198-kiu12856");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "kiu12856-c198-6532-jf28-b893d8395280",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3a7069e-ba5d-4809-9230-6e0b31c4832d", "AQAAAAEAACcQAAAAENQvqpJY2aRR9BcnzGQowCuC8KdCjZaMXYvpeMELl4NmWES/Zv1c+djQcbYBglhpOg==", "744e4c27-18e9-46c8-b821-7c81aacc624e" });
        }
    }
}

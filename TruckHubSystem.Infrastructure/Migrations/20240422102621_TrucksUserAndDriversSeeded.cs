using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckHubSystem.Infrastructure.Migrations
{
    public partial class TrucksUserAndDriversSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "kiu12856-c198-6532-jf28-b893d8395280",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3a7069e-ba5d-4809-9230-6e0b31c4832d", "AQAAAAEAACcQAAAAENQvqpJY2aRR9BcnzGQowCuC8KdCjZaMXYvpeMELl4NmWES/Zv1c+djQcbYBglhpOg==", "744e4c27-18e9-46c8-b821-7c81aacc624e" });

            migrationBuilder.InsertData(
                table: "Trucks",
                columns: new[] { "Id", "Available", "CapacityKg", "ImageUrl", "LicensePlate", "Manufacturer", "Model", "YearManufactured" },
                values: new object[,]
                {
                    { 1, true, 14000, "https://content.presspage.com/uploads/2678/6a533810-4bd3-4c85-b7cc-cefe06c5ef1c/1920_njitransport-5.jpg", "P7777PP", "Man", "TGX", 2021 },
                    { 2, true, 15000, "https://autobild.bg/wp-content/uploads/2020/09/Actros-Edition-2-3.jpg", "C1234CC", "Mercedes-Benz", "Actros", 2022 },
                    { 3, true, 13000, "http://www.autoconsulting.com.ua/pictures/others/2019/Volvo_FH_iSave_01.jpg", "PB5678BB", "Volvo", "FH", 2020 },
                    { 4, true, 12000, "https://autobild.bg/wp-content/uploads/2021/11/DAF-XF-Hydrogen_Truck-Innovation-Award.jpg", "B9999BB", "DAF", "XF", 2019 },
                    { 5, true, 13500, "https://img.carswp.com/scania/r-series/scania_r-series_2014_images_1.jpg", "A1111AA", "Scania", "R Series", 2021 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "kiu12856-c198-6532-jf28-b893d8395280",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83a48823-86f4-4c17-9735-e0a5778b8f66", "AQAAAAEAACcQAAAAEEdVEW9AR6N38GVfSHI50cRfZOjh2kZkOYoORIr+GFvBjoHlD8JC/jvWMI6hNZP1Yw==", "790a204a-e8eb-40c5-ba89-07959054fc51" });
        }
    }
}

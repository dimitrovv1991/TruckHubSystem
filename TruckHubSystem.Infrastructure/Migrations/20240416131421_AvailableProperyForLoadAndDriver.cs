using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckHubSystem.Infrastructure.Migrations
{
    public partial class AvailableProperyForLoadAndDriver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLoadAvailable",
                table: "Loads",
                type: "bit",
                nullable: false,
                defaultValue: true,
                comment: "Is load available");

            migrationBuilder.AddColumn<bool>(
                name: "IsDriverAvailable",
                table: "Drivers",
                type: "bit",
                nullable: false,
                defaultValue: true,
                comment: "Is driver available");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLoadAvailable",
                table: "Loads");

            migrationBuilder.DropColumn(
                name: "IsDriverAvailable",
                table: "Drivers");
        }
    }
}

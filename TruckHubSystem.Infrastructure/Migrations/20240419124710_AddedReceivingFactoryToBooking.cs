using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckHubSystem.Infrastructure.Migrations
{
    public partial class AddedReceivingFactoryToBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceivingFactoryId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Receiving factory identifier");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ReceivingFactoryId",
                table: "Bookings",
                column: "ReceivingFactoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Factories_ReceivingFactoryId",
                table: "Bookings",
                column: "ReceivingFactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Factories_ReceivingFactoryId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ReceivingFactoryId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ReceivingFactoryId",
                table: "Bookings");
        }
    }
}

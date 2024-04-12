using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckHubSystem.Infrastructure.Migrations
{
    public partial class LoadModelChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loads_Factories_LoadingFactoryId",
                table: "Loads");

            migrationBuilder.DropForeignKey(
                name: "FK_Loads_Factories_UnloadingFactoryId",
                table: "Loads");

            migrationBuilder.DropIndex(
                name: "IX_Loads_LoadingFactoryId",
                table: "Loads");

            migrationBuilder.DropColumn(
                name: "DestinationCity",
                table: "Loads");

            migrationBuilder.DropColumn(
                name: "DistanceInKm",
                table: "Loads");

            migrationBuilder.DropColumn(
                name: "LoadingCity",
                table: "Loads");

            migrationBuilder.DropColumn(
                name: "LoadingFactoryId",
                table: "Loads");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Loads");

            migrationBuilder.RenameColumn(
                name: "UnloadingFactoryId",
                table: "Loads",
                newName: "FactoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Loads_UnloadingFactoryId",
                table: "Loads",
                newName: "IX_Loads_FactoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loads_Factories_FactoryId",
                table: "Loads",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loads_Factories_FactoryId",
                table: "Loads");

            migrationBuilder.RenameColumn(
                name: "FactoryId",
                table: "Loads",
                newName: "UnloadingFactoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Loads_FactoryId",
                table: "Loads",
                newName: "IX_Loads_UnloadingFactoryId");

            migrationBuilder.AddColumn<string>(
                name: "DestinationCity",
                table: "Loads",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "City of unloading the goods");

            migrationBuilder.AddColumn<int>(
                name: "DistanceInKm",
                table: "Loads",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Distance between the cities");

            migrationBuilder.AddColumn<string>(
                name: "LoadingCity",
                table: "Loads",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "City of loading the goods");

            migrationBuilder.AddColumn<int>(
                name: "LoadingFactoryId",
                table: "Loads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Loads",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Load price");

            migrationBuilder.CreateIndex(
                name: "IX_Loads_LoadingFactoryId",
                table: "Loads",
                column: "LoadingFactoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loads_Factories_LoadingFactoryId",
                table: "Loads",
                column: "LoadingFactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Loads_Factories_UnloadingFactoryId",
                table: "Loads",
                column: "UnloadingFactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

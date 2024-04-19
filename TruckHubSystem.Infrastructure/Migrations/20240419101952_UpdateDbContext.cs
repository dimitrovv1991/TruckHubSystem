using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckHubSystem.Infrastructure.Migrations
{
    public partial class UpdateDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrentLoad_Factories_FactoryId",
                table: "CurrentLoad");

            migrationBuilder.DropForeignKey(
                name: "FK_CurrentLoad_Loads_LoadId",
                table: "CurrentLoad");

            migrationBuilder.DropForeignKey(
                name: "FK_LoadReceived_Factories_FactoryId",
                table: "LoadReceived");

            migrationBuilder.DropForeignKey(
                name: "FK_LoadReceived_Loads_LoadId",
                table: "LoadReceived");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoadReceived",
                table: "LoadReceived");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CurrentLoad",
                table: "CurrentLoad");

            migrationBuilder.RenameTable(
                name: "LoadReceived",
                newName: "LoadsReceived");

            migrationBuilder.RenameTable(
                name: "CurrentLoad",
                newName: "CurrentLoads");

            migrationBuilder.RenameIndex(
                name: "IX_LoadReceived_LoadId",
                table: "LoadsReceived",
                newName: "IX_LoadsReceived_LoadId");

            migrationBuilder.RenameIndex(
                name: "IX_LoadReceived_FactoryId",
                table: "LoadsReceived",
                newName: "IX_LoadsReceived_FactoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CurrentLoad_LoadId",
                table: "CurrentLoads",
                newName: "IX_CurrentLoads_LoadId");

            migrationBuilder.RenameIndex(
                name: "IX_CurrentLoad_FactoryId",
                table: "CurrentLoads",
                newName: "IX_CurrentLoads_FactoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoadsReceived",
                table: "LoadsReceived",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CurrentLoads",
                table: "CurrentLoads",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrentLoads_Factories_FactoryId",
                table: "CurrentLoads",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CurrentLoads_Loads_LoadId",
                table: "CurrentLoads",
                column: "LoadId",
                principalTable: "Loads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoadsReceived_Factories_FactoryId",
                table: "LoadsReceived",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoadsReceived_Loads_LoadId",
                table: "LoadsReceived",
                column: "LoadId",
                principalTable: "Loads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrentLoads_Factories_FactoryId",
                table: "CurrentLoads");

            migrationBuilder.DropForeignKey(
                name: "FK_CurrentLoads_Loads_LoadId",
                table: "CurrentLoads");

            migrationBuilder.DropForeignKey(
                name: "FK_LoadsReceived_Factories_FactoryId",
                table: "LoadsReceived");

            migrationBuilder.DropForeignKey(
                name: "FK_LoadsReceived_Loads_LoadId",
                table: "LoadsReceived");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoadsReceived",
                table: "LoadsReceived");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CurrentLoads",
                table: "CurrentLoads");

            migrationBuilder.RenameTable(
                name: "LoadsReceived",
                newName: "LoadReceived");

            migrationBuilder.RenameTable(
                name: "CurrentLoads",
                newName: "CurrentLoad");

            migrationBuilder.RenameIndex(
                name: "IX_LoadsReceived_LoadId",
                table: "LoadReceived",
                newName: "IX_LoadReceived_LoadId");

            migrationBuilder.RenameIndex(
                name: "IX_LoadsReceived_FactoryId",
                table: "LoadReceived",
                newName: "IX_LoadReceived_FactoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CurrentLoads_LoadId",
                table: "CurrentLoad",
                newName: "IX_CurrentLoad_LoadId");

            migrationBuilder.RenameIndex(
                name: "IX_CurrentLoads_FactoryId",
                table: "CurrentLoad",
                newName: "IX_CurrentLoad_FactoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoadReceived",
                table: "LoadReceived",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CurrentLoad",
                table: "CurrentLoad",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrentLoad_Factories_FactoryId",
                table: "CurrentLoad",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CurrentLoad_Loads_LoadId",
                table: "CurrentLoad",
                column: "LoadId",
                principalTable: "Loads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoadReceived_Factories_FactoryId",
                table: "LoadReceived",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoadReceived_Loads_LoadId",
                table: "LoadReceived",
                column: "LoadId",
                principalTable: "Loads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

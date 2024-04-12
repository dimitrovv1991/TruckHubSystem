using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckHubSystem.Infrastructure.Migrations
{
    public partial class newest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoadReceived_Factories_FactoryId",
                table: "LoadReceived");

            migrationBuilder.DropForeignKey(
                name: "FK_LoadReceived_Loads_LoadId",
                table: "LoadReceived");

            migrationBuilder.DropForeignKey(
                name: "FK_LoadSent_Factories_FactoryId",
                table: "LoadSent");

            migrationBuilder.DropForeignKey(
                name: "FK_LoadSent_Loads_LoadId",
                table: "LoadSent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoadSent",
                table: "LoadSent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoadReceived",
                table: "LoadReceived");

            migrationBuilder.RenameTable(
                name: "LoadSent",
                newName: "LoadsSent");

            migrationBuilder.RenameTable(
                name: "LoadReceived",
                newName: "LoadsReceived");

            migrationBuilder.RenameIndex(
                name: "IX_LoadSent_LoadId",
                table: "LoadsSent",
                newName: "IX_LoadsSent_LoadId");

            migrationBuilder.RenameIndex(
                name: "IX_LoadSent_FactoryId",
                table: "LoadsSent",
                newName: "IX_LoadsSent_FactoryId");

            migrationBuilder.RenameIndex(
                name: "IX_LoadReceived_LoadId",
                table: "LoadsReceived",
                newName: "IX_LoadsReceived_LoadId");

            migrationBuilder.RenameIndex(
                name: "IX_LoadReceived_FactoryId",
                table: "LoadsReceived",
                newName: "IX_LoadsReceived_FactoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoadsSent",
                table: "LoadsSent",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoadsReceived",
                table: "LoadsReceived",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_LoadsSent_Factories_FactoryId",
                table: "LoadsSent",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoadsSent_Loads_LoadId",
                table: "LoadsSent",
                column: "LoadId",
                principalTable: "Loads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoadsReceived_Factories_FactoryId",
                table: "LoadsReceived");

            migrationBuilder.DropForeignKey(
                name: "FK_LoadsReceived_Loads_LoadId",
                table: "LoadsReceived");

            migrationBuilder.DropForeignKey(
                name: "FK_LoadsSent_Factories_FactoryId",
                table: "LoadsSent");

            migrationBuilder.DropForeignKey(
                name: "FK_LoadsSent_Loads_LoadId",
                table: "LoadsSent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoadsSent",
                table: "LoadsSent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoadsReceived",
                table: "LoadsReceived");

            migrationBuilder.RenameTable(
                name: "LoadsSent",
                newName: "LoadSent");

            migrationBuilder.RenameTable(
                name: "LoadsReceived",
                newName: "LoadReceived");

            migrationBuilder.RenameIndex(
                name: "IX_LoadsSent_LoadId",
                table: "LoadSent",
                newName: "IX_LoadSent_LoadId");

            migrationBuilder.RenameIndex(
                name: "IX_LoadsSent_FactoryId",
                table: "LoadSent",
                newName: "IX_LoadSent_FactoryId");

            migrationBuilder.RenameIndex(
                name: "IX_LoadsReceived_LoadId",
                table: "LoadReceived",
                newName: "IX_LoadReceived_LoadId");

            migrationBuilder.RenameIndex(
                name: "IX_LoadsReceived_FactoryId",
                table: "LoadReceived",
                newName: "IX_LoadReceived_FactoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoadSent",
                table: "LoadSent",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoadReceived",
                table: "LoadReceived",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_LoadSent_Factories_FactoryId",
                table: "LoadSent",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoadSent_Loads_LoadId",
                table: "LoadSent",
                column: "LoadId",
                principalTable: "Loads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

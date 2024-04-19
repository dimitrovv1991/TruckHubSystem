using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckHubSystem.Infrastructure.Migrations
{
    public partial class CurrentLoadTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoadsReceived_Factories_FactoryId",
                table: "LoadsReceived");

            migrationBuilder.DropForeignKey(
                name: "FK_LoadsReceived_Loads_LoadId",
                table: "LoadsReceived");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoadsReceived",
                table: "LoadsReceived");

            migrationBuilder.RenameTable(
                name: "LoadsReceived",
                newName: "LoadReceived");

            migrationBuilder.RenameIndex(
                name: "IX_LoadsReceived_LoadId",
                table: "LoadReceived",
                newName: "IX_LoadReceived_LoadId");

            migrationBuilder.RenameIndex(
                name: "IX_LoadsReceived_FactoryId",
                table: "LoadReceived",
                newName: "IX_LoadReceived_FactoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoadReceived",
                table: "LoadReceived",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CurrentLoad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Load identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    LoadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentLoad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrentLoad_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurrentLoad_Loads_LoadId",
                        column: x => x.LoadId,
                        principalTable: "Loads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrentLoad_FactoryId",
                table: "CurrentLoad",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentLoad_LoadId",
                table: "CurrentLoad",
                column: "LoadId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoadReceived_Factories_FactoryId",
                table: "LoadReceived");

            migrationBuilder.DropForeignKey(
                name: "FK_LoadReceived_Loads_LoadId",
                table: "LoadReceived");

            migrationBuilder.DropTable(
                name: "CurrentLoad");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoadReceived",
                table: "LoadReceived");

            migrationBuilder.RenameTable(
                name: "LoadReceived",
                newName: "LoadsReceived");

            migrationBuilder.RenameIndex(
                name: "IX_LoadReceived_LoadId",
                table: "LoadsReceived",
                newName: "IX_LoadsReceived_LoadId");

            migrationBuilder.RenameIndex(
                name: "IX_LoadReceived_FactoryId",
                table: "LoadsReceived",
                newName: "IX_LoadsReceived_FactoryId");

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
        }
    }
}

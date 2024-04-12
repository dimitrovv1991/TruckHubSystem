using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckHubSystem.Infrastructure.Migrations
{
    public partial class CreatorAddedToFactory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Factories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                comment: "Creator identifier");

            migrationBuilder.CreateIndex(
                name: "IX_Factories_CreatorId",
                table: "Factories",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Factories_AspNetUsers_CreatorId",
                table: "Factories",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factories_AspNetUsers_CreatorId",
                table: "Factories");

            migrationBuilder.DropIndex(
                name: "IX_Factories_CreatorId",
                table: "Factories");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Factories");
        }
    }
}

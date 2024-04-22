using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckHubSystem.Infrastructure.Migrations
{
    public partial class FormsAdjusted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LoadId",
                table: "LoadsSent",
                type: "int",
                nullable: false,
                comment: "Load identifier",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FactoryId",
                table: "LoadsSent",
                type: "int",
                nullable: false,
                comment: "Sending factory identifier",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LoadId",
                table: "LoadsReceived",
                type: "int",
                nullable: false,
                comment: "Load identifier",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FactoryId",
                table: "LoadsReceived",
                type: "int",
                nullable: false,
                comment: "Receiving factory identifier",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LoadCategoryId",
                table: "Loads",
                type: "int",
                nullable: false,
                comment: "Load category identifier",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FactoryId",
                table: "Loads",
                type: "int",
                nullable: false,
                comment: "Factory identifier",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Factories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "City",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Factories",
                type: "int",
                nullable: false,
                comment: "Factory identifier",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "YearDrivingLicenseAcquired",
                table: "Drivers",
                type: "int",
                nullable: false,
                comment: "Which year driver has acquired his driving license",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LoadId",
                table: "CurrentLoads",
                type: "int",
                nullable: false,
                comment: "Load identifier",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FactoryId",
                table: "CurrentLoads",
                type: "int",
                nullable: false,
                comment: "Factory identifier",
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LoadId",
                table: "LoadsSent",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Load identifier");

            migrationBuilder.AlterColumn<int>(
                name: "FactoryId",
                table: "LoadsSent",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Sending factory identifier");

            migrationBuilder.AlterColumn<int>(
                name: "LoadId",
                table: "LoadsReceived",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Load identifier");

            migrationBuilder.AlterColumn<int>(
                name: "FactoryId",
                table: "LoadsReceived",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Receiving factory identifier");

            migrationBuilder.AlterColumn<int>(
                name: "LoadCategoryId",
                table: "Loads",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Load category identifier");

            migrationBuilder.AlterColumn<int>(
                name: "FactoryId",
                table: "Loads",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Factory identifier");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Factories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "City");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Factories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Factory identifier")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "YearDrivingLicenseAcquired",
                table: "Drivers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Which year driver has acquired his driving license");

            migrationBuilder.AlterColumn<int>(
                name: "LoadId",
                table: "CurrentLoads",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Load identifier");

            migrationBuilder.AlterColumn<int>(
                name: "FactoryId",
                table: "CurrentLoads",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Factory identifier");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b893d8395280-jf28-6532-c198-kiu12856",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b7d3339-1c97-4c0b-90b9-effe28ce54be", "AQAAAAEAACcQAAAAEPPktPd6zlmv4SsscAs7pRX5HE1Pe92xcDkM3yFO8vW81jrtQ4epld/ag6K3sZFG+w==", "dd54405c-b802-4187-a1ad-e68451781288" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "kiu12856-c198-6532-jf28-b893d8395280",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b87dc457-5f32-4ceb-99ec-64f29da30a11", "AQAAAAEAACcQAAAAELRsWZ8pzLiUCtkOd/SiMD20i3/02G/PP+AxZAuubLFI1TuXKP9NDG6rPuQ5nOuZuw==", "79649552-ecee-41c2-b1e1-5ad62c7ba850" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckHubSystem.Infrastructure.Migrations
{
    public partial class MainTablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Booking status indentifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Booking status")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingStatuses", x => x.Id);
                },
                comment: "Booking status");

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Driver identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Driver's first name"),
                    FamilyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Driver's family name"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Driver's phone number"),
                    YearDrivingLicenseAcquired = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                },
                comment: "Driver");

            migrationBuilder.CreateTable(
                name: "Factories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Factory name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factories", x => x.Id);
                },
                comment: "Factory");

            migrationBuilder.CreateTable(
                name: "LoadCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Category Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Load category")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadCategories", x => x.Id);
                },
                comment: "Load category");

            migrationBuilder.CreateTable(
                name: "TransmissionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "TransmissionType Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Transmission type")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransmissionTypes", x => x.Id);
                },
                comment: "Truck transmission type");

            migrationBuilder.CreateTable(
                name: "Loads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Load identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Load name"),
                    Weigth = table.Column<int>(type: "int", nullable: false, comment: "Load weight"),
                    LoadCategoryId = table.Column<int>(type: "int", nullable: false),
                    LoadingCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "City of loading the goods"),
                    DestinationCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "City of unloading the goods"),
                    LoadingFactoryId = table.Column<int>(type: "int", nullable: false),
                    UnloadingFactoryId = table.Column<int>(type: "int", nullable: false),
                    DistanceInKm = table.Column<int>(type: "int", nullable: false, comment: "Distance between the cities"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Load price")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loads_Factories_LoadingFactoryId",
                        column: x => x.LoadingFactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Loads_Factories_UnloadingFactoryId",
                        column: x => x.UnloadingFactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Loads_LoadCategories_LoadCategoryId",
                        column: x => x.LoadCategoryId,
                        principalTable: "LoadCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Load");

            migrationBuilder.CreateTable(
                name: "Trucks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Truck Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Manufacturer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Manufactrurer"),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Model"),
                    YearManufactured = table.Column<int>(type: "int", nullable: false, comment: "Year manufactured"),
                    LicensePlate = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "License plate number"),
                    CapacityKg = table.Column<int>(type: "int", nullable: false, comment: "Capacity in kilograms"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Truck image url"),
                    Available = table.Column<bool>(type: "bit", nullable: false, comment: "Is truck available"),
                    TransmissionTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trucks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trucks_TransmissionTypes_TransmissionTypeId",
                        column: x => x.TransmissionTypeId,
                        principalTable: "TransmissionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Truck");

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TruckId = table.Column<int>(type: "int", nullable: false, comment: "Truck identifier"),
                    LoadId = table.Column<int>(type: "int", nullable: false, comment: "Load identifier"),
                    DriverId = table.Column<int>(type: "int", nullable: false, comment: "Driver identifier"),
                    BookingStatusId = table.Column<int>(type: "int", nullable: false, comment: "Booking status identifier"),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_BookingStatuses_BookingStatusId",
                        column: x => x.BookingStatusId,
                        principalTable: "BookingStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Loads_LoadId",
                        column: x => x.LoadId,
                        principalTable: "Loads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Trucks_TruckId",
                        column: x => x.TruckId,
                        principalTable: "Trucks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Booking");

            migrationBuilder.InsertData(
                table: "BookingStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "In progress" },
                    { 2, "Completed" }
                });

            migrationBuilder.InsertData(
                table: "LoadCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Building materials" },
                    { 2, "Foods" },
                    { 3, "Electronics" },
                    { 4, "Medical Supplies" },
                    { 5, "Chemicals" },
                    { 6, "Automotive" },
                    { 7, "Textiles" },
                    { 8, "Others" }
                });

            migrationBuilder.InsertData(
                table: "TransmissionTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Automatic" },
                    { 2, "Manual" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookingStatusId",
                table: "Bookings",
                column: "BookingStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_DriverId",
                table: "Bookings",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_LoadId",
                table: "Bookings",
                column: "LoadId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TruckId",
                table: "Bookings",
                column: "TruckId");

            migrationBuilder.CreateIndex(
                name: "IX_Loads_LoadCategoryId",
                table: "Loads",
                column: "LoadCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Loads_LoadingFactoryId",
                table: "Loads",
                column: "LoadingFactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Loads_UnloadingFactoryId",
                table: "Loads",
                column: "UnloadingFactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Trucks_TransmissionTypeId",
                table: "Trucks",
                column: "TransmissionTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "BookingStatuses");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Loads");

            migrationBuilder.DropTable(
                name: "Trucks");

            migrationBuilder.DropTable(
                name: "Factories");

            migrationBuilder.DropTable(
                name: "LoadCategories");

            migrationBuilder.DropTable(
                name: "TransmissionTypes");
        }
    }
}

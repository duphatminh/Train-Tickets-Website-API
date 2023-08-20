using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainTicketsWebsite.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    stationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stationName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    stationLocation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.stationID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_ID);
                });

            migrationBuilder.CreateTable(
                name: "Trains",
                columns: table => new
                {
                    trainID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stationID = table.Column<int>(type: "int", nullable: false),
                    trainName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    schedule = table.Column<DateTime>(type: "datetime2", nullable: false),
                    departureStation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    arrivalStation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    departureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    arrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trains", x => x.trainID);
                    table.ForeignKey(
                        name: "FK_Trains_Stations_stationID",
                        column: x => x.stationID,
                        principalTable: "Stations",
                        principalColumn: "stationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carriages",
                columns: table => new
                {
                    carriageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    trainID = table.Column<int>(type: "int", nullable: false),
                    carriageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    carriageType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    carriageStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carriages", x => x.carriageID);
                    table.ForeignKey(
                        name: "FK_Carriages_Trains_trainID",
                        column: x => x.trainID,
                        principalTable: "Trains",
                        principalColumn: "trainID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cabins",
                columns: table => new
                {
                    cabinID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    carriageID = table.Column<int>(type: "int", nullable: false),
                    cabinName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabins", x => x.cabinID);
                    table.ForeignKey(
                        name: "FK_Cabins_Carriages_carriageID",
                        column: x => x.carriageID,
                        principalTable: "Carriages",
                        principalColumn: "carriageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    seatID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cabinID = table.Column<int>(type: "int", nullable: false),
                    seatNumber = table.Column<int>(type: "int", nullable: false),
                    seatType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    seatAvailability = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.seatID);
                    table.ForeignKey(
                        name: "FK_Seats_Cabins_cabinID",
                        column: x => x.cabinID,
                        principalTable: "Cabins",
                        principalColumn: "cabinID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cabins_carriageID",
                table: "Cabins",
                column: "carriageID");

            migrationBuilder.CreateIndex(
                name: "IX_Carriages_trainID",
                table: "Carriages",
                column: "trainID");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_cabinID",
                table: "Seats",
                column: "cabinID");

            migrationBuilder.CreateIndex(
                name: "IX_Trains_stationID",
                table: "Trains",
                column: "stationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cabins");

            migrationBuilder.DropTable(
                name: "Carriages");

            migrationBuilder.DropTable(
                name: "Trains");

            migrationBuilder.DropTable(
                name: "Stations");
        }
    }
}

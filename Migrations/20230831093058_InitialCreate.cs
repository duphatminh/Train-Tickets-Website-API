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
                name: "StationsInfo",
                columns: table => new
                {
                    stationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stationName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    stationLocation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationsInfo", x => x.stationID);
                });

            migrationBuilder.CreateTable(
                name: "UsersInfo",
                columns: table => new
                {
                    user_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInfo", x => x.user_ID);
                });

            migrationBuilder.CreateTable(
                name: "TrainsInfo",
                columns: table => new
                {
                    trainID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stationID = table.Column<int>(type: "int", nullable: false),
                    trainName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    schedule = table.Column<DateTime>(type: "datetime2", nullable: false),
                    departureStation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    arrivalStation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    departureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    arrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainsInfo", x => x.trainID);
                    table.ForeignKey(
                        name: "FK_TrainsInfo_StationsInfo_stationID",
                        column: x => x.stationID,
                        principalTable: "StationsInfo",
                        principalColumn: "stationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarriagesInfo",
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
                    table.PrimaryKey("PK_CarriagesInfo", x => x.carriageID);
                    table.ForeignKey(
                        name: "FK_CarriagesInfo_TrainsInfo_trainID",
                        column: x => x.trainID,
                        principalTable: "TrainsInfo",
                        principalColumn: "trainID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CabinsInfo",
                columns: table => new
                {
                    cabinID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    carriageID = table.Column<int>(type: "int", nullable: false),
                    cabinName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabinsInfo", x => x.cabinID);
                    table.ForeignKey(
                        name: "FK_CabinsInfo_CarriagesInfo_carriageID",
                        column: x => x.carriageID,
                        principalTable: "CarriagesInfo",
                        principalColumn: "carriageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeatsInfo",
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
                    table.PrimaryKey("PK_SeatsInfo", x => x.seatID);
                    table.ForeignKey(
                        name: "FK_SeatsInfo_CabinsInfo_cabinID",
                        column: x => x.cabinID,
                        principalTable: "CabinsInfo",
                        principalColumn: "cabinID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CabinsInfo_carriageID",
                table: "CabinsInfo",
                column: "carriageID");

            migrationBuilder.CreateIndex(
                name: "IX_CarriagesInfo_trainID",
                table: "CarriagesInfo",
                column: "trainID");

            migrationBuilder.CreateIndex(
                name: "IX_SeatsInfo_cabinID",
                table: "SeatsInfo",
                column: "cabinID");

            migrationBuilder.CreateIndex(
                name: "IX_TrainsInfo_stationID",
                table: "TrainsInfo",
                column: "stationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeatsInfo");

            migrationBuilder.DropTable(
                name: "UsersInfo");

            migrationBuilder.DropTable(
                name: "CabinsInfo");

            migrationBuilder.DropTable(
                name: "CarriagesInfo");

            migrationBuilder.DropTable(
                name: "TrainsInfo");

            migrationBuilder.DropTable(
                name: "StationsInfo");
        }
    }
}

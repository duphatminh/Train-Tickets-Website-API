using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainTicketsWebsite.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatever2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingsInfo",
                columns: table => new
                {
                    bookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userID = table.Column<int>(type: "int", nullable: false),
                    seatID = table.Column<int>(type: "int", nullable: false),
                    departureStation = table.Column<int>(type: "int", nullable: false),
                    arrivalStation = table.Column<int>(type: "int", nullable: false),
                    departureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    numberOfTickets = table.Column<int>(type: "int", nullable: false),
                    totalPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingsInfo", x => x.bookingID);
                    table.ForeignKey(
                        name: "FK_BookingsInfo_SeatsInfo_seatID",
                        column: x => x.seatID,
                        principalTable: "SeatsInfo",
                        principalColumn: "seatID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingsInfo_UsersInfo_userID",
                        column: x => x.userID,
                        principalTable: "UsersInfo",
                        principalColumn: "user_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentsInfo",
                columns: table => new
                {
                    paymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creditCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    expirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cvv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentsInfo", x => x.paymentID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingsInfo_seatID",
                table: "BookingsInfo",
                column: "seatID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingsInfo_userID",
                table: "BookingsInfo",
                column: "userID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingsInfo");

            migrationBuilder.DropTable(
                name: "PaymentsInfo");
        }
    }
}

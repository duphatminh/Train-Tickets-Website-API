using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainTicketsWebsite.Migrations
{
    /// <inheritdoc />
    public partial class CreateTrainModelandUpdateTrainController : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreateTrains",
                columns: table => new
                {
                    stationID = table.Column<int>(type: "int", nullable: false),
                    trainName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    departureStation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    arrivalStation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreateTrains");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage2Grupp5.Migrations
{
    public partial class AttilaStarkenius1212023AddingTypeColumnToParkedVehicleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkedVehicle_VehicleType_TypeId",
                table: "ParkedVehicle");

            migrationBuilder.DropTable(
                name: "UnparkedVehicleViewModel");

            migrationBuilder.DropTable(
                name: "VehicleType");

            migrationBuilder.DropIndex(
                name: "IX_ParkedVehicle_TypeId",
                table: "ParkedVehicle");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "ParkedVehicle");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "ParkedVehicle",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "ParkedVehicle");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "ParkedVehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnparkedVehicleViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NrOfWheels = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    parkingPrice = table.Column<double>(type: "float", nullable: false),
                    parkingTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnparkedVehicleViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnparkedVehicleViewModel_VehicleType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "VehicleType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkedVehicle_TypeId",
                table: "ParkedVehicle",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UnparkedVehicleViewModel_TypeId",
                table: "UnparkedVehicleViewModel",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkedVehicle_VehicleType_TypeId",
                table: "ParkedVehicle",
                column: "TypeId",
                principalTable: "VehicleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

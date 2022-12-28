using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage2Grupp5.Migrations
{
    public partial class AttilaStarkenius28122022AddDepartureTimeandPricecolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureTime",
                table: "ParkedVehicle",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ParkedVehicle",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartureTime",
                table: "ParkedVehicle");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ParkedVehicle");
        }
    }
}

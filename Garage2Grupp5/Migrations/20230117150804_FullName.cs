using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage2Grupp5.Migrations
{
    public partial class FullName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkedVehicle_ParkedVehicleViewModel_ParkedVehicleViewModelId",
                table: "ParkedVehicle");

            migrationBuilder.DropTable(
                name: "ParkedVehicleViewModel");

            migrationBuilder.DropIndex(
                name: "IX_ParkedVehicle_ParkedVehicleViewModelId",
                table: "ParkedVehicle");

            migrationBuilder.DropColumn(
                name: "ParkedVehicleViewModelId",
                table: "ParkedVehicle");

            migrationBuilder.DropColumn(
                name: "VehicleType",
                table: "ParkedVehicle");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Membership");

            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "Id", "FirstName", "LastName", "SocialSecurityNumber" },
                values: new object[] { 1, "Abc", "Def", "23409812-32134" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Membership",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "ParkedVehicleViewModelId",
                table: "ParkedVehicle",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleType",
                table: "ParkedVehicle",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Membership",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ParkedVehicleViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    NrOfWheels = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkedVehicleViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkedVehicleViewModel_VehicleType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "VehicleType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkedVehicle_ParkedVehicleViewModelId",
                table: "ParkedVehicle",
                column: "ParkedVehicleViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkedVehicleViewModel_TypeId",
                table: "ParkedVehicleViewModel",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkedVehicle_ParkedVehicleViewModel_ParkedVehicleViewModelId",
                table: "ParkedVehicle",
                column: "ParkedVehicleViewModelId",
                principalTable: "ParkedVehicleViewModel",
                principalColumn: "Id");
        }
    }
}

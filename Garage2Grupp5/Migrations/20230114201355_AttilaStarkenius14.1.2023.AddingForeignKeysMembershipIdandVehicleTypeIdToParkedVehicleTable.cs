using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage2Grupp5.Migrations
{
    public partial class AttilaStarkenius1412023AddingForeignKeysMembershipIdandVehicleTypeIdToParkedVehicleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkedVehicle_VehicleType_TypeId",
                table: "ParkedVehicle");

            migrationBuilder.DropIndex(
                name: "IX_ParkedVehicle_TypeId",
                table: "ParkedVehicle");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "ParkedVehicle");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "ParkedVehicle",
                newName: "VehicleTypeId");

            migrationBuilder.AddColumn<int>(
                name: "MembershipId",
                table: "ParkedVehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Membership",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocialSecurityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParkedVehicleViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NrOfWheels = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                name: "IX_ParkedVehicle_MembershipId",
                table: "ParkedVehicle",
                column: "MembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkedVehicle_VehicleTypeId",
                table: "ParkedVehicle",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkedVehicleViewModel_TypeId",
                table: "ParkedVehicleViewModel",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkedVehicle_Membership_MembershipId",
                table: "ParkedVehicle",
                column: "MembershipId",
                principalTable: "Membership",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkedVehicle_VehicleType_VehicleTypeId",
                table: "ParkedVehicle",
                column: "VehicleTypeId",
                principalTable: "VehicleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkedVehicle_Membership_MembershipId",
                table: "ParkedVehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_ParkedVehicle_VehicleType_VehicleTypeId",
                table: "ParkedVehicle");

            migrationBuilder.DropTable(
                name: "Membership");

            migrationBuilder.DropTable(
                name: "ParkedVehicleViewModel");

            migrationBuilder.DropIndex(
                name: "IX_ParkedVehicle_MembershipId",
                table: "ParkedVehicle");

            migrationBuilder.DropIndex(
                name: "IX_ParkedVehicle_VehicleTypeId",
                table: "ParkedVehicle");

            migrationBuilder.DropColumn(
                name: "MembershipId",
                table: "ParkedVehicle");

            migrationBuilder.RenameColumn(
                name: "VehicleTypeId",
                table: "ParkedVehicle",
                newName: "MemberId");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "ParkedVehicle",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParkedVehicle_TypeId",
                table: "ParkedVehicle",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkedVehicle_VehicleType_TypeId",
                table: "ParkedVehicle",
                column: "TypeId",
                principalTable: "VehicleType",
                principalColumn: "Id");
        }
    }
}

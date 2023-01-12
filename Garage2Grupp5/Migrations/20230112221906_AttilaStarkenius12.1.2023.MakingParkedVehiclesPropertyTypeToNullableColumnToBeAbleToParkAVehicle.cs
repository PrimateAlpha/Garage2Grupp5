using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage2Grupp5.Migrations
{
    public partial class AttilaStarkenius1212023MakingParkedVehiclesPropertyTypeToNullableColumnToBeAbleToParkAVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkedVehicle_VehicleType_TypeId",
                table: "ParkedVehicle");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "ParkedVehicle",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkedVehicle_VehicleType_TypeId",
                table: "ParkedVehicle",
                column: "TypeId",
                principalTable: "VehicleType",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkedVehicle_VehicleType_TypeId",
                table: "ParkedVehicle");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "ParkedVehicle",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

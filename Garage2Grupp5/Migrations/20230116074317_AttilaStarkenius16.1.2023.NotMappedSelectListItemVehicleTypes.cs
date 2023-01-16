using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage2Grupp5.Migrations
{
    public partial class AttilaStarkenius1612023NotMappedSelectListItemVehicleTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParkedVehicleViewModelId",
                table: "ParkedVehicle",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParkedVehicle_ParkedVehicleViewModelId",
                table: "ParkedVehicle",
                column: "ParkedVehicleViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkedVehicle_ParkedVehicleViewModel_ParkedVehicleViewModelId",
                table: "ParkedVehicle",
                column: "ParkedVehicleViewModelId",
                principalTable: "ParkedVehicleViewModel",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkedVehicle_ParkedVehicleViewModel_ParkedVehicleViewModelId",
                table: "ParkedVehicle");

            migrationBuilder.DropIndex(
                name: "IX_ParkedVehicle_ParkedVehicleViewModelId",
                table: "ParkedVehicle");

            migrationBuilder.DropColumn(
                name: "ParkedVehicleViewModelId",
                table: "ParkedVehicle");
        }
    }
}

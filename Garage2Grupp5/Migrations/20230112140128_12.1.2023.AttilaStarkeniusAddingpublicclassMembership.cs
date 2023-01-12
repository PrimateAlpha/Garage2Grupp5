using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage2Grupp5.Migrations
{
    public partial class _1212023AttilaStarkeniusAddingpublicclassMembership : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "UnparkedVehicleViewModel",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "ParkedVehicle",
                newName: "TypeId");

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

            migrationBuilder.CreateIndex(
                name: "IX_UnparkedVehicleViewModel_TypeId",
                table: "UnparkedVehicleViewModel",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkedVehicle_TypeId",
                table: "ParkedVehicle",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkedVehicle_VehicleType_TypeId",
                table: "ParkedVehicle",
                column: "TypeId",
                principalTable: "VehicleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnparkedVehicleViewModel_VehicleType_TypeId",
                table: "UnparkedVehicleViewModel",
                column: "TypeId",
                principalTable: "VehicleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkedVehicle_VehicleType_TypeId",
                table: "ParkedVehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_UnparkedVehicleViewModel_VehicleType_TypeId",
                table: "UnparkedVehicleViewModel");

            migrationBuilder.DropTable(
                name: "VehicleType");

            migrationBuilder.DropIndex(
                name: "IX_UnparkedVehicleViewModel_TypeId",
                table: "UnparkedVehicleViewModel");

            migrationBuilder.DropIndex(
                name: "IX_ParkedVehicle_TypeId",
                table: "ParkedVehicle");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "UnparkedVehicleViewModel",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "ParkedVehicle",
                newName: "Type");
        }
    }
}

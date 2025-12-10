using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportLogistics.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class MakeVehicleNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VehicleStatus",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_VehicleId",
                table: "Orders",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Vehicles_VehicleId",
                table: "Orders",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Vehicles_VehicleId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_VehicleId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "VehicleStatus",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Orders");
        }
    }
}

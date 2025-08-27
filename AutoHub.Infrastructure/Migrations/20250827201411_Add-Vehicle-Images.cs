using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleAutoHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddVehicleImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleImage");

            migrationBuilder.AddColumn<string>(
                name: "VehicleImages",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleImages",
                table: "Vehicles");

            migrationBuilder.CreateTable(
                name: "VehicleImage",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleImage", x => new { x.VehicleId, x.Id });
                    table.ForeignKey(
                        name: "FK_VehicleImage_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "PK_Vehicle_Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}

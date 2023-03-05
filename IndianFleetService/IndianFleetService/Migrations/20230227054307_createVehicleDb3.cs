using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndianFleetService.Migrations
{
    /// <inheritdoc />
    public partial class createVehicleDb3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AltCompType",
                table: "AlternateComponentMasters",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AltCompType",
                table: "AlternateComponentMasters");
        }
    }
}

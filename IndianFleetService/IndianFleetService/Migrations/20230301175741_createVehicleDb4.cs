using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndianFleetService.Migrations
{
    /// <inheritdoc />
    public partial class createVehicleDb4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetailMasters_InvoiceHeaderMasters_InvoiceId",
                table: "InvoiceDetailMasters");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "InvoiceDetailMasters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AltCompId",
                table: "InvoiceDetailMasters",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetailMasters_InvoiceHeaderMasters_InvoiceId",
                table: "InvoiceDetailMasters",
                column: "InvoiceId",
                principalTable: "InvoiceHeaderMasters",
                principalColumn: "InvoiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetailMasters_InvoiceHeaderMasters_InvoiceId",
                table: "InvoiceDetailMasters");

            migrationBuilder.DropColumn(
                name: "AltCompId",
                table: "InvoiceDetailMasters");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "InvoiceDetailMasters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetailMasters_InvoiceHeaderMasters_InvoiceId",
                table: "InvoiceDetailMasters",
                column: "InvoiceId",
                principalTable: "InvoiceHeaderMasters",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndianFleetService.Migrations
{
    /// <inheritdoc />
    public partial class createVehicleDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComponentMasterMasters",
                columns: table => new
                {
                    compId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentMasterMasters", x => x.compId);
                });

            migrationBuilder.CreateTable(
                name: "SegmentMasterMasters",
                columns: table => new
                {
                    SegId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SegName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SegmentMasterMasters", x => x.SegId);
                });

            migrationBuilder.CreateTable(
                name: "UserDataMasters",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    holding = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDataMasters", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "MfgMasters",
                columns: table => new
                {
                    MfgId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MfgName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SegId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MfgMasters", x => x.MfgId);
                    table.ForeignKey(
                        name: "FK_MfgMasters_SegmentMasterMasters_SegId",
                        column: x => x.SegId,
                        principalTable: "SegmentMasterMasters",
                        principalColumn: "SegId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceHeaderMasters",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BillingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<int>(type: "int", nullable: false),
                    UserDataUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceHeaderMasters", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_InvoiceHeaderMasters_UserDataMasters_UserDataUserId",
                        column: x => x.UserDataUserId,
                        principalTable: "UserDataMasters",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "ModelMasterMasters",
                columns: table => new
                {
                    ModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MfgId = table.Column<int>(type: "int", nullable: false),
                    MinQty = table.Column<int>(type: "int", nullable: false),
                    BasicPrice = table.Column<double>(type: "float", nullable: false),
                    ImagPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelMasterMasters", x => x.ModelId);
                    table.ForeignKey(
                        name: "FK_ModelMasterMasters_MfgMasters_MfgId",
                        column: x => x.MfgId,
                        principalTable: "MfgMasters",
                        principalColumn: "MfgId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetailMasters",
                columns: table => new
                {
                    InvoiceDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    VehicleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetailMasters", x => x.InvoiceDetailId);
                    table.ForeignKey(
                        name: "FK_InvoiceDetailMasters_InvoiceHeaderMasters_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "InvoiceHeaderMasters",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlternateComponentMasters",
                columns: table => new
                {
                    AltId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    CompId = table.Column<int>(type: "int", nullable: true),
                    AltCompId = table.Column<int>(type: "int", nullable: true),
                    DeltaPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlternateComponentMasters", x => x.AltId);
                    table.ForeignKey(
                        name: "FK_AlternateComponentMasters_ComponentMasterMasters_CompId",
                        column: x => x.CompId,
                        principalTable: "ComponentMasterMasters",
                        principalColumn: "compId");
                    table.ForeignKey(
                        name: "FK_AlternateComponentMasters_ModelMasterMasters_ModelId",
                        column: x => x.ModelId,
                        principalTable: "ModelMasterMasters",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleDetailMasters",
                columns: table => new
                {
                    ConfiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    CompId = table.Column<int>(type: "int", nullable: false),
                    CompType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsConfigurable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDetailMasters", x => x.ConfiId);
                    table.ForeignKey(
                        name: "FK_VehicleDetailMasters_ComponentMasterMasters_CompId",
                        column: x => x.CompId,
                        principalTable: "ComponentMasterMasters",
                        principalColumn: "compId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleDetailMasters_ModelMasterMasters_ModelId",
                        column: x => x.ModelId,
                        principalTable: "ModelMasterMasters",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlternateComponentMasters_CompId",
                table: "AlternateComponentMasters",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_AlternateComponentMasters_ModelId",
                table: "AlternateComponentMasters",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetailMasters_InvoiceId",
                table: "InvoiceDetailMasters",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHeaderMasters_UserDataUserId",
                table: "InvoiceHeaderMasters",
                column: "UserDataUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MfgMasters_SegId",
                table: "MfgMasters",
                column: "SegId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelMasterMasters_MfgId",
                table: "ModelMasterMasters",
                column: "MfgId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDetailMasters_CompId",
                table: "VehicleDetailMasters",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDetailMasters_ModelId",
                table: "VehicleDetailMasters",
                column: "ModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlternateComponentMasters");

            migrationBuilder.DropTable(
                name: "InvoiceDetailMasters");

            migrationBuilder.DropTable(
                name: "VehicleDetailMasters");

            migrationBuilder.DropTable(
                name: "InvoiceHeaderMasters");

            migrationBuilder.DropTable(
                name: "ComponentMasterMasters");

            migrationBuilder.DropTable(
                name: "ModelMasterMasters");

            migrationBuilder.DropTable(
                name: "UserDataMasters");

            migrationBuilder.DropTable(
                name: "MfgMasters");

            migrationBuilder.DropTable(
                name: "SegmentMasterMasters");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_Licitacion.Migrations
{
    public partial class ReqProveedorAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MontoReferencial",
                table: "Requerimientos",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "ReqProveedor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dml = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpDateTime = table.Column<DateTime>(nullable: false),
                    UserLogin = table.Column<string>(nullable: true),
                    ProveedorId = table.Column<int>(nullable: true),
                    RequerimientoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReqProveedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReqProveedor_Proveedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReqProveedor_Requerimientos_RequerimientoId",
                        column: x => x.RequerimientoId,
                        principalTable: "Requerimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReqProveedor_ProveedorId",
                table: "ReqProveedor",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_ReqProveedor_RequerimientoId",
                table: "ReqProveedor",
                column: "RequerimientoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReqProveedor");

            migrationBuilder.DropColumn(
                name: "MontoReferencial",
                table: "Requerimientos");
        }
    }
}

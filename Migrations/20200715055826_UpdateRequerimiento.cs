using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_Licitacion.Migrations
{
    public partial class UpdateRequerimiento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReqProveedor_Proveedores_ProveedorId",
                table: "ReqProveedor");

            migrationBuilder.DropForeignKey(
                name: "FK_ReqProveedor_Requerimientos_RequerimientoId",
                table: "ReqProveedor");

            migrationBuilder.DropForeignKey(
                name: "FK_Requerimientos_ConfigProcesos_ConfigProcesoId",
                table: "Requerimientos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReqProveedor",
                table: "ReqProveedor");

            migrationBuilder.DropColumn(
                name: "ConfigProcesoId",
                table: "Requerimientos");

            migrationBuilder.DropColumn(
                name: "FechaAdjudicacion",
                table: "ConfigProcesos");

            migrationBuilder.RenameTable(
                name: "ReqProveedor",
                newName: "ReqProveedors");

            migrationBuilder.RenameIndex(
                name: "IX_ReqProveedor_RequerimientoId",
                table: "ReqProveedors",
                newName: "IX_ReqProveedors_RequerimientoId");

            migrationBuilder.RenameIndex(
                name: "IX_ReqProveedor_ProveedorId",
                table: "ReqProveedors",
                newName: "IX_ReqProveedors_ProveedorId");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAdjudicacion",
                table: "Requerimientos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "RequerimientoId",
                table: "ConfigProcesos",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReqProveedors",
                table: "ReqProveedors",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigProcesos_RequerimientoId",
                table: "ConfigProcesos",
                column: "RequerimientoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfigProcesos_Requerimientos_RequerimientoId",
                table: "ConfigProcesos",
                column: "RequerimientoId",
                principalTable: "Requerimientos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReqProveedors_Proveedores_ProveedorId",
                table: "ReqProveedors",
                column: "ProveedorId",
                principalTable: "Proveedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReqProveedors_Requerimientos_RequerimientoId",
                table: "ReqProveedors",
                column: "RequerimientoId",
                principalTable: "Requerimientos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfigProcesos_Requerimientos_RequerimientoId",
                table: "ConfigProcesos");

            migrationBuilder.DropForeignKey(
                name: "FK_ReqProveedors_Proveedores_ProveedorId",
                table: "ReqProveedors");

            migrationBuilder.DropForeignKey(
                name: "FK_ReqProveedors_Requerimientos_RequerimientoId",
                table: "ReqProveedors");

            migrationBuilder.DropIndex(
                name: "IX_ConfigProcesos_RequerimientoId",
                table: "ConfigProcesos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReqProveedors",
                table: "ReqProveedors");

            migrationBuilder.DropColumn(
                name: "FechaAdjudicacion",
                table: "Requerimientos");

            migrationBuilder.DropColumn(
                name: "RequerimientoId",
                table: "ConfigProcesos");

            migrationBuilder.RenameTable(
                name: "ReqProveedors",
                newName: "ReqProveedor");

            migrationBuilder.RenameIndex(
                name: "IX_ReqProveedors_RequerimientoId",
                table: "ReqProveedor",
                newName: "IX_ReqProveedor_RequerimientoId");

            migrationBuilder.RenameIndex(
                name: "IX_ReqProveedors_ProveedorId",
                table: "ReqProveedor",
                newName: "IX_ReqProveedor_ProveedorId");

            migrationBuilder.AddColumn<int>(
                name: "ConfigProcesoId",
                table: "Requerimientos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FechaAdjudicacion",
                table: "ConfigProcesos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReqProveedor",
                table: "ReqProveedor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReqProveedor_Proveedores_ProveedorId",
                table: "ReqProveedor",
                column: "ProveedorId",
                principalTable: "Proveedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReqProveedor_Requerimientos_RequerimientoId",
                table: "ReqProveedor",
                column: "RequerimientoId",
                principalTable: "Requerimientos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requerimientos_ConfigProcesos_ConfigProcesoId",
                table: "Requerimientos",
                column: "ConfigProcesoId",
                principalTable: "ConfigProcesos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

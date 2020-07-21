using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_Licitacion.Migrations
{
    public partial class newEntityUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NotificarPostores",
                table: "Requerimientos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TieneRFI",
                table: "Requerimientos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TieneVisitaCampo",
                table: "Requerimientos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dml = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpDateTime = table.Column<DateTime>(nullable: false),
                    UserLogin = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    AnalistaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Analistas_AnalistaId",
                        column: x => x.AnalistaId,
                        principalTable: "Analistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_AnalistaId",
                table: "Usuarios",
                column: "AnalistaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropColumn(
                name: "NotificarPostores",
                table: "Requerimientos");

            migrationBuilder.DropColumn(
                name: "TieneRFI",
                table: "Requerimientos");

            migrationBuilder.DropColumn(
                name: "TieneVisitaCampo",
                table: "Requerimientos");
        }
    }
}

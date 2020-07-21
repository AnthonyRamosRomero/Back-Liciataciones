using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_Licitacion.Migrations
{
    public partial class AddAtributos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Anulado",
                table: "Requerimientos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ganador",
                table: "ReqProveedor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anulado",
                table: "Requerimientos");

            migrationBuilder.DropColumn(
                name: "Ganador",
                table: "ReqProveedor");
        }
    }
}

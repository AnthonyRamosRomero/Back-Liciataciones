using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_Licitacion.Migrations
{
    public partial class licitacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreaSolicitantes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dml = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpDateTime = table.Column<DateTime>(nullable: false),
                    UserLogin = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Encargado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaSolicitantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dml = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpDateTime = table.Column<DateTime>(nullable: false),
                    UserLogin = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoRequerimientos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dml = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpDateTime = table.Column<DateTime>(nullable: false),
                    UserLogin = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRequerimientos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dml = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpDateTime = table.Column<DateTime>(nullable: false),
                    UserLogin = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    UnidadMedida = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    CategoriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requerimientos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dml = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpDateTime = table.Column<DateTime>(nullable: false),
                    UserLogin = table.Column<string>(nullable: true),
                    TipoRequerimientoId = table.Column<int>(nullable: false),
                    AreaSolicitanteId = table.Column<int>(nullable: false),
                    ConfigProceso = table.Column<int>(nullable: false),
                    UsuarioSolicitante = table.Column<string>(nullable: true),
                    FechaSolicitud = table.Column<string>(nullable: true),
                    FechaEstimadaEntrega = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requerimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requerimientos_AreaSolicitantes_AreaSolicitanteId",
                        column: x => x.AreaSolicitanteId,
                        principalTable: "AreaSolicitantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requerimientos_TipoRequerimientos_TipoRequerimientoId",
                        column: x => x.TipoRequerimientoId,
                        principalTable: "TipoRequerimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleRequerimientos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dml = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpDateTime = table.Column<DateTime>(nullable: false),
                    UserLogin = table.Column<string>(nullable: true),
                    ProductoId = table.Column<int>(nullable: false),
                    RequerimientoId = table.Column<int>(nullable: false),
                    CantidadSolicitada = table.Column<int>(nullable: false),
                    PrecioUnitarioEstimado = table.Column<int>(nullable: false),
                    PrecioTotalEstimado = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleRequerimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleRequerimientos_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleRequerimientos_Requerimientos_RequerimientoId",
                        column: x => x.RequerimientoId,
                        principalTable: "Requerimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleRequerimientos_ProductoId",
                table: "DetalleRequerimientos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleRequerimientos_RequerimientoId",
                table: "DetalleRequerimientos",
                column: "RequerimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Requerimientos_AreaSolicitanteId",
                table: "Requerimientos",
                column: "AreaSolicitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Requerimientos_TipoRequerimientoId",
                table: "Requerimientos",
                column: "TipoRequerimientoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleRequerimientos");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Requerimientos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "AreaSolicitantes");

            migrationBuilder.DropTable(
                name: "TipoRequerimientos");
        }
    }
}

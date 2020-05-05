using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_Licitacion.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adjuntos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dml = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpDateTime = table.Column<DateTime>(nullable: false),
                    UserLogin = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    FolderId = table.Column<int>(nullable: false),
                    DocumentId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    ContentType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adjuntos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Analistas",
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
                    table.PrimaryKey("PK_Analistas", x => x.Id);
                });

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
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dml = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpDateTime = table.Column<DateTime>(nullable: false),
                    UserLogin = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Dni = table.Column<int>(nullable: false),
                    Telefono = table.Column<int>(nullable: false),
                    Correo = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dml = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpDateTime = table.Column<DateTime>(nullable: false),
                    UserLogin = table.Column<string>(nullable: true),
                    RazonSocial = table.Column<string>(nullable: true),
                    NumeroRuc = table.Column<string>(nullable: true),
                    Mails = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Contacto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id);
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
                name: "ConfigProcesos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dml = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpDateTime = table.Column<DateTime>(nullable: false),
                    UserLogin = table.Column<string>(nullable: true),
                    AnalistaId = table.Column<int>(nullable: false),
                    EstadoId = table.Column<int>(nullable: false),
                    FechaTratamiento = table.Column<string>(nullable: true),
                    FechaAdjudicacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigProcesos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfigProcesos_Analistas_AnalistaId",
                        column: x => x.AnalistaId,
                        principalTable: "Analistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfigProcesos_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Procesos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dml = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpDateTime = table.Column<DateTime>(nullable: false),
                    UserLogin = table.Column<string>(nullable: true),
                    ConfigProcesoId = table.Column<int>(nullable: false),
                    TipoProceso = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procesos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Procesos_ConfigProcesos_ConfigProcesoId",
                        column: x => x.ConfigProcesoId,
                        principalTable: "ConfigProcesos",
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
                    ConfigProcesoId = table.Column<int>(nullable: false),
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
                        name: "FK_Requerimientos_ConfigProcesos_ConfigProcesoId",
                        column: x => x.ConfigProcesoId,
                        principalTable: "ConfigProcesos",
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
                name: "Rondas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dml = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpDateTime = table.Column<DateTime>(nullable: false),
                    UserLogin = table.Column<string>(nullable: true),
                    ProcesoId = table.Column<int>(nullable: false),
                    NumeroRonda = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rondas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rondas_Procesos_ProcesoId",
                        column: x => x.ProcesoId,
                        principalTable: "Procesos",
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

            migrationBuilder.CreateTable(
                name: "RondaProveedores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dml = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpDateTime = table.Column<DateTime>(nullable: false),
                    UserLogin = table.Column<string>(nullable: true),
                    RondaId = table.Column<int>(nullable: false),
                    ProveedorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RondaProveedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RondaProveedores_Proveedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RondaProveedores_Rondas_RondaId",
                        column: x => x.RondaId,
                        principalTable: "Rondas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdjuntoRondaProveedores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dml = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpDateTime = table.Column<DateTime>(nullable: false),
                    UserLogin = table.Column<string>(nullable: true),
                    AdjuntoId = table.Column<int>(nullable: false),
                    RondaProveedorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdjuntoRondaProveedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdjuntoRondaProveedores_Adjuntos_AdjuntoId",
                        column: x => x.AdjuntoId,
                        principalTable: "Adjuntos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdjuntoRondaProveedores_RondaProveedores_RondaProveedorId",
                        column: x => x.RondaProveedorId,
                        principalTable: "RondaProveedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdjuntoRondaProveedores_AdjuntoId",
                table: "AdjuntoRondaProveedores",
                column: "AdjuntoId");

            migrationBuilder.CreateIndex(
                name: "IX_AdjuntoRondaProveedores_RondaProveedorId",
                table: "AdjuntoRondaProveedores",
                column: "RondaProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigProcesos_AnalistaId",
                table: "ConfigProcesos",
                column: "AnalistaId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigProcesos_EstadoId",
                table: "ConfigProcesos",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleRequerimientos_ProductoId",
                table: "DetalleRequerimientos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleRequerimientos_RequerimientoId",
                table: "DetalleRequerimientos",
                column: "RequerimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Procesos_ConfigProcesoId",
                table: "Procesos",
                column: "ConfigProcesoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Requerimientos_AreaSolicitanteId",
                table: "Requerimientos",
                column: "AreaSolicitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Requerimientos_ConfigProcesoId",
                table: "Requerimientos",
                column: "ConfigProcesoId");

            migrationBuilder.CreateIndex(
                name: "IX_Requerimientos_TipoRequerimientoId",
                table: "Requerimientos",
                column: "TipoRequerimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_RondaProveedores_ProveedorId",
                table: "RondaProveedores",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_RondaProveedores_RondaId",
                table: "RondaProveedores",
                column: "RondaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rondas_ProcesoId",
                table: "Rondas",
                column: "ProcesoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdjuntoRondaProveedores");

            migrationBuilder.DropTable(
                name: "DetalleRequerimientos");

            migrationBuilder.DropTable(
                name: "Adjuntos");

            migrationBuilder.DropTable(
                name: "RondaProveedores");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Requerimientos");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Rondas");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "AreaSolicitantes");

            migrationBuilder.DropTable(
                name: "TipoRequerimientos");

            migrationBuilder.DropTable(
                name: "Procesos");

            migrationBuilder.DropTable(
                name: "ConfigProcesos");

            migrationBuilder.DropTable(
                name: "Analistas");

            migrationBuilder.DropTable(
                name: "Estados");
        }
    }
}

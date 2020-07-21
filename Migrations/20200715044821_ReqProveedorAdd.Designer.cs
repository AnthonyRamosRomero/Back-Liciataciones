﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto_Licitacion.Global.Config.DBContext;

namespace Proyecto_Licitacion.Migrations
{
    [DbContext(typeof(DBContextLic))]
    [Migration("20200715044821_ReqProveedorAdd")]
    partial class ReqProveedorAdd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.Adjunto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dml")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DocumentId")
                        .HasColumnType("int");

                    b.Property<int>("FolderId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserLogin")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Adjuntos");
                });

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.AdjuntoRondaProveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdjuntoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dml")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RondaProveedorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserLogin")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdjuntoId");

                    b.HasIndex("RondaProveedorId");

                    b.ToTable("AdjuntoRondaProveedores");
                });

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.Analista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dml")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Dni")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserLogin")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Analistas");
                });

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.AreaSolicitante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dml")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Encargado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserLogin")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AreaSolicitantes");
                });

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dml")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserLogin")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.ConfigProceso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnalistaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dml")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EstadoId")
                        .HasColumnType("int");

                    b.Property<string>("FechaAdjudicacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaTratamiento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserLogin")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnalistaId");

                    b.HasIndex("EstadoId");

                    b.ToTable("ConfigProcesos");
                });

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.DetalleRequerimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantidadSolicitada")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dml")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrecioTotalEstimado")
                        .HasColumnType("int");

                    b.Property<int>("PrecioUnitarioEstimado")
                        .HasColumnType("int");

                    b.Property<int?>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int?>("RequerimientoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserLogin")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.HasIndex("RequerimientoId");

                    b.ToTable("DetalleRequerimientos");
                });

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dml")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserLogin")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.Proceso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ConfigProcesoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dml")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoProceso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserLogin")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConfigProcesoId");

                    b.ToTable("Procesos");
                });

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dml")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnidadMedida")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserLogin")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contacto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dml")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroRuc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RazonSocial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserLogin")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.ReqProveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dml")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProveedorId")
                        .HasColumnType("int");

                    b.Property<int?>("RequerimientoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserLogin")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProveedorId");

                    b.HasIndex("RequerimientoId");

                    b.ToTable("ReqProveedor");
                });

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.Requerimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AreaSolicitanteId")
                        .HasColumnType("int");

                    b.Property<int?>("ConfigProcesoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dml")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaEstimadaEntrante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaSolicitud")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MontoReferencial")
                        .HasColumnType("float");

                    b.Property<string>("NotificarPostores")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TieneRFI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TieneVisitaCampo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TipoRequerimientoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserLogin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioSolicitante")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AreaSolicitanteId");

                    b.HasIndex("ConfigProcesoId");

                    b.HasIndex("TipoRequerimientoId");

                    b.ToTable("Requerimientos");
                });

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.Ronda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dml")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroRonda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProcesoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserLogin")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProcesoId");

                    b.ToTable("Rondas");
                });

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.RondaProveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dml")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProveedorId")
                        .HasColumnType("int");

                    b.Property<int?>("RondaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserLogin")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProveedorId");

                    b.HasIndex("RondaId");

                    b.ToTable("RondaProveedores");
                });

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.TipoRequerimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dml")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserLogin")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoRequerimientos");
                });

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnalistaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dml")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserLogin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnalistaId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.AdjuntoRondaProveedor", b =>
                {
                    b.HasOne("Proyecto_Licitacion.Models.Entities.Adjunto", "Adjunto")
                        .WithMany("AdjuntoRondaProveedores")
                        .HasForeignKey("AdjuntoId");

                    b.HasOne("Proyecto_Licitacion.Models.Entities.RondaProveedor", "RondaProveedor")
                        .WithMany("AdjuntoRondaProveedores")
                        .HasForeignKey("RondaProveedorId");
                });

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.ConfigProceso", b =>
                {
                    b.HasOne("Proyecto_Licitacion.Models.Entities.Analista", "Analista")
                        .WithMany("ConfigProcesos")
                        .HasForeignKey("AnalistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto_Licitacion.Models.Entities.Estado", "Estado")
                        .WithMany("ConfigProcesos")
                        .HasForeignKey("EstadoId");
                });

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.DetalleRequerimiento", b =>
                {
                    b.HasOne("Proyecto_Licitacion.Models.Entities.Producto", "Producto")
                        .WithMany("DetalleRequerimientos")
                        .HasForeignKey("ProductoId");

                    b.HasOne("Proyecto_Licitacion.Models.Entities.Requerimiento", "Requerimiento")
                        .WithMany("DetalleRequerimientos")
                        .HasForeignKey("RequerimientoId");
                });

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.Proceso", b =>
                {
                    b.HasOne("Proyecto_Licitacion.Models.Entities.ConfigProceso", "ConfigProceso")
                        .WithMany("Procesos")
                        .HasForeignKey("ConfigProcesoId");
                });

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.Producto", b =>
                {
                    b.HasOne("Proyecto_Licitacion.Models.Entities.Categoria", "Categoria")
                        .WithMany("Productos")
                        .HasForeignKey("CategoriaId");
                });

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.ReqProveedor", b =>
                {
                    b.HasOne("Proyecto_Licitacion.Models.Entities.Proveedor", "Proveedor")
                        .WithMany("ReqProveedors")
                        .HasForeignKey("ProveedorId");

                    b.HasOne("Proyecto_Licitacion.Models.Entities.Requerimiento", "Requerimiento")
                        .WithMany("ReqProveedors")
                        .HasForeignKey("RequerimientoId");
                });

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.Requerimiento", b =>
                {
                    b.HasOne("Proyecto_Licitacion.Models.Entities.AreaSolicitante", "AreaSolicitante")
                        .WithMany("Requerimientos")
                        .HasForeignKey("AreaSolicitanteId");

                    b.HasOne("Proyecto_Licitacion.Models.Entities.ConfigProceso", "ConfigProceso")
                        .WithMany("Requerimientos")
                        .HasForeignKey("ConfigProcesoId");

                    b.HasOne("Proyecto_Licitacion.Models.Entities.TipoRequerimiento", "TipoRequerimiento")
                        .WithMany("Requerimientos")
                        .HasForeignKey("TipoRequerimientoId");
                });

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.Ronda", b =>
                {
                    b.HasOne("Proyecto_Licitacion.Models.Entities.Proceso", "Proceso")
                        .WithMany("Rondas")
                        .HasForeignKey("ProcesoId");
                });

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.RondaProveedor", b =>
                {
                    b.HasOne("Proyecto_Licitacion.Models.Entities.Proveedor", "Proveedor")
                        .WithMany("RondaProveedores")
                        .HasForeignKey("ProveedorId");

                    b.HasOne("Proyecto_Licitacion.Models.Entities.Ronda", "Ronda")
                        .WithMany("RondaProveedores")
                        .HasForeignKey("RondaId");
                });

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.Usuario", b =>
                {
                    b.HasOne("Proyecto_Licitacion.Models.Entities.Analista", "analista")
                        .WithMany("Usuarios")
                        .HasForeignKey("AnalistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

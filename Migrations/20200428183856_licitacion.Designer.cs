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
    [Migration("20200428183856_licitacion")]
    partial class licitacion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<double>("PrecioTotalEstimado")
                        .HasColumnType("float");

                    b.Property<int>("PrecioUnitarioEstimado")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int>("RequerimientoId")
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

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaId")
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

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.Requerimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AreaSolicitanteId")
                        .HasColumnType("int");

                    b.Property<int>("ConfigProceso")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dml")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaEstimadaEntrega")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaSolicitud")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoRequerimientoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserLogin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioSolicitante")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AreaSolicitanteId");

                    b.HasIndex("TipoRequerimientoId");

                    b.ToTable("Requerimientos");
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

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.DetalleRequerimiento", b =>
                {
                    b.HasOne("Proyecto_Licitacion.Models.Entities.Producto", "Producto")
                        .WithMany("DetalleRequerimientos")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto_Licitacion.Models.Entities.Requerimiento", "Requerimiento")
                        .WithMany("DetalleRequerimientos")
                        .HasForeignKey("RequerimientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.Producto", b =>
                {
                    b.HasOne("Proyecto_Licitacion.Models.Entities.Categoria", "Categoria")
                        .WithMany("Productos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Proyecto_Licitacion.Models.Entities.Requerimiento", b =>
                {
                    b.HasOne("Proyecto_Licitacion.Models.Entities.AreaSolicitante", "AreaSolicitante")
                        .WithMany("Requerimientos")
                        .HasForeignKey("AreaSolicitanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto_Licitacion.Models.Entities.TipoRequerimiento", "TipoRequerimiento")
                        .WithMany("Requerimientos")
                        .HasForeignKey("TipoRequerimientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Proyecto_Licitacion.Models.Entities;

namespace Proyecto_Licitacion.Global.Config.DBContext
{
    public class DBContextLic : DbContext
    {
        public DBContextLic(DbContextOptions<DBContextLic> options) : base(options)
        {
        }

        /***ENTITIES***/
        public DbSet<Producto> Productos { get; set; }
        public DbSet<DetalleRequerimiento> DetalleRequerimientos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Requerimiento> Requerimientos { get; set; }
        public DbSet<TipoRequerimiento> TipoRequerimientos { get; set; }
        public DbSet<AreaSolicitante> AreaSolicitantes { get; set; }
        public DbSet<Analista> Analistas { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<ConfigProceso> ConfigProcesos { get; set; }
        public DbSet<Proceso> Procesos { get; set; }
        public DbSet<RondaProveedor> RondaProveedores { get; set; }
        public DbSet<AdjuntoRondaProveedor> AdjuntoRondaProveedores { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Adjunto> Adjuntos { get; set; }
        public DbSet<Ronda> Rondas { get; set; }


    }
}

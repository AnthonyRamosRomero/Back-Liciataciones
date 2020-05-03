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


    }
}

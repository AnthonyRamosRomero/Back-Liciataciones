using Microsoft.EntityFrameworkCore;
using Proyecto_Licitacion.Global.Config.DBContext;
using Proyecto_Licitacion.Models.Entities;
using Proyecto_Licitacion.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Licitacion.Services
{
    public class AdjuntoRondaProveedorService : IAdjuntoRondaProveedorService
    {
        private readonly DBContextLic dbContext;

        //Para inyectar el DBContext
        public AdjuntoRondaProveedorService(DBContextLic dbContext)
        {
            this.dbContext = dbContext;
        }



        /******************************************METHOD'S*******************************/
        public async Task<AdjuntoRondaProveedor> deleteById(int Id)
        {
            AdjuntoRondaProveedor adjuntorondaproveedor = findById(Id).Result;
            adjuntorondaproveedor.Dml = "D";
            dbContext.AdjuntoRondaProveedores.Update(adjuntorondaproveedor);
            await dbContext.SaveChangesAsync();
            return adjuntorondaproveedor;
        }

        public async Task<List<AdjuntoRondaProveedor>> finAll()
        {
            return await dbContext.AdjuntoRondaProveedores.ToListAsync();
        }

        public async Task<AdjuntoRondaProveedor> findById(int Id)
        {
            if (Id == null || Id == 0) return new AdjuntoRondaProveedor();
            AdjuntoRondaProveedor adjuntorondaproveedor = await dbContext.AdjuntoRondaProveedores.FindAsync(Id);
            return adjuntorondaproveedor;
        }

        public async Task<AdjuntoRondaProveedor> save(AdjuntoRondaProveedor adjuntorondaproveedor)
        {
            adjuntorondaproveedor.Dml = "I";
            adjuntorondaproveedor.UpDateTime = new DateTime();
            adjuntorondaproveedor.CreateTime = new DateTime();
            dbContext.AdjuntoRondaProveedores.Add(adjuntorondaproveedor);
            await dbContext.SaveChangesAsync();
            return adjuntorondaproveedor;
        }

        /********************MIGRATE DATA**********************/
        private const int ID = 0;
        private const int ADJUNTO = 1;
        private const int RONDA_PROVEEDOR = 2;

        public async Task<List<AdjuntoRondaProveedor>> migrateCsvData(string file)
        {
            List<AdjuntoRondaProveedor> colection = new List<AdjuntoRondaProveedor>();
            string[] st = System.IO.File.ReadAllLines(file);
            List<String> filas = st.ToList();
            filas
                .Where(fila => fila != filas[0])
                .ToList()
                .ForEach(fila =>
                {
                    string[] atributo = fila.Split(";");
                    AdjuntoRondaProveedor adjuntorondaproveedor = new AdjuntoRondaProveedor();
                    //tipoRequerimiento.Id = int.Parse(atributo[ID]);
                    adjuntorondaproveedor.AdjuntoId = int.Parse(atributo[ADJUNTO]);
                    adjuntorondaproveedor.RondaProveedorId = int.Parse(atributo[RONDA_PROVEEDOR]);
                    adjuntorondaproveedor.Dml = "I";
                    dbContext.AdjuntoRondaProveedores.AddAsync(adjuntorondaproveedor);
                    colection.Add(adjuntorondaproveedor);
                });
            await dbContext.SaveChangesAsync();
            return colection;
        }

    }
}

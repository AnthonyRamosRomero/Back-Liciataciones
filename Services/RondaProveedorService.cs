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
    public class RondaProveedorService : IRondaProveedorService
    {
        private readonly DBContextLic dbContext;

        //Para inyectar el DBContext
        public RondaProveedorService(DBContextLic dbContext)
        {
            this.dbContext = dbContext;
        }



        /******************************************METHOD'S*******************************/
        public async Task<RondaProveedor> deleteById(int Id)
        {
            RondaProveedor rondaproveedor = findById(Id).Result;
            rondaproveedor.Dml = "D";
            dbContext.RondaProveedores.Update(rondaproveedor);
            await dbContext.SaveChangesAsync();
            return rondaproveedor;
        }

        public async Task<List<RondaProveedor>> finAll()
        {
            return await dbContext.RondaProveedores.ToListAsync();
        }

        public async Task<RondaProveedor> findById(int Id)
        {
            if (Id == null || Id == 0) return new RondaProveedor();
            RondaProveedor rondaproveedor = await dbContext.RondaProveedores.FindAsync(Id);
            return rondaproveedor;
        }

        public async Task<RondaProveedor> save(RondaProveedor rondaproveedor)
        {
            rondaproveedor.Dml = "I";
            rondaproveedor.UpDateTime = new DateTime();
            rondaproveedor.CreateTime = new DateTime();
            dbContext.RondaProveedores.Add(rondaproveedor);
            await dbContext.SaveChangesAsync();
            return rondaproveedor;
        }

        /********************MIGRATE DATA**********************/
        private const int ID = 0;
        private const int RONDA = 1;
        private const int PROVEEDOR = 2;

        public async Task<List<RondaProveedor>> migrateCsvData(string file)
        {
            List<RondaProveedor> colection = new List<RondaProveedor>();
            string[] st = System.IO.File.ReadAllLines(file);
            List<String> filas = st.ToList();
            filas
                .Where(fila => fila != filas[0])
                .ToList()
                .ForEach(fila =>
                {
                    string[] atributo = fila.Split(";");
                    RondaProveedor rondaproveedor = new RondaProveedor();
                    //tipoRequerimiento.Id = int.Parse(atributo[ID]);
                    rondaproveedor.RondaId = int.Parse(atributo[RONDA]);
                    rondaproveedor.ProveedorId = int.Parse(atributo[PROVEEDOR]);
                    rondaproveedor.Dml = "I";
                    dbContext.RondaProveedores.AddAsync(rondaproveedor);
                    colection.Add(rondaproveedor);
                });
            await dbContext.SaveChangesAsync();
            return colection;
        }

    }
}

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

    public class DetalleRequerimientoService : IDetalleRequerimientoService
    {
        private readonly DBContextLic dbContext;

        //Para inyectar el DBContext
        public DetalleRequerimientoService(DBContextLic dbContext)
        {
            this.dbContext = dbContext;
        }



        /******************************************METHOD'S*******************************/
        public async Task<DetalleRequerimiento> deleteById(int Id)
        {
            DetalleRequerimiento detallerequerimiento = findById(Id).Result;
            detallerequerimiento.Dml = "D";
            dbContext.DetalleRequerimientos.Update(detallerequerimiento);
            await dbContext.SaveChangesAsync();
            return detallerequerimiento;
        }

        public async Task<List<DetalleRequerimiento>> finAll()
        {
            return await dbContext.DetalleRequerimientos.ToListAsync();
        }

        public async Task<DetalleRequerimiento> findById(int Id)
        {
            if(Id == null || Id == 0) return new DetalleRequerimiento();
            DetalleRequerimiento detallerequerimiento = await dbContext.DetalleRequerimientos.FindAsync(Id);
            return detallerequerimiento;
        }

        public async Task<DetalleRequerimiento> save(DetalleRequerimiento detallerequerimiento)
        {
            
                detallerequerimiento.Dml = "I";
                detallerequerimiento.UpDateTime = new DateTime();
                detallerequerimiento.CreateTime = new DateTime();
                dbContext.DetalleRequerimientos.Add(detallerequerimiento);
            await dbContext.SaveChangesAsync();
            return detallerequerimiento;
        }

    }
}

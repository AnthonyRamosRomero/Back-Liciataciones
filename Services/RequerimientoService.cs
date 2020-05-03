using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto_Licitacion.Global.Config.DBContext;
using Proyecto_Licitacion.Models.Entities;
using Proyecto_Licitacion.Services.Interfaces;

namespace Proyecto_Licitacion.Services
{
    public class RequerimientoService : IRequerimientoService
    {
        private readonly DBContextLic dbContext;

        //Para inyectar el DBContext
        public RequerimientoService(DBContextLic dbContext)
        {
            this.dbContext = dbContext;
        }



        /******************************************METHOD'S*******************************/
        public async Task<Requerimiento> deleteById(int Id)
        {
            Requerimiento requerimiento = findById(Id).Result;
            requerimiento.Dml = "D";
            dbContext.Requerimientos.Update(requerimiento);
            await dbContext.SaveChangesAsync();
            return requerimiento;
        }

        public async Task<List<Requerimiento>> finAll()
        {
            return await dbContext.Requerimientos.ToListAsync();
        }

        public async Task<Requerimiento> findById(int Id)
        {
            if(Id == null || Id == 0) return new Requerimiento();
            Requerimiento requerimiento = await dbContext.Requerimientos.FindAsync(Id);
            return requerimiento;
        }

        public async Task<Requerimiento> save(Requerimiento requerimiento)
        {
            
                requerimiento.Dml = "I";
                requerimiento.UpDateTime = new DateTime();
                requerimiento.CreateTime = new DateTime();
                dbContext.Requerimientos.Add(requerimiento);
            await dbContext.SaveChangesAsync();
            return requerimiento;
        }

    }
}

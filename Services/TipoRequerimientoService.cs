using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto_Licitacion.Global.Config.DBContext;
using Proyecto_Licitacion.Models.Dto;
using Proyecto_Licitacion.Models.Entities;
using Proyecto_Licitacion.Services.Interfaces;

namespace Proyecto_Licitacion.Services
{
    public class TipoRequerimientoService : ITipoRequerimientoService
    {
        private readonly DBContextLic dbContext;

        //Para inyectar el DBContext
        public TipoRequerimientoService(DBContextLic dbContext)
        {
            this.dbContext = dbContext;
        }



        /******************************************METHOD'S*******************************/
        public async Task<TipoRequerimiento> deleteById(int Id)
        {
            TipoRequerimiento tiporequerimiento = findById(Id).Result;
            tiporequerimiento.Dml = "D";
            dbContext.TipoRequerimientos.Update(tiporequerimiento);
            await dbContext.SaveChangesAsync();
            return tiporequerimiento;
        }

        public async Task<List<TipoRequerimiento>> finAll()
        {
            return await dbContext.TipoRequerimientos.ToListAsync();
        }

        public async Task<TipoRequerimiento> findById(int Id)
        {
            if(Id == null || Id == 0) return new TipoRequerimiento();
            TipoRequerimiento tiporequerimiento = await dbContext.TipoRequerimientos.FindAsync(Id);
            return tiporequerimiento;
        }

        public async Task<TipoRequerimiento> save(TipoRequerimiento tiporequerimiento)
        {
            
                tiporequerimiento.Dml = "I";
                tiporequerimiento.UpDateTime = new DateTime();
                tiporequerimiento.CreateTime = new DateTime();
                dbContext.TipoRequerimientos.Add(tiporequerimiento);
            await dbContext.SaveChangesAsync();
            return tiporequerimiento;
        }

        /********************MIGRATE DATA**********************/

        private const int ID = 0;
        private const int DESCRIPCION = 1;

        public async Task<List<TipoRequerimiento>> migrateCsvData(string file)
        { 
            List<TipoRequerimiento> colection = new List<TipoRequerimiento>();
            string[] st = System.IO.File.ReadAllLines(file);
            List<String> filas = st.ToList();
            filas
                .Where(fila => fila != filas[0])
                .ToList()
                .ForEach(fila =>
                {
                        string[] atributo = fila.Split(";");
                        TipoRequerimiento tipoRequerimiento = new TipoRequerimiento();
                        //tipoRequerimiento.Id = int.Parse(atributo[ID]);
                        tipoRequerimiento.Descripcion = atributo[DESCRIPCION];
                        tipoRequerimiento.Dml = "I";
                        dbContext.TipoRequerimientos.AddAsync(tipoRequerimiento);
                        colection.Add(tipoRequerimiento);
                });
            await dbContext.SaveChangesAsync();
            return colection;
        }
    }
}

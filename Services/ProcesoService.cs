using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto_Licitacion.Global.Config.DBContext;
using Proyecto_Licitacion.Models.Entities;
using Proyecto_Licitacion.Services.Interfaces;

namespace Proyecto_Licitacion.Services
{
    public class ProcesoService : IProcesoService
    {
        private readonly DBContextLic dbContext;

        //Para inyectar el DBContext
        public ProcesoService(DBContextLic dbContext)
        {
            this.dbContext = dbContext;
        }



        /******************************************METHOD'S*******************************/
        public async Task<Proceso> deleteById(int Id)
        {
            Proceso proceso = findById(Id).Result;
            proceso.Dml = "D";
            dbContext.Procesos.Update(proceso);
            await dbContext.SaveChangesAsync();
            return proceso;
        }

        public async Task<List<Proceso>> finAll()
        {
            return await dbContext.Procesos.ToListAsync();
        }

        public async Task<Proceso> findById(int Id)
        {
            if(Id == null || Id == 0) return new Proceso();
            Proceso proceso = await dbContext.Procesos.FindAsync(Id);
            return proceso;
        }

        public async Task<Proceso> save(Proceso proceso)
        {
            
                proceso.Dml = "I";
                proceso.UpDateTime = new DateTime();
                proceso.CreateTime = new DateTime();
                dbContext.Procesos.Add(proceso);
            await dbContext.SaveChangesAsync();
            return proceso;
        }
        /********************MIGRATE DATA**********************/
        private const int ID = 0;
        private const int CONFIGPROCESO = 1;
        private const int TIPO_PROCESO = 2;
        public async Task<List<Proceso>> migrateCsvData(string file)
        {
            List<Proceso> colection = new List<Proceso>();
            string[] st = System.IO.File.ReadAllLines(file);
            List<String> filas = st.ToList();
            filas
                .Where(fila => fila != filas[0])
                .ToList()
                .ForEach(fila =>
                {
                    string[] atributo = fila.Split(";");
                    Proceso proceso = new Proceso();
                    //tipoRequerimiento.Id = int.Parse(atributo[ID]);
                    proceso.ConfigProcesoId =int.Parse(atributo[CONFIGPROCESO]);
                    proceso.TipoProceso =atributo[TIPO_PROCESO];
                    proceso.Dml = "I";
                    dbContext.Procesos.AddAsync(proceso);
                    colection.Add(proceso);
                });
            await dbContext.SaveChangesAsync();
            return colection;
        }


    }
}

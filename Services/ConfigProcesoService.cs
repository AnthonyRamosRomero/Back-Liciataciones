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
    public class ConfigProcesoService : IConfigProcesoService
    {
        private readonly DBContextLic dbContext;

        //Para inyectar el DBContext
        public ConfigProcesoService(DBContextLic dbContext)
        {
            this.dbContext = dbContext;
        }



        /******************************************METHOD'S*******************************/
        public async Task<ConfigProceso> deleteById(int Id)
        {
            ConfigProceso configProceso = findById(Id).Result;
            configProceso.Dml = "D";
            dbContext.ConfigProcesos.Update(configProceso);
            await dbContext.SaveChangesAsync();
            return configProceso;
        }

        public async Task<List<ConfigProceso>> finAll()
        {
            return await dbContext.ConfigProcesos.ToListAsync();
        }

        public async Task<ConfigProceso> findById(int Id)
        {
            if (Id == null || Id == 0) return new ConfigProceso();
            ConfigProceso configProceso = await dbContext.ConfigProcesos.FindAsync(Id);
            return configProceso;
        }

   
   

        public async Task<ConfigProceso> save(ConfigProceso configProceso, int idRequerimiento)
        {
            configProceso.Dml = "I";
            configProceso.UpDateTime = new DateTime();
            configProceso.CreateTime = new DateTime();
            configProceso.FechaTratamiento = new DateTime().ToString();
            dbContext.ConfigProcesos.Add(configProceso);
            await dbContext.SaveChangesAsync();

            /*Relacionarlo con la tabla requerimiento*/
            Requerimiento requerimiento = dbContext.Requerimientos.FindAsync(idRequerimiento).Result;
            

            dbContext.Requerimientos.Update(requerimiento);
            await dbContext.SaveChangesAsync();
            return configProceso;

        }
        /********************MIGRATE DATA**********************/
        private const int ID = 0;
        private const int ANALISTA = 1;
        private const int ESTADO = 2;
        private const int FECHA_TRATAMIENTO = 3;
        private const int FECHA_ADJUDICACION = 4;
        public async Task<List<ConfigProceso>> migrateCsvData(string file)
        {
            List<ConfigProceso> colection = new List<ConfigProceso>();
            string[] st = System.IO.File.ReadAllLines(file);
            List<String> filas = st.ToList();
            filas
                .Where(fila => fila != filas[0])
                .ToList()
                .ForEach(fila =>
                {
                    string[] atributo = fila.Split(";");
                    ConfigProceso configProceso = new ConfigProceso();
                    //tipoRequerimiento.Id = int.Parse(atributo[ID]);
                    configProceso.AnalistaId = int.Parse(atributo[ANALISTA]);
                    configProceso.EstadoId = int.Parse(atributo[ESTADO]);
                    configProceso.FechaTratamiento = atributo[FECHA_TRATAMIENTO];
                    configProceso.Dml = "I";
                    dbContext.ConfigProcesos.AddAsync(configProceso);
                    colection.Add(configProceso);
                });
            await dbContext.SaveChangesAsync();
            return colection;
        }

    }
}

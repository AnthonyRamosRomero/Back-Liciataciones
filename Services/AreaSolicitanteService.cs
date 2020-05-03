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
    public class AreaSolicitanteService : IAreaSolicitanteService
    {
        private readonly DBContextLic dbContext;

        //Para inyectar el DBContext
        public AreaSolicitanteService(DBContextLic dbContext)
        {
            this.dbContext = dbContext;
        }



        /******************************************METHOD'S*******************************/
        public async Task<AreaSolicitante> deleteById(int Id)
        {
            AreaSolicitante areasolicitante = findById(Id).Result;
            areasolicitante.Dml = "D";
            dbContext.AreaSolicitantes.Update(areasolicitante);
            await dbContext.SaveChangesAsync();
            return areasolicitante;
        }

        public async Task<List<AreaSolicitante>> finAll()
        {
            return await dbContext.AreaSolicitantes.ToListAsync();
        }

        public async Task<AreaSolicitante> findById(int Id)
        {
            if(Id == null || Id == 0) return new AreaSolicitante();
            AreaSolicitante areasolicitante = await dbContext.AreaSolicitantes.FindAsync(Id);
            return areasolicitante;
        }


        public async Task<AreaSolicitante> save(AreaSolicitante areasolicitante)
        {
            
                areasolicitante.Dml = "I";
                areasolicitante.UpDateTime = new DateTime();
                areasolicitante.CreateTime = new DateTime();
                dbContext.AreaSolicitantes.Add(areasolicitante);
            await dbContext.SaveChangesAsync();
            return areasolicitante;
        }

        /********************MIGRATE DATA**********************/
        public const int ID = 0;
        public const int NOMBRE = 1;
        public const int ENCARGADO = 2;
        public async Task<List<AreaSolicitante>> migrateCsvData(string file)
        {
            List<AreaSolicitante> colection = new List<AreaSolicitante>();
            string[] st = System.IO.File.ReadAllLines(file);
            List<String> filas = st.ToList();
            filas
                .Where(fila => fila != filas[0])
                .ToList()
                .ForEach(fila =>
                {
                    string[] atributo = fila.Split(";");
                    AreaSolicitante areaSolicitante = new AreaSolicitante();
                    //tipoRequerimiento.Id = int.Parse(atributo[ID]);
                    areaSolicitante.Nombre = atributo[NOMBRE];
                    areaSolicitante.Encargado = atributo[ENCARGADO];
                    areaSolicitante.Dml = "I";
                    dbContext.AreaSolicitantes.AddAsync(areaSolicitante);
                    colection.Add(areaSolicitante);
                });
            await dbContext.SaveChangesAsync();
            return colection;
        }

    }
}

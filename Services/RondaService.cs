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
    public class RondaService : IRondaService
    {
        private readonly DBContextLic dbContext;

        //Para inyectar el DBContext
        public RondaService(DBContextLic dbContext)
        {
            this.dbContext = dbContext;
        }



        /******************************************METHOD'S*******************************/
        public async Task<Ronda> deleteById(int Id)
        {
            Ronda ronda = findById(Id).Result;
            ronda.Dml = "D";
            dbContext.Rondas.Update(ronda);
            await dbContext.SaveChangesAsync();
            return ronda;
        }

        public async Task<List<Ronda>> finAll()
        {
            return await dbContext.Rondas.ToListAsync();
        }

        public async Task<Ronda> findById(int Id)
        {
            if (Id == null || Id == 0) return new Ronda();
            Ronda ronda = await dbContext.Rondas.FindAsync(Id);
            return ronda;
        }

        public async Task<Ronda> save(Ronda ronda)
        {
            ronda.Dml = "I";
            ronda.UpDateTime = new DateTime();
            ronda.CreateTime = new DateTime();
            dbContext.Rondas.Add(ronda);
            await dbContext.SaveChangesAsync();
            return ronda;
        }

        /********************MIGRATE DATA**********************/
        private const int ID = 0;
        private const int PROCESO = 1;
        private const int NUMERO_RONDA = 2;

        public async Task<List<Ronda>> migrateCsvData(string file)
        {
            List<Ronda> colection = new List<Ronda>();
            string[] st = System.IO.File.ReadAllLines(file);
            List<String> filas = st.ToList();
            filas
                .Where(fila => fila != filas[0])
                .ToList()
                .ForEach(fila =>
                {
                    string[] atributo = fila.Split(";");
                    Ronda ronda = new Ronda();
                    //tipoRequerimiento.Id = int.Parse(atributo[ID]);
                    ronda.ProcesoId = int.Parse(atributo[PROCESO]);
                    ronda.NumeroRonda = atributo[NUMERO_RONDA];
                    ronda.Dml = "I";
                    dbContext.Rondas.AddAsync(ronda);
                    colection.Add(ronda);
                });
            await dbContext.SaveChangesAsync();
            return colection;
        }

    }
}

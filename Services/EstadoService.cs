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
    public class EstadoService : IEstadoService
    {
        private readonly DBContextLic dbContext;

        //Para inyectar el DBContext
        public EstadoService(DBContextLic dbContext)
        {
            this.dbContext = dbContext;
        }



        /******************************************METHOD'S*******************************/
        public async Task<Estado> deleteById(int Id)
        {
            Estado estado = findById(Id).Result;
            estado.Dml = "D";
            dbContext.Estados.Update(estado);
            await dbContext.SaveChangesAsync();
            return estado;
        }

        public async Task<List<Estado>> finAll()
        {
            return await dbContext.Estados.ToListAsync();
        }

        public async Task<Estado> findById(int Id)
        {
            if(Id == null || Id == 0) return new Estado();
            Estado estado = await dbContext.Estados.FindAsync(Id);
            return estado;
        }

        public async Task<Estado> save(Estado estado)
        {
            
                estado.Dml = "I";
                estado.UpDateTime = new DateTime();
                estado.CreateTime = new DateTime();
                dbContext.Estados.Add(estado);
            await dbContext.SaveChangesAsync();
            return estado;
        }
        /********************MIGRATE DATA**********************/
        private const int ID = 0;
        private const int DESCRIPCION = 1;
        public async Task<List<Estado>> migrateCsvData(string file)
        {
            List<Estado> colection = new List<Estado>();
            string[] st = System.IO.File.ReadAllLines(file);
            List<String> filas = st.ToList();
            filas
                .Where(fila => fila != filas[0])
                .ToList()
                .ForEach(fila =>
                {
                    string[] atributo = fila.Split(";");
                    Estado estado = new Estado();
                    //tipoRequerimiento.Id = int.Parse(atributo[ID]);
                    estado.Descripcion = atributo[DESCRIPCION];
                    estado.Dml = "I";
                    dbContext.Estados.AddAsync(estado);
                    colection.Add(estado);
                });
            await dbContext.SaveChangesAsync();
            return colection;
        }


    }
}

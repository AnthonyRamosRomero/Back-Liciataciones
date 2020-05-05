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
    public class AdjuntoService : IAdjuntoService
    {
        private readonly DBContextLic dbContext;

        //Para inyectar el DBContext
        public AdjuntoService(DBContextLic dbContext)
        {
            this.dbContext = dbContext;
        }



        /******************************************METHOD'S*******************************/
        public async Task<Adjunto> deleteById(int Id)
        {
           Adjunto adjunto = findById(Id).Result;
            adjunto.Dml = "D";
            dbContext.Adjuntos.Update(adjunto);
            await dbContext.SaveChangesAsync();
            return adjunto;
        }

        public async Task<List<Adjunto>> finAll()
        {
            return await dbContext.Adjuntos.ToListAsync();
        }

        public async Task<Adjunto> findById(int Id)
        {
            if (Id == null || Id == 0) return new Adjunto();
            Adjunto adjunto = await dbContext.Adjuntos.FindAsync(Id);
            return adjunto;
        }

        public async Task<Adjunto> save(Adjunto adjunto)
        {
            adjunto.Dml = "I";
            adjunto.UpDateTime = new DateTime();
            adjunto.CreateTime = new DateTime();
            dbContext.Adjuntos.Add(adjunto);
            await dbContext.SaveChangesAsync();
            return adjunto;
        }


        /********************MIGRATE DATA**********************/
        private const int ID = 0;
        private const int PATH = 1;
        private const int FOLDER = 2;
        private const int DOCUMENT = 0;
        private const int NOMBRE = 1;
        private const int DESCRIPCION = 2;
        private const int CONTENT_TYPE = 2;

        public async Task<List<Adjunto>> migrateCsvData(string file)
        {
            List<Adjunto> colection = new List<Adjunto>();
            string[] st = System.IO.File.ReadAllLines(file);
            List<String> filas = st.ToList();
            filas
                .Where(fila => fila != filas[0])
                .ToList()
                .ForEach(fila =>
                {
                    string[] atributo = fila.Split(";");
                    Adjunto adjunto = new Adjunto();
                    //tipoRequerimiento.Id = int.Parse(atributo[ID]);
                    adjunto.Path = atributo[PATH];
                    adjunto.FolderId = int.Parse(atributo[FOLDER]);
                    adjunto.DocumentId = int.Parse(atributo[DOCUMENT]);
                    adjunto.Nombre = atributo[NOMBRE];
                    adjunto.Descripcion = atributo[DESCRIPCION];
                    adjunto.ContentType = atributo[CONTENT_TYPE];
                    adjunto.Dml = "I";
                    dbContext.Adjuntos.AddAsync(adjunto);
                    colection.Add(adjunto);
                });
            await dbContext.SaveChangesAsync();
            return colection;
        }

    }
}

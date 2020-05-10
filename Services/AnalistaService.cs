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
    public class AnalistaService : IAnalistaService
    {
        private readonly DBContextLic dbContext;

        //Para inyectar el DBContext
        public AnalistaService(DBContextLic dbContext)
        {
            this.dbContext = dbContext;
        }



        /******************************************METHOD'S*******************************/
        public async Task<Analista> deleteById(int Id)
        {
            Analista analista = findById(Id).Result;
            analista.Dml = "D";
            dbContext.Analistas.Update(analista);
            await dbContext.SaveChangesAsync();
            return analista;
        }

        public async Task<List<Analista>> finAll()
        {
            return await dbContext.Analistas.ToListAsync();
        }

        public async Task<Analista> findById(int Id)
        {
            if (Id == null || Id == 0) return new Analista();
            Analista analista = await dbContext.Analistas.FindAsync(Id);
            return analista;
        }

        public async Task<Analista> save(Analista analista)
        {

            analista.Dml = "I";
            analista.UpDateTime = new DateTime();
            analista.CreateTime = new DateTime();
            dbContext.Analistas.Add(analista);
            await dbContext.SaveChangesAsync();
            return analista;
        }

    /********************MIGRATE DATA**********************/
    private const int ID = 0;
    private const int NOMBRE = 1;
    private const int APELLIDOS = 2;
    private const int DNI = 3;
    private const int TELEFONO = 4;
    private const int CORREO = 5;
    private const int DIRECCION = 6;
    public async Task<List<Analista>> migrateCsvData(string file)
    {
        List<Analista> colection = new List<Analista>();
        string[] st = System.IO.File.ReadAllLines(file);
        List<String> filas = st.ToList();
        filas
            .Where(fila => fila != filas[0])
            .ToList()
            .ForEach(fila =>
            {
                string[] atributo = fila.Split(";");
                Analista analista = new Analista();
                    //tipoRequerimiento.Id = int.Parse(atributo[ID]);
                analista.Nombre = atributo[NOMBRE];
                analista.Apellido = atributo[APELLIDOS];
                analista.Dni = int.Parse(atributo[DNI]);
                analista.Telefono = int.Parse(atributo[TELEFONO]);
                analista.Correo = atributo[CORREO];
                analista.Direccion = atributo[DIRECCION];
                analista.Dml = "I";
                dbContext.Analistas.AddAsync(analista);
                colection.Add(analista);
            });
        await dbContext.SaveChangesAsync();
        return colection;
    }
}
}

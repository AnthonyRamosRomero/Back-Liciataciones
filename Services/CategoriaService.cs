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
    public class CategoriaService : ICategoriaService
    {
        private readonly DBContextLic dbContext;

        //Para inyectar el DBContext
        public CategoriaService(DBContextLic dbContext)
        {
            this.dbContext = dbContext;
        }



        /******************************************METHOD'S*******************************/
        public async Task<Categoria> deleteById(int Id)
        {
           Categoria categoria = findById(Id).Result;
            categoria.Dml = "D";
            dbContext.Categorias.Update(categoria);
            await dbContext.SaveChangesAsync();
            return categoria;
        }

        public async Task<List<Categoria>> finAll()
        {
            return await dbContext.Categorias.ToListAsync();
        }

        public async Task<Categoria> findById(int Id)
        {
            if (Id == null || Id == 0) return new Categoria();
            Categoria categoria = await dbContext.Categorias.FindAsync(Id);
            return categoria;
        }

        public async Task<Categoria> save(Categoria categoria)
        {
            categoria.Dml = "I";
            categoria.UpDateTime = new DateTime();
            categoria.CreateTime = new DateTime();
            dbContext.Categorias.Add(categoria);
            await dbContext.SaveChangesAsync();
            return categoria;
        }

        /********************MIGRATE DATA**********************/
        private const int ID = 0;
        private const int NOMBRE = 1;
        private const int DESCRIPCION = 2;
        public async Task<List<Categoria>> migrateCsvData(string file)
        {
            List<Categoria> colection = new List<Categoria>();
            string[] st = System.IO.File.ReadAllLines(file);
            List<String> filas = st.ToList();
            filas
                .Where(fila => fila != filas[0])
                .ToList()
                .ForEach(fila =>
                {
                    string[] atributo = fila.Split(";");
                    Categoria categoria = new Categoria();
                    //tipoRequerimiento.Id = int.Parse(atributo[ID]);
                    categoria.Nombre = atributo[NOMBRE];
                    categoria.Descripcion = atributo[DESCRIPCION];
                    categoria.Dml = "I";
                    dbContext.Categorias.AddAsync(categoria);
                    colection.Add(categoria);
                });
            await dbContext.SaveChangesAsync();
            return colection;
        }

    }
}

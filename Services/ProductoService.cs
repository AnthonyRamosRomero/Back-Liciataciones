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
    public class ProductoService : IProductoService
    {
        private readonly DBContextLic dbContext;

        //Para inyectar el DBContext
        public ProductoService(DBContextLic dbContext)
        {
            this.dbContext = dbContext;
        }



        /******************************************METHOD'S*******************************/
        public async Task<Producto> deleteById(int Id)
        {
            Producto producto = findById(Id).Result;
            producto.Dml = "D";
            dbContext.Productos.Update(producto);
            await dbContext.SaveChangesAsync();
            return producto;
        }

        public async Task<List<Producto>> finAll()
        {
            return await dbContext.Productos.ToListAsync();
        }

        public async Task<Producto> findById(int Id)
        {
            if(Id == null || Id == 0) return new Producto();
            Producto producto = await dbContext.Productos.FindAsync(Id);
            return producto;
        }

        public async Task<Producto> save(Producto producto)
        {
            
                producto.Dml = "I";
                producto.UpDateTime = new DateTime();
                producto.CreateTime = new DateTime();
                dbContext.Productos.Add(producto);
            await dbContext.SaveChangesAsync();
            return producto;
        }

        /********************MIGRATE DATA**********************/
        private const int ID = 0;
        private const int NOMBRE = 1;
        private const int UNIDAD_MEDIDA = 2;
        private const int DESCRIPCION = 3;
        private const int CATEGORIA = 4;
        public async Task<List<Producto>> migrateCsvData(string file)
        {
            List<Producto> colection = new List<Producto>();
            string[] st = System.IO.File.ReadAllLines(file);
            List<String> filas = st.ToList();
            filas
                .Where(fila => fila != filas[0])
                .ToList()
                .ForEach(fila =>
                {
                    string[] atributo = fila.Split(";");
                    Producto producto = new Producto();
                    //tipoRequerimiento.Id = int.Parse(atributo[ID]);
                    producto.Nombre = atributo[NOMBRE];
                    producto.CategoriaId = int.Parse(atributo[CATEGORIA]);
                    producto.Descripcion = atributo[DESCRIPCION];
                    producto.UnidadMedida = atributo[UNIDAD_MEDIDA];
                    producto.Dml = "I";
                    dbContext.Productos.AddAsync(producto);
                    colection.Add(producto);
                });
            await dbContext.SaveChangesAsync();
            return colection;
        }
    }
}

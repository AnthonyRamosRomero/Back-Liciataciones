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

    public class DetalleRequerimientoService : IDetalleRequerimientoService
    {
        private readonly DBContextLic dbContext;

        //Para inyectar el DBContext
        public DetalleRequerimientoService(DBContextLic dbContext)
        {
            this.dbContext = dbContext;
        }



        /******************************************METHOD'S*******************************/
        public async Task<DetalleRequerimiento> deleteById(int Id)
        {
            DetalleRequerimiento detallerequerimiento = findById(Id).Result;
            detallerequerimiento.Dml = "D";
            dbContext.DetalleRequerimientos.Update(detallerequerimiento);
            await dbContext.SaveChangesAsync();
            return detallerequerimiento;
        }

        public async Task<List<DetalleRequerimiento>> finAll()
        {
            return await dbContext
                        .DetalleRequerimientos
                        .Include(o => o.Producto)
                        .Include(o => o.Requerimiento)
                        .ToListAsync();
        }

        public async Task<DetalleRequerimiento> findById(int Id)
        {
            if(Id == null || Id == 0) return new DetalleRequerimiento();
            DetalleRequerimiento detallerequerimiento = await dbContext.DetalleRequerimientos.FindAsync(Id);
            return detallerequerimiento;
        }

        public async Task<DetalleRequerimiento> save(DetalleRequerimiento detallerequerimiento)
        {
            detallerequerimiento.Dml = "I";
                detallerequerimiento.UpDateTime = new DateTime();
                detallerequerimiento.CreateTime = new DateTime();
                dbContext.DetalleRequerimientos.Add(detallerequerimiento);
            await dbContext.SaveChangesAsync();
            return detallerequerimiento;
        }


        public async Task<List<DetalleRequerimiento>> save(List<DetalleRequerimiento> list)
        {
            List<DetalleRequerimiento> response = new List<DetalleRequerimiento>();
            list.ForEach(data =>
            {
                DetalleRequerimiento detallerequerimiento = new DetalleRequerimiento();
                detallerequerimiento.Dml = "I";
                detallerequerimiento.UpDateTime = new DateTime();
                detallerequerimiento.CreateTime = new DateTime();
                dbContext.DetalleRequerimientos.Add(detallerequerimiento);
                response.Add(detallerequerimiento);
            });
            await dbContext.SaveChangesAsync();
            return response;
        }


        /********************MIGRATE DATA**********************/
        private const int ID = 0;
        private const int REQUERIMIENTO = 1;
        private const int PRODUCTO = 2;
        private const int CANTIDAD_SOLICITADA = 3;
        private const int PRECIO_UNITARIO_ESTIMADO = 4;
        private const int PRECIO_TOTAL_ESTIMADO = 5;
        public async Task<List<DetalleRequerimiento>> migrateCsvData(string file)
        {
            List<DetalleRequerimiento> colection = new List<DetalleRequerimiento>();
            string[] st = System.IO.File.ReadAllLines(file);
            List<String> filas = st.ToList();
            filas
                .Where(fila => fila != filas[0])
                .ToList()
                .ForEach(fila =>
                {
                    string[] atributo = fila.Split(";");
                    DetalleRequerimiento detalleRequerimiento = new DetalleRequerimiento();
                    //tipoRequerimiento.Id = int.Parse(atributo[ID]);
                    detalleRequerimiento.ProductoId = int.Parse(atributo[PRODUCTO]);
                    detalleRequerimiento.RequerimientoId = int.Parse(atributo[REQUERIMIENTO]);
                    detalleRequerimiento.CantidadSolicitada = int.Parse(atributo[CANTIDAD_SOLICITADA]);
                    detalleRequerimiento.PrecioUnitarioEstimado = int.Parse(atributo[PRECIO_UNITARIO_ESTIMADO]);
                    detalleRequerimiento.PrecioTotalEstimado = int.Parse(atributo[PRECIO_TOTAL_ESTIMADO]);
                    detalleRequerimiento.Dml = "I";
                    dbContext.DetalleRequerimientos.AddAsync(detalleRequerimiento);
                    colection.Add(detalleRequerimiento);
                });
            await dbContext.SaveChangesAsync();
            return colection;
        }

    }

}


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
    public class ProveedorService : IProveedorService
    {
        private readonly DBContextLic dbContext;

        //Para inyectar el DBContext
        public ProveedorService(DBContextLic dbContext)
        {
            this.dbContext = dbContext;
        }



        /******************************************METHOD'S*******************************/
        public async Task<Proveedor> deleteById(int Id)
        {
            Proveedor proveedor = findById(Id).Result;
            proveedor.Dml = "D";
            dbContext.Proveedores.Update(proveedor);
            await dbContext.SaveChangesAsync();
            return proveedor;
        }

        public async Task<List<Proveedor>> finAll()
        {
            return await dbContext.Proveedores.ToListAsync();
        }

        public async Task<Proveedor> findById(int Id)
        {
            if (Id == null || Id == 0) return new Proveedor();
            Proveedor proveedor = await dbContext.Proveedores.FindAsync(Id);
            return proveedor;
        }

        public async Task<Proveedor> save(Proveedor proveedor)
        {
            proveedor.Dml = "I";
            proveedor.UpDateTime = new DateTime();
            proveedor.CreateTime = new DateTime();
            dbContext.Proveedores.Add(proveedor);
            await dbContext.SaveChangesAsync();
            return proveedor;
        }


        /********************MIGRATE DATA**********************/

        private const int ID = 0;
        private const int RAZON_SOCIAL = 1;
        private const int NUMERO_RUC = 2;
        private const int MAILS = 3;
        private const int TEL = 4;
        private const int DIRECCION = 5;
        private const int CONTACTO = 6;

        public async Task<List<Proveedor>> migrateCsvData(string file)
        {
            List<Proveedor> colection = new List<Proveedor>();
            string[] st = System.IO.File.ReadAllLines(file);
            List<String> filas = st.ToList();
            filas
                .Where(fila => fila != filas[0])
                .ToList()
                .ForEach(fila =>
                {
                    string[] atributo = fila.Split(";");
                    Proveedor proveedor = new Proveedor();
                    //tipoRequerimiento.Id = int.Parse(atributo[ID]);
                    proveedor.RazonSocial = atributo[RAZON_SOCIAL];
                    proveedor.NumeroRuc = atributo[NUMERO_RUC];
                    proveedor.Mails = atributo[MAILS];
                    proveedor.Tel = atributo[TEL];
                    proveedor.Direccion = atributo[DIRECCION];
                    proveedor.Contacto = atributo[CONTACTO];
                    proveedor.Dml = "I";
                    dbContext.Proveedores.AddAsync(proveedor);
                    colection.Add(proveedor);
                });
            await dbContext.SaveChangesAsync();
            return colection;
        }

    }
}

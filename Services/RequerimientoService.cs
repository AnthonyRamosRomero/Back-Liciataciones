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
    public class RequerimientoService : IRequerimientoService
    {
        private readonly DBContextLic dbContext;

        //Para inyectar el DBContext
        public RequerimientoService(DBContextLic dbContext)
        {
            this.dbContext = dbContext;
        }



        /******************************************METHOD'S*******************************/
        public async Task<Requerimiento> deleteById(int Id)
        {
            Requerimiento requerimiento = findById(Id).Result;
            requerimiento.Dml = "D";
            dbContext.Requerimientos.Update(requerimiento);
            await dbContext.SaveChangesAsync();
            return requerimiento;
        }

        public async Task<List<Requerimiento>> finAll()
        {
            return await dbContext
                        .Requerimientos
                        .Include(o => o.AreaSolicitante)
                        .Include(o => o.TipoRequerimiento)
                        .ToListAsync();
        }

        public async Task<Requerimiento> findById(int Id)
        {
            if(Id == null || Id == 0) return new Requerimiento();
            Requerimiento requerimiento = await dbContext.Requerimientos.FindAsync(Id);
            dbContext.Requerimientos.ToList();

            return requerimiento;
        }

        public async Task<Requerimiento> save(Requerimiento requerimiento)
        {
            
                requerimiento.Dml = "I";
                requerimiento.UpDateTime = new DateTime();
                requerimiento.CreateTime = new DateTime();
                dbContext.Requerimientos.Add(requerimiento);
            await dbContext.SaveChangesAsync();
            return requerimiento;
        }

    
    /********************MIGRATE DATA**********************/
    private const int ID = 0;
    private const int TIPO_REQUERIMIENTO= 1;
    private const int AREA_SOLICITANTE= 2;
    private const int USUARIO_SOLICITANTE = 3;
    private const int FECHA_SOLICITUD = 4;
    private const int FECHA_ESTIMADA_ENTRANTE = 5;
    private const int CONFIG_PROCESO = 6;

        public async Task<List<Requerimiento>> migrateCsvData(string file)
    {
        List<Requerimiento> colection = new List<Requerimiento>();
        string[] st = System.IO.File.ReadAllLines(file);
        List<String> filas = st.ToList();
        filas
            .Where(fila => fila != filas[0])
            .ToList()
            .ForEach(fila =>
            {
                string[] atributo = fila.Split(";");
                Requerimiento Requerimiento = new Requerimiento();
                    //tipoRequerimiento.Id = int.Parse(atributo[ID]);
                Requerimiento.TipoRequerimientoId = int.Parse(atributo[TIPO_REQUERIMIENTO]);
                Requerimiento.AreaSolicitanteId = int.Parse(atributo[AREA_SOLICITANTE]);
                Requerimiento.UsuarioSolicitante = atributo[USUARIO_SOLICITANTE];
                Requerimiento.FechaSolicitud = atributo[FECHA_SOLICITUD];
                Requerimiento.FechaEstimadaEntrante = atributo[FECHA_ESTIMADA_ENTRANTE];
                Requerimiento.Dml = "I";
                dbContext.Requerimientos.AddAsync(Requerimiento);
                colection.Add(Requerimiento);
            });
        await dbContext.SaveChangesAsync();
        return colection;
    }

        public async Task<MonitorRequerimientoDTO> saveMonitorRequerimiento(MonitorRequerimientoDTO monitorRequerimiento)
        {
            MonitorRequerimientoDTO response = new MonitorRequerimientoDTO();
            List<DetalleRequerimiento> detalleResponse = new List<DetalleRequerimiento>();

            Requerimiento req = monitorRequerimiento.Requerimiento;

            req.Dml = "I";
            req.FechaSolicitud = new DateTime().ToString();
            req.CreateTime = new DateTime();
            dbContext.Requerimientos.AddAsync(req);
            await dbContext.SaveChangesAsync();
            response.Requerimiento = monitorRequerimiento.Requerimiento;

            monitorRequerimiento
                .DetalleRequerimiento
                //.Where(dd => dd != null)
                //.ToList()
                .ForEach( async o =>
                {
                    o.Dml = "I";
                    o.CreateTime = new DateTime();
                    o.RequerimientoId = req.Id;
                    o.Producto = null;
                    dbContext.DetalleRequerimientos.AddAsync(o);
                    detalleResponse.Add(o);
                });
            await dbContext.SaveChangesAsync();
            return response;
        }

        public Task<string> SaveConfigurationInitial(ConfigProceso configProceso)
        {
            throw new NotImplementedException();
        }
    }
}

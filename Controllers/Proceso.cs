using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Licitacion.Global.Config.DBContext;
using Proyecto_Licitacion.Models.Entities;
using Proyecto_Licitacion.Services;
using Proyecto_Licitacion.Services.Interfaces;


namespace Proyecto_Licitacion.Controllers
{
    [Route("/api/v1/[controller]")]
    [ApiController]
    public class ProcesoController : ControllerBase
    {
        public readonly DBContextLic DbContext;
        public ProcesoController(DBContextLic dbContext)
        {
            this.DbContext = dbContext;
        }

        /******************METHODS****************/

        /******************Lista Areas Solicitantes****************/
        [HttpGet("listProceso")]
        public IActionResult Get()
        {
            Response<List<Proceso>> response = new Response<List<Proceso>>();
            IProcesoService p = new ProcesoService(DbContext);
            try
            {
                List<Proceso> listProceso = p.finAll().Result;
                response.ok(true, listProceso, "Lista de Proceso");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new List<Proceso>(), "No hay Proceso");
                return BadRequest(response);
            }
        }

        /******************Guarda Areas Solicitantes****************/
        [HttpPost("saveProceso")]
        public IActionResult SaveProceso(Proceso proceso)
        {
            Response<Proceso> response = new Response<Proceso>();
            try
            {
                IProcesoService service = new ProcesoService(DbContext);
                Task<Proceso> p = service.save(proceso);
                response.ok(true, p.Result, "Se inserto el proceso");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, null, "Error en el servicio " + ex.Message);
                return BadRequest(response);
            }
        }

        /******************Borra Areas Solicitantes****************/
        [HttpGet("deleteProceso")]
        public IActionResult DeleteProductById(int Id)
        {
            IProcesoService service = new ProcesoService(DbContext);
            Response<Proceso> response = new Response<Proceso>();
            try
            {
               Proceso p = service.deleteById(Id).Result;
                response.ok(true, p, "Se cambio el estado a DELETE");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new Proceso(), "Error al cambiar estado " + ex.Message);
                return BadRequest(response);
            }
        }

        /*****************MIGRACION DE DATA********************/
        [HttpPost("migrateCsvData")]
        public IActionResult ReadCSV(string file)
        {
            IProcesoService service = new ProcesoService(DbContext);
            Response<List<Proceso>> response = new Response<List<Proceso>>();
            try
            {
                List<Proceso> p = service.migrateCsvData(file).Result;
                response.ok(true, p, "La siguiente lista fue migrada");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new List<Proceso>(), "Error al Migrar la data " + ex.Message);
                return BadRequest(response);
            }
        }

    }
}

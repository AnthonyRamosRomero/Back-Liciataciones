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
    public class ConfigProcesoController : ControllerBase
    {
        public readonly DBContextLic DbContext;
        public ConfigProcesoController(DBContextLic dbContext)
        {
            this.DbContext = dbContext;
        }

        /******************METHODS****************/

        /******************Lista Areas Solicitantes****************/
        [HttpGet("listConfigProceso")]
        public IActionResult Get()
        {
            Response<List<ConfigProceso>> response = new Response<List<ConfigProceso>>();
            IConfigProcesoService p = new ConfigProcesoService(DbContext);
            try
            {
                List<ConfigProceso> listConfigProceso = p.finAll().Result;
                response.ok(true, listConfigProceso, "Lista de ConfigProceso");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new List<ConfigProceso>(), "No hay lista");
                return BadRequest(response);
            }
        }

        /******************Guarda Areas Solicitantes****************/
        [HttpPost("saveConfigProceso")]
        public IActionResult SaveConfigProceso(ConfigProceso configProceso, int idRequerimiento)
        {
            Response<ConfigProceso> response = new Response<ConfigProceso>();
            try
            {
                IConfigProcesoService service = new ConfigProcesoService(DbContext);
                Task<ConfigProceso> p = service.save(configProceso, idRequerimiento);
                response.ok(true, p.Result, "Se inserto ConfigProceso");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, null, "Error en el servicio " + ex.Message);
                return BadRequest(response);
            }
        }

        /******************Borra Areas Solicitantes****************/
        [HttpGet("deleteConfigProceso")]
        public IActionResult DeleteProductById(int Id)
        {
            IConfigProcesoService service = new ConfigProcesoService(DbContext);
            Response<ConfigProceso> response = new Response<ConfigProceso>();
            try
            {
               ConfigProceso p = service.deleteById(Id).Result;
                response.ok(true, p, "Se cambio el estado a DELETE");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new ConfigProceso(), "Error al cambiar estado " + ex.Message);
                return BadRequest(response);
            }
        }

        /*****************MIGRACION DE DATA********************/
        [HttpPost("migrateCsvData")]
        public IActionResult ReadCSV(string file)
        {
            IConfigProcesoService service = new ConfigProcesoService(DbContext);
            Response<List<ConfigProceso>> response = new Response<List<ConfigProceso>>();
            try
            {
                List<ConfigProceso> p = service.migrateCsvData(file).Result;
                response.ok(true, p, "La siguiente lista fue migrada");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new List<ConfigProceso>(), "Error al Migrar la data " + ex.Message);
                return BadRequest(response);
            }
        }

    }
}

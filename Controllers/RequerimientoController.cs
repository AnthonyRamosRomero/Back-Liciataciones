using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Licitacion.Global.Config.DBContext;
using Proyecto_Licitacion.Models.Dto;
using Proyecto_Licitacion.Models.Entities;
using Proyecto_Licitacion.Services;
using Proyecto_Licitacion.Services.Interfaces;

namespace Proyecto_Licitacion.Controllers
{
    [Route("/api/v1/[controller]")]
    [ApiController]
    public class RequerimientoController : ControllerBase
    {
        public readonly DBContextLic DbContext;
        public RequerimientoController(DBContextLic dbContext)
        {
            this.DbContext = dbContext;
        }

        /******************METHODS****************/

        /******************Lista Requerimientos****************/
        [HttpGet("listRequirement")]
        public IActionResult Get()
        {
            Response<List<Requerimiento>> response = new Response<List<Requerimiento>>();
            IRequerimientoService p = new RequerimientoService(DbContext);
            try
            {
                List<Requerimiento> listRequirements = p.finAll().Result;
                response.ok(true, listRequirements, "Lista de requerimientos regristrados");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new List<Requerimiento>(), "No hay requerimientos en la lista");
                return BadRequest(response);
            }
        }

        /******************Guarda Requerimientos****************/
        [HttpPost("saveRequirement")]
        public IActionResult SaveRequerimiento(Requerimiento requerimiento)
        {
            Response<Requerimiento> response = new Response<Requerimiento>();
            try
            {
                IRequerimientoService service = new RequerimientoService(DbContext);
                Task<Requerimiento> p = service.save(requerimiento);
                response.ok(true, p.Result, "Se inserto el requerimiento");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, null, "Error en el servicio " + ex.Message);
                return BadRequest(response);
            }
        }

        /******************Borra Requerimientos****************/
        [HttpGet("deleteRequirementa")]
        public IActionResult DeleteRequestById(int Id)
        {
            IRequerimientoService service = new RequerimientoService(DbContext);
            Response<Requerimiento> response = new Response<Requerimiento>();
            try
            {
                Requerimiento p = service.deleteById(Id).Result;
                response.ok(true, p, "Se cambio el estado a DELETE");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new Requerimiento(), "Error al cambiar estado " + ex.Message);
                return BadRequest(response);
            }
        }


        [HttpPost("saveMonitorRequerimiento")]
        public IActionResult SaveMonitorRequerimiento(MonitorRequerimientoDTO monitorRequerimiento)
        {
            IRequerimientoService service = new RequerimientoService(DbContext);
            Response<MonitorRequerimientoDTO> response = new Response<MonitorRequerimientoDTO>();
            try
            {
                MonitorRequerimientoDTO o = service.saveMonitorRequerimiento(monitorRequerimiento).Result;
                response.ok(true, o, "La siguiente informacion fue guardada!");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new MonitorRequerimientoDTO());
                return BadRequest(response);
            }
        }



        [HttpPost("SaveConfigurationInitial")]
        public IActionResult SaveConfigurationInitial(ConfigProceso configProceso)
        {
            IRequerimientoService service = new RequerimientoService(DbContext);
            Response<String> response = new Response<String>();
            try
            {
                string o = "OKI";
                response.ok(true, o, "La siguiente lista fue migrada");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, "ERROR", "Error Al Configurar el proceso" + ex.Message);
                return BadRequest(response);
            }
        }

        /*****************MIGRACION DE DATA********************/
        [HttpPost("migrateCsvData")]
        public IActionResult ReadCSV(string file)
        {
            IRequerimientoService service = new RequerimientoService(DbContext);
            Response<List<Requerimiento>> response = new Response<List<Requerimiento>>();
            try
            {
                List<Requerimiento> p = service.migrateCsvData(file).Result;
                response.ok(true, p, "La siguiente lista fue migrada");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new List<Requerimiento>(), "Error al Migrar la data " + ex.Message);
                return BadRequest(response);
            }
        }
    }
}
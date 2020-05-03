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
    public class AreaSolicitanteController : ControllerBase
    {
        public readonly DBContextLic DbContext;
        public AreaSolicitanteController(DBContextLic dbContext)
        {
            this.DbContext = dbContext;
        }

        /******************METHODS****************/

        /******************Lista Areas Solicitantes****************/
        [HttpGet("listApplicationArea")]
        public IActionResult Get()
        {
            Response<List<AreaSolicitante>> response = new Response<List<AreaSolicitante>>();
            IAreaSolicitanteService p = new AreaSolicitanteService(DbContext);
            try
            {
                List<AreaSolicitante> listApplicantAreas = p.finAll().Result;
                response.ok(true, listApplicantAreas, "Lista de areas solicitantes regristradas");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new List<AreaSolicitante>(), "No hay areas solicitantes en la lista");
                return BadRequest(response);
            }
        }

        /******************Guarda Areas Solicitantes****************/
        [HttpPost("saveApplicationArea")]
        public IActionResult SaveAreaSolicitante(AreaSolicitante areasolicitante)
        {
            Response<AreaSolicitante> response = new Response<AreaSolicitante>();
            try
            {
                IAreaSolicitanteService service = new AreaSolicitanteService(DbContext);
                Task<AreaSolicitante> p = service.save(areasolicitante);
                response.ok(true, p.Result, "Se inserto el area solicitante");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, null, "Error en el servicio " + ex.Message);
                return BadRequest(response);
            }
        }

        /******************Borra Areas Solicitantes****************/
        [HttpGet("deleteApplicationArea")]
        public IActionResult DeleteProductById(int Id)
        {
            IAreaSolicitanteService service = new AreaSolicitanteService(DbContext);
            Response<AreaSolicitante> response = new Response<AreaSolicitante>();
            try
            {
                AreaSolicitante p = service.deleteById(Id).Result;
                response.ok(true, p, "Se cambio el estado a DELETE");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new AreaSolicitante(), "Error al cambiar estado " + ex.Message);
                return BadRequest(response);
            }
        }

        /*****************MIGRACION DE DATA********************/
        [HttpPost("migrateCsvData")]
        public IActionResult ReadCSV(string file)
        {
            IAreaSolicitanteService service = new AreaSolicitanteService(DbContext);
            Response<List<AreaSolicitante>> response = new Response<List<AreaSolicitante>>();
            try
            {
                List<AreaSolicitante> p = service.migrateCsvData(file).Result;
                response.ok(true, p, "La siguiente lista fue migrada");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new List<AreaSolicitante>(), "Error al Migrar la data " + ex.Message);
                return BadRequest(response);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Licitacion.Global.Config.DBContext;
using Proyecto_Licitacion.Models.Dto;
using Proyecto_Licitacion.Models.Entities;
using Proyecto_Licitacion.Services;
using Proyecto_Licitacion.Services.Interfaces;

namespace Proyecto_Licitacion.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TipoRequerimientoController : ControllerBase
    {
        public readonly DBContextLic DbContext;
        public TipoRequerimientoController(DBContextLic dbContext)
        {
            this.DbContext = dbContext;
        }

        /******************METHODS****************/

        /******************Lista Tipos de Requerimientos****************/
        [HttpGet("listTypeRequirement")]
        public IActionResult Get()
        {
            Response<List<TipoRequerimiento>> response = new Response<List<TipoRequerimiento>>();
            ITipoRequerimientoService p = new TipoRequerimientoService(DbContext);
            try
            {
                List<TipoRequerimiento> listTypeRequirements = p.finAll().Result;
                response.ok(true, listTypeRequirements, "Lista de tipo de requerimientos regristradas");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new List<TipoRequerimiento>(), "No hay tipos de requerimientos en la lista");
                return BadRequest(response);
            }
        }

        /******************Guarda Tipos de Requerimientos****************/
        [HttpPost("saveTypeRequirement")]
        public IActionResult SaveTipoRequerimiento(TipoRequerimiento tiporequerimiento)
        {
            Response<TipoRequerimiento> response = new Response<TipoRequerimiento>();
            try
            {
                ITipoRequerimientoService service = new TipoRequerimientoService(DbContext);
                Task<TipoRequerimiento> p = service.save(tiporequerimiento);
                response.ok(true, p.Result, "Se inserto el tipo de requerimiento");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, null, "Error en el servicio " + ex.Message);
                return BadRequest(response);
            }
        }

        /******************Borra Tipos de Requerimientos****************/
        [HttpGet("deleteTypeRequirement")]
        public IActionResult DeleteTipoRequerimientoById(int Id)
        {
            ITipoRequerimientoService service = new TipoRequerimientoService(DbContext);
            Response<TipoRequerimiento> response = new Response<TipoRequerimiento>();
            try
            {
                TipoRequerimiento p = service.deleteById(Id).Result;
                response.ok(true, p, "Se cambio el estado a DELETE");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new TipoRequerimiento(), "Error al cambiar estado " + ex.Message);
                return BadRequest(response);
            }
        }

        /*****************MIGRACION DE DATA********************/
        [HttpPost("migrateCsvData")]
        /*IFormFile iFormFile*/
        public IActionResult ReadCSV(string file)
        {
            ITipoRequerimientoService service = new TipoRequerimientoService(DbContext);
            Response<List<TipoRequerimiento>> response = new Response<List<TipoRequerimiento>>();
            try
            {
                List<TipoRequerimiento> p = service.migrateCsvData(file).Result;
                response.ok(true, p, "La siguiente lista fue migrada");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new List<TipoRequerimiento>(), "Error al Migrar la data " + ex.Message);
                return BadRequest(response);
            }
        }
    }
}
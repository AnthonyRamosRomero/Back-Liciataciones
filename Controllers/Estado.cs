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
    public class EstadoController : ControllerBase
    {
        public readonly DBContextLic DbContext;
        public EstadoController(DBContextLic dbContext)
        {
            this.DbContext = dbContext;
        }

        /******************METHODS****************/

        /******************Lista Areas Solicitantes****************/
        [HttpGet("listEstado")]
        public IActionResult Get()
        {
            Response<List<Estado>> response = new Response<List<Estado>>();
            IEstadoService p = new EstadoService(DbContext);
            try
            {
                List<Estado> listEstado = p.finAll().Result;
                response.ok(true, listEstado, "Lista de Estado");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new List<Estado>(), "No hay lista");
                return BadRequest(response);
            }
        }

        /******************Guarda Areas Solicitantes****************/
        [HttpPost("saveEstado")]
        public IActionResult SaveEstado(Estado estado)
        {
            Response<Estado> response = new Response<Estado>();
            try
            {
                IEstadoService service = new EstadoService(DbContext);
                Task<Estado> p = service.save(estado);
                response.ok(true, p.Result, "Se inserto estado");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, null, "Error en el servicio " + ex.Message);
                return BadRequest(response);
            }
        }

        /******************Borra Areas Solicitantes****************/
        [HttpGet("deleteEstado")]
        public IActionResult DeleteProductById(int Id)
        {
            IEstadoService service = new EstadoService(DbContext);
            Response<Estado> response = new Response<Estado>();
            try
            {
               Estado p = service.deleteById(Id).Result;
                response.ok(true, p, "Se cambio el estado a DELETE");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new Estado(), "Error al cambiar estado " + ex.Message);
                return BadRequest(response);
            }
        }

        /*****************MIGRACION DE DATA********************/
        [HttpPost("migrateCsvData")]
        public IActionResult ReadCSV(string file)
        {
            IEstadoService service = new EstadoService(DbContext);
            Response<List<Estado>> response = new Response<List<Estado>>();
            try
            {
                List<Estado> p = service.migrateCsvData(file).Result;
                response.ok(true, p, "La siguiente lista fue migrada");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new List<Estado>(), "Error al Migrar la data " + ex.Message);
                return BadRequest(response);
            }
        }
    }
}

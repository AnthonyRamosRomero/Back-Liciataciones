using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Licitacion.Global.Config.DBContext;
using Proyecto_Licitacion.Models.Entities;
using Proyecto_Licitacion.Services;
using Proyecto_Licitacion.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto_Licitacion.Controllers
{
    [Route("/api/v1/[controller]")]
    [ApiController]
    public class DetalleRequerimientoController : ControllerBase
    {
        public readonly DBContextLic DbContext;
        public DetalleRequerimientoController(DBContextLic dbContext)
        {
            this.DbContext = dbContext;
        }

        /******************METHODS****************/
        [HttpGet("listdetallerequerimiento")]
        public IActionResult Get()
        {
            Response<List<DetalleRequerimiento>> response = new Response<List<DetalleRequerimiento>>();
            IDetalleRequerimientoService p = new DetalleRequerimientoService(DbContext);
            try
            {
                List<DetalleRequerimiento> listdetallerequerimiento = p.finAll().Result;
                response.ok(true, listdetallerequerimiento, "Detalle Listos");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new List<DetalleRequerimiento>(), "No hay Detalle en la lista");
                return BadRequest(response);
            }
        }

        [HttpGet("FindByIdRequerimiento")]
        public IActionResult FindByIdRequerimiento(int idRequerimiento)
        {
            Response<List<DetalleRequerimiento>> response = new Response<List<DetalleRequerimiento>>();
            IDetalleRequerimientoService p = new DetalleRequerimientoService(DbContext);
            try
            {
                List<DetalleRequerimiento> listdetallerequerimiento = p.findAllByIdRequerimiento(idRequerimiento).Result;
                response.ok(true, listdetallerequerimiento, "Detalle Listos");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new List<DetalleRequerimiento>(), "No hay Detalle en la lista");
                return BadRequest(response);
            }
        }

        [HttpPost("savedetallerequerimiento")]
        public IActionResult SaveDetalleRequerimiento(DetalleRequerimiento detalleRequerimiento)
        {
            Response<DetalleRequerimiento> response = new Response<DetalleRequerimiento>();
            try
            {
                IDetalleRequerimientoService service = new DetalleRequerimientoService(DbContext);
                Task<DetalleRequerimiento> p = service.save(detalleRequerimiento);
                response.ok(true, p.Result, "Se inserto detalle");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, null, "Error en el servicio " + ex.Message);
                return BadRequest(response);
            }
        }


        [HttpPost("saveListDetalleRequerimiento")]
        public IActionResult SaveDetalleRequerimiento(List<DetalleRequerimiento> list)
        {
            Response<List<DetalleRequerimiento>> response = new Response<List<DetalleRequerimiento>>();
            try
            {
                IDetalleRequerimientoService service = new DetalleRequerimientoService(DbContext);
                Task<List<DetalleRequerimiento>> p = service.save(list);
                response.ok(true, p.Result, "Se inserto detalle");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, null, "Error en el servicio " + ex.Message);
                return BadRequest(response);
            }
        }

        // DELETE api/<controller>/5
        [HttpGet("deletedetallerequerimiento")]
        public IActionResult DeleteRequerimientotById(int Id)
        {
            IDetalleRequerimientoService service = new DetalleRequerimientoService(DbContext);
            Response<DetalleRequerimiento> response = new Response<DetalleRequerimiento>();
            try
            {
                DetalleRequerimiento p = service.deleteById(Id).Result;
                response.ok(true, p, "Se cambio el estado a DELETE");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new DetalleRequerimiento(), "Error al cambiar estado " + ex.Message);
                return BadRequest(response);
            }
        }
        /*****************MIGRACION DE DATA********************/
        [HttpPost("migrateCsvData")]
        public IActionResult ReadCSV(string file)
        {
            IDetalleRequerimientoService service = new DetalleRequerimientoService(DbContext);
            Response<List<DetalleRequerimiento>> response = new Response<List<DetalleRequerimiento>>();
            try
            {
                List<DetalleRequerimiento> p = service.migrateCsvData(file).Result;
                response.ok(true, p, "La siguiente lista fue migrada");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new List<DetalleRequerimiento>(), "Error al Migrar la data " + ex.Message);
                return BadRequest(response);
            }
        }
    }
}

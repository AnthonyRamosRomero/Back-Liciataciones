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
    [Route("/api/v1/rondaproveedor")]
    [ApiController]
    public class RondaProveedorController : ControllerBase
    {
        public readonly DBContextLic DbContext;
        public RondaProveedorController(DBContextLic dbContext)
        {
            this.DbContext = dbContext;
        }

        /******************METHODS****************/

        /******************Lista Ronda de Proveedores****************/
        [HttpGet, Route("/listProviderRound")]
        public IActionResult Get()
        {
            Response<List<RondaProveedor>> response = new Response<List<RondaProveedor>>();
            IRondaProveedorService p = new RondaProveedorService(DbContext);
            try
            {
                List<RondaProveedor> listProviderRound = p.finAll().Result;
                response.ok(true, listProviderRound, "Lista de ronda de proveedores regristradas");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new List<RondaProveedor>(), "No hay ronda de proveedores en la lista");
                return BadRequest(response);
            }
        }

        /******************Guarda Ronda de Proveedores****************/
        [HttpPost, Route("/saveProviderRound")]
        public IActionResult SaveProviderRound(RondaProveedor rondaproveedor)
        {
            Response<RondaProveedor> response = new Response<RondaProveedor>();
            try
            {
                IRondaProveedorService service = new RondaProveedorService(DbContext);
                Task<RondaProveedor> p = service.save(rondaproveedor);
                response.ok(true, p.Result, "Se inserto la ronda de proveedor");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, null, "Error en el servicio " + ex.Message);
                return BadRequest(response);
            }
        }

        /******************Borra Ronda de Proveedores****************/
        [HttpGet, Route("/deleteProviderRound")]
        public IActionResult DeleteProviderRoundById(int Id)
        {
            IRondaProveedorService service = new RondaProveedorService(DbContext);
            Response<RondaProveedor> response = new Response<RondaProveedor>();
            try
            {
                RondaProveedor p = service.deleteById(Id).Result;
                response.ok(true, p, "Se cambio el estado a DELETE");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new RondaProveedor(), "Error al cambiar estado " + ex.Message);
                return BadRequest(response);
            }
        }

        /*****************MIGRACION DE DATA********************/
        [HttpPost("migrateCsvData")]
        public IActionResult ReadCSV(string file)
        {
            IRondaProveedorService service = new RondaProveedorService(DbContext);
            Response<List<RondaProveedor>> response = new Response<List<RondaProveedor>>();
            try
            {
                List<RondaProveedor> p = service.migrateCsvData(file).Result;
                response.ok(true, p, "La siguiente lista fue migrada");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new List<RondaProveedor>(), "Error al Migrar la data " + ex.Message);
                return BadRequest(response);
            }
        }

    }
}
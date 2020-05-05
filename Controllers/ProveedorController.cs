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
    [Route("/api/v1/proveedor")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        public readonly DBContextLic DbContext;
        public ProveedorController(DBContextLic dbContext)
        {
            this.DbContext = dbContext;
        }

        /******************METHODS****************/

        /******************Lista Proveedores****************/
        [HttpGet, Route("/listProvider")]
        public IActionResult Get()
        {
            Response<List<Proveedor>> response = new Response<List<Proveedor>>();
            IProveedorService p = new ProveedorService(DbContext);
            try
            {
                List<Proveedor> listProvider = p.finAll().Result;
                response.ok(true, listProvider, "Lista de proveedores regristrados");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new List<Proveedor>(), "No hay proveedores en la lista");
                return BadRequest(response);
            }
        }

        /******************Guarda Proveedores****************/
        [HttpPost, Route("/saveProvider")]
        public IActionResult SaveProveedor(Proveedor proveedor)
        {
            Response<Proveedor> response = new Response<Proveedor>();
            try
            {
                IProveedorService service = new ProveedorService(DbContext);
                Task<Proveedor> p = service.save(proveedor);
                response.ok(true, p.Result, "Se inserto el proveedor");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, null, "Error en el servicio " + ex.Message);
                return BadRequest(response);
            }
        }

        /******************Borra Proveedores****************/
        [HttpGet, Route("/deleteProvider")]
        public IActionResult DeleteProviderById(int Id)
        {
            IProveedorService service = new ProveedorService(DbContext);
            Response<Proveedor> response = new Response<Proveedor>();
            try
            {
                Proveedor p = service.deleteById(Id).Result;
                response.ok(true, p, "Se cambio el estado a DELETE");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new Proveedor(), "Error al cambiar estado " + ex.Message);
                return BadRequest(response);
            }
        }

        /*****************MIGRACION DE DATA********************/
        [HttpPost("migrateCsvData")]
        public IActionResult ReadCSV(string file)
        {
            IProveedorService service = new ProveedorService(DbContext);
            Response<List<Proveedor>> response = new Response<List<Proveedor>>();
            try
            {
                List<Proveedor> p = service.migrateCsvData(file).Result;
                response.ok(true, p, "La siguiente lista fue migrada");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new List<Proveedor>(), "Error al Migrar la data " + ex.Message);
                return BadRequest(response);
            }
        }

    }
}
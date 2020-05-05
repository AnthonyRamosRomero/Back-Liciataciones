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
    [Route("/api/v1/adjuntorondaproveedor")]
    [ApiController]
    public class AdjuntoRondaProveedorController : ControllerBase
    {
        public readonly DBContextLic DbContext;
        public AdjuntoRondaProveedorController(DBContextLic dbContext)
        {
            this.DbContext = dbContext;
        }

        /******************METHODS****************/

        /******************Lista Adjunto de Ronda de Proveedores****************/
        [HttpGet, Route("/listRoundAttachmentProvider")]
        public IActionResult Get()
        {
            Response<List<AdjuntoRondaProveedor>> response = new Response<List<AdjuntoRondaProveedor>>();
            IAdjuntoRondaProveedorService p = new AdjuntoRondaProveedorService(DbContext);
            try
            {
                List<AdjuntoRondaProveedor> listRoundAttachmentProvider = p.finAll().Result;
                response.ok(true, listRoundAttachmentProvider, "Lista de adjunto de ronda de proveedores regristradas");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new List<AdjuntoRondaProveedor>(), "No hay adjunto de rondas de proveedores en la lista");
                return BadRequest(response);
            }
        }

        /******************Guarda Adjunto de Ronda de Proveedores****************/
        [HttpPost, Route("/saveRoundAttachmentProvider")]
        public IActionResult SaveRoundAttachmentProvider(AdjuntoRondaProveedor adjuntorondaproveedor)
        {
            Response<AdjuntoRondaProveedor> response = new Response<AdjuntoRondaProveedor>();
            try
            {
                IAdjuntoRondaProveedorService service = new AdjuntoRondaProveedorService(DbContext);
                Task<AdjuntoRondaProveedor> p = service.save(adjuntorondaproveedor);
                response.ok(true, p.Result, "Se inserto el adjunto de ronda de proveedor");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, null, "Error en el servicio " + ex.Message);
                return BadRequest(response);
            }
        }

        /******************Borra Adjunto de Ronda de Proveedor****************/
        [HttpGet, Route("/deleteRoundAttachmentProvider")]
        public IActionResult DeleteRoundAttachmentProviderById(int Id)
        {
            IAdjuntoRondaProveedorService service = new AdjuntoRondaProveedorService(DbContext);
            Response<AdjuntoRondaProveedor> response = new Response<AdjuntoRondaProveedor>();
            try
            {
                AdjuntoRondaProveedor p = service.deleteById(Id).Result;
                response.ok(true, p, "Se cambio el estado a DELETE");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new AdjuntoRondaProveedor(), "Error al cambiar estado " + ex.Message);
                return BadRequest(response);
            }
        }

        /*****************MIGRACION DE DATA********************/
        [HttpPost("migrateCsvData")]
        public IActionResult ReadCSV(string file)
        {
            IAdjuntoRondaProveedorService service = new AdjuntoRondaProveedorService(DbContext);
            Response<List<AdjuntoRondaProveedor>> response = new Response<List<AdjuntoRondaProveedor>>();
            try
            {
                List<AdjuntoRondaProveedor> p = service.migrateCsvData(file).Result;
                response.ok(true, p, "La siguiente lista fue migrada");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new List<AdjuntoRondaProveedor>(), "Error al Migrar la data " + ex.Message);
                return BadRequest(response);
            }
        }

    }
}
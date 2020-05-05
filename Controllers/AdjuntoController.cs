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
    [Route("/api/v1/adjunto")]
    [ApiController]
    public class AdjuntoController : ControllerBase
    {
        public readonly DBContextLic DbContext;
        public AdjuntoController(DBContextLic dbContext)
        {
            this.DbContext = dbContext;
        }

        /******************METHODS****************/

        /******************Lista Adjuntos****************/
        [HttpGet, Route("/listAttached")]
        public IActionResult Get()
        {
            Response<List<Adjunto>> response = new Response<List<Adjunto>>();
            IAdjuntoService p = new AdjuntoService(DbContext);
            try
            {
                List<Adjunto> listAttached = p.finAll().Result;
                response.ok(true, listAttached, "Lista de adjuntos regristrados");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new List<Adjunto>(), "No hay adjuntos en la lista");
                return BadRequest(response);
            }
        }

        /******************Guarda Adjuntos****************/
        [HttpPost, Route("/saveAttached")]
        public IActionResult SaveAdjunto(Adjunto adjunto)
        {
            Response<Adjunto> response = new Response<Adjunto>();
            try
            {
                IAdjuntoService service = new AdjuntoService(DbContext);
                Task<Adjunto> p = service.save(adjunto);
                response.ok(true, p.Result, "Se inserto el adjunto");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, null, "Error en el servicio " + ex.Message);
                return BadRequest(response);
            }
        }

        /******************Borra Adjuntos****************/
        [HttpGet, Route("/deleteAttached")]
        public IActionResult DeleteAttachedById(int Id)
        {
            IAdjuntoService service = new AdjuntoService(DbContext);
            Response<Adjunto> response = new Response<Adjunto>();
            try
            {
                Adjunto p = service.deleteById(Id).Result;
                response.ok(true, p, "Se cambio el estado a DELETE");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new Adjunto(), "Error al cambiar estado " + ex.Message);
                return BadRequest(response);
            }
        }

        /*****************MIGRACION DE DATA********************/
        [HttpPost("migrateCsvData")]
        public IActionResult ReadCSV(string file)
        {
            IAdjuntoService service = new AdjuntoService(DbContext);
            Response<List<Adjunto>> response = new Response<List<Adjunto>>();
            try
            {
                List<Adjunto> p = service.migrateCsvData(file).Result;
                response.ok(true, p, "La siguiente lista fue migrada");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new List<Adjunto>(), "Error al Migrar la data " + ex.Message);
                return BadRequest(response);
            }
        }

    }
}
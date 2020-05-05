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
    [Route("/api/v1/ronda")]
    [ApiController]
    public class RondaController : ControllerBase
    {
        public readonly DBContextLic DbContext;
        public RondaController(DBContextLic dbContext)
        {
            this.DbContext = dbContext;
        }

        /******************METHODS****************/

        /******************Lista Rondas****************/
        [HttpGet, Route("/listRound")]
        public IActionResult Get()
        {
            Response<List<Ronda>> response = new Response<List<Ronda>>();
            IRondaService p = new RondaService(DbContext);
            try
            {
                List<Ronda> listRound = p.finAll().Result;
                response.ok(true, listRound, "Lista de rondas regristradas");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new List<Ronda>(), "No hay rondas en la lista");
                return BadRequest(response);
            }
        }

        /******************Guarda Rondas****************/
        [HttpPost, Route("/saveRound")]
        public IActionResult SaveRonda(Ronda ronda)
        {
            Response<Ronda> response = new Response<Ronda>();
            try
            {
                IRondaService service = new RondaService(DbContext);
                Task<Ronda> p = service.save(ronda);
                response.ok(true, p.Result, "Se inserto la ronda");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, null, "Error en el servicio " + ex.Message);
                return BadRequest(response);
            }
        }

        /******************Borra Rondas****************/
        [HttpGet, Route("/deleteRound")]
        public IActionResult DeleteRoundById(int Id)
        {
            IRondaService service = new RondaService(DbContext);
            Response<Ronda> response = new Response<Ronda>();
            try
            {
                Ronda p = service.deleteById(Id).Result;
                response.ok(true, p, "Se cambio el estado a DELETE");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new Ronda(), "Error al cambiar estado " + ex.Message);
                return BadRequest(response);
            }
        }

        /*****************MIGRACION DE DATA********************/
        [HttpPost("migrateCsvData")]
        public IActionResult ReadCSV(string file)
        {
            IRondaService service = new RondaService(DbContext);
            Response<List<Ronda>> response = new Response<List<Ronda>>();
            try
            {
                List<Ronda> p = service.migrateCsvData(file).Result;
                response.ok(true, p, "La siguiente lista fue migrada");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new List<Ronda>(), "Error al Migrar la data " + ex.Message);
                return BadRequest(response);
            }
        }

    }
}
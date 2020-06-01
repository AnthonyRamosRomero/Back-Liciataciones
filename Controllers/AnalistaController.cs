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
    public class AnalistaController : ControllerBase
    {
        public readonly DBContextLic DbContext;
        public AnalistaController(DBContextLic dbContext)
        {
            this.DbContext = dbContext;
        }

        /******************METHODS****************/

        /******************Lista Areas Solicitantes****************/
        [HttpGet("listAnalista")]
        public IActionResult Get()
        {
            Response<List<Analista>> response = new Response<List<Analista>>();
            IAnalistaService p = new AnalistaService(DbContext);
            try
            {
                List<Analista> listAnalista = p.finAll().Result;
                response.ok(true, listAnalista, "Lista de Analista");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new List<Analista>(), "No hay lista");
                return BadRequest(response);
            }
        }

        /**************************GET ANALISTA BY ID************************/
        [HttpGet("findById")]
        public IActionResult FindById(int id)
        {
            Response<Analista> response = new Response<Analista>();
            IAnalistaService p = new AnalistaService(DbContext);
            try
            {
                Analista analista = p.findById(id).Result;
                response.ok(true, analista, "Analista:");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new Analista(), "El analista con el id " + id + " No existe");
                return BadRequest(response);
            }
        }


        /******************Guarda Areas Solicitantes****************/
        [HttpPost("saveAnalista")]
        public IActionResult SaveAnalista(Analista analista)
        {
            Response<Analista> response = new Response<Analista>();
            try
            {
                IAnalistaService service = new AnalistaService(DbContext);
                Task<Analista> p = service.save(analista);
                response.ok(true, p.Result, "Se inserto analista");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, null, "Error en el servicio " + ex.Message);
                return BadRequest(response);
            }
        }

        /******************Borra Areas Solicitantes****************/
        [HttpGet("deleteAnalista")]
        public IActionResult DeleteProductById(int Id)
        {
            IAnalistaService service = new AnalistaService(DbContext);
            Response<Analista> response = new Response<Analista>();
            try
            {
               Analista p = service.deleteById(Id).Result;
                response.ok(true, p, "Se cambio el estado a DELETE");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new Analista(), "Error al cambiar estado " + ex.Message);
                return BadRequest(response);
            }
        }

        /*****************MIGRACION DE DATA********************/
        [HttpPost("migrateCsvData")]
        public IActionResult ReadCSV(string file)
        {
            IAnalistaService service = new AnalistaService(DbContext);
            Response<List<Analista>> response = new Response<List<Analista>>();
            try
            {
                List<Analista> p = service.migrateCsvData(file).Result;
                response.ok(true, p, "La siguiente lista fue migrada");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new List<Analista>(), "Error al Migrar la data " + ex.Message);
                return BadRequest(response);
            }
        }

    }
}

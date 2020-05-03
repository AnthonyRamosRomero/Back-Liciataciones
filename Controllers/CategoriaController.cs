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
    public class CategoriaController : ControllerBase
    {
        public readonly DBContextLic DbContext;
        public CategoriaController(DBContextLic dbContext)
        {
            this.DbContext = dbContext;
        }

        /******************METHODS****************/
        [HttpGet("listcategory")]
        public IActionResult Get()
        {
            Response<List<Categoria>> response = new Response<List<Categoria>>();
            ICategoriaService p = new CategoriaService(DbContext);
            try
            {
                List<Categoria> listCategorias = p.finAll().Result;
                response.ok(true, listCategorias, "Categorias Listos");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new List<Categoria>(), "No hay Categorias en la lista");
                return BadRequest(response);
            }
        }
        [HttpPost("savecategory")]
        public IActionResult SaveCategoria(Categoria categoria)
        {
            Response<Categoria> response = new Response<Categoria>();
            try
            {
                ICategoriaService service = new CategoriaService(DbContext);
                Task<Categoria> p = service.save(categoria);
                response.ok(true, p.Result, "Se inserto categoria");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, null, "Error en el servicio " + ex.Message);
                return BadRequest(response);
            }
        }

        // DELETE api/<controller>/5
        [HttpGet("deletecategory")]
        public IActionResult DeleteCategoriatById(int Id)
        {
            ICategoriaService service = new CategoriaService(DbContext);
            Response<Categoria> response = new Response<Categoria>();
            try
            {
               Categoria p = service.deleteById(Id).Result;
                response.ok(true, p, "Se cambio el estado a DELETE");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new Categoria(), "Error al cambiar estado " + ex.Message);
                return BadRequest(response);
            }
        }

        /*****************MIGRACION DE DATA********************/
        [HttpPost("migrateCsvData")]
        public IActionResult ReadCSV(string file)
        {
            ICategoriaService service = new CategoriaService(DbContext);
            Response<List<Categoria>> response = new Response<List<Categoria>>();
            try
            {
                List<Categoria> p = service.migrateCsvData(file).Result;
                response.ok(true, p, "La siguiente lista fue migrada");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new List<Categoria>(), "Error al Migrar la data " + ex.Message);
                return BadRequest(response);
            }
        }
    }
}

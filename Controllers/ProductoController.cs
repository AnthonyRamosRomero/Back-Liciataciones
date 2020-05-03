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
    public class ProductoController : ControllerBase
    {
        public readonly DBContextLic DbContext;
        public ProductoController(DBContextLic dbContext)
        {
            this.DbContext = dbContext;
        }

        /******************METHODS****************/
        [HttpGet("listProducts")]
        public IActionResult Get()
        {
            Response<List<Producto>> response = new Response<List<Producto>>();
            IProductoService p = new ProductoService(DbContext);
            try
            {
                List<Producto> listProducts = p.finAll().Result;
                response.ok(true, listProducts, "Lista de productos regristrados");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new List<Producto>(), "No hay productos en la lista");
                return BadRequest(response);
            }
        }

        [HttpPost("saveProduct")]
        public IActionResult SaveProducto(Producto producto)
        {
            Response<Producto> response = new Response<Producto>();
            try
            {
                IProductoService service = new ProductoService(DbContext);
                Task<Producto> p = service.save(producto);
                response.ok(true, p.Result, "Se inserto el producto");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, null, "Error en el servicio " + ex.Message);
                return BadRequest(response);
            }
        }

        [HttpGet("deleteProducto")]
        public IActionResult DeleteProductById(int Id)
        {
            IProductoService service = new ProductoService(DbContext);
            Response<Producto> response = new Response<Producto>();
            try
            {
                Producto p = service.deleteById(Id).Result;
                response.ok(true, p, "Se cambio el estado a DELETE");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new Producto(), "Error al cambiar estado " + ex.Message);
                return BadRequest(response);
            }
        }

        /*****************MIGRACION DE DATA********************/
        [HttpPost("migrateCsvData")]
        public IActionResult ReadCSV(string file)
        {
            IProductoService service = new ProductoService(DbContext);
            Response<List<Producto>> response = new Response<List<Producto>>();
            try
            {
                List<Producto> p = service.migrateCsvData(file).Result;
                response.ok(true, p, "La siguiente lista fue migrada");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new List<Producto>(), "Error al Migrar la data " + ex.Message);
                return BadRequest(response);
            }
        }
    }
}
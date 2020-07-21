using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Licitacion.Global.Config.DBContext;
using Proyecto_Licitacion.Models.Dto;
using Proyecto_Licitacion.Models.Entities;
using Proyecto_Licitacion.Services;
using Proyecto_Licitacion.Services.Interfaces;

namespace Proyecto_Licitacion.Controllers
{
    [Route("/api/v1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public readonly DBContextLic DbContext;
        public UsuarioController(DBContextLic dbContext)
        {
            this.DbContext = dbContext;
        }

        /******************METHODS****************/

        /******************Valida Usuario****************/
        [HttpPost("UsersValidate")]
        public IActionResult ValidarUsuarioLogin(UserLoginDTO userLoginDTO)
        {
            Response<Usuario> response = new Response<Usuario>();
            IUsuarioService p = new UsuarioService(DbContext);
            try
            {
                Usuario usuario = p.ValidarUsuarioLogin(userLoginDTO).Result;
                response.ok(true, usuario, "Usuario encontrado en la base de datos");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new Usuario(), "El usuario no existe en la base de datos");
                return BadRequest(response);
            }
        }

        [HttpPost("Save")]
        public IActionResult Save(Usuario usuario)
        {
            Response<Usuario> response = new Response<Usuario>();
            IUsuarioService p = new UsuarioService(DbContext);
            try
            {
                Usuario o = p.Save(usuario).Result;
                response.ok(true, o, "Usuario registrado");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ok(false, new Usuario(), "Error! No se pudo registrar el Usuario");
                return BadRequest(response);
            }
        }
    }  
}
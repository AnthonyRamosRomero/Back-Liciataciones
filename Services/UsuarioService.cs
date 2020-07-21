using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto_Licitacion.Global.Config.DBContext;
using Proyecto_Licitacion.Models.Dto;
using Proyecto_Licitacion.Models.Entities;
using Proyecto_Licitacion.Services.Interfaces;

namespace Proyecto_Licitacion.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly DBContextLic dbContext;

        //Para inyectar el DBContext
        public UsuarioService(DBContextLic dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Usuario> Save(Usuario usuario)
        {
            usuario.Dml = "I";
            usuario.CreateTime = new DateTime();
            usuario.UpDateTime = new DateTime();
            usuario.UserLogin = "SYSTEM";

            dbContext.Usuarios.AddAsync(usuario);
            await dbContext.SaveChangesAsync();
            
            return usuario;
        }



        /******************************************METHOD'S*******************************/

        public async Task<Usuario> ValidarUsuarioLogin(UserLoginDTO Usuario)
        {
            List<Usuario> list = dbContext.Usuarios.ToList();
            Usuario response = null ;
            list.ForEach(o => {
                if (o.UserName.Trim().Equals(Usuario.UserName) && o.Password.Trim().Equals(Usuario.Password))
                {
                    response = o;
                }
            });
            return response;
        }

}
}

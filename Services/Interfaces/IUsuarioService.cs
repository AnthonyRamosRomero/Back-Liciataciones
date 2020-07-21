using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Licitacion.Models.Dto;
using Proyecto_Licitacion.Models.Entities;

namespace Proyecto_Licitacion.Services.Interfaces
{
    interface IUsuarioService
    {

        Task<Usuario> ValidarUsuarioLogin(UserLoginDTO Usuario);
        Task<Usuario> Save(Usuario usuario);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proyecto_Licitacion.Models.Entities;

namespace Proyecto_Licitacion.Models.Dto
{
    public class UserLoginDTO
    {

        public string UserName { get; set; }
        public string Password { get; set; }

    }
}

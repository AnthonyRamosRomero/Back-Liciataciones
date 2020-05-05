    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Licitacion.Models.Entities;

namespace Proyecto_Licitacion.Services.Interfaces
{
    interface IRondaService
    {

        Task<Ronda> save(Ronda ronda);
        Task<List<Ronda>> finAll();
        Task<Ronda> findById(int Id);
        Task<Ronda> deleteById(int Id);

        /*Carga de data*/
        Task<List<Ronda>> migrateCsvData(string file);
    }
}

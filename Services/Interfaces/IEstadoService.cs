using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Licitacion.Models.Entities;

namespace Proyecto_Licitacion.Services.Interfaces
{
    interface IEstadoService
    {

        Task<Estado> save(Estado estado);
        Task<List<Estado>> finAll();
        Task<Estado> findById(int Id);
        Task<Estado> deleteById(int Id);
        /*Carga de data*/
        Task<List<Estado>> migrateCsvData(string file);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Licitacion.Models.Entities;

namespace Proyecto_Licitacion.Services.Interfaces
{
    interface IProcesoService
    {

        Task<Proceso> save(Proceso proceso);
        Task<List<Proceso>> finAll();
        Task<Proceso> findById(int Id);
        Task<Proceso> deleteById(int Id);

        /*Carga de data*/
        Task<List<Proceso>> migrateCsvData(string file);
    }
}

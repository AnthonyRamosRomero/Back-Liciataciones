using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Licitacion.Models.Entities;

namespace Proyecto_Licitacion.Services.Interfaces
{
    interface IAreaSolicitanteService
    {

        Task<AreaSolicitante> save(AreaSolicitante areasolicitante);
        Task<List<AreaSolicitante>> finAll();
        Task<AreaSolicitante> findById(int Id);
        Task<AreaSolicitante> deleteById(int Id);

        /*Carga de data*/
        Task<List<AreaSolicitante>> migrateCsvData(string file);

    }
}

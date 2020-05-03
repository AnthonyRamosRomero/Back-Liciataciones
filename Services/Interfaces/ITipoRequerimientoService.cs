using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Licitacion.Models.Entities;

namespace Proyecto_Licitacion.Services.Interfaces
{
    interface ITipoRequerimientoService
    {

        Task<TipoRequerimiento> save(TipoRequerimiento tiporequerimiento);
        Task<List<TipoRequerimiento>> finAll();
        Task<TipoRequerimiento> findById(int Id);
        Task<TipoRequerimiento> deleteById(int Id);

        /*Carga de data*/
        Task<List<TipoRequerimiento>> migrateCsvData(string file);

    }
}

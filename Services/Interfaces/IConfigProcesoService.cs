using Proyecto_Licitacion.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Licitacion.Services.Interfaces
{
    interface IConfigProcesoService
    {
        Task<ConfigProceso> save(ConfigProceso configProceso);
        Task<List<ConfigProceso>> finAll();
        Task<ConfigProceso> findById(int Id);
        Task<ConfigProceso> deleteById(int Id);

        /*Carga de data*/
        Task<List<ConfigProceso>> migrateCsvData(string file);



    }
}

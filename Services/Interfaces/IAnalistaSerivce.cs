using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Licitacion.Models.Entities;

namespace Proyecto_Licitacion.Services.Interfaces
{
    interface IAnalistaService
    {

        Task<Analista> save(Analista analista);
        Task<List<Analista>> finAll();
        Task<Analista> findById(int Id);
        Task<Analista> deleteById(int Id);
        /*Carga de data*/
        Task<List<Analista>> migrateCsvData(string file);

    }
}

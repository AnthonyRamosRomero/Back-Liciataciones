using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Licitacion.Models.Entities;

namespace Proyecto_Licitacion.Services.Interfaces
{
    interface IProductoService
    {

        Task<Producto> save(Producto producto);
        Task<List<Producto>> finAll();
        Task<Producto> findById(int Id);
        Task<Producto> deleteById(int Id);

        /*Carga de data*/
        Task<List<Producto>> migrateCsvData(string file);
    }
}

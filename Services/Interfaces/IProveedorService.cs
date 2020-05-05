using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Licitacion.Models.Entities;

namespace Proyecto_Licitacion.Services.Interfaces
{
    interface IProveedorService
    {

        Task<Proveedor> save(Proveedor proveedor);
        Task<List<Proveedor>> finAll();
        Task<Proveedor> findById(int Id);
        Task<Proveedor> deleteById(int Id);

        /*Carga de data*/
        Task<List<Proveedor>> migrateCsvData(string file);
    }
}

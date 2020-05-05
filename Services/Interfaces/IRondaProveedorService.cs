using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Licitacion.Models.Entities;

namespace Proyecto_Licitacion.Services.Interfaces
{
    interface IRondaProveedorService
    {

        Task<RondaProveedor> save(RondaProveedor rondaproveedor);
        Task<List<RondaProveedor>> finAll();
        Task<RondaProveedor> findById(int Id);
        Task<RondaProveedor> deleteById(int Id);

        /*Carga de data*/
        Task<List<RondaProveedor>> migrateCsvData(string file);
    }
}

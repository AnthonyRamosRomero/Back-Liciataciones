using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Licitacion.Models.Entities;

namespace Proyecto_Licitacion.Services.Interfaces
{
    interface IAdjuntoRondaProveedorService
    {

        Task<AdjuntoRondaProveedor> save(AdjuntoRondaProveedor adjuntorondaproveedor);
        Task<List<AdjuntoRondaProveedor>> finAll();
        Task<AdjuntoRondaProveedor> findById(int Id);
        Task<AdjuntoRondaProveedor> deleteById(int Id);

        /*Carga de data*/
        Task<List<AdjuntoRondaProveedor>> migrateCsvData(string file);
    }
}

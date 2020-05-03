using Proyecto_Licitacion.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Licitacion.Services.Interfaces
{

        interface IDetalleRequerimientoService
        {

            Task<DetalleRequerimiento> save(DetalleRequerimiento detallerequerimiento);
            Task<List<DetalleRequerimiento>> finAll();
            Task<DetalleRequerimiento> findById(int Id);
            Task<DetalleRequerimiento> deleteById(int Id);
        }
}

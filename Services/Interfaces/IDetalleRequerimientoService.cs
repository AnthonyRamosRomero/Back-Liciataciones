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
            Task<List<DetalleRequerimiento>> save(List<DetalleRequerimiento> list);
        Task<List<DetalleRequerimiento>> finAll();
            Task<DetalleRequerimiento> findById(int Id);
            Task<DetalleRequerimiento> deleteById(int Id);
        /*Carga de data*/
        Task<List<DetalleRequerimiento>> migrateCsvData(string file);

        Task<List<DetalleRequerimiento>> findAllByIdRequerimiento(int IdRequerimiento);
        }
}

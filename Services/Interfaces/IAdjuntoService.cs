    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Licitacion.Models.Entities;

namespace Proyecto_Licitacion.Services.Interfaces
{
    interface IAdjuntoService
    {

        Task<Adjunto> save(Adjunto adjunto);
        Task<List<Adjunto>> finAll();
        Task<Adjunto> findById(int Id);
        Task<Adjunto> deleteById(int Id);

        /*Carga de data*/
        Task<List<Adjunto>> migrateCsvData(string file);
    }
}

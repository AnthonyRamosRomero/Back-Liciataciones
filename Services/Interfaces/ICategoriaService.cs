using Proyecto_Licitacion.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Licitacion.Services.Interfaces
{

    interface ICategoriaService
    {

        Task<Categoria> save(Categoria categoria);
        Task<List<Categoria>> finAll();
        Task<Categoria> findById(int Id);
        Task<Categoria> deleteById(int Id);

        /*Carga de data*/
        Task<List<Categoria>> migrateCsvData(string file);
    }
}
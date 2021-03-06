﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Licitacion.Models.Dto;
using Proyecto_Licitacion.Models.Entities;

namespace Proyecto_Licitacion.Services.Interfaces
{
    interface IRequerimientoService
    {

        Task<Requerimiento> save(Requerimiento requerimiento);
        Task<List<Requerimiento>> finAll();
        Task<Requerimiento> findById(int Id);
        Task<Requerimiento> deleteById(int Id);
        Task<String> SaveConfigurationInitial(ConfigProceso configProceso);

        Task<MonitorRequerimientoDTO> saveMonitorRequerimiento(MonitorRequerimientoDTO monitorRequerimiento);
        /*Carga de data*/
        Task<List<Requerimiento>> migrateCsvData(string file);

    }
}

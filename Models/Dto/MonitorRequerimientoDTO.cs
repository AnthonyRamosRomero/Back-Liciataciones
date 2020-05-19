using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proyecto_Licitacion.Models.Entities;

namespace Proyecto_Licitacion.Models.Dto
{
    public class MonitorRequerimientoDTO
    {

        [JsonProperty("requerimiento")]
        public Requerimiento Requerimiento { get; set; }
        [JsonProperty("detalleRequerimientos")]
        public List<DetalleRequerimiento> DetalleRequerimiento { get; set; }
    }
}

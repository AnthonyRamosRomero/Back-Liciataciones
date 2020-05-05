using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Proyecto_Licitacion.Models.Entities
{
    public class Requerimiento : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public int TipoRequerimientoId { get; set; }
        public TipoRequerimiento TipoRequerimiento { get; set; }
        public int AreaSolicitanteId { get; set; }
        public AreaSolicitante AreaSolicitante { get; set; }
        public int ConfigProcesoId { get; set; }
        public ConfigProceso ConfigProceso { get; set; }
        public string UsuarioSolicitante { get; set; }
        public string FechaSolicitud { get; set; }
        public string FechaEstimadaEntrega { get; set; }

        /*ONE TO MANY*/
        [JsonIgnore]
        public virtual List<DetalleRequerimiento> DetalleRequerimientos { get; set; }
    }
}

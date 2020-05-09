using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("TipoRequerimientoId ")] 
        public virtual TipoRequerimiento TipoRequerimiento { get; set; }
        public int AreaSolicitanteId { get; set; } 
        [ForeignKey("AreaSolicitanteId")]//ClaveForanea
        public virtual AreaSolicitante AreaSolicitante { get; set; }
        public int ConfigProcesoId { get; set; }
        [ForeignKey("ConfigProcesoId")]
        public virtual ConfigProceso ConfigProceso { get; set; } // No son nulos
        public string UsuarioSolicitante { get; set; }
        public string FechaSolicitud { get; set; }
        public string FechaEstimadaEntrega { get; set; }

        /*ONE TO MANY*/
        [JsonIgnore]
        public virtual List<DetalleRequerimiento> DetalleRequerimientos { get; set; }
    }
}

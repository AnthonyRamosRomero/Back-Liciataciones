using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Licitacion.Models.Entities
{
    public class ConfigProceso : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int AnalistaId { get; set; } 
        [ForeignKey("AnalistaId")]
        public virtual Analista Analista { get; set; }
        public int EstadoId { get; set; }
        [ForeignKey("EstadoId")]
        public virtual Estado Estado { get; set; }

        public string FechaTratamiento { get; set; }
        public string FechaAdjudicacion { get; set; }


        [JsonIgnore]
        public virtual List<Proceso> Procesos { get; set; }

        [JsonIgnore]
        public virtual List<Requerimiento> Requerimientos { get; set; }


    }
}

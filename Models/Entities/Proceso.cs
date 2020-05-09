using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Licitacion.Models.Entities
{
    public class Proceso : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int ConfigProcesoId { get; set; }
        [ForeignKey("ConfigProcesoId")]
        public virtual ConfigProceso ConfigProceso { get; set; }
        public string TipoProceso { get; set; }

        [JsonIgnore]
        public virtual List<Ronda> Rondas { get; set; }


    }
}

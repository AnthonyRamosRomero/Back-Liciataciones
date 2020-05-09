using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Proyecto_Licitacion.Models.Entities
{
    public class Ronda : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int ProcesoId { get; set; } 
        [ForeignKey("ProcesoId")]
        public virtual Proceso Proceso { get; set; }
        public string NumeroRonda { get; set; }

        /*ONE TO MANY*/
        [JsonIgnore]
        public virtual List<RondaProveedor> RondaProveedores { get; set; }

    }
}

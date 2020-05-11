using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Proyecto_Licitacion.Models.Entities
{
    public class RondaProveedor : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int? RondaId { get; set; }
        [ForeignKey("RondaId")]
        public virtual Ronda Ronda { get; set; }
        public int? ProveedorId { get; set; }
        [ForeignKey("ProveedorId")]
        public virtual Proveedor Proveedor { get; set; }

        /*ONE TO MANY*/
        [JsonIgnore]
        public virtual List<AdjuntoRondaProveedor> AdjuntoRondaProveedores { get; set; }

    }
}

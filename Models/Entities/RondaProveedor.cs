using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Proyecto_Licitacion.Models.Entities
{
    public class RondaProveedor : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int RondaId { get; set; }
        public Ronda Ronda { get; set; }
        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }

        /*ONE TO MANY*/
        [JsonIgnore]
        public virtual List<AdjuntoRondaProveedor> AdjuntoRondaProveedores { get; set; }

    }
}

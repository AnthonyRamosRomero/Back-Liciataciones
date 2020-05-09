    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Proyecto_Licitacion.Models.Entities
{
    public class AdjuntoRondaProveedor : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int AdjuntoId { get; set; } 
        [ForeignKey ("AdjuntoId")]
        public virtual Adjunto Adjunto { get; set; }
        public int RondaProveedorId { get; set; }
        [ForeignKey("RondaProveedorId")]
        public virtual RondaProveedor RondaProveedor { get; set; }

    }
}

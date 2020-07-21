using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Licitacion.Models.Entities
{
    public class ReqProveedor : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        
        public int? ProveedorId { get; set; }
        [ForeignKey("ProveedorId")]
        public virtual Proveedor Proveedor { get; set; }

        public int? RequerimientoId { get; set; }
        [ForeignKey("RequerimientoId")]
        public virtual Requerimiento Requerimiento { get; set; }

        public String Ganador { get; set; }
    }
}

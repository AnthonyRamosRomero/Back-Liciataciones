using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Proyecto_Licitacion.Models.Entities
{
    public class Proveedor : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string NumeroRuc { get; set; }
        public string Mails { get; set; }
        public string Tel { get; set; }
        public string Direccion { get; set; }
        public string Contacto { get; set; }

        /*ONE TO MANY*/
        [JsonIgnore]
        public virtual List<RondaProveedor> RondaProveedores { get; set; }

    }
}

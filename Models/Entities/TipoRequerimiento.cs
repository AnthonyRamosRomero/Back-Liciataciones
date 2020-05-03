using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Proyecto_Licitacion.Models.Entities
{
    public class TipoRequerimiento : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }

        /*ONE TO MANY*/
        [JsonIgnore]
        public virtual List<Requerimiento> Requerimientos { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Proyecto_Licitacion.Models.Entities
{
    public class Analista : BaseEntity
    {
        
        public int Id { get; set; }
        public string Descripcion { get; set; }


        [JsonIgnore]
        public virtual List<ConfigProceso> ConfigProcesos { get; set; }
    }
}

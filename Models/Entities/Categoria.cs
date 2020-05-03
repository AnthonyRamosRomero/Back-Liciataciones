using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Proyecto_Licitacion.Models.Entities
{
    public class Categoria : BaseEntity
    {
        public int Id { get; set; }
        public string Nombre{ get; set; }
        public string Descripcion { get; set; }

        /*ONE TO MANY*/
        [JsonIgnore]
        public virtual List<Producto> Productos { get; set; }
    }
}

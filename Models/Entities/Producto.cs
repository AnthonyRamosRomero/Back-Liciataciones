using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Proyecto_Licitacion.Models.Entities
{
    public class Producto : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string UnidadMedida { get; set; }
        public string Descripcion { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        /*ONE TO MANY*/
        [JsonIgnore]
        public virtual List<DetalleRequerimiento> DetalleRequerimientos { get; set; }

    }
}

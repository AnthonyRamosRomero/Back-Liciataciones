using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Proyecto_Licitacion.Models.Entities
{
    public class Adjunto : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Path { get; set; }
        public int FolderId { get; set; }
        public int DocumentId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string ContentType { get; set; }

                /*ONE TO MANY*/
        [JsonIgnore]
        public virtual List<AdjuntoRondaProveedor> AdjuntoRondaProveedores { get; set; }
    }
}

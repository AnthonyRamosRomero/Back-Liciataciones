using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Proyecto_Licitacion.Models.Entities
{
    public class Usuario : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        /*MANY TO ONE*/
        public int AnalistaId { get; set; }

        [ForeignKey("AnalistaId")]
        public virtual  Analista analista { get; set; }
    }
}

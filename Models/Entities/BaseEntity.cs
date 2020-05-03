using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Licitacion.Models.Entities
{
    public class BaseEntity
    {
        public string Dml { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpDateTime { get; set; }
        public string UserLogin { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Licitacion.Document.Models
{
    public class FileBase64
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public string ContentType { get; set; }
        public string Base64 { get; set; }
    }
}

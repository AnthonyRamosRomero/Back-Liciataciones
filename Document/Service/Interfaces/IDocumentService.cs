using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto_Licitacion.Document.Models;

namespace Proyecto_Licitacion.Document.Service.Interfaces
{
    interface IDocumentService
    {
        FileBase64 getDocumentToFileBase64(String idDocumento);
    }
}

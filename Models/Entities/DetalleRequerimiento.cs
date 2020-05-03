using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Licitacion.Models.Entities
{
    public class DetalleRequerimiento : BaseEntity
    {
        [Key]

        public int Id { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int RequerimientoId { get; set; }
        public Requerimiento Requerimiento { get; set; }
        public int CantidadSolicitada { get; set; }
        public int PrecioUnitarioEstimado { get; set; }
        public double PrecioTotalEstimado { get; set; }
    }
}

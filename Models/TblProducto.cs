using System;
using System.Collections.Generic;

#nullable disable

namespace webcodefirst.Models
{
    public partial class TblProducto
    {
        public int Id { get; set; }
        public string CodigoProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int TblColorId { get; set; }
        public decimal Existencia { get; set; }

        public virtual TblColor TblColor { get; set; }
    }
}

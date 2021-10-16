using System;
using System.Collections.Generic;

#nullable disable

namespace webcodefirst.Models
{
    public partial class TblColor
    {
        public TblColor()
        {
            TblProductos = new HashSet<TblProducto>();
        }

        public int Id { get; set; }
        public string CodigoColor { get; set; }
        public string CodigoHex { get; set; }
        public string NombreColor { get; set; }
        public byte[] Foto { get; set; }
        public bool GrupoOrdenamiento { get; set; }

        public virtual ICollection<TblProducto> TblProductos { get; set; }
    }
}

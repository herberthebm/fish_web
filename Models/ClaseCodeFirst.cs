using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webcodefirst.Models
{
    public class lscDBContext:DbContext
    {
        public lscDBContext(DbContextOptions<lscDBContext> options) : base(options) 
        { 
        
        }
        DbSet<tblProductos> tblProductos { get; set; }
        DbSet<tblColor> tblColor { get; set; }
    }

    public class tblProductos { 
        public int Id { get; set; }
        [MaxLength(20)] [Required] public string CodigoProducto { get; set; }
        [MaxLength(50)] public string Nombre { get; set; }
        [MaxLength(250)] public string Descripcion { get; set; }
        public int tblColorId { get; set; } public tblColor tblColor { get; set; }
        public decimal Existencia { get; set; }        
    }

    public class tblColor { 
        public int Id { get; set; }
        [MaxLength(10)] [Required] public string CodigoColor { get; set; }
        [MaxLength(6)] public string CodigoHex { get; set; }
        [MaxLength(50)] public string NombreColor { get; set; }
        public byte[] Foto { get; set; }
        public bool GrupoOrdenamiento { get; set; }
    }
}

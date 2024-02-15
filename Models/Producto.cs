using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ExamenDefontana_MomoRobertino.Models
{
    public partial class Producto
    {
        public Producto()
        {
            VentaDetalle = new HashSet<VentaDetalle>();
        }

        public long IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public long IdMarca { get; set; }
        public string Modelo { get; set; }
        public int CostoUnitario { get; set; }

        public virtual Marca IdMarcaNavigation { get; set; }
        public virtual ICollection<VentaDetalle> VentaDetalle { get; set; }
    }
}

using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ExamenDefontana_MomoRobertino.Models
{
    public partial class VentaDetalle
    {
        public long IdVentaDetalle { get; set; }
        public long IdVenta { get; set; }
        public int PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public int TotalLinea { get; set; }
        public long IdProducto { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
        public virtual Venta IdVentaNavigation { get; set; }
    }
}

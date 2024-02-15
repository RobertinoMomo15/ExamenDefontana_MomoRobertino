using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ExamenDefontana_MomoRobertino.Models
{
    public partial class Venta
    {
        public Venta()
        {
            VentaDetalle = new HashSet<VentaDetalle>();
        }

        public long IdVenta { get; set; }
        public int Total { get; set; }
        public DateTime Fecha { get; set; }
        public long IdLocal { get; set; }

        public virtual Local IdLocalNavigation { get; set; }
        public virtual ICollection<VentaDetalle> VentaDetalle { get; set; }
    }
}

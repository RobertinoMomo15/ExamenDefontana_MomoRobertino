using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ExamenDefontana_MomoRobertino.Models
{
    public partial class Local
    {
        public Local()
        {
            Venta = new HashSet<Venta>();
        }

        public long IdLocal { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}

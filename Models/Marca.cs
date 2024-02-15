using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ExamenDefontana_MomoRobertino.Models
{
    public partial class Marca
    {
        public Marca()
        {
            Producto = new HashSet<Producto>();
        }

        public long IdMarca { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}

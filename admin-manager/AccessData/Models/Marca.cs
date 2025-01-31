using System;
using System.Collections.Generic;

namespace AccessData.Models
{
    public partial class Marca
    {
        public Marca()
        {
            Modelos = new HashSet<Modelo>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Modelo> Modelos { get; set; }
    }
}

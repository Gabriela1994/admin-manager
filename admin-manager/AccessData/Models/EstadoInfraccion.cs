using System;
using System.Collections.Generic;

namespace AccessData.Models
{
    public partial class EstadoInfraccion
    {
        public EstadoInfraccion()
        {
            Infraccions = new HashSet<Infraccion>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Infraccion> Infraccions { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace AccessData.Models
{
    public partial class Modelo
    {
        public Modelo()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }

        public int Id { get; set; }
        public int? IdMarca { get; set; }
        public string? Nombre { get; set; }
        public int? Año { get; set; }

        public virtual Marca? IdMarcaNavigation { get; set; }
        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}

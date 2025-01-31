using System;
using System.Collections.Generic;

namespace AccessData.Models
{
    public partial class TipoVehiculo
    {
        public TipoVehiculo()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}

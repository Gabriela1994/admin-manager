using System;
using System.Collections.Generic;

namespace AccessData.Models
{
    public partial class Infraccion
    {
        public int Id { get; set; }
        public int? IdVehiculo { get; set; }
        public int? IdTipoInfraccion { get; set; }
        public int? IdEstadoInfraccion { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Latitud { get; set; }
        public string? Longitud { get; set; }

        public virtual EstadoInfraccion? IdEstadoInfraccionNavigation { get; set; }
        public virtual TipoInfraccion? IdTipoInfraccionNavigation { get; set; }
        public virtual Vehiculo? IdVehiculoNavigation { get; set; }
    }
}

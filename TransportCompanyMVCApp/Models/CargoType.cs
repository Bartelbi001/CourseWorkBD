using System;
using System.Collections.Generic;

#nullable disable

namespace TransportCompanyMVCApp.Models
{
    public partial class CargoType
    {
        public CargoType()
        {
            Cargos = new HashSet<Cargo>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string VehicleType { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Cargo> Cargos { get; set; }
    }
}

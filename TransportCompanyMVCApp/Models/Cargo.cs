using System;
using System.Collections.Generic;

#nullable disable

namespace TransportCompanyMVCApp.Models
{
    public partial class Cargo
    {
        public Cargo()
        {
            Fligts = new HashSet<Fligt>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CargoTypesId { get; set; }
        public int ShelfLife { get; set; }
        public string Feature { get; set; }

        public virtual CargoType CargoTypes { get; set; }
        public virtual ICollection<Fligt> Fligts { get; set; }
    }
}

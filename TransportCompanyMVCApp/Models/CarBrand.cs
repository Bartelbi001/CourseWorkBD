using System;
using System.Collections.Generic;

#nullable disable

namespace TransportCompanyMVCApp.Models
{
    public partial class CarBrand
    {
        public CarBrand()
        {
            Cars = new HashSet<Car>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Specification { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}

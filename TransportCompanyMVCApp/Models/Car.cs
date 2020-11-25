using System;
using System.Collections.Generic;

#nullable disable

namespace TransportCompanyMVCApp.Models
{
    public partial class Car
    {
        public Car()
        {
            Fligts = new HashSet<Fligt>();
        }

        public int Id { get; set; }
        public int CarBrandId { get; set; }
        public int CarTypeId { get; set; }
        public string RegistrationNumber { get; set; }
        public string BodyNumber { get; set; }
        public string EngineNumber { get; set; }
        public int YearOfIssue { get; set; }
        public string DriverEmployee { get; set; }
        public DateTime DateOfLastMaintenance { get; set; }
        public string Mechanic { get; set; }

        public virtual CarBrand CarBrand { get; set; }
        public virtual CarType CarType { get; set; }
        public virtual ICollection<Fligt> Fligts { get; set; }
    }
}

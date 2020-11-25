using System;
using System.Collections.Generic;

#nullable disable

namespace TransportCompanyMVCApp.Models
{
    public partial class Fligt
    {
        public int Id { get; set; }
        public int? CarId { get; set; }
        public string Customer { get; set; }
        public string FromWhere { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int CargoId { get; set; }
        public decimal Price { get; set; }
        public string PaymentMark { get; set; }
        public string ReturnMark { get; set; }
        public string DriverEmployee { get; set; }

        public virtual Car Car { get; set; }
        public virtual Cargo Cargo { get; set; }
    }
}

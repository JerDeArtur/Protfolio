using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASP.Models
{
    public class Plane
    {

        public Plane() { }

        public int IdPlane { set; get; }
        public int IdAirport { set; get; }
        public DateTime LastRepair { set; get; }
        public int SeatsCount { set; get; }
        public string State { set; get; }

        public virtual Airport Airport { set; get; }
        public virtual ICollection<Repair> Repairs { set; get; }
        public virtual ICollection<Flight> Flights { set; get; }
    }
}

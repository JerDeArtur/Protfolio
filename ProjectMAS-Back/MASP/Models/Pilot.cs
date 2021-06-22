using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASP.Models
{
    public class Pilot
    {

        public Pilot() { }

        public int IdPilot { set; get; }
        public int IdPerson { set; get; }
        public int TotalPractice { set; get; }
        public int MonthlyFlights { set; get; }

        public virtual Person Person { set; get; }
        public virtual ICollection<Flight> FlightsAs1 { set; get; }
        public virtual ICollection<Flight> FlightsAs2 { set; get; }

    }
}

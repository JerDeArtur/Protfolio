using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASP.Models
{
    public class Flight
    {
        public Flight() { }

        public int IdFlight { set; get; }
        public string From { set; get; }
        public string To { set; get; }
        public int Line { set; get; }
        public double Price { set; get; }
        public DateTime TakeOffDate { set; get; }
        public DateTime LandingDate { set; get; }
        public int IdPlane { set; get; }
        public int IdPilot1 { set; get; }
        public int IdPilot2 { set; get; }
        public int? IdFlightParent { set; get; }

        public virtual Flight FlightParent { set; get; }
        public virtual ICollection<Flight> FlightsChild { set; get; }
        public virtual ICollection<Ticket> Tickets { set; get; }
        public virtual Plane Plane { set; get; }
        public virtual Pilot Pilot1 { set; get; }
        public virtual Pilot Pilot2 { set; get; }
    }
}

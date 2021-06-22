using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASP.Models
{
    public class Airport
    {
        public Airport() { }
        public int IdAirport { set; get; }
        public string Name { set; get; }
        public int NumberOfLines { set; get; }
        public int IdCD { set; get; }

        public virtual ContactData ContactData { set; get; }
        public virtual ICollection<Employment> Employments { set; get; }
        public virtual ICollection<Plane> Planes { set; get; }
        public virtual ICollection<Ticket> Tickets { set; get; }
    }
}

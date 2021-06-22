using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASP.Models
{
    public class Ticket
    {
        public Ticket() { }

        public int IdTicket { set; get; }
        public int IdOrder { set; get; }
        public int IdFlight { set; get; }
        public int IdAirport { set; get; }
        public int SeatsAmount { set; get; }
        public bool Approved { set; get; }
        public string Class { set; get; }
        public int BaggageType { set; get; }
        public bool Animals { set; get; }
        public bool AdditonalMeal { set; get; }
        public string Seat { set; get; }

        public virtual Order Order { set; get; }
        public virtual Flight Flight { set; get; }
        public virtual Airport Airport { set; get; }

    }
}

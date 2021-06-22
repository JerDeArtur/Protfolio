using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASP.Models
{
    public class Order
    {
        public Order() { }

        public int IdOrder { set; get; }
        public DateTime CreationDate { set; get; }
        public bool Payed { set; get; }
        public int IdPerson { set; get; }
        public double? TotalPrice { set; get; }

        public virtual Person Person { set; get; }
        public virtual ICollection<Ticket> Tickets { set; get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASP.Models
{
    public class Employment
    {
        public Employment() { }
        public int IdEmployment { set; get; }
        public int? IdPerson { set; get; }
        public int? IdAirport { set; get; }
        public DateTime HireDate { set; get; }
        public DateTime? Retire { set; get; }
        public string? Characteristics { set; get; }

        public virtual Person Person { set; get; }
        public virtual Airport Airport { set; get; }
    }
}

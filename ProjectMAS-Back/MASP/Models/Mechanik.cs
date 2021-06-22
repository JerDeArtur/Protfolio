using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASP.Models
{
    public class Mechanik
    {
        public Mechanik() { }

        public int IdMechanik { set; get; }
        public int MonthlyRepairs { set; get; }
        public int IdPerson { set; get; }

        public virtual Person Person { set; get; }
        public virtual ICollection<Education> Educations { set; get; }
        public virtual ICollection<Repair> Repairs { set; get; }
    }
}

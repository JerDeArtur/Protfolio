using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASP.Models
{
    public class Staff
    {
        public Staff() { }

        public int IdStaff { set; get; }
        public int WeeklyWorkTime { set; get; }

        public int IdPerson { set; get; }

        public virtual Person Person { set; get; }
    }
}

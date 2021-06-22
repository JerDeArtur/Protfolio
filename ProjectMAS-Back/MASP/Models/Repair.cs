using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASP.Models
{
    public class Repair
    {
        public Repair() { }

        public int IdRepair { set; get; }
        public int IdPlane { set; get; }
        public int IdMechanik { set; get; }
        public DateTime Date { set; get; }
        public int Duration { set; get; }
        public string Type { set; get; }

        public virtual Mechanik Mechanik { set; get; }
        public virtual Plane Plane { set; get; }
    }
}

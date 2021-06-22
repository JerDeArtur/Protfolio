using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASP.Models
{
    public class Education
    {

        public Education() { }

        public int IdEducation { set; get; }
        public string Name { set; get; }
        public string? University { set; get; }
        public string? Grade { set; get; }
        public int IdMechanik { set; get; }

        public virtual Mechanik Mechanik { set; get; }
    }
}

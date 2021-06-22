using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASP.Models
{
    public class Person
    {
        public Person() { }

        public int IdPerson { set; get; }
        public string Name { set; get; }
        public string Surname { set; get; }
        public int IdCD { set; get; }
        public string? PESEL { set; get; } //{ unique }
        public double? Salary { set; get; }
        public int? IdEmp { set; get; } //{ unique }
        public string? Login { set; get; }//{ unique } [0..1]
        public string? Password { set; get; }// [0..1]]
        public bool Logined { set; get; }
        public int IdType { set; get; }


        public virtual ContactData ContactData { set; get; }
        public virtual ICollection<Employment> Employments { set; get; }
        public virtual ICollection<Order> Orders { set; get; }
        public virtual Mechanik Mechanik { set; get; }
        public virtual Pilot Pilot { set; get; }
        public virtual Staff Staff { set; get; }
}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASP.Models
{
    public class ContactData
    {
        public ContactData() { }

        public int IdCD { set; get; }
        public string PhoneNumber { set; get; }
        public string Email { set; get; }
        public string PostCode { set; get; }
        public string City { set; get; }
        public string Street { set; get; }
        public int? AppartmentNumber { set; get; }

        public virtual Airport Airport { set; get; }
        public virtual Person Person { set; get; }
    }
}

using MASP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MASP.DTO
{
    public class TicketRequest
    {
        [Required]
        public int idPerson { set; get; }
        [Required]
        public int idOrder { set; get; }
        public Ticket ticket { set; get; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MASP.DTO
{
    public class OrderRequest
    {
        [Required]
        public int idPerson { set; get; }
    }
}

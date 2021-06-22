using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MASP.DTO
{
    public class LogInRequest
    {
        [Required]
        public string login { set; get; }
        [Required]
        public string password { set; get; }
    }
}

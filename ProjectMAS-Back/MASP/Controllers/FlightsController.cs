using MASP.DTO;
using MASP.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASP.Controllers
{
    [ApiController]
    [Route("flights")]
    public class FlightsController : ControllerBase
    {
        private readonly ISqLServerService service;

        public FlightsController(ISqLServerService ser)
        {
            service = ser;
        }

        [HttpGet]
        public IActionResult GetFlights([FromQuery]string from, [FromQuery] string to, [FromQuery] string date)
        {
            DateTime? ndate = null;
            try
            {
                ndate = DateTime.Parse(date);
            }
            catch (Exception) { }
            var res = service.GetFlights(from,to,ndate);
            return Ok(res);
        }
    }
}

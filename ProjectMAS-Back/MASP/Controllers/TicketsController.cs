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
    [Route("ticket")]
    public class TicketsController : ControllerBase
    {

        private readonly ISqLServerService service;

        public TicketsController(ISqLServerService ser)
        {
            service = ser;
        }

        [HttpPost]
        [Route("get")]
        public IActionResult GetTickets([FromBody] TicketRequest req)
        {
            var res = service.GetTickets(req.idPerson, req.idOrder);
            if (res == null)
                return NotFound("Person or order data is incorrect");
            return Ok(res);
        }

        [HttpPost]
        public IActionResult CreateTicket([FromBody]TicketRequest ticketRequest)
        {
            var res = service.CreateTicket(ticketRequest.idPerson, ticketRequest.ticket, ticketRequest.idOrder);
            if (res == null)
                return NotFound("Ticket data is incorrect or such order does not exist");
            return Ok(res);
        }


    }
}

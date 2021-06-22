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
    [Route("order")]
    public class OrdersController : ControllerBase
    {

        private readonly ISqLServerService service;

        public OrdersController(ISqLServerService ser)
        {
            service = ser;
        }

        [HttpPost]
        public IActionResult GetOrders([FromBody] OrderRequest req)
        {
            var res = service.GetOrders(req.idPerson);
            if (res == null)
                return NotFound("Person data is incorrect");
            return Ok(res);
        }

        [HttpPost("reserve")]
        public IActionResult Reserve([FromBody] TicketRequest req)
        {
            var res = service.PayReserve(req.idPerson, req.idOrder);
            if (res == null)
                return NotFound("Passed data is incorrect");
            return Ok(res);
        }

        [HttpPost("fully")]
        public IActionResult PayFully([FromBody] TicketRequest req)
        {
            var res = service.PayFully(req.idPerson, req.idOrder);
            if (res == null)
                return NotFound("Passed data is incorrect");
            return Ok(res);
        }
    }
}

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
    [Route("login")]
    public class PersonsController : ControllerBase
    {
        private readonly ISqLServerService service;

        public PersonsController(ISqLServerService ser)
        {
            service = ser;
        }
        [HttpPost]
        public IActionResult LogIn([FromBody] LogInRequest req)
        {
            var res = service.Login(req.login, req.password);
            if (res == null)
                return NotFound(req.login+" and "+req.password);
            return Ok(res);
        }
    }
}

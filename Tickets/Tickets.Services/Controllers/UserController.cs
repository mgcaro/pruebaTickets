using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Tickets.Data;

namespace Tickets.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        TicketsContext db = new TicketsContext();

        [HttpGet]
        [ProducesResponseType(typeof(List<Usuario>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get()
        {
            var users = db.Usuarios.ToList();

            return Ok(users);
        }
    }
}

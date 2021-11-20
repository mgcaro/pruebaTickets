using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Tickets.Data;
using Tickets.Services.Model;

namespace Tickets.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        TicketsContext db = new TicketsContext();

        [HttpGet("GetAll/{page?}")]
        [ProducesResponseType(typeof(List<Ticket>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get(int? page)
        {
            // 2 items per page, if we have more items we'll be able to increase the number.
            int itemsPerPage = 2;
            int firstNumber = (itemsPerPage * ((page ?? 1)-1));

            var tickets = db.Tickets.Skip(firstNumber).Take(itemsPerPage)
                .Include(r=>r.IdEstatusNavigation).Include(r=>r.IdUsuarioNavigation)
                .ToList();

            return Ok(tickets);
        }

        [HttpGet("{idTicket}")]
        [ProducesResponseType(typeof(Ticket), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get(int idTicket)
        {
            var ticket = db.Tickets.Where(r=>r.IdTicket==idTicket).Include(r => r.IdEstatusNavigation).Include(r => r.IdUsuarioNavigation)
                .FirstOrDefault();

            return Ok(ticket);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Ticket), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Post(Ticket ticket)
        {
            ticket.FechaCreacion = DateTime.Now;
            ticket.IdEstatus = (int)EnumStatus.Open;
            db.Tickets.Add(ticket);
            db.SaveChanges();
            return Ok(ticket);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Ticket), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Put(Ticket ticket)
        {
            ticket.FechaCreacion = db.Tickets.Where(r => r.IdTicket == ticket.IdTicket).Select(r => r.FechaCreacion).FirstOrDefault();
            ticket.FechaActualizacion = DateTime.Now;
            db.Entry(ticket).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(ticket);
        }

        [HttpDelete("{idTicket}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Delete(int idTicket)
        {
            var ticket = db.Tickets.FirstOrDefault(r => r.IdTicket == idTicket);
            db.Tickets.Remove(ticket);
            db.SaveChanges();
            return Ok(true);
        }
    }
}

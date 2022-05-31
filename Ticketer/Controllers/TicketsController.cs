#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ticketer.Data;
using Ticketer.Models;

namespace Ticketer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly TimingController _timing;

        public TicketsController(DataContext context, TimingController timing)
        {
            _context = context;
            _timing = timing;
        }

        // GET: Tickets
        [HttpGet]
        public async Task<ActionResult<List<Ticket>>> Get()
        {
            return Ok(await _context.Ticket.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Ticket>>> GetTicket(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);

            if(ticket == null)
            {
                return NotFound("Ticket Not Found");
            }

            return Ok(ticket);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTicket(Ticket ticket)
        {

            var time = new Timing();
            ticket.status = "Opened";
            ticket.isBase = false;
            ticket.baseTicketId = null;

            // Todo: add userOpenId
            // ticket.userOpenId = user.id;

            _context.Ticket.Add(ticket);

            await _context.SaveChangesAsync();

            time.ticketId = ticket.id;
            time.collectTime = ticket.date;
            await _timing.CreateTime(time);

            return CreatedAtAction(nameof(Get), new { id = ticket.id }, ticket);
        }

        // Todo: create a controller for sub-ticket

        [HttpPut("{id}")]
        public async Task<ActionResult> EditTicket(Ticket ticket)
        {
            var tic = await _context.Ticket.FindAsync(ticket.id);
            if(tic == null)
            {
                return NotFound("Ticket Not Found");
            }

            tic.title = ticket.title;
            tic.description = ticket.description;
            tic.date = ticket.date;
            tic.status = ticket.status;
            tic.flag = ticket.flag;
            tic.baseTicketId = ticket.baseTicketId;
            tic.category = ticket.category;
            tic.departmentId = ticket.departmentId;
            tic.isBase = ticket.isBase;
            tic.userCollectId = ticket.userCollectId;
            tic.userProcessId = ticket.userProcessId;
            tic.userOpenId = ticket.userOpenId;
            

            await _context.SaveChangesAsync();

            return Ok(await _context.Ticket.ToListAsync());

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTicket(int id)
        {
            var tic = await _context.Ticket.FindAsync(id);
            if(tic == null)
            {
                return BadRequest("Ticket Not Found");
            }

            _context.Ticket.Remove(tic);

            await _context.SaveChangesAsync();

            return Ok(await _context.Ticket.ToListAsync());
        }

    }
}

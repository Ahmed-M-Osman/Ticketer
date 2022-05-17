using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ticketer.Data;
using Ticketer.Models;

namespace Ticketer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimingController : Controller
    {
        private readonly DataContext _context;

        public TimingController(DataContext context)
        {
            _context = context;
        }

        // GET: Tickets
        [HttpGet]
        public async Task<ActionResult<List<Timing>>> Get()
        {
            return Ok(await _context.Timing.ToListAsync());
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Timing>> GetTime(int id)
        {
            var time = await _context.Timing.FindAsync(id);

            if (time == null)
            {
                return NotFound();
            }

            return time;

        }

        [HttpPost]
        public async Task<ActionResult<List<Timing>>> CreateTime(Timing time)
        {
            _context.Timing.Add(time);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(Get), new { id = time.id }, time);
        }


        [HttpPut]
        public async Task<ActionResult<Timing>> EditTime(Timing time)
        {
            var dbtime = await _context.Timing.FindAsync(time.id);

            if (dbtime == null)
                return BadRequest("Department Not Found");

            dbtime.ticketId = time.ticketId;
            dbtime.collectTime = time.collectTime;
            dbtime.processTime = time.processTime;
            dbtime.solveTime = time.solveTime;
            dbtime.suspendTime = time.suspendTime;
            dbtime.pendingTime = time.pendingTime;
            dbtime.closeTime = time.closeTime;

            await _context.SaveChangesAsync();

            return Ok(await _context.Timing.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Timing>> DeleteTime(int id)
        {
            var dbtime = await _context.Timing.FindAsync(id);

            if (dbtime == null)
                return BadRequest("Department Not Found");

            _context.Timing.Remove(dbtime);

            await _context.SaveChangesAsync();

            return Ok(await _context.Timing.ToListAsync());
        }

    }
}

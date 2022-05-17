using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ticketer.Data;
using Ticketer.Models;

namespace Ticketer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolutionsController : Controller
    {
        private readonly DataContext _context;

        public SolutionsController(DataContext context)
        {
            _context = context;
        }

        // GET: Tickets
        [HttpGet]
        public async Task<ActionResult<List<Solution>>> Get()
        {
            return Ok(await _context.Solution.ToListAsync());
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Solution>> GetTime(int id)
        {
            var sol = await _context.Solution.FindAsync(id);

            if (sol == null)
            {
                return NotFound();
            }

            return sol;

        }

        [HttpPost]
        public async Task<ActionResult<List<Solution>>> PostTime(Solution sol)
        {
            _context.Solution.Add(sol);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(Get), new { id = sol.id }, sol);
        }

        [HttpPut]
        public async Task<ActionResult<Solution>> PutTime(Solution sol)
        {
            var dbsol = await _context.Solution.FindAsync(sol.id);

            if (sol == null)
                return BadRequest("Department Not Found");

            dbsol.date = sol.date;
            dbsol.ticketId = sol.ticketId;
            dbsol.description = sol.description;
            dbsol.recommendations = sol.recommendations;
            dbsol.references = sol.references;
            dbsol.links = sol.links;

            await _context.SaveChangesAsync();

            return Ok(await _context.Solution.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Solution>> DeleteTime(int id)
        {
            var dbsol = await _context.Solution.FindAsync(id);

            if (dbsol == null)
                return BadRequest("Department Not Found");

            _context.Solution.Remove(dbsol);

            await _context.SaveChangesAsync();

            return Ok(await _context.Solution.ToListAsync());
        }


    }
}

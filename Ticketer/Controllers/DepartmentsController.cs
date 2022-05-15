#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ticketer.Data;
using Ticketer.Models;

namespace Ticketer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : Controller
    {
        private readonly DataContext _context;

        public DepartmentsController(DataContext context)
        {
            _context = context;
        }

        // GET: Tickets
        [HttpGet]
        public async Task<ActionResult<List<Department>>> Get()
        {
            return Ok(await _context.Department.ToListAsync());
        }

        

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDep(int id)
        {
            var dep = await _context.Department.FindAsync(id);

            if (dep == null)
            {
                return NotFound();
            }

            return dep;

        }

        [HttpPost]
        public async Task<ActionResult<List<Department>>> PostDep(Department dep)
        {
            _context.Department.Add(dep);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(Get), new { id = dep.id }, dep);
        }

        [HttpPut]
        public async Task<ActionResult<Department>> PutDep(Department dep)
        {
            var dbdep = await _context.Department.FindAsync(dep.id);

            if (dbdep == null)
                return BadRequest("Department Not Found");

            dbdep.name = dep.name;
            dbdep.leadId = dep.leadId;

            await _context.SaveChangesAsync();

            return Ok(await _context.Department.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Department>> DeleteDep(int id)
        {
            var dbdep = await _context.Department.FindAsync(id);

            if (dbdep == null)
                return BadRequest("Department Not Found");

            _context.Department.Remove(dbdep);

            await _context.SaveChangesAsync();

            return Ok(await _context.Department.ToListAsync());
        }
    }
}

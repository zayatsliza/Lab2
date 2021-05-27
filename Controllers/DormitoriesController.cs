using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab2.Models;
using static Lab2.Validation;

namespace Lab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DormitoriesController : ControllerBase
    {
        private readonly Lab2Context _context;

        public DormitoriesController(Lab2Context context)
        {
            _context = context;
        }

        // GET: api/Dormitories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dormitory>>> GetDormitory()
        {
            return await _context.Dormitory.ToListAsync();
        }

        // GET: api/Dormitories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dormitory>> GetDormitory(int id)
        {
            var dormitory = await _context.Dormitory.FindAsync(id);

            if (dormitory == null)
            {
                return NotFound();
            }

            return dormitory;
        }

        // PUT: api/Dormitories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDormitory(int id, Dormitory dormitory)
        {
            if (id != dormitory.Id)
            {
                return BadRequest();
            }

            DormValid valid = new DormValid(_context, dormitory);
            if (valid.Valid() == false) return BadRequest("This Dormitory is already exist");

            _context.Entry(dormitory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DormitoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Dormitories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dormitory>> PostDormitory(Dormitory dormitory)
        {
            DormValid valid = new DormValid(_context, dormitory);
            if (valid.Valid() == false) return BadRequest("This dormitory is already exist");
            _context.Dormitory.Add(dormitory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDormitory", new { id = dormitory.Id }, dormitory);
        }

        // DELETE: api/Dormitories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dormitory>> DeleteDormitory(int id)
        {
            var dormitory = await _context.Dormitory.FindAsync(id);
            if (dormitory == null)
            {
                return NotFound();
            }

            _context.Dormitory.Remove(dormitory);
            await _context.SaveChangesAsync();

            return dormitory;
        }

        private bool DormitoryExists(int id)
        {
            return _context.Dormitory.Any(e => e.Id == id);
        }
    }
}

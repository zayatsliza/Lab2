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
    public class CampusesController : ControllerBase
    {
        private readonly Lab2Context _context;

        public CampusesController(Lab2Context context)
        {
            _context = context;
        }

        // GET: api/Campuses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Campus>>> GetCampus()
        {
            return await _context.Campus.ToListAsync();
        }

        // GET: api/Campuses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Campus>> GetCampus(int id)
        {
            var campus = await _context.Campus.FindAsync(id);

            if (campus == null)
            {
                return NotFound();
            }

            return campus;
        }

        // PUT: api/Campuses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCampus(int id, Campus campus)
        {
            if (id != campus.Id)
            {
                return BadRequest();
            }

            CampusValid valid = new CampusValid(_context, campus);
            if (valid.Valid() == false) return BadRequest("This Campus is already exist");

            _context.Entry(campus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampusExists(id))
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

        // POST: api/Campuses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Campus>> PostCampus(Campus campus)
        {
            CampusValid valid = new CampusValid(_context, campus);
            if (valid.Valid() == false) return BadRequest("This campus is already exist");
            _context.Campus.Add(campus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCampus", new { id = campus.Id }, campus);
        }

        // DELETE: api/Campuses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Campus>> DeleteCampus(int id)
        {
            var campus = await _context.Campus.FindAsync(id);
            if (campus == null)
            {
                return NotFound();
            }

            _context.Campus.Remove(campus);
            await _context.SaveChangesAsync();

            return campus;
        }

        private bool CampusExists(int id)
        {
            return _context.Campus.Any(e => e.Id == id);
        }
    }
}

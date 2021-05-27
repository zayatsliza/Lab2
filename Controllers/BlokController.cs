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
    public class BlokController : ControllerBase
    {
        private readonly Lab2Context _context;

        public BlokController(Lab2Context context)
        {
            _context = context;
        }

        // GET: api/Blok
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blok>>> GetBlok()
        {
            return await _context.Blok.ToListAsync();
        }

        // GET: api/Blok/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Blok>> GetBlok(int id)
        {
            var blok = await _context.Blok.FindAsync(id);

            if (blok == null)
            {
                return NotFound();
            }

            return blok;
        }

        // PUT: api/Blok/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlok(int id, Blok blok)
        {
            if (id != blok.Id)
            {
                return BadRequest();
            }

            BlokValid valid = new BlokValid(_context, blok);
            if (valid.Valid() == false) return BadRequest("This Block is already exist");

            _context.Entry(blok).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlokExists(id))
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

        // POST: api/Blok
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Blok>> PostBlok(Blok blok)
        {
            BlokValid valid = new BlokValid(_context, blok);
            if (valid.Valid() == false) return BadRequest("This blok is already exist");
            _context.Blok.Add(blok);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlok", new { id = blok.Id }, blok);
        }

        // DELETE: api/Blok/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Blok>> DeleteBlok(int id)
        {
            var blok = await _context.Blok.FindAsync(id);
            if (blok == null)
            {
                return NotFound();
            }

            _context.Blok.Remove(blok);
            await _context.SaveChangesAsync();

            return blok;
        }

        private bool BlokExists(int id)
        {
            return _context.Blok.Any(e => e.Id == id);
        }
    }
}

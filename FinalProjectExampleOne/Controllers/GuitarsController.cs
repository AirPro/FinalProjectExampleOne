using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProjectExampleOne.Data;
using FinalProjectExampleOne.Models;

namespace FinalProjectExampleOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuitarsController : ControllerBase
    {
        private readonly ContactsAPIDBContext _context;

        public GuitarsController(ContactsAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Guitars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guitar>>> GetGuitars()
        {
          if (_context.Guitars == null)
          {
              return NotFound();
          }
            return await _context.Guitars.ToListAsync();
        }

        // GET: api/Guitars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Guitar>> GetGuitar(Guid id)
        {
          if (_context.Guitars == null)
          {
              return NotFound();
          }
            var guitar = await _context.Guitars.FindAsync(id);

            if (guitar == null)
            {
                return NotFound();
            }

            return guitar;
        }

        // PUT: api/Guitars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuitar(Guid id, Guitar guitar)
        {
            if (id != guitar.Id)
            {
                return BadRequest();
            }

            _context.Entry(guitar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuitarExists(id))
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

        // POST: api/Guitars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Guitar>> PostGuitar(Guitar guitar)
        {
          if (_context.Guitars == null)
          {
              return Problem("Entity set 'ContactsAPIDBContext.Guitars'  is null.");
          }
            _context.Guitars.Add(guitar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGuitar", new { id = guitar.Id }, guitar);
        }

        // DELETE: api/Guitars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuitar(Guid id)
        {
            if (_context.Guitars == null)
            {
                return NotFound();
            }
            var guitar = await _context.Guitars.FindAsync(id);
            if (guitar == null)
            {
                return NotFound();
            }

            _context.Guitars.Remove(guitar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GuitarExists(Guid id)
        {
            return (_context.Guitars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

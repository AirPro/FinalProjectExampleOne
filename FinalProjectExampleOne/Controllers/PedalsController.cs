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
    public class PedalsController : ControllerBase
    {
        private readonly ContactsAPIDBContext _context;

        public PedalsController(ContactsAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Pedals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedal>>> GetPedals()
        {
          if (_context.Pedals == null)
          {
              return NotFound();
          }
            return await _context.Pedals.ToListAsync();
        }

        // GET: api/Pedals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedal>> GetPedal(Guid id)
        {
          if (_context.Pedals == null)
          {
              return NotFound();
          }
            var pedal = await _context.Pedals.FindAsync(id);

            if (pedal == null)
            {
                return NotFound();
            }

            return pedal;
        }

        // PUT: api/Pedals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedal(Guid id, Pedal pedal)
        {
            if (id != pedal.Id)
            {
                return BadRequest();
            }

            _context.Entry(pedal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedalExists(id))
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

        // POST: api/Pedals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pedal>> PostPedal(Pedal pedal)
        {
          if (_context.Pedals == null)
          {
              return Problem("Entity set 'ContactsAPIDBContext.Pedals'  is null.");
          }
            _context.Pedals.Add(pedal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedal", new { id = pedal.Id }, pedal);
        }

        // DELETE: api/Pedals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedal(Guid id)
        {
            if (_context.Pedals == null)
            {
                return NotFound();
            }
            var pedal = await _context.Pedals.FindAsync(id);
            if (pedal == null)
            {
                return NotFound();
            }

            _context.Pedals.Remove(pedal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PedalExists(Guid id)
        {
            return (_context.Pedals?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

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
    public class AmplifiersController : ControllerBase
    {
        private readonly ContactsAPIDBContext _context;

        public AmplifiersController(ContactsAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Amplifiers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Amplifier>>> GetAmplifiers()
        {
          if (_context.Amplifiers == null)
          {
              return NotFound();
          }
            return await _context.Amplifiers.ToListAsync();
        }

        // GET: api/Amplifiers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Amplifier>> GetAmplifier(Guid id)
        {
          if (_context.Amplifiers == null)
          {
              return NotFound();
          }
            var amplifier = await _context.Amplifiers.FindAsync(id);

            if (amplifier == null)
            {
                return NotFound();
            }

            return amplifier;
        }

        // PUT: api/Amplifiers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmplifier(Guid id, Amplifier amplifier)
        {
            if (id != amplifier.Id)
            {
                return BadRequest();
            }

            _context.Entry(amplifier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmplifierExists(id))
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

        // POST: api/Amplifiers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Amplifier>> PostAmplifier(Amplifier amplifier)
        {
          if (_context.Amplifiers == null)
          {
              return Problem("Entity set 'ContactsAPIDBContext.Amplifiers'  is null.");
          }
            _context.Amplifiers.Add(amplifier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAmplifier", new { id = amplifier.Id }, amplifier);
        }

        // DELETE: api/Amplifiers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmplifier(Guid id)
        {
            if (_context.Amplifiers == null)
            {
                return NotFound();
            }
            var amplifier = await _context.Amplifiers.FindAsync(id);
            if (amplifier == null)
            {
                return NotFound();
            }

            _context.Amplifiers.Remove(amplifier);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AmplifierExists(Guid id)
        {
            return (_context.Amplifiers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

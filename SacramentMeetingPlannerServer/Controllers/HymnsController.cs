using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlannerServer.Data;
using SacramentMeetingPlannerServer.Models;

namespace SacramentMeetingPlannerServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HymnsController : ControllerBase
    {
        private readonly SacramentMeetingPlannerServerContext _context;

        public HymnsController(SacramentMeetingPlannerServerContext context)
        {
            _context = context;
        }

        // GET: api/Hymns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hymn>>> GetHymn()
        {
          if (_context.Hymn == null)
          {
              return NotFound();
          }
            return await _context.Hymn.ToListAsync();
        }

        // GET: api/Hymns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hymn>> GetHymn(int id)
        {
          if (_context.Hymn == null)
          {
              return NotFound();
          }
            var hymn = await _context.Hymn.FindAsync(id);

            if (hymn == null)
            {
                return NotFound();
            }

            return hymn;
        }

        // PUT: api/Hymns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHymn(int id, Hymn hymn)
        {
            if (id != hymn.HymnNumber)
            {
                return BadRequest();
            }

            _context.Entry(hymn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HymnExists(id))
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

        // POST: api/Hymns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hymn>> PostHymn(Hymn hymn)
        {
          if (_context.Hymn == null)
          {
              return Problem("Entity set 'SacramentMeetingPlannerServerContext.Hymn'  is null.");
          }
            _context.Hymn.Add(hymn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHymn", new { id = hymn.HymnNumber }, hymn);
        }

        // DELETE: api/Hymns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHymn(int id)
        {
            if (_context.Hymn == null)
            {
                return NotFound();
            }
            var hymn = await _context.Hymn.FindAsync(id);
            if (hymn == null)
            {
                return NotFound();
            }

            _context.Hymn.Remove(hymn);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HymnExists(int id)
        {
            return (_context.Hymn?.Any(e => e.HymnNumber == id)).GetValueOrDefault();
        }
    }
}

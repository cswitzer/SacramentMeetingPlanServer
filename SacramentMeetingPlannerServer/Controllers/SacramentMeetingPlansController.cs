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
    public class SacramentMeetingPlansController : ControllerBase
    {
        private readonly SacramentMeetingPlannerServerContext _context;

        public SacramentMeetingPlansController(SacramentMeetingPlannerServerContext context)
        {
            _context = context;
        }

        // GET: api/SacramentMeetingPlans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SacramentMeetingPlan>>> GetSacramentMeetingPlan()
        {
          if (_context.SacramentMeetingPlan == null)
          {
              return NotFound();
          }
            return await _context.SacramentMeetingPlan.ToListAsync();
        }

        // GET: api/SacramentMeetingPlans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SacramentMeetingPlan>> GetSacramentMeetingPlan(int id)
        {
          if (_context.SacramentMeetingPlan == null)
          {
              return NotFound();
          }
            var sacramentMeetingPlan = await _context.SacramentMeetingPlan.FindAsync(id);

            if (sacramentMeetingPlan == null)
            {
                return NotFound();
            }

            return sacramentMeetingPlan;
        }

        // PUT: api/SacramentMeetingPlans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSacramentMeetingPlan(int id, SacramentMeetingPlan sacramentMeetingPlan)
        {
            if (id != sacramentMeetingPlan.SacramentMeetingPlanId)
            {
                return BadRequest();
            }

            _context.Entry(sacramentMeetingPlan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SacramentMeetingPlanExists(id))
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

        // POST: api/SacramentMeetingPlans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SacramentMeetingPlan>> PostSacramentMeetingPlan([Bind("ConductingLeaderId", "OpeningPrayerId", "SacramentPrayerId", "ClosingPrayerId", "OpeningHymnId", "SacramentHymnId", "IntermediateHymnId", "ClosingHymnId")] SacramentMeetingPlan sacramentMeetingPlan)
        {
          if (_context.SacramentMeetingPlan == null)
          {
              return Problem("Entity set 'SacramentMeetingPlannerServerContext.SacramentMeetingPlan'  is null.");
          }
            _context.SacramentMeetingPlan.Add(sacramentMeetingPlan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSacramentMeetingPlan", new { id = sacramentMeetingPlan.SacramentMeetingPlanId }, sacramentMeetingPlan);
        }

        // DELETE: api/SacramentMeetingPlans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSacramentMeetingPlan(int id)
        {
            if (_context.SacramentMeetingPlan == null)
            {
                return NotFound();
            }
            var sacramentMeetingPlan = await _context.SacramentMeetingPlan.FindAsync(id);
            if (sacramentMeetingPlan == null)
            {
                return NotFound();
            }

            _context.SacramentMeetingPlan.Remove(sacramentMeetingPlan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SacramentMeetingPlanExists(int id)
        {
            return (_context.SacramentMeetingPlan?.Any(e => e.SacramentMeetingPlanId == id)).GetValueOrDefault();
        }
    }
}

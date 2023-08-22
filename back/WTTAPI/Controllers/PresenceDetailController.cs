using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WTTAPI.Models;

namespace WTTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresenceDetailController : ControllerBase
    {
        private readonly PresenceDetailContext _context;

        public PresenceDetailController(PresenceDetailContext context)
        {
            _context = context;
        }

        // GET: api/PresenceDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PresenceDetail>>> GetPresenceDetails()
        {
          if (_context.PresenceDetails == null)
          {
              return NotFound();
          }
            return await _context.PresenceDetails.ToListAsync();
        }

        // GET: api/PresenceDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PresenceDetail>> GetPresenceDetail(int id)
        {
          if (_context.PresenceDetails == null)
          {
              return NotFound();
          }
            var presenceDetail = await _context.PresenceDetails.FindAsync(id);

            if (presenceDetail == null)
            {
                return NotFound();
            }

            return presenceDetail;
        }

        // PUT: api/PresenceDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPresenceDetail(int id, PresenceDetail presenceDetail)
        {
            if (id != presenceDetail.PresenceId)
            {
                return BadRequest();
            }

            _context.Entry(presenceDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PresenceDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await _context.PresenceDetails.ToListAsync());
        }

        // POST: api/PresenceDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PresenceDetail>> PostPresenceDetail(PresenceDetail presenceDetail)
        {
          if (_context.PresenceDetails == null)
          {
              return Problem("Entity set 'PresenceDetailContext.PresenceDetails'  is null.");
          }
            _context.PresenceDetails.Add(presenceDetail);
            await _context.SaveChangesAsync();

            return Ok(await _context.PresenceDetails.ToListAsync());
        }

        // DELETE: api/PresenceDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePresenceDetail(int id)
        {
            if (_context.PresenceDetails == null)
            {
                return NotFound();
            }
            var presenceDetail = await _context.PresenceDetails.FindAsync(id);
            if (presenceDetail == null)
            {
                return NotFound();
            }

            _context.PresenceDetails.Remove(presenceDetail);
            await _context.SaveChangesAsync();

            return Ok(await _context.PresenceDetails.ToListAsync());
        }

        private bool PresenceDetailExists(int id)
        {
            return (_context.PresenceDetails?.Any(e => e.PresenceId == id)).GetValueOrDefault();
        }
    }
}

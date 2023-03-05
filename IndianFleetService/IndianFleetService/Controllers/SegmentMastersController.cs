using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleConfigurator.Model;

namespace IndianFleetService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegmentMastersController : ControllerBase
    {
        private readonly VehicleDbContext _context;

        public SegmentMastersController(VehicleDbContext context)
        {
            _context = context;
        }

        // GET: api/SegmentMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SegmentMaster>>> GetSegmentMasterMasters()
        {
          if (_context.SegmentMasterMasters == null)
          {
              return NotFound();
          }
            return await _context.SegmentMasterMasters.ToListAsync();
        }

        // GET: api/SegmentMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SegmentMaster>> GetSegmentMaster(int id)
        {
          if (_context.SegmentMasterMasters == null)
          {
              return NotFound();
          }
            var segmentMaster = await _context.SegmentMasterMasters.FindAsync(id);

            if (segmentMaster == null)
            {
                return NotFound();
            }

            return segmentMaster;
        }

        // PUT: api/SegmentMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSegmentMaster(int id, SegmentMaster segmentMaster)
        {
            if (id != segmentMaster.SegId)
            {
                return BadRequest();
            }

            _context.Entry(segmentMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SegmentMasterExists(id))
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

        // POST: api/SegmentMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SegmentMaster>> PostSegmentMaster(SegmentMaster segmentMaster)
        {
          if (_context.SegmentMasterMasters == null)
          {
              return Problem("Entity set 'VehicleDbContext.SegmentMasterMasters'  is null.");
          }
            _context.SegmentMasterMasters.Add(segmentMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSegmentMaster", new { id = segmentMaster.SegId }, segmentMaster);
        }

        // DELETE: api/SegmentMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSegmentMaster(int id)
        {
            if (_context.SegmentMasterMasters == null)
            {
                return NotFound();
            }
            var segmentMaster = await _context.SegmentMasterMasters.FindAsync(id);
            if (segmentMaster == null)
            {
                return NotFound();
            }

            _context.SegmentMasterMasters.Remove(segmentMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SegmentMasterExists(int id)
        {
            return (_context.SegmentMasterMasters?.Any(e => e.SegId == id)).GetValueOrDefault();
        }
    }
}

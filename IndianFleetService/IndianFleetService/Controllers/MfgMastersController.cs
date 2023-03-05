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
    public class MfgMastersController : ControllerBase
    {
        private readonly VehicleDbContext _context;

        public MfgMastersController(VehicleDbContext context)
        {
            _context = context;
        }

        // GET: api/MfgMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MfgMaster>>> GetMfgMasters()
        {
          if (_context.MfgMasters == null)
          {
              return NotFound();
          }
            return await _context.MfgMasters.ToListAsync();
        }

        // GET: api/MfgMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MfgMaster>>> GetMfgMaster(int id)
        {
          if (_context.MfgMasters == null)
          {
              return NotFound();
          }
            var mfgMaster = await _context.MfgMasters.Where(p=>p.SegId == id).ToListAsync();

            Console.WriteLine(mfgMaster);

            if (mfgMaster == null)
            {
                return NotFound();
            }
            else
            {
                return mfgMaster;
            }
                
        }

        // PUT: api/MfgMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMfgMaster(int id, MfgMaster mfgMaster)
        {
            if (id != mfgMaster.MfgId)
            {
                return BadRequest();
            }

            _context.Entry(mfgMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MfgMasterExists(id))
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

        // POST: api/MfgMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MfgMaster>> PostMfgMaster(MfgMaster mfgMaster)
        {
          if (_context.MfgMasters == null)
          {
              return Problem("Entity set 'VehicleDbContext.MfgMasters'  is null.");
          }
            _context.MfgMasters.Add(mfgMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMfgMaster", new { id = mfgMaster.MfgId }, mfgMaster);
        }

        // DELETE: api/MfgMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMfgMaster(int id)
        {
            if (_context.MfgMasters == null)
            {
                return NotFound();
            }
            var mfgMaster = await _context.MfgMasters.FindAsync(id);
            if (mfgMaster == null)
            {
                return NotFound();
            }

            _context.MfgMasters.Remove(mfgMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MfgMasterExists(int id)
        {
            return (_context.MfgMasters?.Any(e => e.MfgId == id)).GetValueOrDefault();
        }
    }
}

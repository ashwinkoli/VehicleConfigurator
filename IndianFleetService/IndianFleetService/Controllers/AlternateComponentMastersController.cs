using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class AlternateComponentMastersController : ControllerBase
    {
        private readonly VehicleDbContext _context;

        public AlternateComponentMastersController(VehicleDbContext context)
        {
            _context = context;
        }

        // GET: api/AlternateComponentMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlternateComponentMaster>>> GetAlternateComponentMasters()
        {
          if (_context.AlternateComponentMasters == null)
          {
              return NotFound();
          }
            return await _context.AlternateComponentMasters.ToListAsync();
        }

        // GET: api/AlternateComponentMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlternateComponentMaster>> GetAlternateComponentMaster(int id)
        {
          if (_context.AlternateComponentMasters == null)
          {
              return NotFound();
          }
            var alternateComponentMaster = await _context.AlternateComponentMasters.FindAsync(id);

            if (alternateComponentMaster == null)
            {
                return NotFound();
            }

            return alternateComponentMaster;
        }

        [HttpGet("{id}/{ch}")]
        public async Task<ActionResult<IEnumerable<VehicleDbContext>>> GetAlternateComponentMaster(int id,  String ch)
        {
            if (_context.AlternateComponentMasters == null)
            {
                return NotFound();
            }
            using (var db = new VehicleDbContext())
            {
                var alternateComponentMaster = await db.AlternateComponentMasters
                                .Join(db.ComponentMasterMasters, a => a.AltCompId, c => c.CompId, (a, c) => new { a, c })
                                .Where(x => x.a.ModelId == id && x.a.AltCompId == x.c.CompId)
                                .Select(x => new 
                                {
                                    CompId = x.a.CompId,
                                    CompName = x.c.CompName,
                                    DeltaPrice = x.a.DeltaPrice,
                                    AltCompId = x.a.AltCompId   ,
                                    AltCompType = x.a.AltCompType,
                                }
                                ).ToListAsync();

                if (alternateComponentMaster == null)
                {
                    return NotFound();
                }

                return Ok(alternateComponentMaster);
            }

            

            
        }




        // PUT: api/AlternateComponentMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlternateComponentMaster(int id, AlternateComponentMaster alternateComponentMaster)
        {
            if (id != alternateComponentMaster.AltId)
            {
                return BadRequest();
            }

            _context.Entry(alternateComponentMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlternateComponentMasterExists(id))
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

        // POST: api/AlternateComponentMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AlternateComponentMaster>> PostAlternateComponentMaster(AlternateComponentMaster alternateComponentMaster)
        {
          if (_context.AlternateComponentMasters == null)
          {
              return Problem("Entity set 'VehicleDbContext.AlternateComponentMasters'  is null.");
          }
            _context.AlternateComponentMasters.Add(alternateComponentMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlternateComponentMaster", new { id = alternateComponentMaster.AltId }, alternateComponentMaster);
        }

        // DELETE: api/AlternateComponentMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlternateComponentMaster(int id)
        {
            if (_context.AlternateComponentMasters == null)
            {
                return NotFound();
            }
            var alternateComponentMaster = await _context.AlternateComponentMasters.FindAsync(id);
            if (alternateComponentMaster == null)
            {
                return NotFound();
            }

            _context.AlternateComponentMasters.Remove(alternateComponentMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlternateComponentMasterExists(int id)
        {
            return (_context.AlternateComponentMasters?.Any(e => e.AltId == id)).GetValueOrDefault();
        }
    }
}

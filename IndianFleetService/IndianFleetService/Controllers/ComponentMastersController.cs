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
    public class ComponentMastersController : ControllerBase
    {
        private readonly VehicleDbContext _context;

        public ComponentMastersController(VehicleDbContext context)
        {
            _context = context;
        }

        // GET: api/ComponentMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComponentMaster>>> GetComponentMasterMasters()
        {
          if (_context.ComponentMasterMasters == null)
          {
              return NotFound();
          }
            return await _context.ComponentMasterMasters.ToListAsync();
        }

        // GET: api/ComponentMasters/5/ch
        [HttpGet("{id}/{ch}")]
        public async Task<ActionResult<IEnumerable<ComponentMaster>>> GetComponentMaster(int id, String ch)
        {
          if (_context.ComponentMasterMasters == null)
          {
              return NotFound();
          }
    

          var componentMaster = await _context.VehicleDetailMasters
                                .Join(_context.ComponentMasterMasters, v => v.CompId, c => c.CompId, (v, c) => new { v, c })
                                .Where(x => x.v.CompType == ch && x.v.ModelId == id && x.v.CompId==x.c.CompId)
                                .Select(x => new ComponentMaster
                                {
                                        CompId = x.c.CompId,
                                        CompName = x.c.CompName
                                }).ToListAsync(); 

            if (componentMaster == null)
            {
                return NotFound();
            }

            return componentMaster;
        }

        [HttpGet("{id1}/{id2}/{x}/{y}")]
        public async Task<ActionResult<IEnumerable<ComponentMaster>>> GetComponentMaster(int id1, int id2, String x, String y )
        {
            if (_context.ComponentMasterMasters == null)
            {
                return NotFound();
            }


            var componentMaster = await _context.ComponentMasterMasters
                                        .Where(c => _context.AlternateComponentMasters
                                        .Where(a => a.ModelId == id1 && a.CompId == id2)
                                        .Any(a => a.AltCompId == c.CompId))
                                        .Select(c => new ComponentMaster
                                        {
                                                CompId = c.CompId,
                                                CompName = c.CompName,
                                        })
                                        .ToListAsync();


            if (componentMaster == null)
            {
                return NotFound();
            }

            return componentMaster;
        }


        [HttpGet("{id}/{ch}/{a}")]
        public async Task<ActionResult<IEnumerable<ComponentMaster>>> GetComponentMaster(int id, String ch, int a)
        {
            if (_context.ComponentMasterMasters == null)
            {
                return NotFound();
            }


            var componentMaster = await _context.VehicleDetailMasters
                                  .Join(_context.ComponentMasterMasters, v => v.CompId, c => c.CompId, (v, c) => new { v, c })
                                  .Where(x => x.v.CompType == ch && x.v.ModelId == id && x.v.CompId == x.c.CompId && x.v.IsConfigurable==true)
                                  .Select(x => new ComponentMaster
                                  {
                                      CompId = x.c.CompId,
                                      CompName = x.c.CompName
                                  }).ToListAsync();

            if (componentMaster == null)
            {
                return NotFound();
            }

            return componentMaster;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ComponentMaster>> GetComponentMaster(int id)
        {
            if (_context.ComponentMasterMasters == null)
            {
                return NotFound();
            }
            var componentMaster = await _context.ComponentMasterMasters.FindAsync(id);

            if (componentMaster == null)
            {
                return NotFound();
            }

            return componentMaster;
        }
        // PUT: api/ComponentMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComponentMaster(int id, ComponentMaster componentMaster)
        {
            if (id != componentMaster.CompId)
            {
                return BadRequest();
            }

            _context.Entry(componentMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponentMasterExists(id))
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

        // POST: api/ComponentMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ComponentMaster>> PostComponentMaster(ComponentMaster componentMaster)
        {
          if (_context.ComponentMasterMasters == null)
          {
              return Problem("Entity set 'VehicleDbContext.ComponentMasterMasters'  is null.");
          }
            _context.ComponentMasterMasters.Add(componentMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComponentMaster", new { id = componentMaster.CompId }, componentMaster);
        }

        // DELETE: api/ComponentMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComponentMaster(int id)
        {
            if (_context.ComponentMasterMasters == null)
            {
                return NotFound();
            }
            var componentMaster = await _context.ComponentMasterMasters.FindAsync(id);
            if (componentMaster == null)
            {
                return NotFound();
            }

            _context.ComponentMasterMasters.Remove(componentMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComponentMasterExists(int id)
        {
            return (_context.ComponentMasterMasters?.Any(e => e.CompId == id)).GetValueOrDefault();
        }
    }
}

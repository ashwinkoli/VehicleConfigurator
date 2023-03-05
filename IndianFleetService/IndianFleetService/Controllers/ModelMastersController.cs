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
    public class ModelMastersController : ControllerBase
    {
        private readonly VehicleDbContext _context;

        public ModelMastersController(VehicleDbContext context)
        {
            _context = context;
        }

        // GET: api/ModelMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModelMaster>>> GetModelMasterMasters()
        {
          if (_context.ModelMasterMasters == null)
          {
              return NotFound();
          }
            return await _context.ModelMasterMasters.ToListAsync();
        }

        // GET: api/ModelMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ModelMaster>>> GetModelMaster(int id)
        {
            if (_context.ModelMasterMasters == null)
            {
                return NotFound();
            }

            var modelMaster = await _context.ModelMasterMasters.Where(p => p.MfgId == id).ToListAsync();

            if (modelMaster == null)
            {
                return NotFound();
            }

            return modelMaster;
        }
        // GET: api/ModelMasters/5/1
        [HttpGet("{id}/{a}")]
        public async Task<ActionResult<IEnumerable<VehicleDbContext>>> GetModelMaster(int id, int a)
        {
          if (_context.ModelMasterMasters == null)
          {
              return NotFound();
          }
    
            var modelMaster = await _context.MfgMasters
                                .Join(_context.ModelMasterMasters, v => v.MfgId, c => c.MfgId, (v, c) => new { v, c })
                                .Where(x => x.v.MfgId == x.v.MfgId && x.c.ModelId == id)
                                .Select(x => new 
                                {
                                    ModelId = x.c.ModelId,
                                    MfgId = x.c.MfgId,
                                    ModelName = x.c.ModelName,
                                    BasicPrice = x.c.BasicPrice,
                                    MinQty = x.c.MinQty,
                                    ImagPath = x.c.ImagPath,
                                    MfgName = x.v.MfgName,
                                }).ToListAsync();

            if (modelMaster == null)
            {
                return NotFound();
            }

            return Ok(modelMaster);
        }

        
        // PUT: api/ModelMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelMaster(int id, ModelMaster modelMaster)
        {
            if (id != modelMaster.ModelId)
            {
                return BadRequest();
            }

            _context.Entry(modelMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelMasterExists(id))
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

        // POST: api/ModelMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ModelMaster>> PostModelMaster(ModelMaster modelMaster)
        {
          if (_context.ModelMasterMasters == null)
          {
              return Problem("Entity set 'VehicleDbContext.ModelMasterMasters'  is null.");
          }
            _context.ModelMasterMasters.Add(modelMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModelMaster", new { id = modelMaster.ModelId }, modelMaster);
        }

        // DELETE: api/ModelMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelMaster(int id)
        {
            if (_context.ModelMasterMasters == null)
            {
                return NotFound();
            }
            var modelMaster = await _context.ModelMasterMasters.FindAsync(id);
            if (modelMaster == null)
            {
                return NotFound();
            }

            _context.ModelMasterMasters.Remove(modelMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModelMasterExists(int id)
        {
            return (_context.ModelMasterMasters?.Any(e => e.ModelId == id)).GetValueOrDefault();
        }
    }
}

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
    public class VehicleDetailsController : ControllerBase
    {
        private readonly VehicleDbContext _context;

        public VehicleDetailsController(VehicleDbContext context)
        {
            _context = context;
        }

        // GET: api/VehicleDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleDetail>>> GetVehicleDetailMasters()
        {
          if (_context.VehicleDetailMasters == null)
          {
              return NotFound();
          }
            return await _context.VehicleDetailMasters.ToListAsync();
        }

        // GET: api/VehicleDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleDetail>> GetVehicleDetail(int id)
        {
          if (_context.VehicleDetailMasters == null)
          {
              return NotFound();
          }
            var vehicleDetail = await _context.VehicleDetailMasters.FindAsync(id);


            if (vehicleDetail == null)
            {
                return NotFound();
            }

            return vehicleDetail;
        }

        

        [HttpGet("{id}/{ch}")]
        public async Task<ActionResult<VehicleDetail>> GetVehicleDetail(int id, String ch)
        {
            if (_context.VehicleDetailMasters == null)
            {
                return NotFound();
            }
            var vehicleDetail = await _context.VehicleDetailMasters.FindAsync(id);


            if (vehicleDetail == null)
            {
                return NotFound();
            }

            return vehicleDetail;
        }

        // PUT: api/VehicleDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleDetail(int id, VehicleDetail vehicleDetail)
        {
            if (id != vehicleDetail.ConfiId)
            {
                return BadRequest();
            }

            _context.Entry(vehicleDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleDetailExists(id))
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

        // POST: api/VehicleDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VehicleDetail>> PostVehicleDetail(VehicleDetail vehicleDetail)
        {
          if (_context.VehicleDetailMasters == null)
          {
              return Problem("Entity set 'VehicleDbContext.VehicleDetailMasters'  is null.");
          }
            _context.VehicleDetailMasters.Add(vehicleDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicleDetail", new { id = vehicleDetail.ConfiId }, vehicleDetail);
        }

        // DELETE: api/VehicleDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleDetail(int id)
        {
            if (_context.VehicleDetailMasters == null)
            {
                return NotFound();
            }
            var vehicleDetail = await _context.VehicleDetailMasters.FindAsync(id);
            if (vehicleDetail == null)
            {
                return NotFound();
            }

            _context.VehicleDetailMasters.Remove(vehicleDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehicleDetailExists(int id)
        {
            return (_context.VehicleDetailMasters?.Any(e => e.ConfiId == id)).GetValueOrDefault();
        }
    }
}

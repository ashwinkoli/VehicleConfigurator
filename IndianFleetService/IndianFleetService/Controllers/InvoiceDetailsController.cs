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
    public class InvoiceDetailsController : ControllerBase
    {
        private readonly VehicleDbContext _context;

        public InvoiceDetailsController(VehicleDbContext context)
        {
            _context = context;
        }

        // GET: api/InvoiceDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceDetail>>> GetInvoiceDetailMasters()
        {
          if (_context.InvoiceDetailMasters == null)
          {
              return NotFound();
          }
            return await _context.InvoiceDetailMasters.ToListAsync();
        }

        // GET: api/InvoiceDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceDetail>> GetInvoiceDetail(int id)
        {
          if (_context.InvoiceDetailMasters == null)
          {
              return NotFound();
          }
            var invoiceDetail = await _context.InvoiceDetailMasters.FindAsync(id);

            if (invoiceDetail == null)
            {
                return NotFound();
            }

            return invoiceDetail;
        }

        // PUT: api/InvoiceDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceDetail(int id, InvoiceDetail invoiceDetail)
        {
            if (id != invoiceDetail.InvoiceDetailId)
            {
                return BadRequest();
            }

            _context.Entry(invoiceDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceDetailExists(id))
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

        // POST: api/InvoiceDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvoiceDetail>> PostInvoiceDetail(InvoiceDetail invoiceDetail)
        {
          if (_context.InvoiceDetailMasters == null)
          {
              return Problem("Entity set 'VehicleDbContext.InvoiceDetailMasters'  is null.");
          }
            _context.InvoiceDetailMasters.Add(invoiceDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoiceDetail", new { id = invoiceDetail.InvoiceDetailId }, invoiceDetail);
        }

        // DELETE: api/InvoiceDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoiceDetail(int id)
        {
            if (_context.InvoiceDetailMasters == null)
            {
                return NotFound();
            }
            var invoiceDetail = await _context.InvoiceDetailMasters.FindAsync(id);
            if (invoiceDetail == null)
            {
                return NotFound();
            }

            _context.InvoiceDetailMasters.Remove(invoiceDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvoiceDetailExists(int id)
        {
            return (_context.InvoiceDetailMasters?.Any(e => e.InvoiceDetailId == id)).GetValueOrDefault();
        }
    }
}

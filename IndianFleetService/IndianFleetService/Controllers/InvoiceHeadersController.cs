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
    public class InvoiceHeadersController : ControllerBase
    {
        private readonly VehicleDbContext _context;

        public InvoiceHeadersController(VehicleDbContext context)
        {
            _context = context;
        }

        // GET: api/InvoiceHeaders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceHeader>>> GetInvoiceHeaderMasters()
        {
          if (_context.InvoiceHeaderMasters == null)
          {
              return NotFound();
          }
            return await _context.InvoiceHeaderMasters.ToListAsync();
        }

        // GET: api/InvoiceHeaders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceHeader>> GetInvoiceHeader(int id)
        {
          if (_context.InvoiceHeaderMasters == null)
          {
              return NotFound();
          }
            var invoiceHeader = await _context.InvoiceHeaderMasters.FindAsync(id);

            if (invoiceHeader == null)
            {
                return NotFound();
            }

            return invoiceHeader;
        }

        // PUT: api/InvoiceHeaders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceHeader(int id, InvoiceHeader invoiceHeader)
        {
            if (id != invoiceHeader.InvoiceId)
            {
                return BadRequest();
            }

            _context.Entry(invoiceHeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceHeaderExists(id))
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

        // POST: api/InvoiceHeaders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvoiceHeader>> PostInvoiceHeader(InvoiceHeader invoiceHeader)
        {
          if (_context.InvoiceHeaderMasters == null)
          {
              return Problem("Entity set 'VehicleDbContext.InvoiceHeaderMasters'  is null.");
          }
            _context.InvoiceHeaderMasters.Add(invoiceHeader);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoiceHeader", new { id = invoiceHeader.InvoiceId }, invoiceHeader);
        }

        // DELETE: api/InvoiceHeaders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoiceHeader(int id)
        {
            if (_context.InvoiceHeaderMasters == null)
            {
                return NotFound();
            }
            var invoiceHeader = await _context.InvoiceHeaderMasters.FindAsync(id);
            if (invoiceHeader == null)
            {
                return NotFound();
            }

            _context.InvoiceHeaderMasters.Remove(invoiceHeader);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvoiceHeaderExists(int id)
        {
            return (_context.InvoiceHeaderMasters?.Any(e => e.InvoiceId == id)).GetValueOrDefault();
        }
    }
}

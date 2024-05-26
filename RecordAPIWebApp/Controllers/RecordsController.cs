using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecordAPIWebApp.Models;

namespace RecordAPIWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly CollectionAPIContext _context;

        public RecordsController(CollectionAPIContext context)
        {
            _context = context;
        }

        // GET: api/Records
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Record>>> GetRecords()
        {
            if (_context.Records == null)
            {
                return NotFound();
            }
            return await _context.Records.ToListAsync();
        }

        // GET: api/Records/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Record>> GetRecord(int id)
        {
            if (_context.Records == null)
            {
                return NotFound();
            }

            var record = await _context.Records.FindAsync(id);

            if (record == null)
            {
                return NotFound();
            }

            return record;
        }

        // POST: api/Records
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Record>> CreateRecord([Bind("Id,Name,Description,ArtistId,Year,GenreId,Image,ReviewId")] Record record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Records.Add(record);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRecord), new { id = record.Id }, record);
        }

        // PUT: api/Records/5
        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRecord(int id, [Bind("Id,Name,Description,ArtistId,Year,GenreId,Image,ReviewId")] Record record)
        {
            if (id != record.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(record).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecordExists(id))
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

        // DELETE: api/Records/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRecord(int id)
        {
            if (_context.Records == null)
            {
                return NotFound();
            }

            var record = await _context.Records.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }

            _context.Records.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecordExists(int id)
        {
            return (_context.Records?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}

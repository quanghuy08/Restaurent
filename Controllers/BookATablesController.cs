#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurent.Data;
using Restaurent.Models;

namespace Restaurent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookATablesController : ControllerBase
    {
        private readonly RestaurentContext _context;

        public BookATablesController(RestaurentContext context)
        {
            _context = context;
        }

        // GET: api/BookATables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookATable>>> GetBookATable()
        {
            return await _context.BookATable.ToListAsync();
        }

        // GET: api/BookATables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookATable>> GetBookATable(int id)
        {
            var bookATable = await _context.BookATable.FindAsync(id);

            if (bookATable == null)
            {
                return NotFound();
            }

            return bookATable;
        }

        // PUT: api/BookATables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookATable(int id, BookATable bookATable)
        {
            if (id != bookATable.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookATable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookATableExists(id))
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

        // POST: api/BookATables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookATable>> PostBookATable(BookATable bookATable)
        {
            _context.BookATable.Add(bookATable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookATable", new { id = bookATable.Id }, bookATable);
        }

        // DELETE: api/BookATables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookATable(int id)
        {
            var bookATable = await _context.BookATable.FindAsync(id);
            if (bookATable == null)
            {
                return NotFound();
            }

            _context.BookATable.Remove(bookATable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookATableExists(int id)
        {
            return _context.BookATable.Any(e => e.Id == id);
        }
    }
}

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
    public class AdminAccountsController : ControllerBase
    {
        private readonly RestaurentContext _context;

        public AdminAccountsController(RestaurentContext context)
        {
            _context = context;
        }

        // GET: api/AdminAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminAccount>>> GetAdminAccount()
        {
            return await _context.AdminAccount.ToListAsync();
        }

        // GET: api/AdminAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminAccount>> GetAdminAccount(int id)
        {
            var adminAccount = await _context.AdminAccount.FindAsync(id);

            if (adminAccount == null)
            {
                return NotFound();
            }

            return adminAccount;
        }

        // PUT: api/AdminAccounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdminAccount(int id, AdminAccount adminAccount)
        {
            if (id != adminAccount.Id)
            {
                return BadRequest();
            }

            _context.Entry(adminAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminAccountExists(id))
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

        // POST: api/AdminAccounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdminAccount>> PostAdminAccount(AdminAccount adminAccount)
        {
            _context.AdminAccount.Add(adminAccount);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdminAccount", new { id = adminAccount.Id }, adminAccount);
        }

        // DELETE: api/AdminAccounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminAccount(int id)
        {
            var adminAccount = await _context.AdminAccount.FindAsync(id);
            if (adminAccount == null)
            {
                return NotFound();
            }

            _context.AdminAccount.Remove(adminAccount);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdminAccountExists(int id)
        {
            return _context.AdminAccount.Any(e => e.Id == id);
        }
    }
}

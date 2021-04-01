using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffWebAPi.Data;
using StaffWebAPi.Models;

namespace StaffWebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffNamesController : ControllerBase
    {
        private readonly StaffWebAPiContext _context;

        public StaffNamesController(StaffWebAPiContext context)
        {
            _context = context;
        }

        // GET: api/StaffNames
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StaffName>>> GetStaffName()
        {
            return await _context.StaffName.ToListAsync();
        }

        // GET: api/StaffNames/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StaffName>> GetStaffName(int id)
        {
            var staffName = await _context.StaffName.FindAsync(id);

            if (staffName == null)
            {
                return NotFound();
            }

            return staffName;
        }

        // PUT: api/StaffNames/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaffName(int id, StaffName staffName)
        {
            if (id != staffName.Id)
            {
                return BadRequest();
            }

            _context.Entry(staffName).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffNameExists(id))
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

        // POST: api/StaffNames
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StaffName>> PostStaffName(StaffName staffName)
        {
            _context.StaffName.Add(staffName);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStaffName", new { id = staffName.Id }, staffName);
        }

        // DELETE: api/StaffNames/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffName(int id)
        {
            var staffName = await _context.StaffName.FindAsync(id);
            if (staffName == null)
            {
                return NotFound();
            }

            _context.StaffName.Remove(staffName);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StaffNameExists(int id)
        {
            return _context.StaffName.Any(e => e.Id == id);
        }
    }
}

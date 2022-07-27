using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IdentityVote.Models;
using Searching_Tool_Assignment.Models;
using Microsoft.AspNetCore.Authorization;

namespace Searching_Tool_Assignment.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SourcesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SourcesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sources
        [HttpGet]
        [Authorize(Roles = UserRoles.User+","+UserRoles.Admin)]
        public async Task<ActionResult<IEnumerable<Source>>> GetSources()
        {
          if (_context.Sources == null)
          {
              return NotFound();
          }
            return await _context.Sources.ToListAsync();
        }

        // GET: Sources/5
        [HttpGet("{id}")]
        [Authorize(Roles = UserRoles.User + "," + UserRoles.Admin)]
        public async Task<ActionResult<Source>> GetSource(int id)
        {
          if (_context.Sources == null)
          {
              return NotFound();
          }
            var source = await _context.Sources.FindAsync(id);

            if (source == null)
            {
                return NotFound();
            }

            return source;
        }

        // PUT: Sources/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> EditSource(int id, Source source)
        {
            if (id != source.Id)
            {
                return BadRequest();
            }

            _context.Entry(source).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SourceExists(id))
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

        // POST: Sources
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<Source>> AddSource(Source source)
        {
          if (_context.Sources == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Sources'  is null.");
          }
            _context.Sources.Add(source);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSource", new { id = source.Id }, source);
        }

        // DELETE: Sources/5
        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteSource(int id)
        {
            if (_context.Sources == null)
            {
                return NotFound();
            }
            var source = await _context.Sources.FindAsync(id);
            if (source == null)
            {
                return NotFound();
            }

            _context.Sources.Remove(source);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SourceExists(int id)
        {
            return (_context.Sources?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Searching_Tool_Assignment.Models;
using Microsoft.AspNetCore.Authorization;
using Searching_Tool_Assignment.Repositories;

namespace Searching_Tool_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourcesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UnitOfWork _unitOfWork;

        public SourcesController(ApplicationDbContext context,UnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: Sources
        [HttpGet]
        [Authorize(Roles = UserRoles.User+","+UserRoles.Admin)]
        public async Task<ActionResult<IEnumerable<Source>>> GetSource()
        {
          if (_unitOfWork.Sources == null)
          {
              return NotFound();
          }
            return Ok(_unitOfWork.Sources.GetAll());
        }

        // GET: Sources/5
        [HttpGet("{id}")]
        [Authorize(Roles = UserRoles.User + "," + UserRoles.Admin)]
        public async Task<ActionResult<Source>> GetSource(int id)
        {
          if (_unitOfWork.Sources == null)
          {
              return NotFound();
          }
            var source = await _unitOfWork.Sources.Get(id);

            if (source == null)
            {
                return NotFound();
            }

            return Ok(source);
        }

        // POST: Sources
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<Source>> PostSource(Source source)
        {
          if (_unitOfWork.Sources == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Sources'  is null.");
          }
            _unitOfWork.Sources.Add(source);

            return CreatedAtAction("GetSource", new { id = source.Id }, source);
        }

        // DELETE: Sources/5
        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteSource(int id)
        {
            if (_unitOfWork.Sources == null)
            {
                return NotFound();
            }
            var source = await _unitOfWork.Sources.Get(id);
            if (source == null)
            {
                return NotFound();
            }

            _unitOfWork.Sources.Remove(source);
            _unitOfWork.Save();

            return Ok();
        }
    }
}

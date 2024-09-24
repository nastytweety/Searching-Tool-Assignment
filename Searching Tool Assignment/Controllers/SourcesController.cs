using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Searching_Tool_Assignment.IRepositories;
using Searching_Tool_Assignment.Models;

namespace Searching_Tool_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourcesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SourcesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Sources
        [OutputCache(Duration = 1000, PolicyName = nameof(CachePolicy))]
        [HttpGet]
        [Authorize(Roles = UserRoles.User+","+UserRoles.Admin)]
        public async Task<ActionResult<IEnumerable<Source>>> GetSources()
        {
            var sources = await _unitOfWork.Sources.GetAll();
            if (_unitOfWork.Sources is null)
                return NotFound();

            return Ok(sources);
        }

        // GET: Sources/5
        [HttpGet("{id}")]
        [Authorize(Roles = UserRoles.User + "," + UserRoles.Admin)]
        public async Task<ActionResult<Source>> GetSource(int id)
        {
            var source = await _unitOfWork.Sources.Get(id);
            if (source == null)
                return NotFound();
            
            return Ok(source);
        }

        // POST: Sources
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<Source>> PostSource(Source source)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            await _unitOfWork.Sources.Add(source);
            return CreatedAtAction("GetSource", new { id = source.Id }, source);
        }

        // DELETE: Sources/5
        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteSource(int id)
        {
            var source = await _unitOfWork.Sources.Get(id);
            if (source is null)
                return NotFound();
            
            _unitOfWork.Sources.Remove(source);
            await _unitOfWork.Save();
            return Ok();
        }
    }
}

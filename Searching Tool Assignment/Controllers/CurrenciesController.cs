using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Searching_Tool_Assignment.IRepositories;
using Searching_Tool_Assignment.Models;

namespace Searching_Tool_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRoles.Admin)]
    public class CurrenciesController : ControllerBase
    {
        private readonly IUnitOfWork _unitofWork;

        public CurrenciesController(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        // GET: api/Currencies
        [OutputCache(Duration = 1000, PolicyName = nameof(CachePolicy))]
        [HttpGet]
        public ActionResult<IEnumerable<Currency>> GetCurrency()
        {
            if (_unitofWork.Currencies.GetAll() is null)
                return NotFound();

            return Ok(_unitofWork.Currencies.GetAll());
        }

        // GET: api/Currencies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Currency>> GetCurrency(int id)
        {
            var currency = await _unitofWork.Currencies.Get(id);
            if (currency is null)
                return NotFound();
            
            return Ok(currency);
        }

        // POST: api/Currencies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Currency>> PostCurrency(Currency currency)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            await _unitofWork.Currencies.Add(currency);

            return CreatedAtAction("GetCurrency", new { id = currency.CurrencyId }, currency);
        }

        // DELETE: api/Currencies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurrency(int id)
        {
            var currency = await _unitofWork.Currencies.Get(id);
            if (currency == null)
                return NotFound();
            
            _unitofWork.Currencies.Remove(currency);
            await _unitofWork.Save();
            return Ok();
        }
    }
}

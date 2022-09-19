using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Searching_Tool_Assignment.IRepositories;
using Searching_Tool_Assignment.Models;
using Searching_Tool_Assignment.Repositories;

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
        [HttpGet]
        public ActionResult<IEnumerable<Currency>> GetCurrency()
        {
          if (_unitofWork.Currencies == null)
          {
              return NotFound();
          }
            return Ok(_unitofWork.Currencies.GetAll());
        }

        // GET: api/Currencies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Currency>> GetCurrency(int id)
        {
          if (_unitofWork.Currencies == null)
          {
              return NotFound();
          }
            var currency = await _unitofWork.Currencies.Get(id);

            if (currency == null)
            {
                return NotFound();
            }

            return Ok(currency);
        }

        // POST: api/Currencies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Currency>> PostCurrency(Currency currency)
        {
          if (_unitofWork.Currencies == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Currencies'  is null.");
          }
            _unitofWork.Currencies.Add(currency);

            return CreatedAtAction("GetCurrency", new { id = currency.CurrencyId }, currency);
        }

        // DELETE: api/Currencies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurrency(int id)
        {
            if (_unitofWork.Currencies == null)
            {
                return NotFound();
            }
            var currency = await _unitofWork.Currencies.Get(id);
            if (currency == null)
            {
                return NotFound();
            }

            _unitofWork.Currencies.Remove(currency);
            _unitofWork.Save();

            return Ok();
        }
    }
}

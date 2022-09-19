using Microsoft.AspNetCore.Mvc;
using Searching_Tool_Assignment.Models;
using Newtonsoft.Json.Linq;
using Searching_Tool_Assignment.Services;
using Microsoft.AspNetCore.Authorization;
using Searching_Tool_Assignment.Repositories;
using Searching_Tool_Assignment.DTOs;
using Searching_Tool_Assignment.IRepositories;

namespace Searching_Tool_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TickersController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IApplicationService _applicationService;
        public TickersController(IUnitOfWork unitofwork, IApplicationService appservice)
        {
            _unitofwork = unitofwork;
            _applicationService = appservice;
        }

        [Authorize(Roles = UserRoles.User + "," + UserRoles.Admin)]
        [HttpGet("{SourceName}")]
        public async Task<ActionResult<IEnumerable<Ticker>>> GetTickers(string SourceName)
        {
            Source source = new Source();
            if (SourceName == null)
            {
                return BadRequest();
            }
            else if (!_unitofwork.Sources.SourceExists(SourceName).Result)
            {
                return NotFound();
            }
            else
            {
                source = _unitofwork.Sources.Get(SourceName).Result;
            }

            
            IEnumerable<Currency> currencies = _unitofwork.Currencies.GetAll();
            List<Ticker> result = new List<Ticker>();

            using (var client = _applicationService.GetHttpClient(source.BaseURL))
            {
                foreach (var currency in currencies)
                {
                    HttpResponseMessage Res = await client.GetAsync(currency.Extension);
                    if (Res.IsSuccessStatusCode)
                    {
                        string Response = Res.Content.ReadAsStringAsync().Result;
                        JObject obj = JObject.Parse(Response);
                        Ticker tick = _applicationService.GetTicker(obj, source, currency.CurrencyName);
                        result.Add(tick);
                        _unitofwork.Tickers.Add(tick);
                        _unitofwork.Save();
                    }
                }
            }
            return result;
        }

        [Authorize(Roles = UserRoles.User + "," + UserRoles.Admin)]
        [HttpGet]
        public async Task<ActionResult<List<Ticker>>> GetTickersHistory([FromQuery] string? FilterBySource,[FromQuery]string? FilterByDate, [FromQuery]string? OrderBy, [FromQuery]int? Page)
        {
            if (_unitofwork.Tickers == null)
            {
                return NotFound();
            }

            IEnumerable<Ticker> tickers = _unitofwork.Tickers.GetAll();

            if (FilterBySource != null)
            {
                if(_unitofwork.Sources.Get(FilterBySource).Result!= null)
                {
                    tickers = tickers.Where(x => x.Source == FilterBySource).ToList();
                }
                else
                {
                    return NotFound();
                }
            }
            if(FilterByDate != null)
            {
                if(tickers.Where(x => x.CreatedDate == FilterByDate).ToList()!=null)
                {
                    tickers = tickers.Where(x => x.CreatedDate == FilterByDate).ToList();
                }
                else
                {
                    return NotFound();
                }
            }
            if (OrderBy != null)
            {
                if(OrderBy == "Price"|| OrderBy == "price")
                {
                    if (tickers != null)
                    {
                        tickers = tickers.OrderBy(x => x.Price).ToList();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                if(OrderBy == "Date" || OrderBy == "date")
                {
                    if (tickers != null)
                    {
                        tickers = tickers.OrderBy(x => x.CreatedDate).ToList();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            int TotalPages= 0;
            if(Page != null && Page>=1)
            {
                var PageResults = 5f;
                TotalPages = Convert.ToInt32(Math.Ceiling(tickers.Count() / PageResults));
                tickers = tickers.Skip((Page.Value - 1) * (int)PageResults).Take((int)PageResults).ToList();
            }
            return Ok(new TickerDTO { Pages = TotalPages, Tickers = tickers});
        }

        [HttpDelete]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteTickersHistory()
        {
            if (_unitofwork.Tickers == null)
            {
                return NotFound();
            }

            _unitofwork.Tickers.RemoveAll(_unitofwork.Tickers.GetAll());
            _unitofwork.Save();

            return Ok();

        }
    }
}

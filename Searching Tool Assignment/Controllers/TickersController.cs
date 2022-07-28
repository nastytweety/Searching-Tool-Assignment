using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IdentityVote.Models;
using Searching_Tool_Assignment.Models;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Searching_Tool_Assignment.Services;

namespace Searching_Tool_Assignment.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TickersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IApplicationService _applicationService;
        public TickersController(ApplicationDbContext context, IApplicationService appservice)
        {
            _context = context;
            _applicationService = appservice;
        }

        [HttpGet("{SourceName}")]
        public async Task<ActionResult<List<Ticker>>> FetchPricesFromSource(string SourceName)
        {
            
            if (SourceName == null)
            {
                return BadRequest();
            }
            else if (await _context.Sources.Where(x => x.Name == SourceName).SingleOrDefaultAsync() == null)
            {
                return NotFound();
            }

            Source source = await _context.Sources.Where(x => x.Name == SourceName).SingleAsync();
            List<Currency> currencies = await _context.Currencies.ToListAsync();
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
                        _context.Tickers.Add(tick);
                        await _context.SaveChangesAsync();
                    }                  
                }
            }
            return result;
        }

        [HttpGet]
        public async Task<ActionResult<List<Ticker>>> FetchPricesHistory()
        {
            if (_context.Tickers == null)
            {
                return NotFound();
            }
            var tickers = await _context.Tickers.ToListAsync();

            if (tickers == null)
            {
                return NotFound();
            }

            return tickers;
        }

        private bool TickerExists(int id)
        {
            return (_context.Tickers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

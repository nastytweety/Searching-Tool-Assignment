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

namespace Searching_Tool_Assignment.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TickersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TickersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{SourceName}")]
        public async Task<ActionResult<List<Ticker>>> FetchPricesFromSource(string SourceName)
        {
            List<Ticker> result = new List<Ticker>();
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

            using (var client = new HttpClient())
            {
                //Passing service url
                client.BaseAddress = new Uri(source.BaseURL);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                foreach (var currency in currencies)
                {
                    HttpResponseMessage Res = await client.GetAsync(currency.Extension);
                    //Checking the response is successful or not which is sent using HttpClient
                    if (Res.IsSuccessStatusCode)
                    {
                        string Response = Res.Content.ReadAsStringAsync().Result;
                        JObject obj = JObject.Parse(Response);
                        var price = obj.SelectToken(source.PriceKeyword);
                        var timestamp = obj.SelectToken(source.DateTimeKeyword);
                        Ticker tick = new Ticker();
                        tick.Source = source.Name;
                        tick.Currency = currency.CurrencyName;
                        tick.Price = price.ToString();
                        tick.CreatedDate = timestamp.ToString();
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

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Searching_Tool_Assignment.Models;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Searching_Tool_Assignment.Services;
using Microsoft.AspNetCore.Authorization;

namespace Searching_Tool_Assignment.Controllers
{
    [Route("api/[controller]")]
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

        [Authorize(Roles = UserRoles.User + "," + UserRoles.Admin)]
        [HttpGet("{SourceName}")]
        public async Task<ActionResult<List<Ticker>>> GetTickers(string SourceName)
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

        [Authorize(Roles = UserRoles.User + "," + UserRoles.Admin)]
        [HttpGet]
        public async Task<ActionResult<List<Ticker>>> GetTickersHistory([FromQuery] string? FilterBySource,[FromQuery]string? FilterByDate, [FromQuery]string? OrderBy, [FromQuery]int? Page)
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

            if(FilterBySource != null)
            {
                if(_context.Sources.Where(x => x.Name == FilterBySource).FirstOrDefault() != null)
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
            if(Page != null && Page>=1)
            {
                var PageResults = 5f;
                var TotalPages = Math.Ceiling(tickers.Count() / PageResults);
                tickers = tickers.Skip((Page.Value - 1) * (int)PageResults).Take((int)PageResults).ToList();
            }
            return Ok(tickers);
        }

        [HttpDelete]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteTickersHistory()
        {
            if (_context.Tickers == null)
            {
                return NotFound();
            }

            _context.Tickers.RemoveRange(_context.Tickers);
            await _context.SaveChangesAsync();

            return NoContent();

        }

        private bool TickerExists(int id)
        {
            return (_context.Tickers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

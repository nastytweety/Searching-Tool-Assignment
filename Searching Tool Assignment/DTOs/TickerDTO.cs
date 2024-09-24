﻿using Searching_Tool_Assignment.Models;

namespace Searching_Tool_Assignment.DTOs
{
    public record TickerDTO
    {
        public int Pages { get; set; }
        public IEnumerable<Ticker> Tickers { get; set; } = null!;
    }
}

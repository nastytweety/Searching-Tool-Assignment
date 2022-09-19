using Microsoft.EntityFrameworkCore;
using Searching_Tool_Assignment.Models;

namespace Searching_Tool_Assignment.Repositories
{
    public class TickerRepository : ITickerRepository
    {
        protected readonly ApplicationDbContext _context;

        public TickerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ticker>> GetTickers(string SourceName)
        {
            return await _context.Tickers.Where(x=>x.Equals(SourceName)).ToListAsync();
        }

        public async Task Add(Ticker ticker)
        {
            await _context.Tickers.AddAsync(ticker);
        }

    }
}

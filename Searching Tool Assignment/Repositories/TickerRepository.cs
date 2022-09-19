using Microsoft.EntityFrameworkCore;
using Searching_Tool_Assignment.IRepositories;
using Searching_Tool_Assignment.Models;

namespace Searching_Tool_Assignment.Repositories
{
    public class TickerRepository : Repository<Ticker>,ITickerRepository
    {
        protected readonly ApplicationDbContext _context;

        public TickerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Ticker>> GetTickers(string SourceName)
        {
            return await _context.Tickers.Where(x=>x.Equals(SourceName)).ToListAsync();
        }


        public void RemoveAll(IEnumerable<Ticker> tickers)
        {
            _context.Tickers.RemoveRange(tickers);
        }

    }
}

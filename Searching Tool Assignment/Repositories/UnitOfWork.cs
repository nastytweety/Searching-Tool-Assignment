using Searching_Tool_Assignment.Models;

namespace Searching_Tool_Assignment.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ITickerRepository Tickers { get; set; }
        public ISourceRepository Sources { get; set; }
        public ICurrencyrepository Currencies { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Tickers = new TickerRepository(_context);
            Sources = new SourceRepository(_context);
            Currencies = new CurrencyRepository(_context);
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}

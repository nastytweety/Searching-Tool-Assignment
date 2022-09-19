using Searching_Tool_Assignment.Models;

namespace Searching_Tool_Assignment.Repositories
{
    public interface ITickerRepository : IRepository<Ticker>
    {
        public void RemoveAll(IEnumerable<Ticker> tickers);
    }
}

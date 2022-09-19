using Searching_Tool_Assignment.Models;

namespace Searching_Tool_Assignment.IRepositories
{
    public interface ITickerRepository : IRepository<Ticker>
    {
        public void RemoveAll(IEnumerable<Ticker> tickers);
    }
}

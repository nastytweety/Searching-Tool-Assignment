namespace Searching_Tool_Assignment.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        ITickerRepository Tickers { get; }
        ISourceRepository Sources { get; }
        ICurrencyrepository Currencies { get; }
        int Save();
    }
}

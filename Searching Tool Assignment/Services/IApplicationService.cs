using Searching_Tool_Assignment.Models;

namespace Searching_Tool_Assignment.Services
{
    public interface IApplicationService
    {
        public List<Currency> GetCurrencies();
        public HttpClient GetHttpClient();
        public Ticker GetTicker(string Response);
    }
}
